﻿using Dviaje.DataAccess.Repository.IRepository;
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
                    Imagenes = p.Imagenes.Any()
                        ? p.Imagenes
                        : new List<PublicacionImagenVM> { new PublicacionImagenVM { Ruta = p.ImagenPrincipal } }, // Asigna la imagen principal si no hay lista
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
