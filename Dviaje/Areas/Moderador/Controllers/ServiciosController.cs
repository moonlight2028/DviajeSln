using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Moderador.Controllers
{
    [Area("Moderador")]
    [Route("servicios")]
    [Authorize(Roles = RolesUtility.RoleModerador)]
    public class ServiciosController : Controller
    {
        private readonly IServiciosRepository _serviciosRepository;

        public ServiciosController(IServiciosRepository serviciosRepository)
        {
            _serviciosRepository = serviciosRepository;
        }

        // Acción para crear un servicio
        [HttpPost]
        [Route("servicios")]
        public async Task<IActionResult> CrearServicio(Servicio servicio)
        {
            bool resultado = await _serviciosRepository.CrearServicioAsync(servicio);

            if (resultado)
                return Ok(new { success = true, message = "Servicio creado exitosamente." });

            return BadRequest(new { success = false, message = "No se pudo crear el servicio." });
        }

        // Acción para obtener un servicio por ID
        [HttpGet]
        [Route("servicios/{id?}")]
        public async Task<IActionResult> ObtenerServicio(int? id)
        {
            if (!id.HasValue)
                return BadRequest(new { success = false, message = "ID de servicio no proporcionado." });

            Servicio? servicio = await _serviciosRepository.ObtenerServicioPorIdAsync(id.Value);

            if (servicio == null)
                return NotFound(new { success = false, message = "Servicio no encontrado." });

            return Ok(new { success = true, data = servicio });
        }

        // Acción para actualizar un servicio
        [HttpPut]
        [Route("servicios")]
        public async Task<IActionResult> ActualizarServicio(Servicio servicio)
        {
            bool resultado = await _serviciosRepository.ActualizarServicioAsync(servicio);

            if (resultado)
                return Ok(new { success = true, message = "Servicio actualizado exitosamente." });

            return BadRequest(new { success = false, message = "No se pudo actualizar el servicio." });
        }

        // Acción para eliminar un servicio por ID
        [HttpDelete]
        [Route("servicios/{id?}")]
        public async Task<IActionResult> EliminarServicio(int? id)
        {
            if (!id.HasValue)
                return BadRequest(new { success = false, message = "ID de servicio no proporcionado." });

            bool resultado = await _serviciosRepository.EliminarServicioAsync(id.Value);

            if (resultado)
                return Ok(new { success = true, message = "Servicio eliminado exitosamente." });

            return BadRequest(new { success = false, message = "No se pudo eliminar el servicio." });
        }
    }
}
