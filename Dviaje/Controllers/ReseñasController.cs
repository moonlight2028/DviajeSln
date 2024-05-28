using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Controllers
{
    [Area("Dviaje")]
    public class ReseñasController : Controller
    {
        public IActionResult Reseñas()
        {
            return View();
        }
    }
}
