using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class ReseñasController : Controller
    {
        // Inyección en el controlador.
        public ReseñasController()
        {
        }


        public IActionResult Reseñas(string? idPublicacion, int? pagina)
        {
            // Validacion ruta de pagina


            // Paginación.
            int publicacionesTotales = 10; // Consulta 
            int numeroPublicaciones = 10;
            int paginasTotales = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(publicacionesTotales) / Convert.ToDecimal(numeroPublicaciones)));

            // Validacion ruta de pagina
            if (pagina > paginasTotales) pagina = 1;

            // Lista de resenas
            /*Consulta
             * ordenar las reseñas en la consulta de mejor calificacion a peor calificacion
             * paginar las resenas recibiendo los parametros
             */
            ResenasVistaDviajeVM? resenas = null; // Consulta

            return View(resenas);
        }
    }
}
