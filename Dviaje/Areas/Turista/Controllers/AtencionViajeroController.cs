using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    public class AtencionViajeroController : Controller
    {
        public IActionResult Atencion()
        {
            return View();
        }
    }
}
