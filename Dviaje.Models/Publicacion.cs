using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class Publicacion
    {
        [Key]
        public int IdPublicacion { get; set; }


        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El título debe tener entre 3 y 50 caracteres.")]
        public string? Titulo { get; set; }


        //[Column(TypeName = "numeric(2,1)")]
        [Range(0.0, 5.0, ErrorMessage = "La puntuación debe estar entre 0.0 y 5.0.")]
        public decimal Puntuacion { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "El número de reseñas no puede ser negativo.")]
        public int NumeroResenas { get; set; }


        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(1500, MinimumLength = 10, ErrorMessage = "La descripción debe tener entre 10 y 1500 caracteres.")]
        [Column(TypeName = "text")]
        public string? Descripcion { get; set; }


        //[Column(TypeName = "numeric(10,2)")]
        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(1.0, 10000000000.00, ErrorMessage = "El precio debe ser mayor a 1.")]
        public decimal Precio { get; set; }


        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [Column(TypeName = "timestamp")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }


        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "La dirección debe tener entre 10 y 50 caracteres.")]
        public string? Direccion { get; set; }


        [Required]
        public string? IdAliado { get; set; }


        [ForeignKey("IdAliado")]
        public Aliado? Aliado { get; set; }
    }
}
