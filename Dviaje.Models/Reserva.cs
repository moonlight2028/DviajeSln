using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }

        [Required]
        [DisplayName("Fecha inicial")]
        public DateTime FechaInicial { get; set; }

        [Required]
        [DisplayName("Fecha final")]
        public DateTime FechaFinal { get; set; }

        [Required]
        public ReservaEstado ReservaEstado { get; set; }

        [Required]
        [DisplayName("Numero de personas")]
        public int NumeroPersonas { get; set; }

        public string IdUsuario { get; set; }

        public int IdPublicacion { get; set; }


        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("IdPublicacion")]
        public Publicacion Publicacion { get; set; }








    }
}
