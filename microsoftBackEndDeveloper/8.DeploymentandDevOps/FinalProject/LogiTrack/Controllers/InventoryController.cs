// Controller responsável por gerenciar operações de inventário
using Microsoft.AspNetCore.Mvc;
using LogiTrack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;

namespace LogiTrack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Requer autenticação para acessar qualquer endpoint
    public class InventoryController : ControllerBase
    {
        // Contexto do banco de dados
        private readonly LogiTrackContext _context;
        // Cache em memória para otimização de performance
        private readonly IMemoryCache _cache;

        // Construtor que injeta as dependências
        public InventoryController(LogiTrackContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        // Endpoint GET para listar todos os itens de inventário
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryItem>>> GetInventory()
        {
            // Chave para armazenar o cache
            const string cacheKey = "InventoryList";
            // Tenta obter os dados do cache
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<InventoryItem> inventory))
            {
                // Se não estiver em cache, busca no banco de dados sem rastreamento para performance
                inventory = await _context.InventoryItems.AsNoTracking().ToListAsync();
                // Define opções de cache com expiração deslizante de 30 segundos
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30));
                // Armazena no cache
                _cache.Set(cacheKey, inventory, cacheEntryOptions);
            }
            // Retorna os dados (do cache ou do banco)
            return Ok(inventory);
        }

        // Endpoint POST para criar um novo item de inventário
        [HttpPost]
        [Authorize(Roles = "Manager")] // Requer role de Manager
        public async Task<ActionResult<InventoryItem>> PostInventoryItem(InventoryItem item)
        {
            // Adiciona o item ao contexto
            _context.InventoryItems.Add(item);
            // Salva as mudanças no banco
            await _context.SaveChangesAsync();
            // Retorna resposta de criação com localização do novo recurso
            return CreatedAtAction(nameof(GetInventory), new { id = item.ItemId }, item);
        }

        // Endpoint DELETE para remover um item de inventário por ID
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")] // Requer role de Manager
        public async Task<IActionResult> DeleteInventoryItem(int id)
        {
            // Busca o item pelo ID
            var item = await _context.InventoryItems.FindAsync(id);
            if (item == null)
            {
                // Retorna 404 se o item não for encontrado
                return NotFound();
            }
            // Remove o item do contexto
            _context.InventoryItems.Remove(item);
            // Salva as mudanças
            await _context.SaveChangesAsync();
            // Retorna 204 No Content
            return NoContent();
        }
    }
}