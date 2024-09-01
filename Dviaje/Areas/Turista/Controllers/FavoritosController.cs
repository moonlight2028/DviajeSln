using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    public class FavoritosController : Controller
    {
        // Inyección en el controlador.
        public FavoritosController()
        {
        }


        public IActionResult Favoritos(int? pagina)
        {
            return View();
        }

        [HttpPost]
        [ActionName("Favorito")]
        public IActionResult CrearFavorito(int? idPublicacion)
        {
            return Ok();
        }

        [HttpDelete]
        [ActionName("Favorito")]
        public IActionResult EliminarFavorito(int? idPublicacion)
        {
            return Ok();
        }

    }
}
