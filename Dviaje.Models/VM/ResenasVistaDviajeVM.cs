namespace Dviaje.Models.VM
{
    public class ResenasVistaDviajeVM
    {
        public string? IdPublicacion { get; set; }
        public string? TituloPublicacion { get; set; }
        public decimal Puntuacion { get; set; }
        public string? Descripcion { get; set; }
        public string? Direccion { get; set; }
        public string? Imagen { get; set; }
        public List<ResenasTarjetaVM>? ResenasTarjeta { get; set; }
    }
}
