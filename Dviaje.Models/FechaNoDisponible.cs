using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class FechaNoDisponible
    {
        [Key]
        public int IdFechaNoDisponible { get; set; }


        [Required(ErrorMessage = "La fecha inicial es obligatoria.")]
        [Column(TypeName = "timestamp")]
        public DateTime FechaInicial { get; set; }


        [Required(ErrorMessage = "La fecha final es obligatoria.")]
        [Column(TypeName = "timestamp")]
        public DateTime FechaFinal { get; set; }


        [Required(ErrorMessage = "El ID de la publicación es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de la publicación debe ser mayor que 0.")]
        public int IdPublicacion { get; set; }


        [ForeignKey("IdPublicacion")]
        public Publicacion? Publicacion { get; set; }
    }
}
