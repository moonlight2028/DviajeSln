using Dviaje.Models;
using Dviaje.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class PqrsController : Controller
    {

        private IEnvioEmail _email;

        public PqrsController(IEnvioEmail email)
        {
            _email = email;
        }

        public async Task<IActionResult> Pqrs()
        {
            await _email.EnviarEmail("sex", "joansebastianft9@gmail.com", "sexNow", "todas mias", "<h1>nigga</h1>");


            return View();
        }




        [HttpPost]
        public IActionResult Pqrs(AtencionViajero atencionViajero)
        {
            if (!ModelState.IsValid)
            {
                return View(atencionViajero);

            }

            return View();
        }
    }
}
