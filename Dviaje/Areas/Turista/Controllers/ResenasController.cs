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


        [Route("reseña/escribir/{id?}")]
        public IActionResult Crear(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(nameof(Disponibles));
            }

            // Agregar validaciones de lógica de negocio

            var resenaFormulario = new ResenaCrearVM
            {
                IdReserva = id.Value
            };

            return View(resenaFormulario);
        }

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

        [Route("reseñas/disponibles/{pagina?}")]
        public async Task<IActionResult> Disponibles(int? pagina)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtiene el ID del usuario autenticado

            var paginaActual = pagina ?? 1;

            var resenasDisponibles = await _resenaRepository.ObtenerListaResenaTarjetaDisponibleVMAsync(userId, paginaActual, 10);

            return View(resenasDisponibles);
        }

        [Route("reseñas/mis-reseñas/{pagina?}")]
        public async Task<IActionResult> MisReseñas(int? pagina)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var paginaActual = pagina ?? 1;

            var resenas = await _resenaRepository.ObtenerListaResenaTarjetaDetalleAsync(userId, paginaActual, 10);

            return View(resenas);
        }


        [HttpPost]
        [Route("resena/like/{id?}")]
        public async Task<IActionResult> CrearMeGusta(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var success = await _resenaRepository.AgregarMeGustaAsync(id.Value, userId);
            if (success)
            {
                var meGustaCount = await _resenaRepository.ObtenerMeGustaCountAsync(id.Value);
                return Ok(new { meGusta = meGustaCount });
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("resena/like/{id?}")]
        public async Task<IActionResult> EliminarMeGusta(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var success = await _resenaRepository.EliminarMeGustaAsync(id.Value, userId);
            if (success)
            {
                var meGustaCount = await _resenaRepository.ObtenerMeGustaCountAsync(id.Value);
                return Ok(new { meGusta = meGustaCount });
            }

            return BadRequest();
        }















        // Acción para mostrar las reseñas con más "Me Gusta"
        //public async Task<IActionResult> TopResenas(int cantidad = 10)
        //{
        //    var resenasTop = await _resenaRepository.ObtenerResenasTopAsync(cantidad);

        //    if (resenasTop == null || !resenasTop.Any())
        //    {
        //        return View("SinResenas");
        //    }

        //    return View(resenasTop);
        //}


















        // POST: Incrementa el contador de "Me Gusta" en una reseña (usando endpoint asíncrono)


    }
}

