using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            List<ReservaTablaItemVM>? reservas = await _reservaRepository.ObtenerListaReservaTablaItemVMAsync("IDALIADO");

            return Ok(reservas);
        }

        [HttpPut]
        [Route("reserva/alido/cancelar/{id?}")]
        public async Task<IActionResult> CancelarReserva(int? id)
        {
            bool resultado = await _reservaRepository.CancelarReservaAsync((int)id);

            return Ok();
        }
    }
}
