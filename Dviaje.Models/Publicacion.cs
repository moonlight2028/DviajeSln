﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class Publicacion
    {
        [Key]
        public int IdPublicacion { get; set; }

        [Required]
        [Column(TypeName = "text")]
        [StringLength(50)]
        public string Titulo { get; set; }


        public int Puntuacion { get; set; }

        public int NumeroRsenas { get; set; }

        public int CapacidadCamas { get; set; }

        [Required]
        [Column(TypeName = "text")]
        [StringLength(1500)]
        public string Descripcion { get; set; }

        [Required]

        public double Precio { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [Column(TypeName = "text")]
        [StringLength(50)]
        public string Direccion { get; set; }

        public int IdAliado { get; set; }

        [ForeignKey("IdAliado")]
        public Aliado Aliado { get; set; }


    }
}