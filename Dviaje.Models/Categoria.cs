using System.ComponentModel.DataAnnotations;

namespace Dviaje.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El campo NombreCategoria es obligatorio.")]
        public string NombreCategoria { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es obligatorio.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo RutaIcono es obligatorio.")]
        public string RutaIcono { get; set; }

        [Required(ErrorMessage = "El campo UrlImagen es obligatorio.")]
        public string UrlImagen { get; set; }

        [Required(ErrorMessage = "El campo IdImagen es obligatorio.")]
        public string IdImagen { get; set; }
    }
}

