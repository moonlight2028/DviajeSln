

namespace Dviaje.Models.VM
{
    public class PublicacionTarjetaBusquedaVM
    {
        public int IdPublicacion { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string? Direccion { get; set; }
        public decimal Puntuacion { get; set; }
        public int IdPropiedad { get; set; }
        public string? NombrePropiedad { get; set; }
        public string? IconoPropiedad { get; set; }
        public int IdCategoria { get; set; }
        public string? NombreCategoria { get; set; }
        public string? IconoCategoria { get; set; }
        public string? AliadoId { get; set; }
        public string? AvatarAliado { get; set; }
        public string? NombreAliado { get; set; }
        public int TotalPublicacionesAliado { get; set; }
        public bool Verificado { get; set; } = false;
        public int NumeroResenas { get; set; }
        public int TotalResultados { get; set; }
        public List<PublicacionImagenVM>? Imagenes { get; set; }
    }
}
