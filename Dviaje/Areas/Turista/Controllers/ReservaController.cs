using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Dviaje.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    public class ReservaController : Controller
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IEnvioEmail _envioEmail;

        // Constructor con inyección de dependencias para el repositorio de reservas y el servicio de envío de correos
        public ReservaController(IReservaRepository reservaRepository, IEnvioEmail envioEmail)
        {
            _reservaRepository = reservaRepository;
            _envioEmail = envioEmail;
        }

        // GET: Muestra el formulario para reservar una publicación específica
        public async Task<IActionResult> Reservar(int? idPublicacion)
        {
            // Verifica si el ID de publicación es válido
            if (!idPublicacion.HasValue)
            {
                return RedirectToAction("Index", "Publicaciones"); // Redirige si no hay una publicación seleccionada
            }

            // Inicializa un ViewModel de ReservaCrearVM para la vista
            var reservaFormulario = new ReservaCrearVM
            {
                IdPublicacion = idPublicacion.Value,
                ServiciosAdicionales = new List<ServicioAdicionalVM>() // Cargar servicios adicionales 
            };



            return View(reservaFormulario);
        }

        // POST: Crea y guarda una nueva reserva en la base de datos
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

        // GET: Muestra la lista de reservas del usuario autenticado
        public async Task<IActionResult> MisReservas(int? pagina, string? estado)
        {
            // Obtiene el ID del usuario autenticado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Obtiene todas las reservas del usuario a través del repositorio
            var reservas = await _reservaRepository.GetAllReservasAsync(userId);

            // Si no hay reservas, muestra la vista "SinReservas"
            if (reservas == null || !reservas.Any())
            {
                return View("SinReservas");
            }

            //  implementar paginación,  hacerlo aquí

            return View(reservas); // Muestra la lista de reservas del usuario
        }

        // GET: Muestra los detalles de una reserva específica
        public async Task<IActionResult> MiReserva(int? idReserva)
        {
            // Verifica si el ID de la reserva es válido
            if (!idReserva.HasValue)
            {
                return RedirectToAction(nameof(MisReservas)); // Redirige si no se encuentra el ID de la reserva
            }

            // Obtiene los detalles de la reserva a través del repositorio
            var reservaDetalles = await _reservaRepository.GetReservaByIdAsync(idReserva.Value);

            // Si no se encuentra la reserva, redirige a la lista de reservas
            if (reservaDetalles == null)
            {
                return RedirectToAction(nameof(MisReservas));
            }

            return View(reservaDetalles); // Muestra los detalles de la reserva
        }

        // DELETE: Cancela una reserva específica
        [HttpDelete]
        public async Task<IActionResult> CancelarReserva(int reservaId)
        {
            // Llama al método del repositorio para cancelar la reserva
            var success = await _reservaRepository.CancelarReservaAsync(reservaId);

            // Si la cancelación es exitosa, retorna una respuesta Ok
            if (success)
            {
                return Ok(new { success = true });
            }

            return BadRequest(new { success = false }); // Si falla, retorna un error
        }
    }
}
