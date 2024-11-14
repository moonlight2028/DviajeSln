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


        // Inyección de dependencias
        public ResenasController(IResenasRepository resenaRepository, IPublicacionesRepository publicacionesRepository)
        {
            _resenaRepository = resenaRepository;
            _publicacionesRepository = publicacionesRepository;
        }


        // Muestra las reseñas públicas de una publicación específica
        [Route("reseñas/{id?}")]
        public async Task<IActionResult> Resenas(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Publicaciones", "Publicaciones");
            }

            // Corregir consulta retornar solo la informacion del modelo ResenasPublicacionVM
            var publicacion = await _publicacionesRepository.ObtenerPublicacionResenasVMAsync((int)id);

            if (publicacion == null)
            {
                return RedirectToAction("Publicaciones", "Publicaciones");
            }

            return View(publicacion);
        }


        [HttpGet]
        [Route("reseñas/lista")]
        public async Task<IActionResult> ResenasPorPublicacion(int? id, int? pagina, [FromQuery(Name = "resultados-mostrados")] int? resultadosMostrados)
        {
            List<ResenaTarjetaBasicaVM>? resenas = await _resenaRepository.ObtenerListaResenaTarjetaBasicaVMAsync((int)id, (int)pagina, (int)resultadosMostrados);

            if (resenas == null || !resenas.Any())
            {
                return NoContent();
            }

            return Ok(resenas);
        }

        // Obtener lista de reseñas paginadas por usuario
        //[HttpGet]
        //public async Task<IActionResult> ListaReseñas(string? idUsuario, int? pagina = 1)
        //{
        //    if (string.IsNullOrEmpty(idUsuario) || pagina == null)
        //    {
        //        return BadRequest();
        //    }

        //    var resenas = await _resenaRepository.ObtenerMisResenasAsync(idUsuario, pagina.Value);

        //    if (resenas == null || !resenas.Any())
        //    {
        //        return NoContent();
        //    }

        //    return Ok(resenas);
        //}


        [HttpPost]
        [Route("reseñas/me-gusta")]
        public async Task<IActionResult> MeGusta(int idResena)
        {
            var idUsuario = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtén el ID del usuario
            if (idUsuario == null)
            {
                // Si el usuario no está autenticado, redirige al inicio de sesión
                return Challenge();
            }

            var yaLeDioLike = await _resenaRepository.VerificarSiUsuarioLeDioLike(idResena, idUsuario);

            if (yaLeDioLike)
            {
                // Elimina el like si ya lo ha dado
                await _resenaRepository.EliminarMeGustaAsync(idResena, idUsuario);
            }
            else
            {
                // Añade un like si no lo ha dado
                await _resenaRepository.AgregarMeGustaAsync(idResena, idUsuario);
            }

            // Obtiene el nuevo conteo de likes
            var nuevoConteoLikes = await _resenaRepository.ObtenerMeGustaCountAsync(idResena);

            return Json(new { likes = nuevoConteoLikes, yaLeDioLike = !yaLeDioLike });
        }





    }
}