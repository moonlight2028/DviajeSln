using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    [Authorize(Roles = RolesUtility.RoleTurista)]
    public class PqrsController : Controller
    {
        private readonly IPqrsRepository _pqrsRepository;


        public PqrsController(IPqrsRepository pqrsRepository)
        {
            _pqrsRepository = pqrsRepository;
        }


        [Route("pqrs/mis-pqrs")]
        public async Task<IActionResult> MisPqrs()
        {
            // Datos esperados de la DB
            List<AtencionViajerosPqrsVM>? pqrs = await _pqrsRepository.ObtenerListaAtencionViajerosPqrsVM("ASDF");

            return View(pqrs);
        }


        [HttpGet]
        [Route("pqrs/mensajes/{id?}")]
        public IActionResult Mensajes(int id)
        {
            // Datos esperados de la DB
            List<MensajesPqrsVM>? mensajes = null;

            return Ok(mensajes);
        }

        [HttpPost]
        [Route("pqrs/mensajes")]
        public IActionResult Mensajes(MensajesPqrsPostVM mensaje)
        {
            return Ok();
        }
    }
}
