using CarReservationApi.Data;
using CarReservationApi.Models;

namespace CarReservationApi.Routes.Carros;

public static class CarrosPostRoutes
{
    public static void MapCarrosPostRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/carros", async (Carro carro, ApplicationDbContext db) =>
        {
            db.Carros.Add(carro);
            await db.SaveChangesAsync();
            return Results.Created($"/api/carros/{carro.Id}", carro);
        });
    }
}