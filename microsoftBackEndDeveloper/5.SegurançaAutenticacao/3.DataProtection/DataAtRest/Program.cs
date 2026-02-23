using System.Text;
using System.Security.Cryptography;
using System.Security.Claims;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("DataProtectionDb")
);

builder.Services.AddSingleton<IEncryptionService, EncryptionService>();

var jwtKey = Convert.FromBase64String(
    builder.Configuration["Authentication:Schemes:Bearer:SigningKeys:0:Value"]
    ?? throw new NullReferenceException("Missing JWT key")
);

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(jwtKey),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = "dotnet-user-jwts",
        ValidAudience = "dotnet-user-jwts"
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/messages", async (AppDbContext dbContext) =>
{
    var messages = await dbContext.Messages.ToListAsync();
    return Results.Ok(messages);
});

app.MapGet("/messages/{id}", async (AppDbContext dbContext, int id) =>
{
    var message = await dbContext.Messages.FindAsync(id);
    if (message == null)
    {
        return Results.NotFound("Message not found");
    }
    return Results.Ok(message.Text);
});

app.MapPost("/messages", async (IEncryptionService encryptionService, HttpContext context, AppDbContext dbContext, MessageDTO messageDto) =>
{
    var user = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? context.User.FindFirst("sub")?.Value;

    if (user == null)
        return Results.BadRequest("Email is required");

    var message = new Message
    {
        Text = encryptionService.Encrypt(messageDto.Text),
        User = user
    };

    dbContext.Messages.Add(message);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/messages/{message.Id}", message.Text);
}).RequireAuthorization();

app.Run();

public record MessageRequest(string message);

internal interface IEncryptionService
{
    string Encrypt(string plainText);
    string Decrypt(string cipherText);
}

internal class EncryptionService : IEncryptionService
{
    private readonly byte[] _key;
    private readonly byte[] _iv;

    public EncryptionService(IConfiguration configuration)
    {
        _key = Encoding.UTF8.GetBytes(configuration["Encryption:Key"] ?? throw new NullReferenceException("Missing encryption key"));
        _iv = Encoding.UTF8.GetBytes(configuration["Encryption:IV"] ?? throw new NullReferenceException("Missing encryption IV"));
    }

    public string Encrypt(string plainText)
    {
        using var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;

        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using var msEncrypt = new MemoryStream();
        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        using (var swEncrypt = new StreamWriter(csEncrypt))
        {
            swEncrypt.Write(plainText);
        }
        return Convert.ToBase64String(msEncrypt.ToArray());
    }

    public string Decrypt(string cipherText)
    {
        using var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;

        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText));
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using var srDecrypt = new StreamReader(csDecrypt);
        return srDecrypt.ReadToEnd();
    }
}

public class MessageDTO
{
    required public string Text { get; set; }
}

public class Message
{
    public int Id { get; set; }
    required public string Text { get; set; }
    required public string User { get; set; }
}

public class AppDbContext : DbContext
{
    public DbSet<Message> Messages { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}
