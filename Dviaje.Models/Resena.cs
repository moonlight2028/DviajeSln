using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class Resena
    {
        [Key]
        public int IdResena { get; set; }


        [Required(ErrorMessage = "La opinión es obligatoria.")]
        [Column(TypeName = "text")]
        [StringLength(1500, MinimumLength = 10, ErrorMessage = "La opinión debe tener entre 10 y 1500 caracteres.")]
        public string? Opinion { get; set; }


        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [Column(TypeName = "timestamp")]
        public DateTime Fecha { get; set; }


        [Required(ErrorMessage = "La calificación es obligatoria.")]
        [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5.")]
        public int Calificacion { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "El número de 'Me Gusta' no puede ser negativo.")]
        public int MeGusta { get; set; }


        [Required(ErrorMessage = "El ID de la publicación es obligatorio.")]
        public int IdPublicacion { get; set; }


        [Required(ErrorMessage = "El ID de la reserva es obligatorio.")]
        public int IdReserva { get; set; }


        [ForeignKey("IdPublicacion")]
        public Publicacion? Publicacion { get; set; }


        [ForeignKey("IdReserva")]
        public Reserva? Reserva { get; set; }
    }
}
