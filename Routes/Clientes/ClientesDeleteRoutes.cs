using CarReservationApi.Data;
using CarReservationApi.Models;

namespace CarReservationApi.Routes.Clientes;

public static class ClientesDeleteRoutes
{
    public static void MapClientesDeleteRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapDelete("/api/clientes/{id}", async (int id, ApplicationDbContext db) =>
        {
            var cliente = await db.Clientes.FindAsync(id);
            if (cliente is null) return Results.NotFound();

            db.Clientes.Remove(cliente);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}