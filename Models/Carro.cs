namespace CarReservationApi.Models
{
    public class Carro
    {
        public int Id { get; set; }

        public string Modelo { get; set; } = string.Empty;

        public string Marca { get; set; } = string.Empty;

        public int Ano { get; set; }

        public string Placa { get; set; } = string.Empty;

        public string Status { get; set; } = "Disponível"; // <- adicionado
    }
}
