using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    public class ReservaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Turista/Reserva/Reserva
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
                // Recargar la publicación en caso de error para mostrarse en la vista
                reserva.Publicacion = await _unitOfWork.PublicacionRepository.GetAsync(p => p.IdPublicacion == reserva.IdPublicacion);
                return View(reserva);
            }

            await _unitOfWork.ReservaRepository.AddAsync(reserva);
            await _unitOfWork.Save();
            return RedirectToAction(nameof(MisReservas));
        }

        // GET: Turista/Reserva/MisReservas
        public async Task<IActionResult> MisReservas()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var reservas = await _unitOfWork.ReservaRepository.GetAllAsync(r => r.IdUsuario == userId);
            reservas = reservas.Include(r => r.Publicacion); // Incluye la propiedad relacionada

            return View(reservas);
        }

        // GET: Turista/Reserva/MiReserva/5
        public async Task<IActionResult> MiReserva(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _unitOfWork.ReservaRepository.GetAsync(r => r.IdReserva == id, includeProperties: "Publicacion,Usuario");

            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // Método opcional para cancelar una reserva
        public async Task<IActionResult> CancelarReserva(int id)
        {
            var reserva = await _unitOfWork.ReservaRepository.GetAsync(r => r.IdReserva == id);

            if (reserva == null)
            {
                return NotFound();
            }

            _unitOfWork.ReservaRepository.Remove(reserva);
            await _unitOfWork.Save();
            return RedirectToAction(nameof(MisReservas));
        }
    }
}
