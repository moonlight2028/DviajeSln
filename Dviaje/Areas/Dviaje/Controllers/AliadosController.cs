using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class AliadosController : Controller
    {
        public IActionResult Aliados()
        {
            return View();
        }


        public IActionResult Aliado(string? id)
        {
            return View();
        }

        public IActionResult Publicaciones(string? id)
        {
            return View();
        }
    }
}
