// Contexto do banco de dados para a aplicação LogiTrack
// Herda de IdentityDbContext para incluir tabelas de usuários e roles do ASP.NET Identity
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LogiTrack.Models;

public class LogiTrackContext : IdentityDbContext<ApplicationUser>
{
    // DbSet para a tabela de itens de inventário
    public DbSet<InventoryItem> InventoryItems { get; set; }

    // DbSet para a tabela de pedidos
    public DbSet<Order> Orders { get; set; }

    // Construtor que recebe as opções de configuração do banco de dados
    public LogiTrackContext(DbContextOptions<LogiTrackContext> options) : base(options) { }
}