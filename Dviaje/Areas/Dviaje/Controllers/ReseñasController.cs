using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class ReseñasController : Controller
    {
        // Inyección en el controlador.
        public ReseñasController()
        {
        }


        public IActionResult Reseñas(int? idPublicacion)
        {
            // Validacion ruta de pagina, si no pasa valiadciones retornar a Publicaciones

            // Consulta
            ResenasPublicacionVM? resenas = null;

            // Si resenas es null retornar a Publicaciones

            return View(resenas);
        }


        // Endpoints para JS
        [HttpGet]
        public IActionResult ListaReseñas(int? idPublicacion, int? pagina)
        {
            // Validacion ruta

            // Agregar logica de paginacion para las ResenasTarjetas con sus validaciones, en esta logica se necesita otra consulta

            /* Consulta
             * La lista de ResenasTarjetaVM debe tener paginacion
             * Ordenar las reseñas en la consulta de mejor calificacion a peor calificacion
             */
            List<ResenasTarjetaVM>? listaResenas = null; // Consulta

            // Retornar JSON, si es null retornar NoContent

            return Ok();
        }

        [HttpGet]
        public IActionResult ListaReseñas(string? idUsuario, int? pagina)
        {
            // Validacion ruta de idUsuario

            // Agregar logica de paginacion para las ResenasTarjetas con sus validaciones, en esta logica se necesita otra consulta

            /* Consulta
             * La lista de ResenasTarjetaVM debe tener paginacion
             * Ordenar las reseñas en la consulta de mejor calificacion a peor calificacion
             */
            List<ResenasTarjetaVM>? listaResenas = null; // Consulta

            // Retornar JSON, si es null retornar NoContent

            return Ok();
        }

        [HttpGet]
        public IActionResult TopReseñas(string? idPublicacion)
        {
            // Validacion ruta de idPublicacion

            /* Consulta
             * Obtener top 3 reseñas con mejor calificacion
             */
            List<ResenasTarjetaVM>? listaResenas = null; // Consulta

            // Retornar JSON, si es null retornar NoContent

            return Ok();
        }

    }
}
