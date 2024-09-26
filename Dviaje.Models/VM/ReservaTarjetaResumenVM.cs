namespace Dviaje.Models.VM
{
    public class ReservaTarjetaResumenVM
    {
        public int IdReserva { get; set; }
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int Personas { get; set; }
        public int IdPublicacion { get; set; }
        public int NumeroResenasPublicacion { get; set; }
        public int NumeroReservasPublicacion { get; set; }
        public string? ImagenPublicacion { get; set; }
    }
}
