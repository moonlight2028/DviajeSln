namespace Dviaje.Models.VM
{
    public class PublicacionTarjetaImagenVM
    {
        public int IdPublicacion { get; set; }
        public string? Titulo { get; set; }
        public string? Imagen { get; set; }
        public string? Direccion { get; set; }
        public decimal Puntuacion { get; set; }
        public string? IdAliado { get; set; }
        public string? AvatarAliado { get; set; }
        public string? NombreAliado { get; set; }
    }
}
