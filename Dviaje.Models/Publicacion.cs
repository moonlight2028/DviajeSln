using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class Publicacion
    {
        [Key]
        public int IdPublicacion { get; set; }


        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El título debe tener entre 3 y 50 caracteres.")]
        public string? Titulo { get; set; }


        [Range(0.0, 5.0, ErrorMessage = "La puntuación debe estar entre 0.0 y 5.0.")]
        [Column(TypeName = "numeric(1,1)")]
        public decimal Puntuacion { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "El número de reseñas no puede ser negativo.")]
        public int NumeroResenas { get; set; }


        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(1500, MinimumLength = 10, ErrorMessage = "La descripción debe tener entre 10 y 1500 caracteres.")]
        [Column(TypeName = "text")]
        public string? Descripcion { get; set; }


        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(1.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 1.")]
        [Column(TypeName = "numeric(10,2)")]
        public double Precio { get; set; }


        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [Column(TypeName = "timestamp")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }


        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "La dirección debe tener entre 10 y 50 caracteres.")]
        public string? Direccion { get; set; }


        [Required]
        public string? IdUsuario { get; set; }


        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }
    }
}
