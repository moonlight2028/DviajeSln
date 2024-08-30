using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    public class ReseñaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReseñaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Disponibles(int? paginaActual)
        {
            return View();
        }

        public IActionResult MisReseñas(int? paginaActual)
        {
            return View();
        }

        public IActionResult Crear(int reservaId)
        {
            // Crear una nueva reseña asociada a una reserva
            var resena = new Resena { IdReserva = reservaId };
            return View(resena);
        }

        [HttpPost]
        public IActionResult Crear(Resena resena)
        {
            if (ModelState.IsValid)
            {
                // Guardar la nueva reseña en la base de datos
                _unitOfWork.ResenaRepository.AddAsync(resena);
                _unitOfWork.Save();
                return RedirectToAction("Index", new { reservaId = resena.IdReserva });
            }

            return View(resena);
        }

        [HttpPost]
        [ActionName("MeGusta")]
        public async Task<IActionResult> CrearMeGusta(int id)
        {
            /*
             * Referencia borrar despues
            var resena = await _unitOfWork.ResenaRepository.GetAsync(r => r.IdResena == id);
            if (resena == null)
            {
                return NotFound();
            }

            resena.MeGusta += 1;
            _unitOfWork.ResenaRepository.Update(resena);
            await _unitOfWork.Save();
            */
            return Ok();
        }

        [HttpDelete]
        [ActionName("MeGusta")]
        public async Task<IActionResult> EliminarMeGusta(int id)
        {
            return Ok();
        }

    }
}
