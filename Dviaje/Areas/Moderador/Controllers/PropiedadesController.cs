using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Moderador.Controllers
{
    [Area("Moderador")]
    [Route("Moderador/propiedades")]
    [Authorize(Roles = RolesUtility.RoleModerador)]
    public class PropiedadesController : Controller
    {
        private readonly IPropiedadesRepository _propiedadesRepository;

        public PropiedadesController(IPropiedadesRepository propiedadesRepository)
        {
            _propiedadesRepository = propiedadesRepository;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ObtenerPropiedades()
        {
            try
            {
                var propiedades = await _propiedadesRepository.ObtenerPropiedadesAsync();
                return Ok(new { data = propiedades });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Error al obtener las propiedades.", details = ex.Message });
            }
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearPropiedad(Propiedad propiedad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = "Datos inválidos." });
            }

            var resultado = await _propiedadesRepository.CrearPropiedadAsync(propiedad);
            return resultado
                ? Ok(new { success = true, message = "Propiedad creada exitosamente." })
                : BadRequest(new { success = false, message = "Error al crear la propiedad." });
        }

        [HttpGet]
        [Route("obtener/{id?}")]
        public async Task<IActionResult> ObtenerPropiedad(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest(new { success = false, message = "ID no proporcionado." });
            }

            var propiedad = await _propiedadesRepository.ObtenerPropiedadPorIdAsync(id.Value);
            return propiedad != null
                ? Ok(new { success = true, data = propiedad })
                : NotFound(new { success = false, message = "Propiedad no encontrada." });
        }

        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> ActualizarPropiedad(Propiedad propiedad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = "Datos inválidos." });
            }

            var resultado = await _propiedadesRepository.ActualizarPropiedadAsync(propiedad);
            return resultado
                ? Ok(new { success = true, message = "Propiedad actualizada exitosamente." })
                : BadRequest(new { success = false, message = "Error al actualizar la propiedad." });
        }

        [HttpDelete]
        [Route("eliminar/{id?}")]
        public async Task<IActionResult> EliminarPropiedad(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest(new { success = false, message = "ID no proporcionado." });
            }

            var resultado = await _propiedadesRepository.EliminarPropiedadAsync(id.Value);
            return resultado
                ? Ok(new { success = true, message = "Propiedad eliminada exitosamente." })
                : BadRequest(new { success = false, message = "Error al eliminar la propiedad." });
        }
    }
}
