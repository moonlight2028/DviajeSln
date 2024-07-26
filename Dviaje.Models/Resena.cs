using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class Resena
    {
        [Key]
        public int IdResena { get; set; }

        [Required]
        [Column(TypeName = "text")]
        [StringLength(1500)]
        public string? Opinion { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int Calificacion { get; set; }

        public int MeGusta { get; set; }

        public int IdPublicacion { get; set; }

        public int IdReserva { get; set; }

        [ForeignKey("IdPublicacion")]
        public Publicacion? Publicacion { get; set; }

        [ForeignKey("IdReserva")]

        public Reserva? Reserva { get; set; }





    }
}
