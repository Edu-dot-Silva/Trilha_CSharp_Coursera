using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SkillSnap.Api.Models;

namespace SkillSnap.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly SkillSnapContext _context;
        private readonly IMemoryCache _cache;
        private const string SkillsCacheKey = "skills_all";
        private const int CacheDurationMinutes = 5;

        public SkillsController(SkillSnapContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> GetSkills()
        {
            if (!_cache.TryGetValue(SkillsCacheKey, out List<Skill>? skills) || skills == null)
            {
                skills = await _context.Skills.AsNoTracking().ToListAsync();
                _cache.Set(SkillsCacheKey, skills, TimeSpan.FromMinutes(CacheDurationMinutes));
            }
            return skills;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkill(int id)
        {
            var skill = await _context.Skills.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
            if (skill == null)
                return NotFound();

            return skill;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Skill>>> GetSkillsByUser(int userId)
        {
            var cacheKey = $"skills_user_{userId}";
            if (!_cache.TryGetValue(cacheKey, out List<Skill>? skills) || skills == null)
            {
                skills = await _context.Skills.AsNoTracking()
                    .Where(s => s.PortfolioUserId == userId)
                    .ToListAsync();
                _cache.Set(cacheKey, skills, TimeSpan.FromMinutes(CacheDurationMinutes));
            }
            return skills;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Skill>> CreateSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            
            // Invalidate cache after creating skill
            _cache.Remove(SkillsCacheKey);
            _cache.Remove($"skills_user_{skill.PortfolioUserId}");
            
            return CreatedAtAction(nameof(GetSkill), new { id = skill.Id }, skill);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkill(int id, Skill skill)
        {
            if (id != skill.Id)
                return BadRequest();

            _context.Entry(skill).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            // Invalidate cache after updating skill
            _cache.Remove(SkillsCacheKey);
            _cache.Remove($"skills_user_{skill.PortfolioUserId}");
            
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
                return NotFound();

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
            
            // Invalidate cache after deleting skill
            _cache.Remove(SkillsCacheKey);
            _cache.Remove($"skills_user_{skill.PortfolioUserId}");
            
            return NoContent();
        }
    }
}
