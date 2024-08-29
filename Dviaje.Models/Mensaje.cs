using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class Mensaje
    {
        [Key]
        public int IdMensaje { get; set; }


        [Required]
        public DateTime Fecha { get; set; }


        [Column(TypeName = "text")]
        [StringLength(250, ErrorMessage = "El mensaje no puede tener más de 250 caracteres.")]
        public string? MensajeDescripcion { get; set; }


        [StringLength(50, MinimumLength = 3, ErrorMessage = "El asunto debe tener entre 3 y 50 caracteres.")]
        public string? Nombre { get; set; }


        [StringLength(50, MinimumLength = 3, ErrorMessage = "El asunto debe tener entre 3 y 50 caracteres.")]
        public string? Apellidos { get; set; }


        [StringLength(50, MinimumLength = 3, ErrorMessage = "El asunto debe tener entre 3 y 50 caracteres.")]
        public string? Correo { get; set; }


        [StringLength(50, MinimumLength = 3, ErrorMessage = "El asunto debe tener entre 3 y 50 caracteres.")]
        public string? Telefono { get; set; }


        public string? IdUsuario { get; set; }


        public int IdAtencionViajero { get; set; }


        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }


        [ForeignKey("IdAtencionViajero")]
        public AtencionViajero? AtencionViajero { get; set; }


        // Propiedades de navegación
        // Relación uno a muchos con Adjuntos
        public ICollection<Adjunto> Adjuntos { get; set; } = new List<Adjunto>();
    }
}
