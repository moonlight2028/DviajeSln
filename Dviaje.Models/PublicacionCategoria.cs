using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class PublicacionCategoria
    {
        [Key]
        public int IdPublicacionCategoria { get; set; }

        [Required]
        public int IdPublicacion { get; set; }

        [Required]
        public int IdCategoria { get; set; }

        [ForeignKey("IdPublicacion")]
        public Publicacion? Publicacion { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria? Categoria { get; set; }
    }
}
