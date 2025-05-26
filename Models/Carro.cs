using System.ComponentModel.DataAnnotations;

namespace CarReservationApi.Models
{
    public class Carro
    {
        public int Id { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public string Marca { get; set; }

        public int Ano { get; set; }

        [Required]
        public string Placa { get; set; }

        public string Status { get; set; } = "Disponível";
    }
}