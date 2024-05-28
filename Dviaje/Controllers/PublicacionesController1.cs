using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Controllers
{
    public class PublicacionesController1 : Controller
    {
        public IActionResult Publicaciones()
        {
            return View();
        }
    }
}
