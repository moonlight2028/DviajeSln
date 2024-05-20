using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dviaje.Models
{
    public class Aliado
    {
        [Key]
        public int IdAliado { get; set; }


        [Column(TypeName = "text")]
        [StringLength(40)]
        public string RazonSocial { get; set; }

        [Column(TypeName = "text")]
        [StringLength(250)]
        public string SitioWeb { get; set; }

        [Column(TypeName = "text")]
        [StringLength(15)]
        public string Telefono { get; set; }

        [Column(TypeName = "text")]
        [StringLength(50)]
        public string Direccion { get; set; }

        [Required]
        public bool Verificado { get; set; }

        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }




    }
}
