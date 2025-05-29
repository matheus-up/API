using CarReservationApi.Data;
using CarReservationApi.Models;

namespace CarReservationApi.Routes.Carros;

public static class CarrosDeleteRoutes
{
    public static void MapCarrosDeleteRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapDelete("/api/carros/{id}", async (int id, ApplicationDbContext db) =>
        {
            var carro = await db.Carros.FindAsync(id);
            if (carro is null) return Results.NotFound();

            db.Carros.Remove(carro);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}