using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Dviaje.Services.IServices;
using Dviaje.Utility;
using FluentValidation;
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
        private IValidator<PublicacionCrearVM> _publicacionCrearVMValidator;
        private ISubirArchivosService _subirArchivosService;


        public PublicacionesController(
            IPublicacionesRepository publicacionesRepository,
            IServiciosRepository serviciosRepository,
            IRestriccionesRepository restriccionesRepository,
            ICategoriasRepository categoriasRepository,
            IValidator<PublicacionCrearVM> publicacionCrearVMValidator,
            ISubirArchivosService subirArchivosService)
        {
            _publicacionesRepository = publicacionesRepository;
            _serviciosRepository = serviciosRepository;
            _restriccionesRepository = restriccionesRepository;
            _categoriasRepository = categoriasRepository;
            _publicacionCrearVMValidator = publicacionCrearVMValidator;
            _subirArchivosService = subirArchivosService;
        }


        /// <summary>
        /// Vista para crear una nueva publicación.
        /// </summary>
        [Route("publicacion/crear")]
        public async Task<IActionResult> Crear()
        {
            //var publicacion = await ObtenerDatosCrearPublicacionAsyn(new PublicacionCrearVM());
            return View();
        }

        /// <summary>
        /// Acción para crear una nueva publicación.
        /// </summary>
        [HttpPost]
        [Route("publicacion/crear")]
        public async Task<IActionResult> Crear(PublicacionCrearVM publicacion, List<IFormFile> imagenes)
        {





            return RedirectToAction(nameof(MisPublicaciones));

            // Validaciones
            //var validacion = await _publicacionCrearVMValidator.ValidateAsync(publicacion);
            //if (!validacion.IsValid)
            //{
            //    validacion.AddToModelState(this.ModelState);
            //}

            //if (imagenes == null || imagenes.Count < 3)
            //{
            //    ModelState.AddModelError("imagenes", "La publicación debe contener al menos tres imágenes.");
            //}
            //else
            //{
            //    foreach (var imagen in imagenes)
            //    {
            //        if (!ArchivosUtility.ArchivosValidosImagenes.Contains(imagen.ContentType))
            //        {
            //            ModelState.AddModelError("imagenes", "Formato de imagen no aceptada, formatos aceptados JPG, JPEG, WEBP o PNG.");
            //        }
            //    }
            //}

            //if (!ModelState.IsValid)
            //{
            //    var datos = await ObtenerDatosCrearPublicacionAsyn(publicacion);
            //    return View(datos);
            //}
            //else
            //{
            //    var servicios = await _serviciosRepository.ObtenerServiciosAsync();
            //    var restricciones = await _restriccionesRepository.ObtenerRestriccionesAsync();
            //    var categorias = await _categoriasRepository.ObtenerCategoriasAsync();
            //    if (publicacion.ServiciosHabitacionSeleccionados != null)
            //    {
            //        foreach (var servicioId in publicacion.ServiciosHabitacionSeleccionados)
            //        {
            //            var servicioExistente = servicios.Any(s => s.IdServicio == servicioId);

            //            if (!servicioExistente)
            //            {
            //                ModelState.AddModelError("ServiciosHabitacionSeleccionados", "Error el servicio no existe.");
            //                break;
            //            }
            //        }
            //    }
            //    if (publicacion.ServiciosEstablecimientoSeleccionados != null)
            //    {
            //        foreach (var servicioId in publicacion.ServiciosEstablecimientoSeleccionados)
            //        {
            //            var servicioExistente = servicios.Any(s => s.IdServicio == servicioId);

            //            if (!servicioExistente)
            //            {
            //                ModelState.AddModelError("ServiciosEstablecimientoSeleccionados", "Error el servicio no existe.");
            //                break;
            //            }
            //        }
            //    }
            //    if (publicacion.CategoriasSeleccionadas != null)
            //    {
            //        foreach (var categoriaId in publicacion.CategoriasSeleccionadas)
            //        {
            //            var categoriaExistente = categorias.Any(c => c.IdCategoria == categoriaId);

            //            if (!categoriaExistente)
            //            {
            //                ModelState.AddModelError("CategoriasSeleccionadas", "Error la categoria no existe.");
            //                break;
            //            }
            //        }
            //    }
            //    if (publicacion.RestriccionesSeleccionadas != null)
            //    {
            //        foreach (var resticcionId in publicacion.RestriccionesSeleccionadas)
            //        {
            //            var restriccionExistente = restricciones.Any(r => r.IdRestriccion == resticcionId);

            //            if (!restriccionExistente)
            //            {
            //                ModelState.AddModelError("RestriccionesSeleccionadas", "Error la restricción no existe.");
            //                break;
            //            }
            //        }
            //    }

            //    if (!ModelState.IsValid)
            //    {
            //        var datos = await ObtenerDatosCrearPublicacionAsyn(publicacion);
            //        return View(datos);
            //    }
            //}


            //// Registro publicación
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //publicacion.IdAliado = userId;
            //publicacion.Fecha = DateTime.UtcNow;

            //var resultado = await _publicacionesRepository.CrearPublicacionAsync(publicacion);
            //if (resultado == null)
            //{
            //    var datos = await ObtenerDatosCrearPublicacionAsyn(publicacion);

            //    TempData["Notificacion"] = "error";
            //    TempData["NotificacionTitulo"] = "Publicación";
            //    TempData["NotificacionMensaje"] = "Error, publicación no registrada.";

            //    return View(datos);
            //}

            //// Subida de imágenes
            //var imagenesSubidas = await _subirArchivosService.SubirImagenesDesdeIFormFileAsync(imagenes, ArchivosUtility.CarpetaPublicaciones((int)resultado), $"{resultado}");
            //if (imagenesSubidas == null)
            //{
            //    var datos = await ObtenerDatosCrearPublicacionAsyn(publicacion);

            //    TempData["Notificacion"] = "error";
            //    TempData["NotificacionTitulo"] = "Publicación";
            //    TempData["NotificacionMensaje"] = "Error, al subir las imágenes.";

            //    return View(datos);
            //}

            //// Registro imágenes
            //var imagenesLista = imagenesSubidas.Select(img => new PublicacionesImagenes
            //{
            //    Ruta = img.Url,
            //    Alt = $"Imagen de la publicación {publicacion.Titulo}",
            //    IdPublicacion = (int)resultado
            //}).ToList();
            //var registroImagenes = await _publicacionesRepository.RegistrarImagenes(imagenesLista);
            //if (!registroImagenes)
            //{
            //    var datos = await ObtenerDatosCrearPublicacionAsyn(publicacion);

            //    TempData["Notificacion"] = "error";
            //    TempData["NotificacionTitulo"] = "Publicación";
            //    TempData["NotificacionMensaje"] = "Error, al registra las imágenes.";

            //    return View(datos);
            //}

            //var testdd = "dasf";


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







        //private async Task<PublicacionCrearVM> ObtenerDatosCrearPublicacionAsyn(PublicacionCrearVM publicacion)
        //{
        //    var servicios = await _serviciosRepository.ObtenerServiciosAsync();
        //    var restricciones = await _restriccionesRepository.ObtenerRestriccionesAsync();
        //    var categorias = await _categoriasRepository.ObtenerCategoriasAsync();

        //    publicacion.ServiciosHabitacion = servicios
        //        .Where(s => s.ServicioTipo == ServicioTipo.Habitacion)
        //        .Select(s => new SeleccionSRCVM
        //        {
        //            Id = s.IdServicio,
        //            Nombre = s.NombreServicio,
        //            Icono = s.RutaIcono
        //        }).ToList();
        //    publicacion.ServiciosEstablecimiento = servicios
        //            .Where(s => s.ServicioTipo == ServicioTipo.Establecimiento)
        //            .Select(s => new SeleccionSRCVM
        //            {
        //                Id = s.IdServicio,
        //                Nombre = s.NombreServicio,
        //                Icono = s.RutaIcono
        //            }).ToList();
        //    publicacion.ServiciosAccesibilidad = servicios
        //            .Where(s => s.ServicioTipo == ServicioTipo.Accesibilidad)
        //            .Select(s => new SeleccionSRCVM
        //            {
        //                Id = s.IdServicio,
        //                Nombre = s.NombreServicio,
        //                Icono = s.RutaIcono
        //            }).ToList();
        //    publicacion.Restricciones = restricciones.Select(r => new SeleccionSRCVM
        //    {
        //        Id = r.IdRestriccion,
        //        Nombre = r.NombreRestriccion,
        //        Icono = r.RutaIcono
        //    }).ToList();
        //    publicacion.Categorias = categorias.Select(c => new SeleccionSRCVM
        //    {
        //        Id = c.IdCategoria,
        //        Nombre = c.NombreCategoria,
        //        Icono = c.RutaIcono
        //    }).ToList();

        //    return publicacion;
        //}


    }
}
