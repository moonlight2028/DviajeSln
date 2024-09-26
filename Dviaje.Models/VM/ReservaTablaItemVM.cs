namespace Dviaje.Models.VM
{
    public class ReservaTablaItemVM
    {
        public int IdReserva { get; set; }
        public ReservaEstado ReservaEstado { get; set; }
        public decimal PrecioReserva { get; set; }
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }

        public int IdUsuairo { get; set; }
        public string? NombreUsuario { get; set; }
        public string? AvatarUsuario { get; set; }

        public int IdPublicacion { get; set; }
        public string? ImagenPublicacion { get; set; }
        public string? TituloPublicacion { get; set; }
    }
}
