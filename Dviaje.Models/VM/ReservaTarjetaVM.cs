namespace Dviaje.Models.VM
{
    public class ReservaTarjetaVM
    {
        // Datos de la publicación
        public int IdPublicacion { get; set; }
        public string? TituloPublicacion { get; set; }
        public decimal Puntuacion { get; set; }
        public int NumeroResenas { get; set; }
        public string? Ubicacion { get; set; }
        // Imagen con el orden 1
        public string? Imagen { get; set; }

        // Datos del aliado
        public string? IdAliado { get; set; }
        public string? AvatarAliado { get; set; }
        public string? NombreAliado { get; set; }

        // Datos de la reserva
        public int IdReserva { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int NumeroPersonas { get; set; }
    }
}
