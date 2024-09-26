namespace Dviaje.Models.VM
{
    public class ResenaTarjetaRecibidaVM
    {
        public string? Opinion { get; set; }
        public decimal Puntuacion { get; set; }
        public DateTime? Fecha { get; set; }
        public int NumerosLikes { get; set; }
        public int IdPublicacion { get; set; }
        public string? TituloPublicacion { get; set; }
        public string? ImagenPublicacion { get; set; }
        public string? IdTurista { get; set; }
        public string? NombreTurista { get; set; }
        public string? AvatarTurista { get; set; }
        public int NumeroResenasTurista { get; set; }
    }
}
