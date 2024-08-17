using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class ReportesController : Controller
    {
        public IActionResult Publicaciones()
        {
            return View();
        }
    }
}
