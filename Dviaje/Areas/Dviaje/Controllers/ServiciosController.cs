using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class ServiciosController : Controller
    {
        private readonly IServiciosRepository _serviciosRepository;


        public ServiciosController(IServiciosRepository serviciosRepository)
        {
            _serviciosRepository = serviciosRepository;
        }


        [HttpGet]
        [Route("servicios")]
        public async Task<IActionResult> Servicios()
        {
            List<ServicioTipoStringVM>? servicios = await _serviciosRepository.ObtenerServiciosAsync();

            if (servicios == null || !servicios.Any()) return NotFound("No se encontraron servicios.");

            return Ok(servicios);
        }
    }
}
