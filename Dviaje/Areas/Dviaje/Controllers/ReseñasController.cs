using Dviaje.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class ReseñasController : Controller
    {
        private readonly IResenasRepository _resenaRepository;

        // Inyección de dependencias
        public ReseñasController(IResenasRepository resenaRepository)
        {
            _resenaRepository = resenaRepository;
        }

        // Muestra las reseñas públicas de una publicación específica
        public async Task<IActionResult> Reseñas(int? idPublicacion)
        {
            if (!idPublicacion.HasValue)
            {
                return RedirectToAction("Index", "Publicaciones");
            }

            // Obtener reseñas para la publicación
            var resenas = await _resenaRepository.ObtenerResenasPorPublicacionAsync(idPublicacion.Value, 1);

            if (resenas == null || !resenas.Any())
            {
                return View("SinResenas");
            }

            return View(resenas);
        }

        // Obtener lista de reseñas paginadas por publicación
        [HttpGet]
        public async Task<IActionResult> ListaReseñas(int? idPublicacion, int? pagina = 1)
        {
            if (!idPublicacion.HasValue || pagina == null)
            {
                return BadRequest();
            }

            var resenas = await _resenaRepository.ObtenerResenasPorPublicacionAsync(idPublicacion.Value, pagina.Value);

            if (resenas == null || !resenas.Any())
            {
                return NoContent();
            }

            return Ok(resenas);
        }

        // Obtener lista de reseñas paginadas por usuario
        [HttpGet]
        public async Task<IActionResult> ListaReseñas(string? idUsuario, int? pagina = 1)
        {
            if (string.IsNullOrEmpty(idUsuario) || pagina == null)
            {
                return BadRequest();
            }

            var resenas = await _resenaRepository.ObtenerMisResenasAsync(idUsuario, pagina.Value);

            if (resenas == null || !resenas.Any())
            {
                return NoContent();
            }

            return Ok(resenas);
        }

        // Obtener las mejores 3 reseñas de una publicación
        [HttpGet]
        public async Task<IActionResult> TopReseñas(int? idPublicacion)
        {
            if (!idPublicacion.HasValue)
            {
                return BadRequest();
            }

            var topResenas = await _resenaRepository.ObtenerTopResenasPorPublicacionAsync(idPublicacion.Value);

            if (topResenas == null || !topResenas.Any())
            {
                return NoContent();
            }

            return Ok(topResenas);
        }
    }
}