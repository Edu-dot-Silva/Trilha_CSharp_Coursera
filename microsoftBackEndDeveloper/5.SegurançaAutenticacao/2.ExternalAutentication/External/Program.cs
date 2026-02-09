using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Configura os esquemas de autenticação da aplicação
builder.Services.AddAuthentication(options =>
{
    // Define o esquema padrão como Cookie para armazenar dados de autenticação localmente
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    // Define o esquema de desafio padrão como Google quando autenticação é necessária
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
// Adiciona autenticação por Cookie
.AddCookie()
// Adiciona autenticação externa via Google OAuth 2.0
.AddGoogle(options => {
        // Obtém o Client ID do Google configurado no appsettings.Development.json
        options.ClientId = builder.Configuration["Autorization:Google:ClientId"];
        // Obtém o Client Secret do Google configurado no appsettings.Development.json
        options.ClientSecret = builder.Configuration["Autorization:Google:ClientSecret"];
});

// Adiciona o serviço de autorização à aplicação
builder.Services.AddAuthorization();

// Constrói a aplicação ASP.NET Core
var app = builder.Build();

// Define rota pública: retorna "Hello World!" sem requer autenticação
app.MapGet("/", () => "Hello World!");

// Define rota protegida: requer que o usuário esteja autenticado
// Sem autenticação, redireciona para o Google para fazer login
app.MapGet("/secure", () => "This is a secure endpoint!")
    .RequireAuthorization();

// Inicia a aplicação
app.Run();