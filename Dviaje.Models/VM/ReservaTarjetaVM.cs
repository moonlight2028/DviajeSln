using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dviaje.Models.VM
{
    public class ReservaTarjetaVM
    {

        public int IdReserva {  get; set; }

        public string? TituloPublicacion { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFinal {  get; set; }

        public string? Imagen {  get; set; } 



    }
}
