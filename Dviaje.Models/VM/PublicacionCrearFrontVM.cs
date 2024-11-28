namespace Dviaje.Models.VM
{
    public class PublicacionCrearFrontVM
    {
        // Datos fronten
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string? Direccion { get; set; }
        public int CategoriaSeleccionada { get; set; }
        public int PropiedadSeleccionada { get; set; }
        public List<int>? ServiciosSeleccionados { get; set; }
        public List<int>? restriccionesSeleccionadas { get; set; }
        public int Huespedes { get; set; }
        public int Recamaras { get; set; }
        public int NumeroCamas { get; set; }
        public int Banios { get; set; }
        public List<ImagenVM>? Imagenes { get; set; }
        public List<FechaNoDisponibleVM>? FechasNoDisponibles { get; set; }
        public decimal PrecioNoche { get; set; }


        // Datos Backend
        public string? IdAliado { get; set; }
        public DateTime Fecha { get; set; }
        public string? PublicacionEstado { get; set; }
    }
}
