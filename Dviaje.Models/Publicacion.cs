using System.ComponentModel;
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
        [DisplayName("Título")]
        public string? Titulo { get; set; }


        [Column(TypeName = "numeric(2,1)")]
        [Range(0.0, 5.0, ErrorMessage = "La puntuación debe estar entre 0.0 y 5.0.")]
        public decimal Puntuacion { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "El número de reseñas no puede ser negativo.")]
        public int NumeroResenas { get; set; }


        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(1500, MinimumLength = 10, ErrorMessage = "La descripción debe tener entre 10 y 1500 caracteres.")]
        [Column(TypeName = "text")]
        [DisplayName("Descripción")]
        public string? Descripcion { get; set; }


        [Column(TypeName = "numeric(10,2)")]
        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(1.0, 99999999.99, ErrorMessage = "El precio debe ser mayor a 1.")]
        public decimal Precio { get; set; }


        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [Column(TypeName = "timestamp")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }


        [StringLength(100, MinimumLength = 10, ErrorMessage = "La dirección debe tener entre 10 y 50 caracteres.")]
        public string? Direccion { get; set; }


        public string? IdAliado { get; set; }


        [ForeignKey("IdAliado")]
        public Aliado? Aliado { get; set; }


        // Propiedades de navegación
        public ICollection<PublicacionCategoria> PublicacionCategorias { get; set; } = new List<PublicacionCategoria>();
        public ICollection<PublicacionImagen> PublicacionImagenes { get; set; } = new List<PublicacionImagen>();
        public ICollection<PublicacionServicio> PublicacionServicios { get; set; } = new List<PublicacionServicio>();
        public ICollection<PublicacionRestriccion> PublicacionRestricciones { get; set; } = new List<PublicacionRestriccion>();
        public ICollection<ServicioAdicional> ServicioAdicionales { get; set; } = new List<ServicioAdicional>();
    }
}
