using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class Verificado
    {
        [Key]
        public int IdVerificado { get; set; }

        [Required]
        public DateTime FechaSolicitud { get; set; }

        public DateTime FechaRespuesta { get; set; }

        [Required]
        public VerificadoEstado VerificadoEstado { get; set; }

        [Required]
        public string IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
    }
}
