namespace Dviaje.Models
{
    public class Servicio
    {
        public int IdServicio { get; set; }
        public string? NombreServicio { get; set; }
        public string? RutaIcono { get; set; }
        public ServicioTipo ServicioTipo { get; set; }
    }
}
