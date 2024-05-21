﻿using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Restriccion
    {
        [Key]
        public int IdRestriccion { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreRestriccion { get; set; }

        [Required]
        public string RutaIcono { get; set; }
    }
}
