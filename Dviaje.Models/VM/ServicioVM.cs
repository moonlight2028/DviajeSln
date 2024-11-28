namespace Dviaje.Models.VM
{
    public class ServicioVM
    {
        public int IdPublicacion { get; set; }
        public int IdServicio { get; set; }
        public string? NombreServicio { get; set; }
        public string? RutaIcono { get; set; }
        public ServicioTipo ServicioTipo { get; set; }
    }
}
