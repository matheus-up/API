using Microsoft.EntityFrameworkCore;
using CarReservationApi.Data;
using CarReservationApi.Models;

namespace CarReservationApi.Routes.Reservas;

public static class ReservasGetRoutes
{
    public static void MapReservasGetRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/reservas", async (ApplicationDbContext db) =>
            await db.Reservas.Include(r => r.Cliente).Include(r => r.Carro).ToListAsync());

        routes.MapGet("/api/reservas/{id}", async (int id, ApplicationDbContext db) =>
        {
            var reserva = await db.Reservas.Include(r => r.Cliente).Include(r => r.Carro).FirstOrDefaultAsync(r => r.Id == id);
            return reserva is not null ? Results.Ok(reserva) : Results.NotFound();
        });
    }
}
