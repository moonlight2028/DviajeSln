using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
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
        [Route("Favoritos/{pagina?}")]
        public async Task<IActionResult> Index(int? pagina)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtener el ID del usuario autenticado

            // Obtiene los favoritos del usuario
            // Corregir, paginar directamente en la consulta SQL, ya que esta trayendo todos los datos para paginar después en el controlador.
            // No es bueno traer todos los datos de la DB.
            // Error: MySqlException: Table 'dviaje.publicacionimagenes' doesn't exist
            //var favoritos = await _favoritoRepository.GetFavoritosByUsuarioAsync(userId);

            //if (favoritos == null || !favoritos.Any())
            //{
            //    ViewBag.Favoritos = false;

            //    return View();
            //}

            // Implementación de paginación
            // Corregir, implementar lógica de paginación en la consulta SQL.
            //var paginaActual = pagina ?? 1;
            //int favoritosPorPagina = 10;
            //int totalFavoritos = favoritos.Count();
            //int paginasTotales = (int)Math.Ceiling((double)totalFavoritos / favoritosPorPagina);

            //var favoritosPaginados = favoritos
            //    .Skip((paginaActual - 1) * favoritosPorPagina)
            //    .Take(favoritosPorPagina)
            //    .ToList();


            // Datos requeridos para la paginacion
            //ViewBag.PaginacionPaginas = paginasTotales;
            //ViewBag.PaginacionItems = favoritosPorPagina;
            //ViewBag.PaginacionResultados = totalFavoritos;


            List<PublicacionTarjetaV2VM>? favoritos = null;

            return View(favoritos);
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
