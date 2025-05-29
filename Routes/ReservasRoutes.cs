using Microsoft.EntityFrameworkCore;
using CarReservationApi.Data;
using CarReservationApi.Models;

namespace CarReservationApi.Routes;

public static class ReservasRoutes
{
    public static void MapReservasRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/reservas", async (ApplicationDbContext db) =>
            await db.Reservas.Include(r => r.Cliente).Include(r => r.Carro).ToListAsync());

        routes.MapGet("/api/reservas/{id}", async (int id, ApplicationDbContext db) =>
        {
            var reserva = await db.Reservas.Include(r => r.Cliente).Include(r => r.Carro)
                                           .FirstOrDefaultAsync(r => r.Id == id);
            return reserva is not null ? Results.Ok(reserva) : Results.NotFound();
        });

        routes.MapPost("/api/reservas", async (Reserva reserva, ApplicationDbContext db) =>
        {
            db.Reservas.Add(reserva);
            await db.SaveChangesAsync();
            return Results.Created($"/api/reservas/{reserva.Id}", reserva);
        });

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