using System.Xml.Linq;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class PublicacionesController : Controller
    {
        private readonly IPublicacionesRepository _publicacionesRepository;
        private readonly IResenasRepository _resenasRepository;


        public PublicacionesController(IPublicacionesRepository publicacionesRepository, IResenasRepository resenasRepository)
        {
            _publicacionesRepository = publicacionesRepository;
            _resenasRepository = resenasRepository;
        }


        [Route("publicaciones")]
        public async Task<IActionResult> Publicaciones(
            [FromQuery(Name = "categorias")] List<int> categorias,
            [FromQuery(Name = "propiedades")] List<int> propieades,
            [FromQuery(Name = "restricciones")] List<int> restricciones,
            [FromQuery(Name = "busqueda")] string busqueda,
            [FromQuery(Name = "fecha-inicio")] DateTime? fechaInicio,
            [FromQuery(Name = "fecha-fin")] DateTime? fechaFin,
            [FromQuery(Name = "precio-minimo")] decimal? precioMinimo,
            [FromQuery(Name = "precio-maximo")] decimal? precioMaximo,
            [FromQuery(Name = "ordenar")] string? ordenar = null,
            [FromQuery(Name = "pagina")] int pagina = 1
        )
        {
            if (pagina <= 0) pagina = 1;
            if (precioMinimo < 0) precioMinimo = null;
            if (precioMaximo < 0) precioMaximo = null;
            ordenar ??= "";
            int elementosPorPagina = 10;


            var publicaciones = await _publicacionesRepository.BuscarPublicacionesAsync(
                categorias, propieades, restricciones, busqueda, fechaInicio, fechaFin, precioMinimo, precioMaximo, ordenar, pagina, elementosPorPagina);

            if (publicaciones == null || !publicaciones.Any()) return View(publicaciones);

            int paginasTotales = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(publicaciones.First().TotalResultados) / elementosPorPagina));
            if (pagina > paginasTotales) pagina = 1;


            ViewBag.PaginacionPaginas = paginasTotales;
            ViewBag.PaginacionItems = elementosPorPagina;
            ViewBag.PaginacionResultados = publicaciones.First().TotalResultados;


            return View(publicaciones);
        }


        // Acción para mostrar el detalle de una publicación
        [Route("publicacion/{id?}")]
        public async Task<IActionResult> Publicacion(int? id)
        {
            if (id is null) return RedirectToAction(nameof(Publicaciones));

            var publicacion = await _publicacionesRepository.ObtenerPublicacionDetalleVMAsync((int)id);
            if (publicacion is null) return RedirectToAction(nameof(Publicaciones));

            var resenas = await _resenasRepository.ObtenerTopResenaTarjetaBasicaVMAsync(publicacion.IdPublicacion);
            publicacion.TopResenas = resenas;


            return View(publicacion);
        }


        [Route("publicacion/imagen/{id?}")]
        public async Task<IActionResult> PublicacionImagen(int? id)
        {
            if (id is < 1)
                return NotFound("Id de publicación incorrecto");

            var publicacion = await _publicacionesRepository.ObtenerPublicacionTarjetaImagenVMAsync(id.Value);
            return publicacion != null
                ? Ok(publicacion)
                : NotFound("Publicación no encontrada.");
        }
    }
}
