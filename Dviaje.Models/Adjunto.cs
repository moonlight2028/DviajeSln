using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class Adjunto
    {
        [Key]
        public int IdAdjunto { get; set; }


        [Required]
        [StringLength(255)]
        public string? RutaAdjunto { get; set; }


        [Required]
        public int IdMensaje { get; set; }


        [ForeignKey("IdMensaje")]
        public Mensaje? Mensaje { get; set; }

    }
}
