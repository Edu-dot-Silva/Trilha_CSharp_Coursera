using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SkillSnap.Api.Models;

namespace SkillSnap.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioUsersController : ControllerBase
    {
        private readonly SkillSnapContext _context;
        private readonly IMemoryCache _cache;
        private const string UserseCacheKey = "portfolio_users_all";
        private const int CacheDurationMinutes = 5;

        public PortfolioUsersController(SkillSnapContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PortfolioUser>>> GetPortfolioUsers()
        {
            if (!_cache.TryGetValue(UserseCacheKey, out List<PortfolioUser>? users) || users == null)
            {
                users = await _context.PortfolioUsers
                    .AsNoTracking()
                    .Include(p => p.Projects)
                    .Include(p => p.Skills)
                    .ToListAsync();
                _cache.Set(UserseCacheKey, users, TimeSpan.FromMinutes(CacheDurationMinutes));
            }
            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PortfolioUser>> GetPortfolioUser(int id)
        {
            var cacheKey = $"portfolio_user_{id}";
            if (!_cache.TryGetValue(cacheKey, out PortfolioUser? user) || user == null)
            {
                user = await _context.PortfolioUsers
                    .AsNoTracking()
                    .Include(p => p.Projects)
                    .Include(p => p.Skills)
                    .FirstOrDefaultAsync(p => p.Id == id);
                
                if (user != null)
                    _cache.Set(cacheKey, user, TimeSpan.FromMinutes(CacheDurationMinutes));
            }

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<PortfolioUser>> CreatePortfolioUser(PortfolioUser user)
        {
            _context.PortfolioUsers.Add(user);
            await _context.SaveChangesAsync();
            
            // Invalidate cache after creating user
            _cache.Remove(UserseCacheKey);
            
            return CreatedAtAction(nameof(GetPortfolioUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePortfolioUser(int id, PortfolioUser user)
        {
            if (id != user.Id)
                return BadRequest();

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            // Invalidate cache after updating user
            _cache.Remove(UserseCacheKey);
            _cache.Remove($"portfolio_user_{id}");
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortfolioUser(int id)
        {
            var user = await _context.PortfolioUsers.FindAsync(id);
            if (user == null)
                return NotFound();

            _context.PortfolioUsers.Remove(user);
            await _context.SaveChangesAsync();
            
            // Invalidate cache after deleting user
            _cache.Remove(UserseCacheKey);
            _cache.Remove($"portfolio_user_{id}");
            
            return NoContent();
        }
    }
}
