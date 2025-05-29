using Microsoft.EntityFrameworkCore;
using CarReservationApi.Data;
using CarReservationApi.Models;

namespace CarReservationApi.Routes;

public static class ClientesRoutes
{
    public static void MapClientesRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/clientes", async (ApplicationDbContext db) =>
            await db.Clientes.ToListAsync());

        routes.MapGet("/api/clientes/{id}", async (int id, ApplicationDbContext db) =>
        {
            var cliente = await db.Clientes.FindAsync(id);
            return cliente is not null ? Results.Ok(cliente) : Results.NotFound();
        });

        routes.MapPost("/api/clientes", async (Cliente cliente, ApplicationDbContext db) =>
        {
            db.Clientes.Add(cliente);
            await db.SaveChangesAsync();
            return Results.Created($"/api/clientes/{cliente.Id}", cliente);
        });

        routes.MapPut("/api/clientes/{id}", async (int id, Cliente updated, ApplicationDbContext db) =>
        {
            var cliente = await db.Clientes.FindAsync(id);
            if (cliente is null) return Results.NotFound();

            cliente.Nome = updated.Nome;
            cliente.Email = updated.Email;
            cliente.Telefone = updated.Telefone;

            await db.SaveChangesAsync();
            return Results.Ok(cliente);
        });

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