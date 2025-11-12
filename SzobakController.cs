using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fogado.Data;
using Fogado.Models;


namespace Fogado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SzobakController : ControllerBase
    {
        private readonly FogadoContext _context;

        public SzobakController(FogadoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Szoba>>> GetAll() => await _context.Szobak.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Szoba>> Get(int id)
        {
            var szoba = await _context.Szobak.FindAsync(id);
            if (szoba == null) return NotFound();
            return szoba;
        }

        [HttpPost]
        public async Task<ActionResult<Szoba>> Create(Szoba szoba)
        {
            _context.Szobak.Add(szoba);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = szoba.Szazon }, szoba);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Szoba szoba)
        {
            if (id != szoba.Szazon) return BadRequest();
            _context.Entry(szoba).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var szoba = await _context.Szobak.FindAsync(id);
            if (szoba == null) return NotFound();
            _context.Szobak.Remove(szoba);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
