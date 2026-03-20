// Importações necessárias para o projeto LogiTrack
using LogiTrack.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

// Criação do construtor da aplicação web
var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner de dependências
// Configuração da API OpenAPI para documentação
builder.Services.AddOpenApi();
// Adiciona suporte ao Swagger para documentação interativa da API
builder.Services.AddSwaggerGen();
// Configura o contexto do banco de dados com SQLite
builder.Services.AddDbContext<LogiTrackContext>(options => options.UseSqlite("Data Source=logitrack.db"));
// Configura o sistema de identidade com usuários e roles
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<LogiTrackContext>();
// Configura a autenticação JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    // Define os parâmetros de validação do token JWT
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
// Adiciona serviço de autorização
builder.Services.AddAuthorization();
// Adiciona suporte a controllers
builder.Services.AddControllers();
// Adiciona cache em memória para otimização de performance
builder.Services.AddMemoryCache();

// Constrói a aplicação
var app = builder.Build();

// Configura o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    // Mapeia os endpoints OpenAPI apenas em desenvolvimento
    app.MapOpenApi();
}

// Redireciona todas as requisições HTTP para HTTPS
app.UseHttpsRedirection();

// Habilita o middleware do Swagger
app.UseSwagger();
// Habilita a interface do usuário do Swagger
app.UseSwaggerUI();

// Habilita autenticação
app.UseAuthentication();
// Habilita autorização
app.UseAuthorization();

// Mapeia os controllers da API
app.MapControllers();

// Inicialização de dados na primeira execução
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    // Obtém o contexto do banco de dados
    var context = services.GetRequiredService<LogiTrackContext>();
    // Obtém o gerenciador de usuários
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    // Obtém o gerenciador de roles
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    // Aplica migrações pendentes no banco de dados
    await context.Database.MigrateAsync();
    // Executa o método de seed para criar dados iniciais
    await SeedData(context, userManager, roleManager);
}

async Task SeedData(LogiTrackContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
{
    // Cria as roles se não existirem
    if (!await roleManager.RoleExistsAsync("Manager"))
    {
        await roleManager.CreateAsync(new IdentityRole("Manager"));
    }
    if (!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(new IdentityRole("User"));
    }

    // Cria um usuário gerente se não existir
    var manager = await userManager.FindByNameAsync("manager");
    if (manager == null)
    {
        manager = new ApplicationUser { UserName = "manager", Email = "manager@logitrack.com" };
        await userManager.CreateAsync(manager, "Password123!");
        await userManager.AddToRoleAsync(manager, "Manager");
    }

    // Cria um usuário comum se não existir
    var user = await userManager.FindByNameAsync("user");
    if (user == null)
    {
        user = new ApplicationUser { UserName = "user", Email = "user@logitrack.com" };
        await userManager.CreateAsync(user, "Password123!");
        await userManager.AddToRoleAsync(user, "User");
    }
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
