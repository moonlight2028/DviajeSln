namespace Dviaje.Models.VM
{
    public class PublicacionTarjetaV2VM
    {
        public int IdPublicacion { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public decimal Puntuacion { get; set; }
        public string? Categoria { get; set; }  // almacenar la categoría
    }
}
