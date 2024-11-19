using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dviaje.Areas.Aliado.Controllers
{
    [Area("Aliado")]
    [Authorize(Roles = RolesUtility.RoleAliado)]
    public class PublicacionesController : Controller
    {
        private readonly IPublicacionesRepository _publicacionesRepository;
        private readonly IServiciosRepository _serviciosRepository;
        private readonly IRestriccionesRepository _restriccionesRepository;
        private readonly ICategoriasRepository _categoriasRepository;


        public PublicacionesController(
            IPublicacionesRepository publicacionesRepository,
            IServiciosRepository serviciosRepository,
            IRestriccionesRepository restriccionesRepository,
            ICategoriasRepository categoriasRepository)
        {
            _publicacionesRepository = publicacionesRepository;
            _serviciosRepository = serviciosRepository;
            _restriccionesRepository = restriccionesRepository;
            _categoriasRepository = categoriasRepository;
        }


        /// <summary>
        /// Vista para crear una nueva publicación.
        /// </summary>
        [Route("publicacion/crear")]
        public async Task<IActionResult> Crear()
        {
            // var datos = await _publicacionesRepository.ObtenerPublicacionCrearVMAsync();

            var servicios = await _serviciosRepository.ObtenerServiciosAsync();
            var restricciones = await _restriccionesRepository.ObtenerRestriccionesAsync();
            var categorias = await _categoriasRepository.ObtenerCategoriasAsync();

            var publicacion = new PublicacionCrearVM
            {
                ServiciosHabitacion = servicios
                    .Where(s => s.ServicioTipo == ServicioTipo.Habitacion)
                    .Select(s => new SeleccionSRCVM
                    {
                        Id = s.IdServicio,
                        Nombre = s.NombreServicio,
                        Icono = s.RutaIcono
                    }).ToList(),
                ServiciosEstablecimiento = servicios
                    .Where(s => s.ServicioTipo == ServicioTipo.Establecimiento)
                    .Select(s => new SeleccionSRCVM
                    {
                        Id = s.IdServicio,
                        Nombre = s.NombreServicio,
                        Icono = s.RutaIcono
                    }).ToList(),
                ServiciosAccesibilidad = servicios
                    .Where(s => s.ServicioTipo == ServicioTipo.Accesibilidad)
                    .Select(s => new SeleccionSRCVM
                    {
                        Id = s.IdServicio,
                        Nombre = s.NombreServicio,
                        Icono = s.RutaIcono
                    }).ToList(),
                Restricciones = restricciones.Select(r => new SeleccionSRCVM
                {
                    Id = r.IdRestriccion,
                    Nombre = r.NombreRestriccion,
                    Icono = r.RutaIcono
                }).ToList(),
                Categorias = categorias.Select(c => new SeleccionSRCVM
                {
                    Id = c.IdCategoria,
                    Nombre = c.NombreCategoria,
                    Icono = c.RutaIcono
                }).ToList()
            };


            return View(publicacion);
        }

        /// <summary>
        /// Acción para crear una nueva publicación.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Crear(PublicacionCrearVM publicacion)
        {
            if (!ModelState.IsValid)
            {
                return View(publicacion);
            }

            var resultado = await _publicacionesRepository.CrearPublicacionAsync(publicacion);
            if (resultado)
            {
                TempData["Success"] = "Publicación creada exitosamente.";
                return RedirectToAction(nameof(MisPublicaciones));
            }

            TempData["Error"] = "Error al crear la publicación.";
            return View(publicacion);
        }

        /// <summary>
        /// Vista para editar una publicación existente.
        /// </summary>
        [Route("publicacion/editar/{id?}")]
        public async Task<IActionResult> Editar(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(nameof(MisPublicaciones));
            }

            var publicacion = await _publicacionesRepository.ObtenerPublicacionCrearVMAsync(id.Value);
            if (publicacion == null)
            {
                return NotFound("Publicación no encontrada.");
            }

            return View(publicacion);
        }

        /// <summary>
        /// Acción para actualizar una publicación existente.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Editar(PublicacionCrearVM publicacion)
        {
            if (!ModelState.IsValid)
            {
                return View(publicacion);
            }

            var resultado = await _publicacionesRepository.EditarPublicacionAsync(publicacion);
            if (resultado)
            {
                TempData["Success"] = "Publicación actualizada exitosamente.";
                return RedirectToAction(nameof(MisPublicaciones));
            }

            TempData["Error"] = "Error al actualizar la publicación.";
            return View(publicacion);
        }

        /// <summary>
        /// Vista de las publicaciones del usuario autenticado.
        /// </summary>
        [Route("publicaciones/mis-publicaciones")]
        public async Task<IActionResult> MisPublicaciones(int? pagina, string? ordenar)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var paginaActual = pagina ?? 1;

            var misPublicaciones = await _publicacionesRepository.ObtenerListaPublicacionTarjetaBusquedaVMAsync(paginaActual, 10, ordenar ?? "puntuacion");

            if (misPublicaciones == null)
            {
                TempData["Info"] = "No tienes publicaciones para mostrar.";
                return View();
            }

            return View(misPublicaciones);
        }

        /// <summary>
        /// Acción para eliminar una publicación (cambia el estado a "Eliminada").
        /// </summary>
        [HttpDelete]
        [Route("publicacion/estado")]
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("ID de publicación no proporcionado.");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var resultado = await _publicacionesRepository.EstadoEliminarPublicacionAsync(id.Value, int.Parse(userId));

            if (resultado)
            {
                return Ok(new { success = true, message = "Publicación eliminada correctamente." });
            }

            return BadRequest(new { success = false, message = "Error al eliminar la publicación." });
        }

        /// <summary>
        /// Acción para cambiar el estado de una publicación (activar o pausar).
        /// </summary>
        [HttpPut]
        [Route("publicacion/estado")]
        public async Task<IActionResult> CambiarEstado(int? id, string? estado)
        {
            if (!id.HasValue || string.IsNullOrEmpty(estado))
            {
                return BadRequest("ID de publicación o estado no proporcionado.");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var resultado = await _publicacionesRepository.EstadoCambiarPublicacionAsync(id.Value, int.Parse(userId), estado);

            if (resultado)
            {
                return Ok(new { success = true, message = "Estado de publicación actualizado." });
            }

            return BadRequest(new { success = false, message = "Error al cambiar el estado de la publicación." });
        }
    }
}
