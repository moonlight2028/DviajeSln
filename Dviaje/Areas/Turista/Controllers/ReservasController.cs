using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Dviaje.Services.IServices;
using Dviaje.Utility;
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
        private readonly IEnvioEmail _envioEmail;


        public ReservasController(IReservaRepository reservaRepository, IEnvioEmail envioEmail)
        {
            _reservaRepository = reservaRepository;
            _envioEmail = envioEmail;
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

            var reservas = await _reservaRepository.ObtenerListaReservaTarjetaBasicaVMAsync();

            // Paso de argumentos de paginación a la vista
            //ViewBag.PaginacionPaginas = paginasTotales;
            //ViewBag.PaginacionItems = numeroPublicaciones;
            //ViewBag.PaginacionResultados = await _reservaRepository.ObtenerTotalReservas(userId, estado);

            return View(reservas);
        }

        [Route("reservar/{id?}")]
        public async Task<IActionResult> Reservar(int? id)
        {
            // Verifica si el ID de publicación es válido
            if (!id.HasValue)
            {
                return RedirectToAction("Publicaciones", "Publicaciones", new { area = "Dviaje" });
            }

            // Inicializa un ViewModel de ReservaCrearVM para la vista
            var reservaFormulario = await _reservaRepository.ObtenerReservaCrearVMAsync((int)id);

            if (reservaFormulario == null)
            {
                return RedirectToAction("Publicaciones", "Publicaciones", new { area = "Dviaje" });
            }

            return View(reservaFormulario);
        }

        [HttpPost]
        public async Task<IActionResult> Reservar(ReservaCrearVM reservaFormCrear)
        {
            // Verifica si el modelo es válido
            if (!ModelState.IsValid)
            {
                return View(reservaFormCrear); // Devuelve el formulario con errores
            }

            // Obtiene el ID del usuario autenticado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            reservaFormCrear.IdUsuario = userId; // Asigna el ID del usuario (string) al ViewModel

            // Llama al método del repositorio para registrar la reserva
            var success = await _reservaRepository.RegistrarReservaAsync(reservaFormCrear);

            // Si la reserva es exitosa
            if (success)
            {
                // Opción para enviar correos de confirmación
                // await _envioEmail.EnviarCorreoDeReservaAsync(...);
                return RedirectToAction(nameof(MisReservas)); // Redirige a la lista de reservas
            }

            return View(reservaFormCrear); // Si falla, muestra nuevamente el formulario
        }


        [HttpPut]
        [Route("reserva/cancelar/{id?}")]
        public async Task<IActionResult> CancelarReserva(int? id)
        {
            // Llama al método del repositorio para cancelar la reserva
            var success = await _reservaRepository.CancelarReservaAsync((int)id);

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
            var reservaTarjeta = await _reservaRepository.ObtenerReservaTarjetaResumenVMAsync((int)id, "ASDF");

            return Ok();
        }
    }
}
