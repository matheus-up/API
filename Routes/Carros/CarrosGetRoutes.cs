using Microsoft.EntityFrameworkCore;
using CarReservationApi.Data;
using CarReservationApi.Models;

namespace CarReservationApi.Routes.Carros;

public static class CarrosGetRoutes
{
    public static void MapCarrosGetRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/carros", async (ApplicationDbContext db) =>
            await db.Carros.ToListAsync());

        routes.MapGet("/api/carros/{id}", async (int id, ApplicationDbContext db) =>
        {
            var carro = await db.Carros.FindAsync(id);
            return carro is not null ? Results.Ok(carro) : Results.NotFound();
        });
    }
}