using CarReservationApi.Data;
using CarReservationApi.Models;

namespace CarReservationApi.Routes.Reservas;

public static class ReservasPostRoutes
{
    public static void MapReservasPostRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/reservas", async (Reserva reserva, ApplicationDbContext db) =>
        {
            db.Reservas.Add(reserva);
            await db.SaveChangesAsync();
            return Results.Created($"/api/reservas/{reserva.Id}", reserva);
        });
    }
}