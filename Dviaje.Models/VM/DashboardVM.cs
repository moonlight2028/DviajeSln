namespace Dviaje.Models.VM
{
    public class DashboardVM
    {
        public int TotalUsuarios { get; set; }
        public int TotalAliados { get; set; }
        public int TotalReservas { get; set; }
        public int ReservasActivas { get; set; }
        public int TotalPublicaciones { get; set; }
        public int PublicacionesActivas { get; set; }
        public int TotalResenas { get; set; }
        public decimal PromedioCalificaciones { get; set; }
    }

}
