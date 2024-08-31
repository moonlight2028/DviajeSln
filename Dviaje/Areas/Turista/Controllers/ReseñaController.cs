using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
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

        // Muestra las reservas pasadas donde el usuario aún no ha hecho reseñas
        public async Task<IActionResult> Disponibles(int? paginaActual = 1)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtiene el ID del usuario autenticado
            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var reservas = await _unitOfWork.ReservaRepository
                .GetAllAsync(r => r.IdUsuario == userId && r.FechaFinal <= DateTime.Now, includeProperties: "Publicacion");

            if (reservas == null || !reservas.Any())
            {
                return RedirectToAction("SinResenas");
            }

            var disponibles = reservas.Select(r => new ResenaDisponibleTarjetaVM
            {
                IdReserva = r.IdReserva,
                TituloPublicacion = r.Publicacion.Titulo,
                DescripcionPublicacion = r.Publicacion.Descripcion,
                FechaInicio = r.FechaInicial,
                FechaFin = r.FechaFinal,
                ImagenUrl = r.Publicacion.Imagen,
                PuedeReseñar = !r.Resena.Any() // Verifica si la reserva ya tiene una reseña
            }).ToList();

            int pageSize = 10;
            var paginatedDisponibles = disponibles
                .Skip((paginaActual.Value - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.PaginaActual = paginaActual.Value;
            ViewBag.TotalPaginas = (int)Math.Ceiling(disponibles.Count() / (double)pageSize);

            return View(paginatedDisponibles);
        }

        // Muestra las reseñas hechas por el usuario
        public async Task<IActionResult> MisReseñas(int? paginaActual)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtiene el ID del usuario autenticado
            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var resenas = await _unitOfWork.ResenaRepository.ObtenerMisResenasAsync(userId, 10, paginaActual ?? 1);

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

        // Elimina un "Me Gusta" en una reseña
        [HttpDelete]
        [ActionName("MeGusta")]
        public async Task<IActionResult> EliminarMeGusta(int id)
        {
            // Implementar la lógica de eliminación de "Me gusta"
            return Ok();
        }
    }
}
