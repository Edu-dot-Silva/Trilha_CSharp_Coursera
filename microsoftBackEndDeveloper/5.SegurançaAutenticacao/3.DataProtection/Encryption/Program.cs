using System.Security.Cryptography;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IEncryptionService, EncryptionService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/encrypt", (IEncryptionService encryption, EncryptRequest resquest) =>
{
    return Results.Ok(encryption.Encrypt(resquest.PlainText));
});

app.MapPost("/decrypt", (IEncryptionService encryption, DecryptRequest resquest) =>
{
    return Results.Ok(encryption.Decrypt(resquest.CipherText));
});

app.Run();

public record EncryptRequest(string PlainText);

public record DecryptRequest(string CipherText);

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
        _key = Encoding.UTF8.GetBytes(configuration["EncryptionKey"]);
        _iv = Encoding.UTF8.GetBytes(configuration["EncryptionIV"]);
    }

    public string Encrypt(string plainText)
    {
        using var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;

        using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using var msEncrypt = new MemoryStream();
        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        using (var write = new StreamWriter(csEncrypt))
        {
            write.Write(plainText);
            write.Flush();
        };
        return Convert.ToBase64String(msEncrypt.ToArray());
    }

    public string Decrypt(string cipherText)
    {
        var buffer = Convert.FromBase64String(cipherText);
        using var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;

        using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using var msDecrypt = new MemoryStream(buffer);
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using var reader = new StreamReader(csDecrypt);

        return reader.ReadToEnd();
    }
}
