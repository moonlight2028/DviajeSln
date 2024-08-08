namespace Dviaje.Models.VM
{
    public class PublicacionTarjetaVM
    {
        public int IdPublicacion { get; set; }

        public string? AliadoId { get; set; }

        public string? AvatarAliado { get; set; }

        public string? NombreAliado { get; set; }

        public int TotalPublicacionesAliado { get; set; }

        public decimal Precio { get; set; }

        public string? Titulo { get; set; }

        public string? Direccion { get; set; }

        public decimal Calificacion { get; set; }

        public int TotalResenas { get; set; }

        public string? Descripcion { get; set; }

        public List<Categoria>? Categorias { get; set; }

        public List<PublicacionImagenVM>? Imagenes { get; set; }
    }
}
