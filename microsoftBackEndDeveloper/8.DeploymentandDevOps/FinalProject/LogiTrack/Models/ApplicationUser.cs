// Classe que representa um usuário da aplicação, herdando de IdentityUser
// Esta classe é usada pelo sistema de identidade do ASP.NET Core para gerenciar usuários
using Microsoft.AspNetCore.Identity;

namespace LogiTrack.Models
{
    public class ApplicationUser : IdentityUser
    {
        // A classe herda todas as propriedades padrão de IdentityUser como:
        // - Id: identificador único do usuário
        // - UserName: nome de usuário
        // - Email: endereço de email
        // - PasswordHash: hash da senha
        // - E outras propriedades relacionadas à segurança
    }
}