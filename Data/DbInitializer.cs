using CarReservationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CarReservationApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.Migrate();

            if (context.Clientes.Any() || context.Carros.Any())
                return; // DB já foi populado

            var clientes = new Cliente[]
            {
                new Cliente { Nome = "Ana Souza", Email = "ana@example.com", Telefone = "1111-1111" },
                new Cliente { Nome = "Bruno Lima", Email = "bruno@example.com", Telefone = "2222-2222" },
                new Cliente { Nome = "Carlos Silva", Email = "carlos@example.com", Telefone = "3333-3333" },
                new Cliente { Nome = "Diana Costa", Email = "diana@example.com", Telefone = "4444-4444" },
                new Cliente { Nome = "Eduardo Melo", Email = "eduardo@example.com", Telefone = "5555-5555" },
                new Cliente { Nome = "Fernanda Dias", Email = "fernanda@example.com", Telefone = "6666-6666" },
                new Cliente { Nome = "Gabriel Rocha", Email = "gabriel@example.com", Telefone = "7777-7777" },
                new Cliente { Nome = "Helena Martins", Email = "helena@example.com", Telefone = "8888-8888" },
                new Cliente { Nome = "Igor Mendes", Email = "igor@example.com", Telefone = "9999-9999" },
                new Cliente { Nome = "Juliana Freitas", Email = "juliana@example.com", Telefone = "0000-0000" }
            };
            context.Clientes.AddRange(clientes);
            context.SaveChanges();

            var carros = new Carro[]
            {
                new Carro { Modelo = "Gol", Marca = "VW", Ano = 2018, Placa = "ABC1A11", Status = "Disponível" },
                new Carro { Modelo = "Civic", Marca = "Honda", Ano = 2020, Placa = "DEF2B22", Status = "Disponível" },
                new Carro { Modelo = "Corolla", Marca = "Toyota", Ano = 2021, Placa = "GHI3C33", Status = "Disponível" },
                new Carro { Modelo = "Uno", Marca = "Fiat", Ano = 2015, Placa = "JKL4D44", Status = "Disponível" },
                new Carro { Modelo = "HB20", Marca = "Hyundai", Ano = 2022, Placa = "MNO5E55", Status = "Disponível" },
                new Carro { Modelo = "Ka", Marca = "Ford", Ano = 2019, Placa = "PQR6F66", Status = "Disponível" },
                new Carro { Modelo = "Onix", Marca = "Chevrolet", Ano = 2020, Placa = "STU7G77", Status = "Disponível" },
                new Carro { Modelo = "T-Cross", Marca = "VW", Ano = 2023, Placa = "VWX8H88", Status = "Disponível" },
                new Carro { Modelo = "Fit", Marca = "Honda", Ano = 2017, Placa = "YZA9I99", Status = "Disponível" },
                new Carro { Modelo = "Palio", Marca = "Fiat", Ano = 2016, Placa = "BCD0J00", Status = "Disponível" }
            };
            context.Carros.AddRange(carros);
            context.SaveChanges();

            var reservas = new Reserva[]
            {
                new Reserva { Id_Cliente = 1, Id_Carro = 1, Data_Inicio = DateTime.Now, Data_Fim = DateTime.Now.AddDays(2), Status = "confirmada" },
                new Reserva { Id_Cliente = 2, Id_Carro = 2, Data_Inicio = DateTime.Now.AddDays(1), Data_Fim = DateTime.Now.AddDays(4), Status = "pendente" },
                new Reserva { Id_Cliente = 3, Id_Carro = 3, Data_Inicio = DateTime.Now.AddDays(-1), Data_Fim = DateTime.Now.AddDays(1), Status = "confirmada" },
                new Reserva { Id_Cliente = 4, Id_Carro = 4, Data_Inicio = DateTime.Now, Data_Fim = DateTime.Now.AddDays(3), Status = "confirmada" },
                new Reserva { Id_Cliente = 5, Id_Carro = 5, Data_Inicio = DateTime.Now.AddDays(2), Data_Fim = DateTime.Now.AddDays(5), Status = "pendente" }
            };
            context.Reservas.AddRange(reservas);

            // Marcar os carros como indisponíveis
            foreach (var r in reservas)
            {
                var carro = context.Carros.Find(r.Id_Carro);
                if (carro != null) carro.Status = "Indisponível";
            }

            context.SaveChanges();
        }
    }
}