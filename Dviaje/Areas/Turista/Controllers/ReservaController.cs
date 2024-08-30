using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    public class ReservaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEnvioEmail _envioEmail;

        public ReservaController(IUnitOfWork unitOfWork, IEnvioEmail envioEmail)
        {
            _unitOfWork = unitOfWork;
            _envioEmail = envioEmail;
        }

        public async Task<IActionResult> Reserva(int? idPublicacion)
        {
            if (idPublicacion == null)
            {
                return NotFound();
            }

            var publicacion = await _unitOfWork.PublicacionRepository.GetAsync(p => p.IdPublicacion == idPublicacion);

            if (publicacion == null)
            {
                return NotFound();
            }

            // Modelo para la vista con datos iniciales
            var reserva = new Reserva
            {
                IdPublicacion = publicacion.IdPublicacion,
                Publicacion = publicacion,
                FechaInicial = DateTime.Now,
                FechaFinal = DateTime.Now.AddDays(1),
                NumeroPersonas = 1
            };

            return View(reserva);
        }

        // POST: Turista/Reserva/Reserva
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reserva(Reserva reserva)
        {
            if (!ModelState.IsValid)
            {
                reserva.Publicacion = await _unitOfWork.PublicacionRepository.GetAsync(p => p.IdPublicacion == reserva.IdPublicacion);
                return View(reserva);
            }

            await _unitOfWork.ReservaRepository.AddAsync(reserva);
            await _unitOfWork.Save();

            // Enviar correo de confirmación al turista
            var turista = await _unitOfWork.UsuariosTest.GetAsync(u => u.Id == reserva.IdUsuario);
            var aliado = await _unitOfWork.UsuariosTest.GetAsync(u => u.Id == reserva.Publicacion.IdAliado);

            string asunto = "Confirmación de Reserva";
            string cuerpoCorreoTurista = $"Hola {turista.Avatar}, tu reserva para {reserva.Publicacion.Titulo} ha sido confirmada.";
            string cuerpoCorreoAliado = $"Hola {aliado.Avatar}, se ha realizado una nueva reserva para tu publicación {reserva.Publicacion.Titulo}.";

            await _envioEmail.EnviarEmail(asunto, turista.Email, turista.Avatar, cuerpoCorreoTurista, "<p>" + cuerpoCorreoTurista + "</p>");
            await _envioEmail.EnviarEmail(asunto, aliado.Email, aliado.Avatar, cuerpoCorreoAliado, "<p>" + cuerpoCorreoAliado + "</p>");

            TempData["Success"] = "Reserva realizada exitosamente y correos enviados.";

            return RedirectToAction(nameof(MisReservas));
        }

        // GET: Turista/Reserva/MisReservas
        public async Task<IActionResult> MisReservas()
        {
            var reservas = await _unitOfWork.ReservaRepository.GetReservaTarjetas();

            if (reservas == null || !reservas.Any())
            {
                return View("NoReservas"); // Si no tienes reservas (en proceso)
            }

            return View(reservas);
        }


        // GET: Turista/Reserva/MiReserva/5
        public async Task<IActionResult> MiReserva(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Llamada al nuevo método GetReservaTarjetaPorId
            var reserva = await _unitOfWork.ReservaRepository.GetReservaTarjetaPorId(id.Value);

            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }



        // cancelar una reserva
        public async Task<IActionResult> CancelarReserva(int reservaId)
        {
            var reserva = await _unitOfWork.ReservaRepository.GetAsync(r => r.IdReserva == reservaId);
            if (reserva == null)
            {
                return NotFound();
            }

            var diasParaReserva = (reserva.FechaInicial - DateTime.Now).TotalDays;
            if (diasParaReserva < 8)
            {
                TempData["Error"] = "No se puede cancelar la reserva, faltan menos de 8 días.";
                return RedirectToAction("MisReservas"); // Redirigir a las reservas del usuario
            }

            reserva.ReservaEstado = ReservaEstado.Cancelado;
            _unitOfWork.ReservaRepository.Update(reserva);
            await _unitOfWork.Save();
            TempData["Success"] = "Reserva cancelada exitosamente.";

            return RedirectToAction("MisReservas");
        }
    }
}
