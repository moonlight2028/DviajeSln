namespace Dviaje.Models.VM
{
    public class PublicacionTarjetaVM
    {
        public int IdPublicacion { get; set; }
        public string? AliadoId { get; set; }
        public string? AvatarAliado { get; set; }
        public string? NombreAliado { get; set; }
        public int TotalPublicacionesAliado { get; set; }
        public bool Verificado { get; set; } = false;
        public decimal Precio { get; set; }
        public string? Titulo { get; set; }
        public string? Direccion { get; set; }
        public decimal Puntuacion { get; set; }
        public int NumeroResenas { get; set; }
        public string? Descripcion { get; set; }
        public List<CategoriaVM>? Categorias { get; set; }
        public List<PublicacionImagenVM>? Imagenes { get; set; }
    }
}
