using System.ComponentModel.DataAnnotations;

namespace Dviaje.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required]
        [StringLength(50)]
        public string? NombreCategoria { get; set; }

        [Required]
        public string? RutaIcono { get; set; }
    }
}
