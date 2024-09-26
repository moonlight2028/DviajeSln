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


        [Route("publicaciones")]
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
            List<PublicacionTarjetaBusquedaVM> listaPublicaciones = await _publicacionesRepository.ObtenerListaPublicacionTarjetaBusquedaVMAsync((int)pagina, numeroPublicaciones, ordenar);

            // Paso de argumentos de paginación a la vista
            ViewBag.PaginacionPaginas = paginasTotales;
            ViewBag.PaginacionItems = numeroPublicaciones;
            ViewBag.PaginacionResultados = publicacionesTotales;

            return View(listaPublicaciones);
        }

        [Route("publicacion/{id?}")]
        public async Task<IActionResult> Publicacion(int? id)
        {
            // Validacion ruta de pagina
            if (id is null) return RedirectToAction(nameof(Publicaciones));

            // Publicación
            PublicacionDetalleVM? publicacionBuscada = await _publicacionesRepository.ObtenerPublicacionDetalleVMAsync((int)id);

            // Validación
            if (publicacionBuscada is null) return RedirectToAction(nameof(Publicaciones));

            return View(publicacionBuscada);
        }


        [HttpGet]
        [Route("publicacion/tarjeta-imagen")]
        public async Task<IActionResult> PublicacionTarjetaImagen(int? id)
        {
            PublicacionTarjetaImagenVM? publicacion = await _publicacionesRepository.ObtenerPublicacionTarjetaImagenVMAsync((int)id);

            return Ok(publicacion);
        }









    }
}
