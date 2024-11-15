using Dviaje.DataAccess.Repository.IRepository;
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

        /// <summary>
        /// Muestra el detalle de una reserva específica en una publicación del aliado.
        /// </summary>
        /// <param name="id">ID de la reserva</param>
        /// <returns>Vista con detalles de la reserva o un mensaje de error si no se encuentra.</returns>
        [Route("reservas/detalle/{id?}")]
        public async Task<IActionResult> Detalle(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound("La reserva especificada no existe.");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reservaDetalles = await _reservaRepository.ObtenerReservaMiReservaAsync(id.Value, userId);

            if (reservaDetalles == null)
            {
                return NotFound("No se encontró la reserva para la publicación del aliado.");
            }

            return View(reservaDetalles);
        }

        /// <summary>
        /// Obtiene la lista de reservas en las publicaciones del aliado.
        /// </summary>
        /// <returns>Vista con la lista de reservas o un mensaje si no hay reservas.</returns>
        [HttpGet]
        [Route("reservas")]
        public async Task<IActionResult> Reservas()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reservas = await _reservaRepository.ObtenerListaReservaTablaItemVMAsync(userId);

            if (reservas == null || !reservas.Any())
            {
                return NotFound("No se encontraron reservas en las publicaciones del aliado.");
            }

            return View(reservas);
        }

        /// <summary>
        /// Cancela una reserva específica en una publicación del aliado.
        /// </summary>
        /// <param name="id">ID de la reserva a cancelar</param>
        /// <returns>Resultado de la operación de cancelación.</returns>
        [HttpPut]
        [Route("reserva/aliado/cancelar/{id?}")]
        public async Task<IActionResult> CancelarReserva(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var success = await _reservaRepository.CancelarReservaAsync(id, userId);

            if (success)
            {
                return Ok("La reserva ha sido cancelada exitosamente.");
            }

            return BadRequest("No se pudo cancelar la reserva.");
        }
    }
}
