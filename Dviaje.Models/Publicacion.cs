using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class Publicacion
    {
        [Key]
        public int IdPublicacion { get; set; }

        [Required]
        [Column(TypeName = "text")]
        [StringLength(50)]
        public string? Titulo { get; set; }

        [Column(TypeName = "decimal(1,1)")]
        public decimal Puntuacion { get; set; }

        public int NumeroResenas { get; set; }

        [Required]
        [Column(TypeName = "text")]
        [StringLength(1500)]
        public string? Descripcion { get; set; }

        [Required]
        public double Precio { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [Column(TypeName = "text")]
        [StringLength(50)]
        public string? Direccion { get; set; }

        public string? IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }
    }
}
