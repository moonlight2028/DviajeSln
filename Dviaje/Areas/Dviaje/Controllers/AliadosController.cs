using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class AliadosController : Controller
    {
        // Inyección en el controlador.
        public AliadosController()
        {
        }


        // Muestra el perfil del aliado con las publicaciones realizadas.
        public IActionResult Aliado(string? idAliado)
        {
            return View();
        }
    }
}
