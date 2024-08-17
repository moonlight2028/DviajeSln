using System.ComponentModel.DataAnnotations;

namespace Dviaje.Models.VM
{
    public class VerificacionVM
    {
        [Required(ErrorMessage = "El motivo es obligatorio.")]
        public string Motivo { get; set; }

        [Required(ErrorMessage = "La dirección del lugar es obligatoria.")]
        public string Direccion { get; set; }

        // Esto puede ser una lista separada por comas o un array, dependiendo de cómo se maneje el almacenamiento
        public string? DocumentosAdjuntos { get; set; }

        public string? DetallesPropiedad { get; set; }
    }
}
