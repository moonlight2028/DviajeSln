using Dviaje.Models.VM;
using Dviaje.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class PqrsController : Controller
    {
        private IEnvioEmail _email;


        // Inyección en el controlador.
        public PqrsController(IEnvioEmail email)
        {
            _email = email;
        }


        public async Task<IActionResult> Pqrs()
        {

            ViewBag.SesionInicaida = false;
            //Validar si l usuario valido session
            //Si la sesion esta iniciada cambiar el viebag a verdadero

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Pqrs(PqrsRegistrarVM pqrsRegistrarVM)
        {


            return View();
        }

    }
}
