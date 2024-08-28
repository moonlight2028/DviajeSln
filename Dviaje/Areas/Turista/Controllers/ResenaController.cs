using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    public class ResenaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResenaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Resena(int reservaId)
        {
            // Obtener todas las reseñas para una reserva específica
            var resenas = await _unitOfWork.ReservaRepository.GetAsync(r => r.IdReserva == reservaId);
            return View();
        }

        public IActionResult Crear(int reservaId)
        {
            // Crear una nueva reseña asociada a una reserva
            var resena = new Resena { IdReserva = reservaId, Fecha = DateTime.Now };
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

        public IActionResult Editar(int id)
        {
            // Obtener la reseña por su ID para editarla
            var resena = _unitOfWork.ResenaRepository.GetAsync(r => r.IdResena == id);
            if (resena == null)
            {
                return NotFound();
            }

            return View(resena);
        }

        [HttpPost]
        public IActionResult Editar(Resena resena)
        {
            if (ModelState.IsValid)
            {
                // Actualizar la reseña en la base de datos
                _unitOfWork.ResenaRepository.Update(resena);
                _unitOfWork.Save();
                return RedirectToAction("Index", new { reservaId = resena.IdReserva });
            }

            return View(resena);
        }

        public IActionResult Eliminar(int id)
        {
            // Obtener la reseña para confirmación de eliminación
            var resena = _unitOfWork.ResenaRepository.GetAsync(r => r.IdResena == id);
            if (resena == null)
            {
                return NotFound();
            }

            return View(resena);
        }

        [HttpPost, ActionName("Eliminar")]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            // Obtener la reseña de la base de datos por ID
            var resena = await _unitOfWork.ResenaRepository.GetAsync(r => r.IdResena == id);
            if (resena == null)
            {
                return NotFound();
            }

            // Eliminar la reseña
            _unitOfWork.ResenaRepository.Remove(resena);
            await _unitOfWork.Save();

            return RedirectToAction("Index", new { reservaId = resena.IdReserva });
        }



        [HttpPost]
        public async Task<IActionResult> MeGusta(int id)
        {
            var resena = await _unitOfWork.ResenaRepository.GetAsync(r => r.IdResena == id);
            if (resena == null)
            {
                return NotFound();
            }

            resena.MeGusta += 1;
            _unitOfWork.ResenaRepository.Update(resena);
            await _unitOfWork.Save();

            return Json(new { meGusta = resena.MeGusta });
        }



    }
}
