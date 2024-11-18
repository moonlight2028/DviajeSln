using Dviaje.Models.VM.Dviaje.Models.VM;

namespace Dviaje.Models.VM
{
    public class PublicacionDetalleVM
    {
        public int IdPublicacion { get; set; }
        public string? Titulo { get; set; }
        public decimal Puntuacion { get; set; }
        public int NumeroResenas { get; set; }
        public string? Descripcion { get; set; }
        public string? Ubicacion { get; set; }
        public string? IdAliado { get; set; }
        public string? AvatarAliado { get; set; }
        public string? NombreAliado { get; set; }
        public int PublicacionesAliado { get; set; }
        public decimal Precio { get; set; }
        public bool VerificadoAliado { get; set; } = false;
        public List<PuntuacionVM>? PuntuacionPorEstrellas { get; set; }
        public List<PublicacionImagenVM>? Imagenes { get; set; }
        public List<CategoriaVM>? Categorias { get; set; }
        public List<ServicioVM>? Servicios { get; set; }
        public List<ServicioAdicionalVM>? ServiciosAdicionales { get; set; }
        public List<RestriccionVM>? Restricciones { get; set; }
        public List<ResenaTarjetaBasicaVM>? TopResenas { get; set; }
    }
}
