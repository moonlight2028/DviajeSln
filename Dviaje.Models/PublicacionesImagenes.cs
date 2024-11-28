namespace Dviaje.Models
{
    public class PublicacionesImagenes
    {
        public int IdPublicacionImagen { get; set; }
        public string? IdPublico { get; set; }
        public string? Ruta { get; set; }
        public string? Alt { get; set; }
        public int Orden { get; set; }
        public int IdPublicacion { get; set; }
    }
}
