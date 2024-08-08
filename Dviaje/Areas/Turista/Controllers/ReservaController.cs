using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Turista.Controllers
{

    [Area("Turista")]

    public class ReservaController : Controller
    {
        //Datos para ingresar a la base de datos
        private readonly IUnitOfWork _db;

        //inyeccion 
        public ReservaController(IUnitOfWork _db)
        {
            this._db = _db;
        }

        public IActionResult Reserva(int? idPublicacion)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reserva(Reserva reserva)
        {
            if (ModelState.IsValid == false)
            {

                return View(reserva);
            }
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
