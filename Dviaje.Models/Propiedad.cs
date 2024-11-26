namespace Dviaje.Models
{
    public class Propiedad
    {
        public int IdPropiedad { get; set; }
        public string? Nombre { get; set; }
        public string? RutaIcono { get; set; }
        public string? Descripcion { get; set; }
        public int IdCategoria { get; set; }
    }
}
