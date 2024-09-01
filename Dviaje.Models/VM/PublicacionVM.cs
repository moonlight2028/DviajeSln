namespace Dviaje.Models.VM
{
    public class PublicacionVM
    {
        public int IdPublicacion { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string? Ubicacion { get; set; }
        public decimal Precio { get; set; }
        public string? IdAliado { get; set; }
        public string? AvatarAliado { get; set; }
        public string? NombreAliado { get; set; }
        public int PublicacionesAliado { get; set; }
        public decimal Puntuacion { get; set; }
        public int NumeroResenas { get; set; }
        public List<ServicioVM>? ServiciosHabitacion { get; set; }
        public List<ServicioVM>? ServiciosEstablecimiento { get; set; }
        public List<ServicioVM>? ServiciosAccesibilidad { get; set; }
        public List<PublicacionImagenVM>? Imagenes { get; set; }
        /*
        public List<Categoria>? Categorias { get; set; }
        public List<Restriccion>? Restricciones { get; set; }
        public List<ServicioAdicional>? ServiciosAdicionales { get; set; }
        */
    }
}
