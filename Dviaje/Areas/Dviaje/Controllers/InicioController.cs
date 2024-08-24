using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class InicioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
