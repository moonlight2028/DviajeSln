namespace Dviaje.Models.VM
{
    public class PublicacionCrearVM
    {
        public int IdPublicacion { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string? Direccion { get; set; }
        public string? IdAliado { get; set; }
        public List<PublicacionImagenVM>? Imagenes { get; set; }
        public List<ServicioVM>? Servicios { get; set; }
        public List<ServicioAdicionalVM>? ServiciosAdicionales { get; set; }
        public List<RestriccionVM>? Restricciones { get; set; }
        public List<Categoria>? Categorias { get; set; }
        public List<FechasNoDisponibles>? FechasNoDisponibles { get; set; }
    }
}
