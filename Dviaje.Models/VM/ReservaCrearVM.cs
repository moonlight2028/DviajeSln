namespace Dviaje.Models.VM
{
    public class ReservaCrearVM
    {
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int NumeroPersonas { get; set; }
        public decimal PrecioTotal { get; set; }
        public int IdUsuario { get; set; }
        public int IdPublicacion { get; set; }
        public List<ServicioAdicionalVM>? ServiciosAdicionales { get; set; }
    }
}
