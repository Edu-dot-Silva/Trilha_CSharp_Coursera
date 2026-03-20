// Controller responsável por gerenciar operações de pedidos
using Microsoft.AspNetCore.Mvc;
using LogiTrack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace LogiTrack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Requer autenticação para todos os endpoints
    public class OrderController : ControllerBase
    {
        // Contexto do banco de dados
        private readonly LogiTrackContext _context;

        // Construtor que injeta o contexto
        public OrderController(LogiTrackContext context)
        {
            _context = context;
        }

        // Endpoint GET para listar todos os pedidos do usuário autenticado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            // Obtém o ID do usuário do token JWT
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized(); // Retorna não autorizado se não conseguir obter o ID
            // Busca pedidos do usuário com itens relacionados, sem rastreamento para performance
            return await _context.Orders.Include(o => o.Items).AsNoTracking().Where(o => o.UserId == userId).ToListAsync();
        }

        // Endpoint GET para obter um pedido específico por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            // Obtém o ID do usuário autenticado
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();
            // Busca o pedido pelo ID e verifica se pertence ao usuário
            var order = await _context.Orders.Include(o => o.Items).AsNoTracking().FirstOrDefaultAsync(o => o.OrderId == id && o.UserId == userId);
            if (order == null)
            {
                return NotFound(); // Retorna 404 se o pedido não for encontrado ou não pertencer ao usuário
            }
            return order;
        }

        // Endpoint POST para criar um novo pedido
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            // Obtém o ID do usuário autenticado
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();
            // Define o proprietário do pedido
            order.UserId = userId;
            // Adiciona o pedido ao contexto
            _context.Orders.Add(order);
            // Salva para obter o ID gerado
            await _context.SaveChangesAsync();
            // Atualiza os itens com o ID do pedido
            foreach (var item in order.Items)
            {
                item.OrderId = order.OrderId;
                item.Order = order;
            }
            // Salva novamente para persistir as relações
            await _context.SaveChangesAsync();
            // Retorna resposta de criação
            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }

        // Endpoint DELETE para remover um pedido (apenas para Managers)
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")] // Requer role de Manager
        public async Task<IActionResult> DeleteOrder(int id)
        {
            // Busca o pedido pelo ID
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            // Remove o pedido
            _context.Orders.Remove(order);
            // Salva as mudanças
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}