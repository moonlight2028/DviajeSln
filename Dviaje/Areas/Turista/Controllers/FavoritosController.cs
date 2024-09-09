using Dviaje.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    public class FavoritosController : Controller
    {
        private readonly IFavoritosRepository _favoritoRepository;

        public FavoritosController(IFavoritosRepository favoritoRepository)
        {
            _favoritoRepository = favoritoRepository;
        }

        // GET: Muestra la lista de favoritos del usuario autenticado
        public async Task<IActionResult> Index(int? pagina)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtener el ID del usuario autenticado
            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // Obtiene los favoritos del usuario
            var favoritos = await _favoritoRepository.GetFavoritosByUsuarioAsync(userId);

            if (favoritos == null || !favoritos.Any())
            {
                return View("SinFavoritos");
            }

            // Implementación de paginación
            var paginaActual = pagina ?? 1;
            int favoritosPorPagina = 10;
            int totalFavoritos = favoritos.Count();
            int paginasTotales = (int)Math.Ceiling((double)totalFavoritos / favoritosPorPagina);

            var favoritosPaginados = favoritos
                .Skip((paginaActual - 1) * favoritosPorPagina)
                .Take(favoritosPorPagina)
                .ToList();

            ViewBag.PaginaActual = paginaActual;
            ViewBag.PaginasTotales = paginasTotales;

            return View(favoritosPaginados);
        }

        // POST: Agrega una publicación a favoritos
        [HttpPost]
        [ActionName("Favorito")]
        public async Task<IActionResult> CrearFavorito(int? idPublicacion)
        {
            if (!idPublicacion.HasValue)
            {
                return BadRequest();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtener el ID del usuario autenticado
            if (userId == null)
            {
                return Unauthorized();
            }

            var success = await _favoritoRepository.CrearFavoritoAsync(idPublicacion.Value, userId);

            if (success)
            {
                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        // DELETE: Elimina una publicación de los favoritos
        [HttpDelete]
        [ActionName("Favorito")]
        public async Task<IActionResult> EliminarFavorito(int? idPublicacion)
        {
            if (!idPublicacion.HasValue)
            {
                return BadRequest();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtener el ID del usuario autenticado
            if (userId == null)
            {
                return Unauthorized();
            }

            var success = await _favoritoRepository.EliminarFavoritoAsync(idPublicacion.Value, userId);

            if (success)
            {
                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }
    }
}
