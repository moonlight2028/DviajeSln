using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class AliadosController : Controller
    {
        public IActionResult Aliado(string? idAliado)
        {
            return View();
        }
    }
}
