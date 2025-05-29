using Microsoft.EntityFrameworkCore;
using CarReservationApi.Data;
using CarReservationApi.Models;

namespace CarReservationApi.Routes.Clientes;

public static class ClientesGetRoutes
{
    public static void MapClientesGetRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/clientes", async (ApplicationDbContext db) =>
            await db.Clientes.ToListAsync());

        routes.MapGet("/api/clientes/{id}", async (int id, ApplicationDbContext db) =>
        {
            var cliente = await db.Clientes.FindAsync(id);
            return cliente is not null ? Results.Ok(cliente) : Results.NotFound();
        });
    }
}