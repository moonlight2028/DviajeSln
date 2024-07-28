using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }


        [Required(ErrorMessage = "La fecha inicial es obligatoria.")]
        [Column(TypeName = "timestamp")]
        [DisplayName("Fecha Inicial")]
        public DateTime FechaInicial { get; set; }


        [Required(ErrorMessage = "La fecha final es obligatoria.")]
        [Column(TypeName = "timestamp")]
        [DisplayName("Fecha Final")]
        public DateTime FechaFinal { get; set; }


        [Required(ErrorMessage = "El estado de la reserva es obligatorio.")]
        public ReservaEstado ReservaEstado { get; set; }


        [Required(ErrorMessage = "El número de personas es obligatorio.")]
        [Range(1, 999, ErrorMessage = "El número de personas debe estar entre 1 y 999.")]
        [DisplayName("Número de personas")]
        public int NumeroPersonas { get; set; }


        [Required(ErrorMessage = "El ID del usuario es obligatorio.")]
        public string? IdUsuario { get; set; }


        [Required(ErrorMessage = "El ID de la publicación es obligatorio.")]
        public int IdPublicacion { get; set; }


        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }


        [ForeignKey("IdPublicacion")]
        public Publicacion? Publicacion { get; set; }
    }
}
