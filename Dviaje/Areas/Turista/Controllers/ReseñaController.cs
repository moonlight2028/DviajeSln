using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        public async Task<IActionResult> Disponibles(int idPublicacion, int? paginaActual = 1)
        {
            if (idPublicacion == 0)
            {
                return RedirectToAction("Error", "Home");
            }

            var resenas = await _unitOfWork.ResenaRepository.ObtenerResenasAsync(idPublicacion);

            if (resenas == null)
            {
                return RedirectToAction("Error", "Home");
            }

            int pageSize = 10;
            var paginatedResenas = resenas
                .Skip((paginaActual.Value - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.PaginaActual = paginaActual.Value;
            ViewBag.TotalPaginas = (int)Math.Ceiling(resenas.Count() / (double)pageSize);

            return View(paginatedResenas);
        }

        public async Task<IActionResult> MisReseñas(int? paginaActual)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtiene el ID del usuario autenticado
            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var resenas = await _unitOfWork.ResenaRepository.ObtenerMisResenasAsync(userId, paginaActual ?? 1, 10);

            if (resenas == null || !resenas.Any())
            {
                return RedirectToAction("Index", "Home");
            }

            return View(resenas);
        }


        public IActionResult Crear(int reservaId)
        {
            var resena = new Resena { IdReserva = reservaId };
            return View(resena);
        }

        [HttpPost]
        public IActionResult Crear(Resena resena)
        {
            if (ModelState.IsValid)
            {
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
            var resena = await _unitOfWork.ResenaRepository.GetAsync(r => r.IdResena == id);
            if (resena == null)
            {
                return NotFound();
            }

            resena.MeGusta += 1;
            _unitOfWork.ResenaRepository.Update(resena);
            await _unitOfWork.Save();

            return Ok(new { success = true, newCount = resena.MeGusta });
        }

        [HttpDelete]
        [ActionName("MeGusta")]
        public async Task<IActionResult> EliminarMeGusta(int id)
        {

            return Ok();
        }
    }
}
