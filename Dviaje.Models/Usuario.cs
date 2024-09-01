﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Dviaje.Models
{
    public class Usuario : IdentityUser
    {
        [StringLength(255)]
        public string? Avatar { get; set; }


        [StringLength(40)]
        public string? RazonSocial { get; set; }


        [StringLength(255)]
        public string? SitioWeb { get; set; }


        [StringLength(50)]
        public string? Direccion { get; set; }


        [Required]
        public bool Verificado { get; set; }


        public int NumeroPublicaciones { get; set; }


        [Required]
        public AliadoEstado AliadoEstado { get; set; }
    }
}
