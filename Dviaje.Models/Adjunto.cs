using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    internal class Adjunto
    {
        [Key]
        public int IdAdjunto { get; set; }

        [Required]
        public string RutaAdjunto { get; set; }

        [Required]
        public int IdAtencion { get; set; }

        [ForeignKey("IdAtencion")]

        public AtencionViajero AtencionViajero { get; set; }
    }
}
