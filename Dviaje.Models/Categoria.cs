using System.ComponentModel.DataAnnotations;

namespace Dviaje.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }


        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "El nombre de la categoría debe tener entre 5 y 50 caracteres.")]
        public string? NombreCategoria { get; set; }


        [Required(ErrorMessage = "La ruta del ícono es obligatoria.")]
        [StringLength(255, ErrorMessage = "La ruta del ícono debe tener hasta 255 caracteres.")]
        public string? RutaIcono { get; set; }


        // Propiedades de navegación
        public ICollection<PublicacionCategoria> PublicacionesCategorias { get; set; } = new List<PublicacionCategoria>();
    }
}
