using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class PublicacionImagen
    {
        [Key]
        public int IdPublicacionImagen { get; set; }

        public string? Ruta { get; set; }

        [Required]
        public int IdPublicacion { get; set; }

        [ForeignKey("IdPublicacion")]

        public Publicacion? Publicacion { get; set; }
    }
}
