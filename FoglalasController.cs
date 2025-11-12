using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fogado.Data;
using Fogado.Models;


namespace Fogado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoglalasController : ControllerBase
    {
        private readonly FogadoContext _context;

        public FoglalasController(FogadoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Foglalas>>> GetAll() => await _context.Foglalasok.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Foglalas>> Get(int id)
        {
            var foglalas = await _context.Foglalasok.FindAsync(id);
            if (foglalas == null) return NotFound();
            return foglalas;
        }

        [HttpPost]
        public async Task<ActionResult<Foglalas>> Create(Foglalas foglalas)
        {
            _context.Foglalasok.Add(foglalas);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = foglalas.Fsorsz }, foglalas);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Foglalas foglalas)
        {
            if (id != foglalas.Fsorsz) return BadRequest();
            _context.Entry(foglalas).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var szoba = await _context.Foglalasok.FindAsync(id);
            if (szoba == null) return NotFound();
            _context.Foglalasok.Remove(foglalas);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
