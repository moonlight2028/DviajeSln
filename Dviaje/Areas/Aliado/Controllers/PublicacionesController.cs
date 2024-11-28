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
        public IActionResult Crear()
        {
            return View();
        }

        /// <summary>
        /// Acción para crear una nueva publicación.
        /// </summary>
        [HttpPost]
        [Route("publicacion/crear")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(
            [FromForm] PublicacionCrearFrontVM publicacion, List<IFormFile> imagenes)
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
            if (publicacion.RestriccionesSeleccionadas != null)
            {
                foreach (var restriccionId in publicacion.RestriccionesSeleccionadas)
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

            if (imagenes.Count < 5)
            {
                return BadRequest(new
                {
                    mensaje = "Debes cargar mínimo 5 imágenes."
                });
            }

            var tiposPermitidos = new[] { "image/jpeg", "image/png", "image/webp" };
            var extensionesPermitidas = new[] { ".jpg", ".jpeg", ".png", ".webp" };
            foreach (var imagen in imagenes)
            {
                var extension = Path.GetExtension(imagen.FileName).ToLowerInvariant();

                if (!tiposPermitidos.Contains(imagen.ContentType) || !extensionesPermitidas.Contains(extension))
                {
                    return BadRequest($"El archivo {imagen.FileName} no es válido. Solo se permiten imágenes en formatos JPEG, PNG o WebP.");
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


            // Subida de imágenes
            var imagenesSubidas = await _subirArchivosService.SubirImagenesDesdeIFormFileAsync(imagenes, ArchivosUtility.CarpetaPublicaciones((int)resultado), $"{resultado}");
            if (imagenesSubidas == null)
            {
                return BadRequest(new
                {
                    mensaje = "Error, al subir las imágenes."
                });
            }


            // Registro imágenes
            var imagenesLista = imagenesSubidas.Select(img => new PublicacionesImagenes
            {
                IdPublico = img.PublicId,
                Ruta = img.Url,
                Alt = $"Imagen de la publicación {publicacion.Titulo}",
                IdPublicacion = (int)resultado
            }).ToList();
            var registroImagenes = await _publicacionesRepository.RegistrarImagenes(imagenesLista);
            if (!registroImagenes)
            {
                return BadRequest(new
                {
                    mensaje = "Error, al registrar las imágenes."
                });
            }


            return Ok(new { mensaje = "Publicación creada con éxito" });
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
            var idAlido = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Verificar si la página es válida
            if (pagina is null or <= 0) pagina = 1;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Lógica para publicaciones generales con paginación
            int publicacionesTotales = await _publicacionesRepository.PublicacionesTotalesPorIdAliadoAsync(idAlido);
            int numeroPublicaciones = 10;
            int paginasTotales = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(publicacionesTotales) / numeroPublicaciones));

            if (pagina > paginasTotales) pagina = 1;

            ordenar ??= "";

            var misPublicaciones = await _publicacionesRepository.ObtenerListaPublicacionMisPublicacionesVMAsync((int)pagina, 10, ordenar ?? "puntuacion", idAlido);

            if (misPublicaciones == null)
            {
                return View(misPublicaciones);
            }

            ViewBag.PaginacionPaginas = paginasTotales;
            ViewBag.PaginacionItems = numeroPublicaciones;
            ViewBag.PaginacionResultados = publicacionesTotales;
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
