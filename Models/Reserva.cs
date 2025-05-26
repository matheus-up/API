using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarReservationApi.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [ForeignKey("Cliente")]
        public int Id_Cliente { get; set; }

        [ForeignKey("Carro")]
        public int Id_Carro { get; set; }

        public DateTime Data_Inicio { get; set; }

        public DateTime Data_Fim { get; set; }

        public string Status { get; set; } = "pendente";

        public Cliente Cliente { get; set; }
        public Carro Carro { get; set; }
    }
}