using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarReservationApi.Data;
using CarReservationApi.Models;

namespace CarReservationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _context.Carros.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            if (carro == null) return NotFound();
            return Ok(carro);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Carro carro)
        {
            _context.Carros.Add(carro);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = carro.Id }, carro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Carro carro)
        {
            if (id != carro.Id) return BadRequest();
            _context.Entry(carro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            if (carro == null) return NotFound();
            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}