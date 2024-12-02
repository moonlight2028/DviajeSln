using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Moderador.Controllers
{
    [Area("Moderador")]
    [Route("Moderador/restricciones")]
    [Authorize(Roles = RolesUtility.RoleModerador)]
    public class RestriccionesController : Controller
    {
        private readonly IRestriccionesRepository _restriccionesRepository;

        public RestriccionesController(IRestriccionesRepository restriccionesRepository)
        {
            _restriccionesRepository = restriccionesRepository;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ObtenerRestricciones()
        {
            try
            {
                var restricciones = await _restriccionesRepository.ObtenerRestriccionesAsync();
                if (restricciones == null || !restricciones.Any())
                {
                    return Ok(new { data = new List<object>(), message = "No hay restricciones disponibles." });
                }

                return Ok(new { data = restricciones });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar restricciones: {ex.Message}");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error al listar restricciones.",
                    details = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("obtener/{id}")]
        public async Task<IActionResult> ObtenerRestriccion(int id)
        {
            try
            {
                var restriccion = await _restriccionesRepository.ObtenerRestriccionPorIdAsync(id);

                if (restriccion == null)
                {
                    Console.WriteLine($"Restricción con ID {id} no encontrada.");
                    return NotFound(new { success = false, message = "Restricción no encontrada." });
                }

                return Ok(new { success = true, data = restriccion });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener restricción con ID {id}: {ex.Message}");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error interno al obtener la restricción.",
                    details = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearRestriccion(Restriccion restriccion)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Console.WriteLine("Errores en el modelo recibido:");
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        Console.WriteLine($" - {error.ErrorMessage}");
                    }
                    return BadRequest(new
                    {
                        success = false,
                        message = "Datos inválidos.",
                        errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
                    });
                }

                var resultado = await _restriccionesRepository.CrearRestriccionAsync(restriccion);

                if (resultado)
                {
                    return Ok(new { success = true, message = "Restricción creada exitosamente." });
                }

                return BadRequest(new { success = false, message = "Error al crear la restricción." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear restricción: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Error interno al crear la restricción.", details = ex.Message });
            }
        }

        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> ActualizarRestriccion(Restriccion restriccion)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { success = false, message = "Datos inválidos." });
                }

                var resultado = await _restriccionesRepository.ActualizarRestriccionAsync(restriccion);

                if (resultado)
                {
                    return Ok(new { success = true, message = "Restricción actualizada exitosamente." });
                }

                return BadRequest(new { success = false, message = "Error al actualizar la restricción." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar restricción: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Error interno al actualizar la restricción.", details = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> EliminarRestriccion(int id)
        {
            try
            {
                var resultado = await _restriccionesRepository.EliminarRestriccionAsync(id);

                if (resultado)
                {
                    return Ok(new { success = true, message = "Restricción eliminada exitosamente." });
                }

                return BadRequest(new { success = false, message = "Error al eliminar la restricción." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar restricción con ID {id}: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Error interno al eliminar la restricción.", details = ex.Message });
            }
        }
    }
}
