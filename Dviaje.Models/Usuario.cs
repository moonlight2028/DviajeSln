using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Dviaje.Models
{
    public class Usuario : IdentityUser
    {

        [Required]
        public AliadoEstado AliadoEstado { get; set; }
    }
}
