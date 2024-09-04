namespace Dviaje.Models.VM
{
    public class ResenaCrearVM
    {
        public string? Opinion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Calificacion { get; set; }
        public int IdReserva { get; set; }
    }
}
