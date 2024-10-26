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


        //crear Reseña 
        [HttpPost]
        public async Task<IActionResult> CrearResena(ResenaCrearVM resenaCrear)
        {
            // Valida el modelo antes de continuar
            if (!ModelState.IsValid)
            {
                return View(resenaCrear);
            }

            // Obtiene el ID del usuario autenticado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return RedirectToAction("Index", "Home"); // Redirige a la página principal si no hay usuario
            }

            // Validación para asegurarse de que el usuario puede dejar una reseña para esta reserva
            var esValido = await _resenaRepository.ValidarReservaParaResenaAsync(resenaCrear.IdReserva, userId);
            if (!esValido)
            {
                TempData["Error"] = "No puedes realizar una reseña para esta reserva.";
                return RedirectToAction(nameof(MisReseñas)); // Redirige a la página de reseñas del usuario
            }

            // Completa la información de la reseña antes de guardar
            resenaCrear.Fecha = DateTime.UtcNow;

            // Llama al repositorio para crear la reseña
            var success = await _resenaRepository.CrearResenaAsync(resenaCrear);

            // Si la creación de la reseña fue exitosa, redirige a "MisReseñas"
            if (success)
            {
                return RedirectToAction(nameof(MisReseñas));
            }

            // Si la creación falla, muestra nuevamente el formulario de creación de reseña con un mensaje de error
            TempData["Error"] = "Ocurrió un error al intentar crear la reseña. Por favor, inténtalo de nuevo.";
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

