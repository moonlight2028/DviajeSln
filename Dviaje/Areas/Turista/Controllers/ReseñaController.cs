using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    public class ReseñaController : Controller
    {
        private readonly IResenasRepository _resenaRepository;

        public ReseñaController(IResenasRepository resenaRepository)
        {
            _resenaRepository = resenaRepository;
        }


        public async Task<IActionResult> TopResenas(int cantidad = 10)
        {
            var resenasTop = await _resenaRepository.ObtenerResenasTopAsync(cantidad);

            if (resenasTop == null || !resenasTop.Any())
            {
                return View("SinResenas");
            }

            return View(resenasTop);
        }


        // GET: Muestra las reseñas disponibles para que el usuario pueda reseñar
        public async Task<IActionResult> Disponibles(int? pagina)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtiene el ID del usuario autenticado
            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var paginaActual = pagina ?? 1;
            var resenasDisponibles = await _resenaRepository.ObtenerResenasDisponiblesAsync(userId, paginaActual);

            if (resenasDisponibles == null || !resenasDisponibles.Any())
            {
                return View("SinResenas");
            }

            return View(resenasDisponibles);
        }

        // GET: Muestra las reseñas realizadas por el usuario
        public async Task<IActionResult> MisReseñas(int? pagina)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var paginaActual = pagina ?? 1;
            var resenas = await _resenaRepository.ObtenerMisResenasAsync(userId, paginaActual);

            if (resenas == null || !resenas.Any())
            {
                return View("SinResenas");
            }

            return View(resenas);
        }

        // GET: Crea una nueva reseña asociada a una reserva
        public IActionResult Crear(int? IdReserva)
        {
            if (!IdReserva.HasValue)
            {
                return RedirectToAction(nameof(Disponibles));
            }

            var resenaFormulario = new ResenaCrearVM
            {
                IdReserva = IdReserva.Value,
                Fecha = DateTime.Now // Fecha actual para la reseña
            };

            return View(resenaFormulario);
        }

        // POST: Guarda la nueva reseña
        [HttpPost]
        public async Task<IActionResult> Crear(ResenaCrearVM resenaCrear)
        {
            if (!ModelState.IsValid)
            {
                return View(resenaCrear);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var validacion = await _resenaRepository.ValidarReservaParaResenaAsync(resenaCrear.IdReserva, userId);

            if (!validacion)
            {
                return RedirectToAction(nameof(MisReseñas));
            }

            var success = await _resenaRepository.CrearResenaAsync(resenaCrear);
            if (success)
            {
                return RedirectToAction(nameof(MisReseñas));
            }

            return View(resenaCrear);
        }

        // POST: Incrementa el contador de "Me Gusta" en una reseña
        [HttpPost]
        [ActionName("MeGusta")]
        public async Task<IActionResult> CrearMeGusta(int? idResena)
        {
            if (!idResena.HasValue)
            {
                return BadRequest();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var success = await _resenaRepository.AgregarMeGustaAsync(idResena.Value, userId);

            if (success)
            {
                return Ok();
            }

            return BadRequest();
        }

        // DELETE: Elimina el "Me Gusta" en una reseña
        [HttpDelete]
        [ActionName("MeGusta")]
        public async Task<IActionResult> EliminarMeGusta(int? idResena)
        {
            if (!idResena.HasValue)
            {
                return BadRequest();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var success = await _resenaRepository.EliminarMeGustaAsync(idResena.Value, userId);

            if (success)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
