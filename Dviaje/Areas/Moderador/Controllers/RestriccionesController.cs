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

        /// <summary>
        /// Obtiene el listado de todas las restricciones (para el DataTable).
        /// </summary>
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ObtenerRestricciones()
        {
            try
            {
                var restricciones = await _restriccionesRepository.ObtenerRestriccionesAsync();
                return Ok(new { data = restricciones }); // Compatible con dataSrc: "data" en DataTable
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Error al obtener las restricciones.", details = ex.Message });
            }
        }

        /// <summary>
        /// Crea una nueva restricción.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CrearRestriccion(Restriccion restriccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _restriccionesRepository.CrearRestriccionAsync(restriccion);
            if (resultado)
            {
                return Ok(new { success = true, message = "Restricción creada exitosamente." });
            }

            return BadRequest(new { success = false, message = "Error al crear la restricción." });
        }

        /// <summary>
        /// Obtiene una restricción por su ID.
        /// </summary>
        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> ObtenerRestriccion(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest(new { success = false, message = "ID de restricción no proporcionado." });
            }

            var restriccion = await _restriccionesRepository.ObtenerRestriccionPorIdAsync(id.Value);
            if (restriccion == null)
            {
                return NotFound(new { success = false, message = "Restricción no encontrada." });
            }

            return Ok(new { success = true, data = restriccion });
        }

        /// <summary>
        /// Actualiza una restricción existente.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> ActualizarRestriccion(Restriccion restriccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _restriccionesRepository.ActualizarRestriccionAsync(restriccion);
            if (resultado)
            {
                return Ok(new { success = true, message = "Restricción actualizada exitosamente." });
            }

            return BadRequest(new { success = false, message = "Error al actualizar la restricción." });
        }

        /// <summary>
        /// Elimina una restricción por su ID.
        /// </summary>
        [HttpDelete]
        [Route("{id?}")]
        public async Task<IActionResult> EliminarRestriccion(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest(new { success = false, message = "ID de restricción no proporcionado." });
            }

            var resultado = await _restriccionesRepository.EliminarRestriccionAsync(id.Value);
            if (resultado)
            {
                return Ok(new { success = true, message = "Restricción eliminada exitosamente." });
            }

            return BadRequest(new { success = false, message = "Error al eliminar la restricción." });
        }
    }
}
