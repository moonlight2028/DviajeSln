using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class ResenasController : Controller
    {
        private readonly IResenasRepository _resenaRepository;

        // Inyección de dependencias
        public ResenasController(IResenasRepository resenaRepository)
        {
            _resenaRepository = resenaRepository;
        }

        // Muestra las reseñas públicas de una publicación específica
        [Route("Reseñas/{id?}")]
        public async Task<IActionResult> Resenas(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Publicaciones", "Publicaciones");
            }

            // Corregir consulta retornar solo la informacion del modelo ResenasPublicacionVM
            // var resenas = await _resenaRepository.ObtenerResenasPorPublicacionAsync(id.Value, 1);

            //if (resenas == null || !resenas.Any())
            //{
            //    return View("SinResenas");
            //}


            // Datos de test borrar cuando esté lista la consulta
            ResenasPublicacionVM informacionResenaPublicacion = new ResenasPublicacionVM
            {
                IdPublicacion = 1,
                TituloPublicacion = "Aventura en la Montaña",
                PuntuacionPunblicacion = 4.2m,
                DescripcionPublicacion = "La comunicación efectiva es fundamental en todos los aspectos de la vida. Permite expresar ideas, compartir conocimientos y construir relaciones sólidas. En el ámbito profesional, la comunicación clara y precisa es clave para alcanzar objetivos, resolver conflictos y fomentar la colaboración. Además, una buena comunicación ayuda a motivar a los equipos, a mejorar la productividad y a garantizar el éxito en proyectos. Dominar esta habilidad es esencial para el desarrollo personal y profesional en un entorno cada vez más interconectado.",
                DireccionPublicacion = "Calle Falsa 123, Ciudad, País",
                ImagenPublicacion = "https://images.unsplash.com/photo-1724093121148-ec407f45e44c?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
            };

            return View(informacionResenaPublicacion);
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