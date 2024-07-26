using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Dviaje.Models
{
    public class Usuario : IdentityUser
    {
        [StringLength(40)]
        public string? RazonSocial { get; set; }

        [StringLength(250)]
        public string? SitioWeb { get; set; }

        [StringLength(15)]
        public string? Telefono { get; set; }

        [StringLength(50)]
        public string? Direccion { get; set; }

        [Required]
        public bool Verificado { get; set; }

        [Required]
        public AliadoEstado AliadoEstado { get; set; }
    }
}
