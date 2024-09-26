namespace Dviaje.Models.VM
{
    public class ResenaTarjetaDetalleVM
    {
        public string? Opinion { get; set; }
        public decimal Puntuacion { get; set; }
        public DateTime? Fecha { get; set; }
        public int NumerosLikes { get; set; }
        public int IdPublicacion { get; set; }
        public string? TituloPublicacion { get; set; }
        public string? ImagenPublicacion { get; set; }
        public string? IdAliado { get; set; }
        public string? NombreAliado { get; set; }
        public string? AvatarAliado { get; set; }
        public int NumeroPublicacionesAliado { get; set; }
    }
}
