using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Dviaje.Models
{
    public class Usuario : IdentityUser
    {
        [StringLength(255, ErrorMessage = "El avatar no puede tener más de 255 caracteres.")]
        [Url(ErrorMessage = "El avatar debe ser una URL válida.")]
        public string? Avatar { get; set; }
    }
}
