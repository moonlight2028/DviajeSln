﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Model
{
    public class AtencionViajero
    {
        [Key]
        public int IdAtencion { get; set; }

        [Required]
        public DateTime FechaAtencion { get; set; }

        [Column(TypeName = "text")]
        [StringLength(250)]
        public string Descripcion { get; set; }

        [Column(TypeName = "text")]
        [StringLength(250)]
        public string Respuesta { get; set; }

        [Required]
        [Column(TypeName = "text")]
        [StringLength(100)]
        public string Asunto { get; set; }

        public DateTime FechaRespuesta { get; set; }

        [Required]
        public AtencionViajeroTipoPqrs AtencionViajeroTipoPqrs { get; set; }

        [Required]
        public AtencionViajeroPrioridad AtencionViajeroPrioridad { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

    }
}