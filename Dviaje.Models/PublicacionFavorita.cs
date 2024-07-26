﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class PublicacionFavorita
    {
        [Key]
        public int IdPublicacionFavorita { get; set; }

        [Required]
        public int IdPublicacion { get; set; }

        [ForeignKey("IdPublicacion")]
        public Publicacion? Publicacion { get; set; }
    }



}
