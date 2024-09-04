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

        // Constructor con inyección de dependencias para acceder al repositorio de reservas y al servicio de envío de correos
        public ReservaController(IReservaRepository reservaRepository, IEnvioEmail envioEmail)
        {
            _reservaRepository = reservaRepository;
            _envioEmail = envioEmail;
        }

        // GET: Muestra el formulario de reserva para una publicación específica
        public async Task<IActionResult> Reservar(int? idPublicacion)
        {
            // Si no se proporciona un id de publicación, redirige a la página de publicaciones
            if (!idPublicacion.HasValue)
            {
                return RedirectToAction("Index", "Publicaciones");
            }

            // Crea un nuevo ViewModel de ReservaCrearVM para pasar datos a la vista
            var reservaFormulario = new ReservaCrearVM
            {
                IdPublicacion = idPublicacion.Value,
                ServiciosAdicionales = new List<ServicioAdicionalVM>() // Cargar servicios adicionales si es necesario
            };

            // Aquí se podrían cargar servicios adicionales específicos de la publicación si es necesario

            return View(reservaFormulario);
        }

        // POST: Registra una nueva reserva en la base de datos
        [HttpPost]
        public async Task<IActionResult> Reservar(ReservaCrearVM reservaFormCrear)
        {
            // Verifica que el modelo de datos sea válido
            if (!ModelState.IsValid)
            {
                return View(reservaFormCrear); // Si no es válido, vuelve a mostrar el formulario con los errores
            }

            // Obtiene el ID del usuario autenticado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            reservaFormCrear.IdUsuario = userId; // Asigna el ID del usuario al ViewModel, nescita corrieccion para saber si es string o int 
            //help xdxdxd

            // Llama al método del repositorio para registrar la reserva en la base de datos
            var success = await _reservaRepository.RegistrarReservaAsync(reservaFormCrear);

            // Si el registro es exitoso, redirige a la lista de reservas
            if (success)
            {
                // Aquí podrías implementar la lógica para enviar correos de confirmación
                // await _envioEmail.EnviarCorreoDeReservaAsync(...);
                return RedirectToAction(nameof(MisReservas));
            }

            return View(reservaFormCrear); // Si el registro falla, muestra de nuevo el formulario
        }

        // GET: Muestra la lista de reservas del usuario autenticado
        public async Task<IActionResult> MisReservas(int? pagina, string? estado)
        {
            // Obtiene el ID del usuario autenticado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Llama al método del repositorio para obtener todas las reservas del usuario
            var reservas = await _reservaRepository.GetAllReservasAsync(userId);

            // Si no hay reservas, muestra la vista "SinReservas"
            if (reservas == null || !reservas.Any())
            {
                return View("SinReservas");
            }

            // Aquí podrías implementar la lógica de paginación si es necesario

            return View(reservas); // Muestra la lista de reservas
        }

        // GET: Muestra los detalles de una reserva específica
        public async Task<IActionResult> MiReserva(int? idReserva)
        {
            // Si no se proporciona un ID de reserva, redirige a la lista de reservas
            if (!idReserva.HasValue)
            {
                return RedirectToAction(nameof(MisReservas));
            }

            // Llama al método del repositorio para obtener los detalles de la reserva
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
            // Llama al método del repositorio para cancelar la reserva en la base de datos
            var success = await _reservaRepository.CancelarReservaAsync(reservaId);

            // Si la cancelación es exitosa, retorna un resultado Ok
            if (success)
            {
                return Ok(new { success = true });
            }

            return BadRequest(new { success = false }); // Si falla, retorna un resultado de error
        }
    }
}
