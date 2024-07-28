using System.ComponentModel.DataAnnotations;

namespace Dviaje.Models
{
    public class Servicio
    {
        [Key]
        public int IdServicio { get; set; }


        [Required(ErrorMessage = "El nombre del servicio es obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre del servicio debe tener entre 3 y 50 caracteres.")]
        public string? NombreServicio { get; set; }


        [Required(ErrorMessage = "El tipo de servicio es obligatorio.")]
        public ServicioTipo ServicioTipo { get; set; }


        [Required(ErrorMessage = "La ruta del ícono es obligatoria.")]
        [StringLength(255, ErrorMessage = "La ruta del ícono debe tener hasta 255 caracteres.")]
        public string? RutaIcono { get; set; }
    }
}
