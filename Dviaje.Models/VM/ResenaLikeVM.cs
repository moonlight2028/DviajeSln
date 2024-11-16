namespace Dviaje.Models.VM
{
    public class ResenaLikeVM
    {
        public int IdResena { get; set; }      // ID de la reseña
        public int Likes { get; set; }         // Número de likes de la reseña
        public bool YaLeDioLike { get; set; }  // Estado de "Me Gusta" del usuario actual
    }

}
