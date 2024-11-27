namespace Dviaje.Models.VM
{
    public class PqrsTablaVM
    {
        public int IdPqrs { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }
        public string Mensaje { get; set; }
        public string Correo { get; set; }
    }

}
