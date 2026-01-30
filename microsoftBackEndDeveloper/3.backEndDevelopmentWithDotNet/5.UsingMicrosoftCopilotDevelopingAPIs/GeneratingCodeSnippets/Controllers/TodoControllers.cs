using Microsoft.AspNetCore.Mvc;
using GeneratingCodeSnippets.Models;

namespace GeneratingCodeSnippets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private static List<TodoItem> items = new List<TodoItem>();
        private static int nextId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetAll()
        {
            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetById(int id)
        {
            var item = items.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public ActionResult<TodoItem> Create(TodoItem item)
        {
            item.Id = nextId++;
            items.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TodoItem updated)
        {
            var item = items.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();

            item.Name = updated.Name;
            item.IsComplete = updated.IsComplete;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = items.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();

            items.Remove(item);
            return NoContent();
        }
    }
}
