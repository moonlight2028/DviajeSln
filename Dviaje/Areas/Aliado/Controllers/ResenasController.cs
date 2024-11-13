using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dviaje.Areas.Aliado.Controllers
{
    [Area("Aliado")]
    [Authorize(Roles = RolesUtility.RoleAliado)]
    public class ResenasController : Controller
    {
        private readonly IResenasRepository _resenasRepository;

        public ResenasController(IResenasRepository resenasRepository)
        {
            _resenasRepository = resenasRepository;
        }

        /// <summary>
        /// Acción para mostrar las reseñas recibidas en las publicaciones del aliado.
        /// </summary>
        /// <param name="pagina">Número de página para la paginación.</param>
        /// <param name="ordenar">Criterio de ordenamiento (ej., por fecha, calificación, likes).</param>
        /// <returns>Vista con la lista de reseñas recibidas.</returns>
        [Route("reseñas/recibidas")]
        public async Task<IActionResult> ResenasRecibidas(int? pagina, string? ordenar)
        {
            // Obtiene el ID del aliado autenticado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            // Configuración de paginación
            var paginaActual = pagina ?? 1;
            int reseñasPorPagina = 10;

            // Obtiene la lista de reseñas recibidas con el criterio de ordenamiento y paginación
            var resenas = await _resenasRepository.ObtenerListaResenaTarjetaRecibidaVMAsync(userId, paginaActual, reseñasPorPagina, ordenar);

            if (resenas == null || !resenas.Any())
            {
                TempData["Info"] = "No tienes reseñas recibidas.";
                return View();
            }

            // Configuración de la vista para la paginación
            ViewBag.PaginaActual = paginaActual;
            ViewBag.Ordenar = ordenar;
            ViewBag.TotalResenas = resenas.Count;

            return View(resenas);
        }
    }
}
