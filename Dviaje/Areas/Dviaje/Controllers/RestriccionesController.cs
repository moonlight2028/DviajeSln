using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class RestriccionesController : Controller
    {
        private readonly IRestriccionesRepository _restriccionesRepository;


        public RestriccionesController(IRestriccionesRepository restriccionesRepository)
        {
            _restriccionesRepository = restriccionesRepository;
        }


        [HttpGet]
        [Route("Restricciones")]
        public async Task<IActionResult> Restricciones()
        {
            // Consulta
            List<Restriccion>? restriccionesLista = await _restriccionesRepository.ObtenerRestriccionesAsync();

            return Ok();
        }
    }
}
