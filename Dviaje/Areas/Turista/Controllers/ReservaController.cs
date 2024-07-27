using Dviaje.DataAccess.Repository;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Turista.Controllers
{

    [Area("Turista")]

    public class ReservaController : Controller
    {
        //Datos para ingresar a la base de datos
        private readonly IUnitOfWork _db;
        private IValidator<Reserva> _validator;

        //inyeccion 
        public ReservaController(IUnitOfWork _db, IValidator<Reserva>_validator)
        {
            this._db = _db;
            this._validator = _validator;

        }

        public IActionResult Reserva()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reserva(Reserva reserva)
        {
            var resultadoValidacion = _validator.Validate(reserva);
            if (!resultadoValidacion.IsValid)
            {

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
