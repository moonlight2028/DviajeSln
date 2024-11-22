namespace Dviaje.Models.VM
{
    public class PublicacionCategoriaVM
    {
        public int IdPublicacion { get; set; }
        public string Titulo { get; set; }
        public decimal? Puntuacion { get; set; }
        public int? NumeroResenas { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Direccion { get; set; }
        public string PublicacionEstado { get; set; }
        public string ImagenPrincipal { get; set; }
        public string NombreCategoria { get; set; }
    }

}
