using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotasyonWebAPI.Data;
using RotasyonWebAPI.Models;

namespace RotasyonWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContainersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/containers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Container>>> GetContainers()
        {
            return await _context.Containers.ToListAsync();
        }

        // POST: api/containers
        [HttpPost]
        public async Task<ActionResult<Container>> PostContainer(Container container)
        {
            _context.Containers.Add(container);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetContainers), new { id = container.Id }, container);
        }

        // DELETE: api/containers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContainer(int id)
        {
            var container = await _context.Containers.FindAsync(id);
            if (container == null) return NotFound();

            _context.Containers.Remove(container);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}