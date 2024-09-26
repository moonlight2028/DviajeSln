namespace Dviaje.Models.VM
{
    public class PublicacionTablaItemVM
    {
        public int IdPublicacion { get; set; }
        public string? ImagenPublicacion { get; set; }
        public string? TituloPublicacion { get; set; }
        public decimal PrecioPublicacion { get; set; }
        public PublicacionEstado PublicacionEstado { get; set; }

        public int IdTurista { get; set; }
        public string? AvatarTurista { get; set; }
        public string? NombreTurista { get; set; }
    }
}
