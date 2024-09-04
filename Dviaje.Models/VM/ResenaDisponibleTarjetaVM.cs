namespace Dviaje.Models.VM
{
    public class ResenaDisponibleTarjetaVM
    {
        public string? TituloPublicacion { get; set; }
        public string? DescripcionPublicacion { get; set; }
        public int IdPublicacion { get; set; }
        public decimal PuntuacionPublicacion { get; set; }
        // Imagen con el orden 1
        public string? ImagenPublicacion { get; set; }
        public int IdReserva { get; set; }
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
    }
}
