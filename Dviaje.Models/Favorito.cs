using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class Favorito
    {
        [Key]
        public int IdFavorito { get; set; }


        [Required(ErrorMessage = "El ID del usuario es obligatorio.")]
        public string? IdUsuario { get; set; }


        [Required(ErrorMessage = "El ID de la publicación es obligatorio.")]
        public int IdPublicacion { get; set; }


        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }


        [ForeignKey("IdPublicacion")]
        public Publicacion? Publicacion { get; set; }
    }
}
