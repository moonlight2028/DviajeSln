using System.ComponentModel.DataAnnotations;

namespace Dviaje.Models
{
    public class Usuario
    {
        [Key]
        public string IdUsuario { get; set; }

        [Required]
        public AliadoEstado AliadoEstado { get; set; }
    }
}
