using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class Favorito
    {
        [Key]
        public int IdFavorito { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [Required]
        public int IdPublicacion { get; set; }

        [ForeignKey("IdPublicacion")]
        public Publicacion Publicacion { get; set; }
    }
}
