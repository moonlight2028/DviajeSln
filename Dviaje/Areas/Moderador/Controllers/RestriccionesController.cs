using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Moderador.Controllers
{
    [Area("Moderador")]
    [Authorize(Roles = RolesUtility.RoleModerador)]
    public class RestriccionesController : Controller
    {
        private readonly IRestriccionesRepository _restriccionesRepository;


        public RestriccionesController(IRestriccionesRepository restriccionesRepository)
        {
            _restriccionesRepository = restriccionesRepository;
        }


        [HttpPost]
        [Route("restricciones")]
        public async Task<IActionResult> CrearRestriccion(Restriccion restriccion)
        {
            bool resultado = await _restriccionesRepository.CrearRestriccionAsync(restriccion);

            return Ok();
        }

        [HttpGet]
        [Route("restricciones/{id?}")]
        public async Task<IActionResult> ObtenerRestriccion(int? id)
        {
            Restriccion? restriccion = await _restriccionesRepository.ObtenerRestriccionPorIdAsync((int)id);

            return Ok(restriccion);
        }

        [HttpPut]
        [Route("restricciones")]
        public async Task<IActionResult> ActualizarRestriccion(Restriccion restriccion)
        {
            bool resultado = await _restriccionesRepository.ActualizarRestriccionAsync(restriccion);

            return Ok();
        }

        [HttpDelete]
        [Route("restricciones/{id?}")]
        public async Task<IActionResult> EliminarRestriccion(int? id)
        {
            bool resultado = await _restriccionesRepository.EliminarRestriccionAsync((int)id);

            return Ok();
        }
    }
}
