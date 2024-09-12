using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class PublicacionesController : Controller
    {
        // Repositorios necesitados
        private IPublicacionesRepository _publicacionesRepository;


        // Inyección de repositorios
        public PublicacionesController(IPublicacionesRepository publicacionesRepository)
        {
            _publicacionesRepository = publicacionesRepository;
        }


        public async Task<IActionResult> Publicaciones(int? pagina, string? ordenar)
        {
            // Validacion ruta de pagina
            if (pagina is null or <= 0) pagina = 1;

            // Paginación.
            int publicacionesTotales = await _publicacionesRepository.PublicacionesTotales();
            int numeroPublicaciones = 10;
            int paginasTotales = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(publicacionesTotales) / Convert.ToDecimal(numeroPublicaciones)));

            // Validacion ruta de pagina
            if (pagina > paginasTotales) pagina = 1;

            // Filtro ordenar
            ordenar = ordenar == null ? "" : ordenar.Trim().ToLower();

            // Lista de publicaciones
            //List<PublicacionTarjetaVM> listaPublicaciones = await _publicacionesRepository.ObtenerPublicacionesAsync((int)pagina, numeroPublicaciones, ordenar);

            // Paso de argumentos de paginación a la vista
            ViewBag.PublicacionesTotales = publicacionesTotales;
            ViewBag.PublicacionesPorVista = numeroPublicaciones;
            ViewBag.PaginasTotales = paginasTotales;

            //return View(listaPublicaciones);
            return View();
        }

        public async Task<IActionResult> Publicacion(int? id)
        {
            // Validacion ruta de pagina
            if (id is null) return RedirectToAction(nameof(Publicaciones));

            // Publicación
            PublicacionVM? publicacionBuscada = await _publicacionesRepository.ObtenerPublicacionPorIdAsync((int)id);

            // Validación
            if (publicacionBuscada is null) return RedirectToAction(nameof(Publicaciones));

            return View(publicacionBuscada);
        }


        // Endpoints para JS
        [HttpGet]
        public IActionResult ListaPublicaciones(string? idUsuario, int? pagina)
        {
            // Validacion ruta de idUsuario

            // Agregar logica de paginacion para las PublicacionesTarjetas con sus validaciones, en esta logica se necesita otra consulta

            /* Consulta
             * La lista de PublicacionTarjetaV2VM debe tener paginacion
            */
            List<PublicacionTarjetaV2VM> listaPublicaciones = null; // Consulta

            // Retornar JSON, si es null retornar NoContent

            return Ok();
        }

    }
}
