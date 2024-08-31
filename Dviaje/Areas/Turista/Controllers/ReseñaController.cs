using System.Security.Claims;
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

        // Muestra las reservas pasadas donde el usuario aún no ha hecho reseñas
        public async Task<IActionResult> Disponibles(int? paginaActual = 1)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtiene el ID del usuario autenticado

            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.PaginaActual = paginaActual.Value;
            // Pendiente
            //ViewBag.TotalPaginas = (int)Math.Ceiling(disponibles.Count() / (double)pageSize);

            return View();
        }

        // Muestra las reseñas hechas por el usuario
        public async Task<IActionResult> MisReseñas(int? paginaActual)
        {
            // Validacion pagina
            if (paginaActual == null || paginaActual < 1) paginaActual = 1;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtiene el ID del usuario autenticado
            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var resenas = await _unitOfWork.ResenaRepository.ObtenerMisResenasAsync(userId, 10, Convert.ToInt16(paginaActual));

            if (resenas == null || !resenas.Any())
            {
                return RedirectToAction("SinResenas");
            }

            return View(resenas);
        }

        // Muestra la vista "SinResenas" si no hay reseñas disponibles
        public IActionResult SinResenas()
        {
            return View();
        }

        // Muestra la vista para crear una nueva reseña
        public IActionResult Crear(int reservaId)
        {
            var resena = new Resena { IdReserva = reservaId };
            return View(resena);
        }

        // Guarda la reseña creada en la base de datos
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

        // Incrementa el contador de "Me Gusta" en una reseña
        [HttpPost]
        [ActionName("MeGusta")]
        public async Task<IActionResult> CrearMeGusta()
        {
            // Obtener usuario
            // Registrar informacion en ResenaMeGusta

            return Ok();
        }

        // Elimina un "Me Gusta" en una reseña
        [HttpDelete]
        [ActionName("MeGusta")]
        public async Task<IActionResult> EliminarMeGusta()
        {
            // Implementar la lógica de eliminación de "Me gusta"
            return Ok();
        }
    }
}
