using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Dviaje.Services.IServices;
using Dviaje.Utility;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    [Authorize(Roles = RolesUtility.RoleTurista)]
    public class ReservasController : Controller
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IEnvioEmailService _envioEmail;
        private IValidator<ReservaCrearVM> _reservaCrearVMValidator;


        public ReservasController(IReservaRepository reservaRepository, IEnvioEmailService envioEmail, IValidator<ReservaCrearVM> reservaCrearVMValidator)
        {
            _reservaRepository = reservaRepository;
            _envioEmail = envioEmail;
            _reservaCrearVMValidator = reservaCrearVMValidator;
        }


        [Route("reserva/mi-reserva/{id?}")]
        public async Task<IActionResult> MiReserva(int? id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!id.HasValue)
            {
                return RedirectToAction(nameof(MisReservas));
            }

            var reservaDetalles = await _reservaRepository.ObtenerReservaMiReservaAsync((int)id, userId);

            if (reservaDetalles == null)
            {
                return RedirectToAction(nameof(MisReservas));
            }

            return View(reservaDetalles);
        }

        [Route("reservas/mis-reservas")]
        public async Task<IActionResult> MisReservas(int? pagina, string? estado)
        {
            // Obtiene el ID del usuario autenticado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Llama al repositorio con los parámetros de paginación y estado
            var reservas = await _reservaRepository.ObtenerListaReservaTarjetaBasicaVMAsync(userId, pagina ?? 1, 10, estado);

            // Lógica para la paginación (descomentar si es necesaria)
            ViewBag.PaginacionPaginas = (reservas?.Count ?? 0) / 10;
            ViewBag.PaginacionItems = 10;
            ViewBag.PaginacionResultados = await _reservaRepository.ObtenerTotalReservas(userId);

            return View(reservas);
        }


        [Route("reservar/{id?}")]
        public async Task<IActionResult> Reservar(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Publicaciones", "Publicaciones", new { area = "Dviaje" });
            }

            var reservaFormulario = await _reservaRepository.ObtenerReservaCrearVMAsync((int)id);

            if (reservaFormulario == null)
            {
                return RedirectToAction("Publicaciones", "Publicaciones", new { area = "Dviaje" });
            }

            return View(reservaFormulario);
        }

        [HttpPost]
        [Route("reservar/{id?}")]
        public async Task<IActionResult> Reservar(ReservaCrearVM reservaFormCrear)
        {
            // Validaciones
            var validacion = await _reservaCrearVMValidator.ValidateAsync(reservaFormCrear);

            if (!validacion.IsValid)
            {
                foreach (var error in validacion.Errors)
                {
                    ModelState.AddModelError($"{error.PropertyName}", error.ErrorMessage);
                }
            }
            if (!ModelState.IsValid)
            {
                var reservaFormulario = await _reservaRepository.ObtenerReservaCrearVMAsync(reservaFormCrear.IdPublicacion);

                if (reservaFormulario == null)
                {
                    return RedirectToAction("Publicaciones", "Publicaciones", new { area = "Dviaje" });
                }
                return View(reservaFormulario);
            }
            // TODO: Validacion fechas disponibles


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            reservaFormCrear.IdUsuario = userId;
            // TODO: Calcular precio
            reservaFormCrear.PrecioTotal = 15616515m;


            var registro = await _reservaRepository.RegistrarReservaAsync(reservaFormCrear);

            // Si la reserva es exitosa
            if (!registro)
            {
                return View(reservaFormCrear);
            }

            return RedirectToAction(nameof(MisReservas));
        }



        [HttpPut]
        [Route("reserva/cancelar/{id?}")]
        public async Task<IActionResult> CancelarReserva(int? id)
        {
            // Llama al método del repositorio para cancelar la reserva
            var success = await _reservaRepository.CancelarReservaAsync((int)id, "sdfsadf");

            // Si la cancelación es exitosa, retorna una respuesta Ok
            if (success)
            {
                return Ok(new { success = true });
            }

            return BadRequest(new { success = false }); // Si falla, retorna un error
        }

        [HttpGet]
        [Route("reserva/resumen/{id?}")]
        public async Task<IActionResult> ReservaTarjetaResumen(int? id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reservaTarjeta = await _reservaRepository.ObtenerReservaTarjetaResumenVMAsync((int)id, "26cfe5c9-00f8-411e-b589-df3405a8b798");

            return Ok();
        }
    }
}
