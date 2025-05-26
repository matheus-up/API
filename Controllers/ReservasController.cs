using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarReservationApi.Data;
using CarReservationApi.Models;

namespace CarReservationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReservasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _context.Reservas.Include(r => r.Cliente).Include(r => r.Carro).ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Carro)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reserva == null) return NotFound();
            return Ok(reserva);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Reserva reserva)
        {
            var carro = await _context.Carros.FindAsync(reserva.Id_Carro);
            if (carro == null || carro.Status == "Indisponível")
                return BadRequest("Carro não disponível.");

            carro.Status = "Indisponível";
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = reserva.Id }, reserva);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null) return NotFound();

            var carro = await _context.Carros.FindAsync(reserva.Id_Carro);
            if (carro != null) carro.Status = "Disponível";

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}