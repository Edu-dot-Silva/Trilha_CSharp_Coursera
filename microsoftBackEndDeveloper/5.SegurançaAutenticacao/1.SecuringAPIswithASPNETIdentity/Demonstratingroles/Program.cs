// Importações necessárias para Identity, EF Core e Claims
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

// Criação do builder da aplicação
var builder = WebApplication.CreateBuilder(args);

// Configura o banco de dados em memória para autenticação
builder.Services.AddDbContext<IdentityDbContext>(options => options.UseInMemoryDatabase("AuthDemoDb"));

// Adiciona serviços de Identity (usuários e roles)
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityDbContext>();

// Configura o cookie de autenticação para retornar 401 em vez de redirecionar para login em rotas /api
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = context =>
    {
        if (context.Request.Path.StartsWithSegments("/api"))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        }
        context.Response.Redirect(context.RedirectUri);
        return Task.CompletedTask;
    };
});

// Adiciona autenticação e políticas de autorização
builder.Services.AddAuthentication();
builder.Services.AddAuthorization(options =>
{
    // Política que exige o papel Admin
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    // Política que exige o claim Department=IT
    options.AddPolicy("ITDepartment", policy => policy.RequireClaim("Department", "IT"));
});

// Cria a aplicação
var app = builder.Build();

// Endpoint raiz
app.MapGet("/", () => "I am root");

// Endpoint protegido: apenas Admin pode acessar
app.MapGet("/api/admin-only", () => "Admin access only")
    .RequireAuthorization("AdminOnly");

// Endpoint protegido: apenas usuários com claim Department=IT podem acessar
app.MapGet("/api/user-claim-check", () => "Acess granted to IT department")
    .RequireAuthorization("ITDepartment");

// Endpoint de login (apenas para referência)
app.MapGet("/account/login", () => "This is the login route");

// Lista de roles a serem criadas
var roles = new[] { "Admin", "User"};

// Endpoint para criar roles no sistema
app.MapPost("/api/create-role", async (RoleManager<IdentityRole> roleManager) =>
{
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
    return Results.Ok("Roles created");
});

// Endpoint para criar usuário e atribuir role Admin
app.MapPost("/api/assign-role", async (UserManager<IdentityUser> userManager) =>
{
    var user = await userManager.FindByEmailAsync("testuser@example.com");
    if (user == null)
    {
        user = new IdentityUser { UserName = "testuser@example.com", Email = "testuser@example.com" };
        var createResult = await userManager.CreateAsync(user, "Abc123#");
        if (!createResult.Succeeded)
        {
            return Results.BadRequest("Failed to create user: " + string.Join(", ", createResult.Errors.Select(e => e.Description)));
        }
    }
    await userManager.AddToRoleAsync(user, "Admin");

    var isInRole = await userManager.IsInRoleAsync(user, "Admin");

    return isInRole ? Results.Ok("User assigned to Admin role") : Results.BadRequest("Failed to assign role");
});

// Endpoint de login: autentica o usuário e retorna 401 se falhar
app.MapPost("/api/login", async (SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, HttpContext httpContext) =>
{
    var user = await userManager.FindByEmailAsync("testuser@example.com");
    if (user == null)
    {
        return Results.NotFound("User not found");
    }

    var result = await signInManager.PasswordSignInAsync(user.UserName, "Abc123#", isPersistent: false, lockoutOnFailure: false);

    if (!result.Succeeded)
    {
        return Results.Json(new { error = "Login failed" }, statusCode: StatusCodes.Status401Unauthorized);
    }

    return Results.Ok("User logged in");
});

// Endpoint para adicionar claim Department=IT ao usuário
app.MapPost("/api/add-claim", async (UserManager<IdentityUser> userManager) =>
{
    var user = await userManager.FindByEmailAsync("testuser@example.com");
    if (user == null)
    {
        return Results.NotFound("User not found");
    }

    await userManager.AddClaimAsync(user, new Claim("Department", "IT"));

    var claims = await userManager.GetClaimsAsync(user);
    var hasITClaim = claims.Any(c => c.Type == "Department" && c.Value == "IT");

    return hasITClaim ? Results.Ok("Claim added to user") : Results.BadRequest("Failed to add claim");

});

// Inicia a aplicação
app.Run();
