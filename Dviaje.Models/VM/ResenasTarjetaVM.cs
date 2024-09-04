namespace Dviaje.Models.VM
{
    public class ResenasTarjetaVM
    {
        public int IdPublicacion { get; set; }
        public string? TituloPublcacion { get; set; }
        public string? Opinion { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal Puntuacion { get; set; }
        public int MeGusta { get; set; }
        public string? AvatarTurista { get; set; }
    }
}
