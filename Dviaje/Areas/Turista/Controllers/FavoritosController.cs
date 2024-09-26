using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    [Authorize(Roles = RolesUtility.RoleTurista)]
    public class FavoritosController : Controller
    {
        private readonly IFavoritosRepository _favoritoRepository;


        public FavoritosController(IFavoritosRepository favoritoRepository)
        {
            _favoritoRepository = favoritoRepository;
        }


        // GET: Muestra la lista de favoritos del usuario autenticado
        [Route("favoritos/{pagina?}")]
        public async Task<IActionResult> Index(int? pagina)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtener el ID del usuario autenticado

            var favoritos = await _favoritoRepository.ObtenerListaFavoritoTarjetaVMAsync(userId);

            //if (favoritos == null || !favoritos.Any())
            //{
            //    ViewBag.favoritos = false;
            //    return View();
            //}


            var paginaActual = pagina ?? 1;
            int favoritosPorPagina = 10;
            //int totalFavoritos = await _favoritoRepository.FavoritosGuardadosTotal(userId);
            int totalFavoritos = 10;
            int paginasTotales = (int)Math.Ceiling((double)totalFavoritos / favoritosPorPagina);


            // Datos requeridos para la paginación
            ViewBag.PaginacionPaginas = paginasTotales;
            ViewBag.PaginacionItems = favoritosPorPagina;
            ViewBag.PaginacionResultados = totalFavoritos;


            return View(favoritos);
        }


        [HttpPost]
        [Route("favorito/{id?}")]
        public async Task<IActionResult> CrearFavorito(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtener el ID del usuario autenticado
            if (userId == null)
            {
                return Unauthorized();
            }

            var success = await _favoritoRepository.CrearFavoritoAsync(id.Value, userId);

            if (success)
            {
                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpDelete]
        [Route("favorito/{id?}")]
        public async Task<IActionResult> EliminarFavorito(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtener el ID del usuario autenticado
            if (userId == null)
            {
                return Unauthorized();
            }

            var success = await _favoritoRepository.EliminarFavoritoAsync(id.Value, userId);

            if (success)
            {
                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }
    }
}
