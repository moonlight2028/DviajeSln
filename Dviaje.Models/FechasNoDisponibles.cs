namespace Dviaje.Models
{
    public class FechasNoDisponibles
    {
        public int IdFechaNoDisponible { get; set; }
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int IdPublicacion { get; set; }
    }
}
