using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    /// <summary>
    /// Modelo que representa a un usuario en el sistema, diseñado para los roles de turista y administrador.
    /// Extiende de IdentityUser para aprovechar las características base de ASP.NET Identity.
    /// Incluye campos adicionales específicos.
    /// </summary>
    public class Usuario : IdentityUser
    {
        [StringLength(40)]
        public string? RazonSocial { get; set; }

        [StringLength(255)]
        public string? SitioWeb { get; set; }

        [StringLength(50)]
        public string? Direccion { get; set; }

        [Required]
        public bool Verificado { get; set; }

        public int NumeroPublicaciones { get; set; }

        public int NumeroReservas { get; set; }

        public int NumeroResenas { get; set; }

        [Required]
        public AliadoEstado AliadoEstado { get; set; }

        [Column(TypeName = "decimal(2,1)")]
        public decimal Puntuacion { get; set; }

        [StringLength(255)]
        public string? Banner { get; set; }

        [StringLength(255)]
        public string? IdBanner { get; set; }

        [StringLength(255)]
        public string? Avatar { get; set; }

        [StringLength(255)]
        public string? IdAvatar { get; set; }
    }
}
