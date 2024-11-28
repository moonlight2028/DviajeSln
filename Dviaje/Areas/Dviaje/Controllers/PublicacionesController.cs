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
        public async Task<IActionResult> Publicaciones(int? pagina, string? ordenar, int? idCategoria)
        {
            // Verificar si la página es válida
            if (pagina is null or <= 0) pagina = 1;

            // Verificar si se está filtrando por categoría
            if (idCategoria.HasValue && idCategoria > 0)
            {
                var publicacionesPorCategoria = await _publicacionesRepository.ObtenerPublicacionesPorCategoriaAsync(idCategoria.Value);

                // Si no hay publicaciones en la categoría, redirigir con mensaje
                if (publicacionesPorCategoria == null || !publicacionesPorCategoria.Any())
                {
                    TempData["Info"] = "No hay publicaciones disponibles en esta categoría.";
                    return RedirectToAction(nameof(Publicaciones));
                }

                // Pasar el resultado a la vista de publicaciones
                return View(publicacionesPorCategoria.Select(p => new PublicacionTarjetaBusquedaVM
                {
                    IdPublicacion = p.IdPublicacion,
                    Titulo = p.Titulo,
                    Precio = p.Precio,
                    Direccion = p.Direccion,
                    Puntuacion = p.Puntuacion ?? 0,
                    NumeroResenas = p.NumeroResenas ?? 0,
                    Descripcion = p.Descripcion,
                    Imagenes = new List<PublicacionImagenVM> { new PublicacionImagenVM { Ruta = p.ImagenPrincipal } },
                    Categorias = new List<CategoriaVM> { new CategoriaVM { NombreCategoria = p.NombreCategoria } }
                }).ToList());
            }

            // Lógica para publicaciones generales con paginación
            int publicacionesTotales = await _publicacionesRepository.PublicacionesTotales();
            int numeroPublicaciones = 10;
            int paginasTotales = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(publicacionesTotales) / numeroPublicaciones));

            if (pagina > paginasTotales) pagina = 1;

            ordenar ??= "";

            var listaPublicaciones = await _publicacionesRepository.ObtenerListaPublicacionTarjetaBusquedaVMAsync((int)pagina, numeroPublicaciones, ordenar);

            // Enviar datos de paginación a la vista
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
