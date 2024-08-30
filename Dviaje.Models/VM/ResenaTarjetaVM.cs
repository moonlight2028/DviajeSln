namespace Dviaje.Models.VM
{
    public class ResenaTarjetaVM
    {
        public int IdResena { get; set; }
        public string? Opinion { get; set; }
        public int Calificacion { get; set; }
        public int MeGusta { get; set; }
        public DateTime Fecha { get; set; }

        // Datos del usuario que hizo la reseña
        public string? NombreUsuario { get; set; }
        public string? AvatarUrl { get; set; }

        // Datos de la publicación a la que pertenece la reseña
        public string? TituloPublicacion { get; set; }
        public decimal? PuntuacionPublicacion { get; set; }
    }
}
