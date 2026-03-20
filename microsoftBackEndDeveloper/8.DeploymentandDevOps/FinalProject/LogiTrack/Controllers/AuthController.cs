// Controller responsável pela autenticação e autorização de usuários
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LogiTrack.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace LogiTrack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // Gerenciador de usuários do ASP.NET Identity
        private readonly UserManager<ApplicationUser> _userManager;
        // Gerenciador de login do ASP.NET Identity
        private readonly SignInManager<ApplicationUser> _signInManager;
        // Configurações da aplicação (para JWT)
        private readonly IConfiguration _configuration;

        // Construtor que injeta as dependências necessárias
        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        // Endpoint para registro de novos usuários
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            // Cria um novo usuário com os dados fornecidos
            var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // Atribui a role padrão "User" ao novo usuário
                await _userManager.AddToRoleAsync(user, "User");
                return Ok(new { Message = "User registered successfully" });
            }
            // Retorna erros se o registro falhar
            return BadRequest(result.Errors);
        }

        // Endpoint para login de usuários
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // Tenta fazer login com as credenciais fornecidas
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (result.Succeeded)
            {
                // Busca o usuário pelo nome
                var user = await _userManager.FindByNameAsync(model.Username);
                // Gera um token JWT para o usuário
                var token = GenerateJwtToken(user);
                return Ok(new { Token = token });
            }
            // Retorna não autorizado se o login falhar
            return Unauthorized();
        }

        // Método privado para gerar um token JWT para o usuário autenticado
        private string GenerateJwtToken(ApplicationUser user)
        {
            // Define as claims (informações) que serão incluídas no token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName), // Nome do usuário
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // ID único do token
                new Claim(ClaimTypes.NameIdentifier, user.Id) // ID do usuário
            };

            // Cria a chave de segurança simétrica usando a chave secreta da configuração
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            // Define as credenciais de assinatura usando HMAC-SHA256
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Cria o token JWT com emissor, audiência, claims, expiração e credenciais
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30), // Token válido por 30 minutos
                signingCredentials: creds);

            // Retorna o token como string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    // Modelo de dados para o registro de usuários
    public class RegisterModel
    {
        public string Username { get; set; } // Nome de usuário desejado
        public string Email { get; set; } // Endereço de email
        public string Password { get; set; } // Senha do usuário
    }

    // Modelo de dados para o login de usuários
    public class LoginModel
    {
        public string Username { get; set; } // Nome de usuário
        public string Password { get; set; } // Senha
    }
}