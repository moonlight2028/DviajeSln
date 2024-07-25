using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Turista.Controllers
{

    [Area("Turista")]

    public class ReservaController : Controller
    {



        public IActionResult Reserva()
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
