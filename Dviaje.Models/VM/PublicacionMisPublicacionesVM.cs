namespace Dviaje.Models.VM
{
    public class PublicacionMisPublicacionesVM
    {
        public int IdPublicacion { get; set; }
        public decimal Precio { get; set; }
        public string? Titulo { get; set; }
        public string? Direccion { get; set; }
        public decimal Puntuacion { get; set; }
        public int NumeroResenas { get; set; }
        public string? Descripcion { get; set; }
        public List<PublicacionImagenVM>? Imagenes { get; set; }
        public PropiedadVM? Propiedad { get; set; }
        public CategoriaVM? Categoria { get; set; }
        public List<ServicioVM>? Servicios { get; set; }
        public List<RestriccionVM>? Restricciones { get; set; }
    }
}
