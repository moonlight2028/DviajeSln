namespace Dviaje.Models.VM
{
    public class ServicioAdicionalVM
    {
        public decimal Precio { get; set; }
        public string? NombreServicio { get; set; }
        public ServicioTipo ServicioTipo { get; set; }
        public string? RutaIcono { get; set; }
    }
}

