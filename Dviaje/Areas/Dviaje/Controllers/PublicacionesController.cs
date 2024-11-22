using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class PublicacionesController : Controller
    {
        private readonly IPublicacionesRepository _publicacionesRepository;

        public PublicacionesController(IPublicacionesRepository publicacionesRepository)
        {
            _publicacionesRepository = publicacionesRepository;
        }

        // Acción para mostrar el listado de publicaciones
        [Route("publicaciones")]
        public async Task<IActionResult> Publicaciones(int? pagina, string? ordenar)
        {
            if (pagina is null or <= 0) pagina = 1;

            int publicacionesTotales = await _publicacionesRepository.PublicacionesTotales();
            int numeroPublicaciones = 10;
            int paginasTotales = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(publicacionesTotales) / Convert.ToDecimal(numeroPublicaciones)));

            if (pagina > paginasTotales) pagina = 1;

            ordenar ??= "";

            List<PublicacionTarjetaBusquedaVM> listaPublicaciones = await _publicacionesRepository.ObtenerListaPublicacionTarjetaBusquedaVMAsync((int)pagina, numeroPublicaciones, ordenar);

            ViewBag.PaginacionPaginas = paginasTotales;
            ViewBag.PaginacionItems = numeroPublicaciones;
            ViewBag.PaginacionResultados = publicacionesTotales;

            return View(listaPublicaciones);
        }

        // Acción para mostrar el detalle de una publicación
        [Route("publicacion/{id?}")]
        public async Task<IActionResult> Publicacion(int? id)
        {
            if (id is null) return RedirectToAction(nameof(Publicaciones));

            var publicacion = await _publicacionesRepository.ObtenerPublicacionDetalleVMAsync((int)id);
            if (publicacion is null) return RedirectToAction(nameof(Publicaciones));

            return View(publicacion);
        }
    }
}
