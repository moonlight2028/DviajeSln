using Dviaje.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Turista.Controllers
{

    [Area("Turista")]

    public class ReservaController : Controller
    {


		
        public IActionResult Reserva(Reserva reserva)
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReservaPost(Reserva reserva)
        {
            return View();
        }

        public IActionResult MisReservas()
		{
			return View();
		}

		public IActionResult MiReserva()
		{
			return View();
		}
	}
}
