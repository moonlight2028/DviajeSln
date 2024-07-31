using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Dviaje.Models
{
    public class Aliado : IdentityUser
    {
        [StringLength(40, MinimumLength = 2, ErrorMessage = "La razón social debe tener entre 5 y 100 caracteres")]
        public string? RazonSocial { get; set; }


        [StringLength(250, ErrorMessage = "El sitio web no puede tener más de 250 caracteres.")]
        [Url(ErrorMessage = "El sitio web debe ser una URL válida.")]
        public string? SitioWeb { get; set; }


        [StringLength(50, ErrorMessage = "La dirección no puede tener más de 50 caracteres.")]
        public string? Direccion { get; set; }


        [Required(ErrorMessage = "El campo Verificado es obligatorio.")]
        public bool Verificado { get; set; }


        [Required]
        public AliadoEstado AliadoEstado { get; set; }
    }
}
