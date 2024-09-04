using Dviaje.Models.VM;
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

        public IActionResult Index(int? pagina)
        {
            // Validacion ruta de pagina

            // Obtener el id del usuario

            // Paginación.
            int favoritosTotales = 10; // Consulta 
            int favoritosPorPagina = 10;
            int paginasTotales = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(favoritosTotales) / Convert.ToDecimal(favoritosPorPagina)));

            // Validacion ruta de pagina
            if (pagina > paginasTotales) pagina = 1;

            // Consulta
            List<PublicacionTarjetaV2VM>? listaFavoritos = null;

            return View(listaFavoritos);
        }

        // Endpoints para JS
        [HttpPost]
        [ActionName("Favorito")]
        public IActionResult CrearFavorito(int? idPublicacion)
        {
            /*
             * Obtener el id del usuario
             * Crear consulta para registrar el favorito
             */

            return Ok();
        }

        [HttpDelete]
        [ActionName("Favorito")]
        public IActionResult EliminarFavorito(int? idPublicacion)
        {
            /*
             * Obtener el id del usuario
             * Crear consulta para eliminar el favorito
             */
            return Ok();
        }

    }
}
