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

        [ForeignKey("IdServicio")]
        public Servicio Servicio { get; set; }
    }
}
