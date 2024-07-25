using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    public class FavoritosController : Controller
    {
        public IActionResult Favoritos()
        {
            List<FavoritoVM> list = new List<FavoritoVM>();

            return View(list);
        }
    }
}
