using System.ComponentModel.DataAnnotations;

namespace Dviaje.Models
{
    public class Restriccion
    {
        [Key]
        public int IdRestriccion { get; set; }


        [Required(ErrorMessage = "El nombre de la restricción es obligatorio.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "El nombre de la restricción debe tener entre 5 y 50 caracteres.")]
        public string? NombreRestriccion { get; set; }


        [Required(ErrorMessage = "La ruta del ícono es obligatoria.")]
        [StringLength(255, ErrorMessage = "La ruta del ícono debe tener hasta 255 caracteres.")]
        public string? RutaIcono { get; set; }
    }
}
