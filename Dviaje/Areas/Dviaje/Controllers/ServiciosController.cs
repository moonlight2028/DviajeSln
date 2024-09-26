using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
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
            // Consulta
            List<Servicio>? servicios = await _serviciosRepository.ObtenerServiciosAsync();

            return Ok(servicios);
        }
    }
}
