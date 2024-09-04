namespace Dviaje.Models.VM
{
    public class ResenasPublicacionVM
    {
        public int IdPublicacion { get; set; }
        public string? TituloPublicacion { get; set; }
        public decimal PuntuacionPunblicacion { get; set; }
        public string? DescripcionPublicacion { get; set; }
        public string? DireccionPublicacion { get; set; }
        // Imagen con el orden 1
        public string? ImagenPublicacion { get; set; }
    }
}
