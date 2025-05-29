using CarReservationApi.Data;
using CarReservationApi.Models;

namespace CarReservationApi.Routes.Reservas;

public static class ReservasDeleteRoutes
{
    public static void MapReservasDeleteRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapDelete("/api/reservas/{id}", async (int id, ApplicationDbContext db) =>
        {
            var reserva = await db.Reservas.FindAsync(id);
            if (reserva is null) return Results.NotFound();

            db.Reservas.Remove(reserva);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}