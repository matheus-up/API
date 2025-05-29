using CarReservationApi.Data;
using CarReservationApi.Routes.Carros;
using CarReservationApi.Routes.Clientes;
using CarReservationApi.Routes.Reservas;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Pipeline HTTP
app.UseHttpsRedirection();

// Rotas de Carros
app.MapCarrosGetRoutes();
app.MapCarrosPostRoutes();
app.MapCarrosDeleteRoutes();

// Rotas de Clientes
app.MapClientesGetRoutes();
app.MapClientesPostRoutes();
app.MapClientesDeleteRoutes();

// Rotas de Reservas
app.MapReservasGetRoutes();
app.MapReservasPostRoutes();
app.MapReservasDeleteRoutes();

app.Run();
