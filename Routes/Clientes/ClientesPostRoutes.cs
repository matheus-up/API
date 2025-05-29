using CarReservationApi.Data;
using CarReservationApi.Models;

namespace CarReservationApi.Routes.Clientes;

public static class ClientesPostRoutes
{
    public static void MapClientesPostRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/clientes", async (Cliente cliente, ApplicationDbContext db) =>
        {
            db.Clientes.Add(cliente);
            await db.SaveChangesAsync();
            return Results.Created($"/api/clientes/{cliente.Id}", cliente);
        });
    }
}