using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class PublicacionServicio
    {
        [Key]
        public int IdPublicacionServicio { get; set; }

        [Required]
        public int IdPublicacion { get; set; }

        [Required]
        public int IdServicio { get; set; }

        [ForeignKey("IdPublicacion")]
        public Publicacion? Publicacion { get; set; }

        [ForeignKey("IdServicio")]
        public Servicio? Servicio { get; set; }


    }
}
