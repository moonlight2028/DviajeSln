namespace Dviaje.Models.VM
{

    public class CategoriaVM
    {
        public int IdPublicacion { get; set; }
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public string RutaIcono { get; set; }
        public string Url { get; set; } // Generado dinámicamente o desde la base de datos
    }


}
