using System.ComponentModel.DataAnnotations;

namespace CarReservationApi.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Telefone { get; set; }
    }
}