using System.ComponentModel.DataAnnotations;

namespace Dviaje.Models
{
    public class Servicio
    {
        [Key]
        public int IdServicio { get; set; }

        [Required]
        [StringLength(50)]
        public string? NombreServicio { get; set; }

        public ServicioTipo ServicioTipo { get; set; }

        [Required]
        public string? RutaIcono { get; set; }
    }
}
