namespace Dviaje.Models.VM
{
    public class ResenaTarjetaBasicaVM
    {
        public int IdReserva { get; set; }
        public string? IdTurista { get; set; }
        public string? NombreTurista { get; set; }
        public string? AvatarTurista { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal Puntuacion { get; set; }
        public int NumeroLikes { get; set; }
    }
}
