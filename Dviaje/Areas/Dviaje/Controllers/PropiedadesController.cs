using Dviaje.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    public class PropiedadesController : Controller
    {
        private readonly IPropiedadesRepository _propiedadesRepository;


        public PropiedadesController(IPropiedadesRepository propiedadesRepository)
        {
            _propiedadesRepository = propiedadesRepository;
        }


        [HttpGet]
        [Route("propiedades")]
        public async Task<IActionResult> Propiedades()
        {
            var propiedades = await _propiedadesRepository.ObtenerPropiedadesAsync();

            if (propiedades == null || !propiedades.Any()) return NotFound("No se encontraron propiedades.");

            return Ok(propiedades);
        }

        [HttpGet]
        [Route("propiedades/{id}")]
        public async Task<IActionResult> Propiedades(int id)
        {
            if (id <= 0) return BadRequest("El ID debe ser un número positivo.");

            var propiedades = await _propiedadesRepository.ObtenerPropiedadesPorCategoriaAsync(id);

            if (propiedades == null || !propiedades.Any()) return NotFound("No se encontraron propiedades para la categoría proporcionada.");

            return Ok(propiedades);
        }

    }
}
