using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class ReseñasController : Controller
    {
        // Inyección en el controlador.
        public ReseñasController()
        {
        }


        public IActionResult Reseñas(int? idPublicacion, int? paginaActual)
        {
            return View();
        }
    }
}
