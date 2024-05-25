using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }

        [Required]
        public DateTime FechaInicial { get; set; }

        [Required]
        public DateTime FechaFinal { get; set; }

        [Required]
        public ReservaEstado ReservaEstado { get; set; }

        [Required]
        public int NumeroPersonas { get; set; }

        public int IdUsuario { get; set; }

        public int IdPublicacion { get; set; }


        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("IdPublicacion")]
        public Publicacion Publicacion { get; set; }








    }
}
