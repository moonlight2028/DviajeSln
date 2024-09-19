namespace Dviaje.Models.VM
{
    public class ResenasTarjetaV2VM
    {
        public int IdPublicacion { get; set; }
        public string? TituloPublcacion { get; set; }
        public string? Opinion { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal Puntuacion { get; set; }
        public int MeGusta { get; set; }
        public string? IdAliado { get; set; }
        public string? AvatarAliado { get; set; }
        public string? NombreAliado { get; set; }
        public int NumeroPublicacionesAliado { get; set; }
    }
}
