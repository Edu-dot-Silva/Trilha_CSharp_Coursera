using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var jwtKey = builder.Configuration["JwtKey"];

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        //essa validacao de lifetime esta no payload do token, onde tem o exp, que é a data de expiração do token, e o JwtBearer vai validar se o token ainda é válido ou se já expirou
        ValidIssuer = "MyIssuer",
        ValidAudience = "http://localhost:5016"
        //essas validacoes de issuer e audience são para garantir que o token foi emitido por uma fonte confiável e é destinado para a aplicação correta, evitando que tokens de outras fontes sejam aceitos
        //no payload adicionar "iss": "MyIssuer", "aud": "http://localhost:5016"
    };
});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("Admin", options => options.RequireRole("Admin"))
    .AddPolicy("ItDepartment", options => options.RequireClaim("Department", "IT"));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.MapGet("/secure", () => "This is a protected endpoint")
    .RequireAuthorization();

app.MapGet("/admin-role", () => "This needs a admin role")
    .RequireAuthorization("Admin");

app.MapGet("/it-claim", () => "This needs a IT claim")
    .RequireAuthorization("ItDepartment");



app.Run();
