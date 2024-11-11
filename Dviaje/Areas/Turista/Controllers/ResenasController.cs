using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    [Authorize(Roles = RolesUtility.RoleTurista)]
    public class ResenasController : Controller
    {
        private readonly IResenasRepository _resenaRepository;

        public ResenasController(IResenasRepository resenaRepository)
        {
            _resenaRepository = resenaRepository;
        }

        // mostrar el formulario de creación de reseña para una reserva específica
        [Route("reseña/escribir/{id?}")]
        public IActionResult Crear(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction(nameof(Disponibles));

            var resenaFormulario = new ResenaCrearVM { IdReserva = id.Value };
            return View(resenaFormulario);
        }

        // envío de la nueva reseña creada por el usuario
        [HttpPost]
        public async Task<IActionResult> CrearResena(ResenaCrearVM resenaCrear)
        {
            if (!ModelState.IsValid)
                return View(resenaCrear);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return RedirectToAction("Index", "Home");

            var esValido = await _resenaRepository.ValidarReservaParaResenaAsync(resenaCrear.IdReserva, userId);
            if (!esValido)
            {
                TempData["Error"] = "No puedes realizar una reseña para esta reserva.";
                return RedirectToAction(nameof(MisReseñas));
            }

            resenaCrear.Fecha = DateTime.UtcNow;

            var success = await _resenaRepository.CrearResenaAsync(resenaCrear);

            if (success)
                return RedirectToAction(nameof(MisReseñas));

            TempData["Error"] = "Ocurrió un error al intentar crear la reseña. Por favor, inténtalo de nuevo.";
            return View(resenaCrear);
        }

        // reservas disponibles que el usuario puede reseñar
        [Route("reseñas/disponibles/{pagina?}")]
        public async Task<IActionResult> Disponibles(int? pagina)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var paginaActual = pagina ?? 1;

            var resenasDisponibles = await _resenaRepository.ObtenerListaResenaTarjetaDisponibleVMAsync(userId, paginaActual, 10);

            return View(resenasDisponibles);
        }

        // mostrar las reseñas creadas por el usuario actual
        [Route("reseñas/mis-reseñas/{pagina?}")]
        public async Task<IActionResult> MisReseñas(int? pagina)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var paginaActual = pagina ?? 1;

            var resenas = await _resenaRepository.ObtenerListaResenaTarjetaDetalleAsync(userId, paginaActual, 10);

            return View(resenas);
        }

        // agregar un "Me Gusta" a una reseña específica
        [HttpPost]
        [Route("resena/like/{id?}")]
        public async Task<IActionResult> CrearMeGusta(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();

            var success = await _resenaRepository.AgregarMeGustaAsync(id.Value, userId);
            if (success)
            {
                var meGustaCount = await _resenaRepository.ObtenerMeGustaCountAsync(id.Value);
                return Ok(new { meGusta = meGustaCount });
            }

            return BadRequest();
        }

        // eliminar un "Me Gusta" de una reseña específica
        [HttpDelete]
        [Route("resena/like/{id?}")]
        public async Task<IActionResult> EliminarMeGusta(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();

            var success = await _resenaRepository.EliminarMeGustaAsync(id.Value, userId);
            if (success)
            {
                var meGustaCount = await _resenaRepository.ObtenerMeGustaCountAsync(id.Value);
                return Ok(new { meGusta = meGustaCount });
            }

            return BadRequest();
        }
    }
}
