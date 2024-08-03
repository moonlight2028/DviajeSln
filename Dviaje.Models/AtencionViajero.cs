using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class AtencionViajero
    {
        [Key]
        public int IdAtencion { get; set; }


        [Required(ErrorMessage = "La fecha de atención es obligatoria.")]
        [Column(TypeName = "timestamp")]
        public DateTime FechaAtencion { get; set; }


        [Column(TypeName = "text")]
        [StringLength(250, ErrorMessage = "La descripción no puede tener más de 250 caracteres.")]
        public string? Descripcion { get; set; }


        [Column(TypeName = "text")]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "La respuesta debe tener entre 10 y 250 caracteres.")]
        public string? Respuesta { get; set; }


        [Required(ErrorMessage = "El asunto es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El asunto debe tener entre 3 y 100 caracteres.")]
        public string? Asunto { get; set; }


        [Column(TypeName = "timestamp")]
        public DateTime FechaRespuesta { get; set; }

        [Required(ErrorMessage = "Ingrese el puto nombre")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El asunto debe tener entre 3 y 50 caracteres.")]
        public string? Nombre { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "El asunto debe tener entre 3 y 50 caracteres.")]
        public string? Apellidos { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "El asunto debe tener entre 3 y 50 caracteres.")]
        public string? Correo { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "El asunto debe tener entre 3 y 50 caracteres.")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El tipo de PQRS es obligatorio.")]
        public AtencionViajeroTipoPqrs AtencionViajeroTipoPqrs { get; set; }


        [Required(ErrorMessage = "La prioridad es obligatoria.")]
        public AtencionViajeroPrioridad AtencionViajeroPrioridad { get; set; }


        [Required(ErrorMessage = "El ID de usuario es obligatorio.")]
        public string? IdUsuario { get; set; }


        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

    }
}