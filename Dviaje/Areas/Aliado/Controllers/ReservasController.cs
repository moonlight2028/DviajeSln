using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dviaje.Areas.Aliado.Controllers
{
    [Area("Aliado")]
    //[Authorize(Roles = RolesUtility.RoleAliado)]
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

            // Llamada al metodo
            List<ReservaTablaItemVM>? reservas = await _reservaRepository.ObtenerListaReservaTablaItemVMAsync("01bfd429-16ea-44b3-902c-794e2c78dfa7");

            if (reservas == null || !reservas.Any()) { 
                return NotFound();
            }

            return Ok(reservas);
        }


        [HttpPut]
        [Route("reserva/alido/cancelar/{id?}")]
        public async Task<IActionResult> CancelarReserva(int id)
        {
            // Obtener ID del usuario 
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //cancelar la reserva
            var success = await _reservaRepository.CancelarReservaAsync(id, userId);

            if (success)
            {
                // respuesta si la cancelación se cumplio 
                return Ok();
            }

            return BadRequest("No se pudo cancelar la reserva.");
        }

    }
}
