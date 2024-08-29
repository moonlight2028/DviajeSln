using System.ComponentModel.DataAnnotations;

namespace Dviaje.Models
{
    public class AtencionViajero
    {
        [Key]
        public int IdAtencion { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaAtencion { get; set; }


        [Required(ErrorMessage = "El asunto es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El asunto debe tener entre 3 y 100 caracteres.")]
        public string? Asunto { get; set; }


        [Required]
        public AtencionViajeroTipoPqrs AtencionViajeroTipoPqrs { get; set; }


        [Required]
        public AtencionViajeroEstado AtencionViajeroEstado { get; set; }


        // Propiedades de navegación
        // Relación uno a muchos con Mensaje
        public ICollection<Mensaje> Mensajes { get; set; } = new List<Mensaje>();
    }
}