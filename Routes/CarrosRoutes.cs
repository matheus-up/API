using Microsoft.EntityFrameworkCore;
using CarReservationApi.Data;
using CarReservationApi.Models;

namespace CarReservationApi.Routes;

public static class CarrosRoutes
{
    public static void MapCarrosRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/carros", async (ApplicationDbContext db) =>
            await db.Carros.ToListAsync());

        routes.MapGet("/api/carros/{id}", async (int id, ApplicationDbContext db) =>
        {
            var carro = await db.Carros.FindAsync(id);
            return carro is not null ? Results.Ok(carro) : Results.NotFound();
        });

        routes.MapPost("/api/carros", async (Carro carro, ApplicationDbContext db) =>
        {
            db.Carros.Add(carro);
            await db.SaveChangesAsync();
            return Results.Created($"/api/carros/{carro.Id}", carro);
        });

        routes.MapPut("/api/carros/{id}", async (int id, Carro updated, ApplicationDbContext db) =>
        {
            var carro = await db.Carros.FindAsync(id);
            if (carro is null) return Results.NotFound();

            carro.Modelo = updated.Modelo;
            carro.Marca = updated.Marca;
            carro.Ano = updated.Ano;
            
            await db.SaveChangesAsync();
            return Results.Ok(carro);
        });

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