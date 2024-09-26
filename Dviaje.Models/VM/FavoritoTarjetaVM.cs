namespace Dviaje.Models.VM
{
    public class FavoritoTarjetaVM
    {
        public int IdFavorito { get; set; }
        public int IdPublicacion { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public decimal Puntuacion { get; set; }
        public int NumeroReseñas { get; set; }
        public string? Imagen { get; set; }
    }
}
