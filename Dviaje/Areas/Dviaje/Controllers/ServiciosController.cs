using Dviaje.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class ServiciosController : Controller
    {
        // Endpoints para JS
        [HttpGet]
        public IActionResult Servicios()
        {
            // Consulta
            List<Servicio>? listaServicios = null;

            return Ok();
        }
    }
}
