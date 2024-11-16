namespace Dviaje.Models.VM
{
    public class PublicacionCrearVM
    {
        public int IdPublicacion { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Direccion { get; set; }
        public string? IdAliado { get; set; }
        public List<PublicacionImagenVM>? Imagenes { get; set; }
        public List<int>? IdServicios { get; set; }
        public List<ServiciosAdicionales>? ServiciosAdicionales { get; set; }
        public List<int>? Restricciones { get; set; }
        public List<int>? Categorias { get; set; }
        public List<FechasNoDisponibles>? FechasNoDisponibles { get; set; }
    }
}
