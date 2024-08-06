using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Aliado.Controllers
{
    [Area("Aliado")]
    public class PublicacionController : Controller
    {
        public IActionResult Crear()
        {
            return View();
        }
    }
}
