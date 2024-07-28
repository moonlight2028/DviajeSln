using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class Adjunto
    {
        [Key]
        public int IdAdjunto { get; set; }


        [Required(ErrorMessage = "La ruta del adjunto es obligatoria.")]
        [StringLength(255, ErrorMessage = "La ruta del adjunto no puede tener más de 255 caracteres.")]
        public string? RutaAdjunto { get; set; }


        [Required(ErrorMessage = "El ID de atención es obligatorio.")]
        public int IdAtencion { get; set; }


        [ForeignKey("IdAtencion")]
        public AtencionViajero? AtencionViajero { get; set; }
    }
}
