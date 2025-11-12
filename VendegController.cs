using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fogado.Data;
using Fogado.Models;


namespace Fogado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendegController : ControllerBase
    {
        private readonly FogadoContext _context;

        public VendegController(FogadoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendeg>>> GetAll() => await _context.Vendegek.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Vendeg>> Get(int id)
        {
            var vendeg = await _context.Vendegek.FindAsync(id);
            if (vendeg == null) return NotFound();
            return vendeg;
        }

        [HttpPost]
        public async Task<ActionResult<Vendeg>> Create(Vendeg vendeg)
        {
            _context.Szobak.Add(vendeg);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = vendeg.Vsorsz }, vendeg);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Vendeg Vendeg)
        {
            if (id != Vendeg.Vsorsz) return BadRequest();
            _context.Entry(Vendeg).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vendeg = await _context.Vendegek.FindAsync(id);
            if (vendeg == null) return NotFound();
            _context.Vendegek.Remove(vendeg);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
