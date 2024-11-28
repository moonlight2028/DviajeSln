namespace Dviaje.Models.VM
{
    public class ReservaCrearVM
    {
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public decimal PrecioTotal { get; set; }
        public string? IdUsuario { get; set; }
        public int IdPublicacion { get; set; }
    }
}
