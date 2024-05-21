using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos
{
    public class FechaNoDisponible
    {
        [Key]
        public int IdFechaNoDisponible { get; set; }

        [Required]
        public DateTime FechaSinDisponible { get; set; }

        [Required]
        public int IdPublicacion { get; set }

        [ForeignKey("IdPublicacion")]
        public Publicacion Publicacion { get; set; }
    }
}
