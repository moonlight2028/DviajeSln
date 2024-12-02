using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Moderador.Controllers
{
    [Area("Moderador")]
    [Route("Moderador/servicios")]
    [Authorize(Roles = RolesUtility.RoleModerador)]
    public class ServiciosController : Controller
    {
        private readonly IServiciosRepository _serviciosRepository;

        public ServiciosController(IServiciosRepository serviciosRepository)
        {
            _serviciosRepository = serviciosRepository;
        }

        /// <summary>
        /// Obtiene el listado de todos los servicios (para el DataTable).
        /// </summary>
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ObtenerServicios()
        {
            try
            {
                var servicios = await _serviciosRepository.ObtenerServiciosAsync();
                if (servicios == null || !servicios.Any())
                {
                    return Ok(new { data = new List<object>() }); // Si no hay servicios, enviar lista vacía
                }
                return Ok(new { data = servicios });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener servicios: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Error interno al obtener los servicios." });
            }
        }

        /// <summary>
        /// Crea un nuevo servicio.
        /// </summary>
        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearServicio(Servicio servicio)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Console.WriteLine("Errores en el modelo para CrearServicio:");
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        Console.WriteLine($"- {error.ErrorMessage}");
                    }
                    return BadRequest(new { success = false, message = "Datos inválidos.", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
                }

                var resultado = await _serviciosRepository.CrearServicioAsync(servicio);

                if (resultado)
                {
                    return Ok(new { success = true, message = "Servicio creado exitosamente." });
                }

                return BadRequest(new { success = false, message = "No se pudo crear el servicio." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear servicio: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Error interno al crear el servicio." });
            }
        }

        /// <summary>
        /// Obtiene un servicio por su ID.
        /// </summary>
        [HttpGet]
        [Route("obtener/{id}")]
        public async Task<IActionResult> ObtenerServicio(int id)
        {
            try
            {
                var servicio = await _serviciosRepository.ObtenerServicioPorIdAsync(id);
                if (servicio == null)
                {
                    return NotFound(new { success = false, message = "Servicio no encontrado." });
                }
                return Ok(new { success = true, data = servicio });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener servicio con ID {id}: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Error interno al obtener el servicio." });
            }
        }

        /// <summary>
        /// Actualiza un servicio existente.
        /// </summary>
        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> ActualizarServicio(Servicio servicio)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { success = false, message = "Datos inválidos.", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
                }

                var resultado = await _serviciosRepository.ActualizarServicioAsync(servicio);

                if (resultado)
                {
                    return Ok(new { success = true, message = "Servicio actualizado exitosamente." });
                }

                return BadRequest(new { success = false, message = "No se pudo actualizar el servicio." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar servicio con ID {servicio.IdServicio}: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Error interno al actualizar el servicio." });
            }
        }

        /// <summary>
        /// Elimina un servicio por su ID.
        /// </summary>
        [HttpDelete]
        [Route("eliminar/{id}")]
        public async Task<IActionResult> EliminarServicio(int id)
        {
            try
            {
                var resultado = await _serviciosRepository.EliminarServicioAsync(id);

                if (resultado)
                {
                    return Ok(new { success = true, message = "Servicio eliminado exitosamente." });
                }

                return BadRequest(new { success = false, message = "No se pudo eliminar el servicio." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar servicio con ID {id}: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Error interno al eliminar el servicio." });
            }
        }
    }
}
