namespace Dviaje.Models.VM
{
    public class PublicacionDestacadaVM
    {
        public int IdPublicacion { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public string ImagenPrincipal { get; set; }
        public List<PublicacionImagenVM> Imagenes { get; set; }
    }
}
