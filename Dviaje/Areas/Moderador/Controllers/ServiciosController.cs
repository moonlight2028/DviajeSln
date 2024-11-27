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
                return Ok(new { data = servicios }); // Compatible con dataSrc: "data" en DataTable
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Error al obtener los servicios.", details = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuevo servicio.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CrearServicio(Servicio servicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _serviciosRepository.CrearServicioAsync(servicio);

            if (resultado)
            {
                return Ok(new { success = true, message = "Servicio creado exitosamente." });
            }

            return BadRequest(new { success = false, message = "No se pudo crear el servicio." });
        }

        /// <summary>
        /// Obtiene un servicio por su ID.
        /// </summary>
        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> ObtenerServicio(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest(new { success = false, message = "ID de servicio no proporcionado." });
            }

            var servicio = await _serviciosRepository.ObtenerServicioPorIdAsync(id.Value);

            if (servicio == null)
            {
                return NotFound(new { success = false, message = "Servicio no encontrado." });
            }

            return Ok(new { success = true, data = servicio });
        }

        /// <summary>
        /// Actualiza un servicio existente.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> ActualizarServicio(Servicio servicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _serviciosRepository.ActualizarServicioAsync(servicio);

            if (resultado)
            {
                return Ok(new { success = true, message = "Servicio actualizado exitosamente." });
            }

            return BadRequest(new { success = false, message = "No se pudo actualizar el servicio." });
        }

        /// <summary>
        /// Elimina un servicio por su ID.
        /// </summary>
        [HttpDelete]
        [Route("{id?}")]
        public async Task<IActionResult> EliminarServicio(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest(new { success = false, message = "ID de servicio no proporcionado." });
            }

            var resultado = await _serviciosRepository.EliminarServicioAsync(id.Value);

            if (resultado)
            {
                return Ok(new { success = true, message = "Servicio eliminado exitosamente." });
            }

            return BadRequest(new { success = false, message = "No se pudo eliminar el servicio." });
        }
    }
}
