using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class PublicacionRestriccion
    {
        [Key]
        public int IdPublicacionRestriccion { get; set; }


        [Required]
        public int IdPublicacion { get; set; }


        [Required]
        public int IdRestriccion { get; set; }


        [ForeignKey("IdPublicacion")]
        public Publicacion? Publicacion { get; set; }


        [ForeignKey("IdRestriccion")]
        public Restriccion? Restriccion { get; set; }
    }
}
