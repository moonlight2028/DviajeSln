using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class ServicioAdicional
    {
        [Key]
        public int IdServicioAdicional { get; set; }


        [Required(ErrorMessage = "El precio del servicio adicional es obligatorio.")]
        [Range(1.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 1.")]
        [Column(TypeName = "numeric(10,2)")]
        public double PrecioServicioAdicional { get; set; }


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
