using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SkillSnap.Api.Models;

namespace SkillSnap.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly SkillSnapContext _context;
        private readonly IMemoryCache _cache;
        private const string ProjectsCacheKey = "projects_all";
        private const int CacheDurationMinutes = 5;

        public ProjectsController(SkillSnapContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            if (!_cache.TryGetValue(ProjectsCacheKey, out List<Project>? projects) || projects == null)
            {
                projects = await _context.Projects.AsNoTracking().ToListAsync();
                _cache.Set(ProjectsCacheKey, projects, TimeSpan.FromMinutes(CacheDurationMinutes));
            }
            return projects;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _context.Projects.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            if (project == null)
                return NotFound();

            return project;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsByUser(int userId)
        {
            var cacheKey = $"projects_user_{userId}";
            if (!_cache.TryGetValue(cacheKey, out List<Project>? projects) || projects == null)
            {
                projects = await _context.Projects.AsNoTracking()
                    .Where(p => p.PortfolioUserId == userId)
                    .ToListAsync();
                _cache.Set(cacheKey, projects, TimeSpan.FromMinutes(CacheDurationMinutes));
            }
            return projects;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            
            // Invalidate cache after creating project
            _cache.Remove(ProjectsCacheKey);
            _cache.Remove($"projects_user_{project.PortfolioUserId}");
            
            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, Project project)
        {
            if (id != project.Id)
                return BadRequest();

            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            // Invalidate cache after updating project
            _cache.Remove(ProjectsCacheKey);
            _cache.Remove($"projects_user_{project.PortfolioUserId}");
            
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
                return NotFound();

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            
            // Invalidate cache after deleting project
            _cache.Remove(ProjectsCacheKey);
            _cache.Remove($"projects_user_{project.PortfolioUserId}");
            
            return NoContent();
        }
    }
}
