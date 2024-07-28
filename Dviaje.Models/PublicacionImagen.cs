using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class PublicacionImagen
    {
        [Key]
        public int IdPublicacionImagen { get; set; }


        [Required(ErrorMessage = "La ruta de la imagen es obligatoria.")]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "La ruta de la imagen debe tener entre 10 y 255 caracteres.")]
        public string? Ruta { get; set; }


        [Required(ErrorMessage = "El ID de la publicación es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de la publicación debe ser mayor que 0.")]
        public int IdPublicacion { get; set; }


        [ForeignKey("IdPublicacion")]
        public Publicacion? Publicacion { get; set; }
    }
}
