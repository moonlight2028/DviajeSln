using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Moderador.Controllers
{
    [Area("Moderador")]
    [Authorize(Roles = RolesUtility.RoleModerador)]
    public class ServiciosController : Controller
    {
        private readonly IServiciosRepository _serviciosRepository;


        public ServiciosController(IServiciosRepository serviciosRepository)
        {
            _serviciosRepository = serviciosRepository;
        }


        [HttpPost]
        [Route("servicios")]
        public async Task<IActionResult> CrearServicio(Servicio servicio)
        {
            bool resultado = await _serviciosRepository.CrearServicioAsync(servicio);

            return Ok();
        }

        [HttpGet]
        [Route("servicios/{id?}")]
        public async Task<IActionResult> ObtenerServicio(int? id)
        {
            Servicio? servicio = await _serviciosRepository.ObtenerServicioPorIdAsync((int)id);

            return Ok(servicio);
        }

        [HttpPut]
        [Route("servicios")]
        public async Task<IActionResult> ActualizarServicio(Servicio servicio)
        {
            bool resultado = await _serviciosRepository.ActualizarServicioAsync(servicio);

            return Ok();
        }

        [HttpDelete]
        [Route("servicios/{id?}")]
        public async Task<IActionResult> EliminarServicio(int? id)
        {
            bool resultado = await _serviciosRepository.EliminarServicioAsync((int)id);

            return Ok();
        }
    }
}
