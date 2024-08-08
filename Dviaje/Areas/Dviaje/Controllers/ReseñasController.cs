using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class ReseñasController : Controller
    {
        [HttpGet("Dviaje/Reseñas/Reseñas")]
        public IActionResult Reseñas()
        {
            return View();
        }


        [HttpGet("Dviaje/Reseñas/Reseñas/{idPublicacion?}")]
        public IActionResult Reseñas(int? idPublicacion)
        {
            return View();
        }
    }
}
