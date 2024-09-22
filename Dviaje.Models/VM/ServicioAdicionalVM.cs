namespace Dviaje.Models.VM
{
    public class ServicioAdicionalVM
    {
        public int IdServicioAdicional { get; set; }
        public decimal Precio { get; set; }
        public string? NombreServicio { get; set; }
        public ServicioTipo ServicioTipo { get; set; }
        public string? RutaIcono { get; set; }
        public bool Seleccionado { get; set; }
    }
}

