using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class Verificado
    {
        [Key]
        public int IdVerificado { get; set; }

        [Required(ErrorMessage = "La fecha de solicitud es obligatoria.")]
        [Column(TypeName = "timestamp")]
        public DateTime FechaSolicitud { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime? FechaRespuesta { get; set; }

        [Required(ErrorMessage = "El estado verificado es obligatorio.")]
        public VerificadoEstado VerificadoEstado { get; set; }

        [Required(ErrorMessage = "El ID del aliado es obligatorio.")]
        public string? IdAliado { get; set; }

        [ForeignKey("IdAliado")]
        public Aliado? Aliado { get; set; }


        /*
         * Evaluar logica verificado
        // Motivo
        [Required(ErrorMessage = "El motivo es obligatorio.")]
        public string Motivo { get; set; }

        [Required(ErrorMessage = "La dirección del lugar es obligatoria.")]
        public string Direccion { get; set; }

        // Adjuntos
        public string? DocumentosAdjuntos { get; set; }

        // Información adicional sobre la propiedad
        public string? DetallesPropiedad { get; set; }
        */
    }


}
