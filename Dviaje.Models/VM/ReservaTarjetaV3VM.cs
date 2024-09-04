namespace Dviaje.Models.VM
{
    public class ReservaTarjetaV3VM
    {
        // Datos de la publicación
        public int IdPublicacion { get; set; }
        public string? TituloPublicacion { get; set; }
        public decimal Puntuacion { get; set; }
        public int NumeroResenas { get; set; }
        public string? Ubicacion { get; set; }
        // Imagenes con el orden, 5 Imagenes
        public List<PublicacionImagenVM>? Imagen { get; set; }

        // Datos del aliado
        public string? IdAliado { get; set; }
        public string? AvatarAliado { get; set; }
        public string? NombreAliado { get; set; }
        public bool Verificado { get; set; } = false;

        // Datos de la reserva
        public int IdReserva { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int NumeroPersonas { get; set; }
        public ReservaEstado ReservaEstado { get; set; }

        List<ServicioAdicionalVM>? ServiciosAdicionales { get; set; }
    }
}
