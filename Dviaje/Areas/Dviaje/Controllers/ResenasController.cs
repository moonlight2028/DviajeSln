using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class ResenasController : Controller
    {
        private readonly IResenasRepository _resenaRepository;
        private readonly IPublicacionesRepository _publicacionesRepository;
        private readonly ILogger<ResenasController> _logger;

        // Inyección de dependencias
        public ResenasController(
            IResenasRepository resenaRepository,
            IPublicacionesRepository publicacionesRepository,
            ILogger<ResenasController> logger)
        {
            _resenaRepository = resenaRepository;
            _publicacionesRepository = publicacionesRepository;
            _logger = logger;
        }

        /// <summary>
        /// Muestra las reseñas públicas de una publicación específica.
        /// </summary>
        [Route("reseñas/{id?}")]
        public async Task<IActionResult> Resenas(int? id)
        {
            if (!id.HasValue)
            {
                TempData["Error"] = "No se proporcionó un ID de publicación.";
                return RedirectToAction("Index", "Inicio");
            }

            try
            {
                var publicacion = await _publicacionesRepository.ObtenerPublicacionResenasVMAsync(id.Value);

                if (publicacion == null)
                {
                    TempData["Error"] = "Publicación no encontrada.";
                    return RedirectToAction("Index", "Inicio");
                }

                return View(publicacion);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener reseñas para la publicación {idPublicacion}.", id);
                TempData["Error"] = "Ocurrió un error al cargar las reseñas.";
                return RedirectToAction("Index", "Inicio");
            }
        }

        /// <summary>
        /// Obtiene la lista de reseñas para una publicación específica, con paginación.
        /// </summary>
        [HttpGet]
        [Route("reseñas/lista")]
        public async Task<IActionResult> ResenasPorPublicacion(int? id, int pagina = 1, int resultadosMostrados = 10)
        {
            if (!id.HasValue)
            {
                return BadRequest(new { success = false, message = "No se proporcionó un ID de publicación." });
            }

            try
            {
                var resenas = await _resenaRepository.ObtenerListaResenaTarjetaBasicaVMAsync(id.Value, pagina, resultadosMostrados);

                if (resenas == null || !resenas.Any())
                {
                    return NoContent(); // Devuelve 204 si no hay contenido
                }

                return Ok(new { success = true, data = resenas });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener reseñas paginadas para la publicación {idPublicacion}.", id);
                return StatusCode(500, new { success = false, message = "Ocurrió un error al procesar la solicitud." });
            }
        }

        /// <summary>
        /// Gestiona el "me gusta" de una reseña, añadiendo o eliminando el like según corresponda.
        /// </summary>
        [HttpPost]
        [Route("reseñas/me-gusta")]
        public async Task<IActionResult> MeGusta(int idResena)
        {
            var idUsuario = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (idUsuario == null)
            {
                return Unauthorized(new { success = false, message = "Usuario no autenticado." });
            }

            try
            {
                // Verificar si el usuario ya dio "Me gusta"
                var yaLeDioLike = await _resenaRepository.VerificarSiUsuarioLeDioLike(idResena, idUsuario);

                if (yaLeDioLike)
                {
                    // Elimina el "Me gusta"
                    await _resenaRepository.EliminarMeGustaAsync(idResena, idUsuario);
                }
                else
                {
                    // Agrega el "Me gusta"
                    await _resenaRepository.AgregarMeGustaAsync(idResena, idUsuario);
                }

                // Obtener el nuevo conteo de likes
                var nuevoConteoLikes = await _resenaRepository.ObtenerMeGustaCountAsync(idResena);

                // Crear objeto de respuesta
                var response = new ResenaLikeVM
                {
                    IdResena = idResena,
                    Likes = nuevoConteoLikes,
                    YaLeDioLike = !yaLeDioLike // Estado actualizado
                };

                return Json(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al gestionar el 'me gusta' de la reseña {idResena}.", idResena);
                return StatusCode(500, new { success = false, message = "Ocurrió un error al procesar la solicitud." });
            }
        }
    }
}
