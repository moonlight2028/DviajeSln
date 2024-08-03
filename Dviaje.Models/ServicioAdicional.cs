using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class ServicioAdicional
    {
        [Key]
        public int IdServicioAdicional { get; set; }


        [Column(TypeName = "numeric(10,2)")]
        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(1.0, 99999999.99, ErrorMessage = "El precio debe ser mayor a 1.")]
        public decimal PrecioServicioAdicional { get; set; }


        [Required(ErrorMessage = "El ID del servicio es obligatorio.")]
        public int IdServicio { get; set; }


        [Required(ErrorMessage = "El ID de la publicación es obligatorio.")]
        public int IdPublicacion { get; set; }


        [ForeignKey("IdServicio")]
        public Servicio? Servicio { get; set; }


        [ForeignKey("IdPublicacion")]
        public Publicacion? Publicacion { get; set; }
    }
}
