using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class ResenaMeGusta
    {
        [Key]
        public int IdResenaMeGusta { get; set; }

        [Required]
        public int IdResena { get; set; }

        [Required]
        public string? IdUsuario { get; set; }

        [ForeignKey("IdResena")]
        public Resena? Resena { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }
    }
}
