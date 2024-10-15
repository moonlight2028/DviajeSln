using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dviaje.Areas.Aliado.Controllers
{
    [Area("Aliado")]
    [Authorize(Roles = RolesUtility.RoleAliado)]
    public class ReservasController : Controller
    {
        private readonly IReservaRepository _reservaRepository;


        public ReservasController(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }


        [Route("reservas/detalle/{id?}")]
        public async Task<IActionResult> Detalle(int? id)
        {
            var reservaDetalles = await _reservaRepository.ObtenerReservaMiReservaAsync((int)id, "IDALIADO");

            return View();
        }


        [HttpGet]
        [Route("reservas")]
        public async Task<IActionResult> Reservas()
        {
            // Id del usuario auntenticado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Verificar si el ID de usuario está disponible (en caso de que no esté autenticado)
            if (userId == null)
            {
                return Unauthorized(); // errorr si el usuario no está autenticado
            }

            // Llamada al metodo
            List<ReservaTablaItemVM>? reservas = await _reservaRepository.ObtenerListaReservaTablaItemVMAsync(userId);

            return Ok(reservas);
        }


        [HttpPut]
        [Route("reserva/alido/cancelar/{id?}")]
        public async Task<IActionResult> CancelarReserva(int idReserva)
        {
            // Obtener ID del usuario 
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // usuario esté autenticado
            if (userId == null)
            {
                return Unauthorized();
            }

            //cancelar la reserva
            var success = await _reservaRepository.CancelarReservaAsync(idReserva, userId);

            if (success)
            {
                // respuesta si la cancelación se cumplio 
                return RedirectToAction(nameof(Reservas));
            }

            //mensaje de error
            ModelState.AddModelError("", "No se pudo cancelar la reserva.");
            return RedirectToAction(nameof(Reservas));
        }

    }
}
