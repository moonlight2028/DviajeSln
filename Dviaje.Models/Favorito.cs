using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Model
{
    internal class Favorito
    {
        [Key]
        public int IdFavorito { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuaio")]
        public Usuario Usuario { get; set; }

        [Required]
        public int IdPublicacion { get; set; }

        [ForeignKey("IdPubliacion")]
        public Publicacion Publicacion { get; set; }
    }
}
