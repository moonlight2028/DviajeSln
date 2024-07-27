using System.ComponentModel.DataAnnotations;

namespace Dviaje.Models.VM
{
    public class PqrsVM
    {
        [MinLength(2, ErrorMessage = "Ajiugjkhkj")]
        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public string? Correo { get; set; }

        public string? Telefono { get; set; }

        public string? Descripcion { get; set; }
    }
}
