using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class ServicioAdicional
    {
        [Key]
        public int IdServicioAdicional { get; set; }

        public double PrecioServicioAdicional { get; set; }

        [Required]
        public int IdServicio { get; set; }

        [Required]
        public int IdPublicacion { get; set; }

        [ForeignKey("IdServicio")]
        public Servicio Servicio { get; set; }

        [ForeignKey("IdPublicacion")]
        public Publicacion Publicacion { get; set; }
    }
}
