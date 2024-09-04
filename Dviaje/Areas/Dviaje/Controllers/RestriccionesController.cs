using Dviaje.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class RestriccionesController : Controller
    {
        // Endpoints para JS
        [HttpGet]
        public IActionResult Restricciones()
        {
            // Consulta
            List<Restriccion>? restriccionesLista = null;

            return Ok();
        }
    }
}
