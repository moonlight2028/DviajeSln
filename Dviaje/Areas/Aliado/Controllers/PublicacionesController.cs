using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
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
        private readonly IPropiedadesRepository _propiedadesRepository;
        private IValidator<PublicacionCrearFrontVM> _publicacionCrearVMValidator;
        private ISubirArchivosService _subirArchivosService;


        public PublicacionesController(
            IPublicacionesRepository publicacionesRepository,
            IServiciosRepository serviciosRepository,
            IRestriccionesRepository restriccionesRepository,
            ICategoriasRepository categoriasRepository,
            IPropiedadesRepository propiedadesRepository,
            IValidator<PublicacionCrearFrontVM> publicacionCrearVMValidator,
        ISubirArchivosService subirArchivosService)
        {
            _publicacionesRepository = publicacionesRepository;
            _serviciosRepository = serviciosRepository;
            _restriccionesRepository = restriccionesRepository;
            _categoriasRepository = categoriasRepository;
            _propiedadesRepository = propiedadesRepository;
            _publicacionCrearVMValidator = publicacionCrearVMValidator;
            _subirArchivosService = subirArchivosService;
        }


        /// <summary>
        /// Vista para crear una nueva publicación.
        /// </summary>
        [Route("publicacion/crear")]
        public async Task<IActionResult> Crear()
        {
            return View();
        }

        /// <summary>
        /// Acción para crear una nueva publicación.
        /// </summary>
        [HttpPost]
        [Route("publicacion/crear")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([FromForm] PublicacionCrearFrontVM publicacion, List<IFormFile> imagenes)
        {
            // Validaciones
            var validacion = await _publicacionCrearVMValidator.ValidateAsync(publicacion);
            if (!validacion.IsValid)
            {
                var errores = validacion.Errors
                    .Select(e => new
                    {
                        campo = e.PropertyName,
                        mensaje = e.ErrorMessage
                    })
                    .ToList();

                return BadRequest(new
                {
                    mensaje = "Errores de validación",
                    errores
                });
            }

            var categorias = await _categoriasRepository.ObtenerCategoriasAsync();
            var categoriaExistente = categorias.Any(c => c.IdCategoria == publicacion.CategoriaSeleccionada);
            if (!categoriaExistente)
            {
                return BadRequest(new
                {
                    mensaje = "La categoría no existe."
                });
            }

            var propiedadValidacion = await _propiedadesRepository.VerificarCategoriaPropiedadAsync(publicacion.CategoriaSeleccionada, publicacion.PropiedadSeleccionada);
            if (!propiedadValidacion)
            {
                return BadRequest(new
                {
                    mensaje = "Error en la propiedad seleccionada."
                });
            }

            var servicios = await _serviciosRepository.ObtenerServiciosAsync();
            if (publicacion.ServiciosSeleccionados != null)
            {
                foreach (var servicioId in publicacion.ServiciosSeleccionados)
                {
                    var servicioExistente = servicios.Any(s => s.IdServicio == servicioId);

                    if (!servicioExistente)
                    {
                        return BadRequest(new
                        {
                            mensaje = "El servicio con el ID " + servicioId + " no existe."
                        });
                    }
                }
            }

            var restricciones = await _restriccionesRepository.ObtenerRestriccionesAsync();
            if (publicacion.restriccionesSeleccionadas != null)
            {
                foreach (var restriccionId in publicacion.restriccionesSeleccionadas)
                {
                    var restriccionExistente = restricciones.Any(r => r.IdRestriccion == restriccionId);

                    if (!restriccionExistente)
                    {
                        return BadRequest(new
                        {
                            mensaje = "La restriccion con el ID " + restriccionId + " no existe."
                        });
                    }
                }
            }


            // Registro publicación
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            publicacion.IdAliado = userId;
            publicacion.Fecha = DateTime.UtcNow;
            publicacion.PublicacionEstado = PublicacionEstado.Activa.ToString();

            var resultado = await _publicacionesRepository.CrearPublicacionAsync(publicacion);
            if (resultado == null)
            {
                return BadRequest(new
                {
                    mensaje = "Error al crear la publicación."
                });
            }







            var resultados = await _subirArchivosService.SubirMultiplesImagenesAsync(publicacion.Imagenes);


            var dafads = "Adf";





            return Ok(new { mensaje = "Publicación creada con éxito" });

























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
