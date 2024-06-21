using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class PublicacionesController : Controller
    {
        public IActionResult Publicaciones()
        {
            return View();
        }

        public IActionResult Publicacion()
        {
            return View();
        }
    }
}
