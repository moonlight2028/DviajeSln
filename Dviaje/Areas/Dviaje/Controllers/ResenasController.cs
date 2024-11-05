using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

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
            //var publicacion = await _publicacionesRepository.ObtenerPublicacionResenasVMAsyn((int)id);

            //if (publicacion == null)
            //{
            //    return RedirectToAction("Publicaciones", "Publicaciones");
            //}

            //return View(publicacion);
            return View();
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






    }
}