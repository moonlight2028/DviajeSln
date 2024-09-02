using Dviaje.Models.VM;
using Dviaje.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class PqrsController : Controller
    {
        // Repositorios necesitados
        private IEnvioEmail _email;


        // Inyección de repositorios
        public PqrsController(IEnvioEmail email)
        {
            _email = email;
        }


        public async Task<IActionResult> Pqrs()
        {
            ViewBag.SesionInicaida = false;

            // Validar si el usuario inició sesión


            // Si la sesión está iniciada, cambiar el ViewBag a verdadero


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Pqrs(PqrsVM pqrs)
        {
            // Validar Modelo

            // Completar datos faltantes al modelo desde el controlador.

            // Consulta de registro

            return View();
        }



    }
}
