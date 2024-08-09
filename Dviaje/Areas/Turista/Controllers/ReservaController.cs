using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public IActionResult Reserva(int? idPublicacion)
        {
            if (idPublicacion == null)
            {
                return NotFound();
            }

            var publicacion = _unitOfWork.Publicacion.GetFirstOrDefault(p => p.IdPublicacion == idPublicacion);

            if (publicacion == null)
            {
                return NotFound();
            }

            //modelo para la vista con datos iniciales
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
        public IActionResult Reserva(Reserva reserva)
        {
            if (!ModelState.IsValid)
            {
                // Recargar la publicación en caso de error para mostrarse en la vista
                reserva.Publicacion = _unitOfWork.Publicacion.GetFirstOrDefault(p => p.IdPublicacion == reserva.IdPublicacion);
                return View(reserva);
            }

            _unitOfWork.Reserva.Add(reserva);
            _unitOfWork.Save();
            return RedirectToAction(nameof(MisReservas));
        }

        // GET: Turista/Reserva/MisReservas
        public IActionResult MisReservas()
        {
            // Obtener el Id del usuario actual 
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var reservas = _unitOfWork.Reserva.GetAll(r => r.IdUsuario == userId, includeProperties: "Publicacion");
            return View(reservas);
        }

        // GET: Turista/Reserva/MiReserva/5
        public IActionResult MiReserva(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = _unitOfWork.Reserva.GetFirstOrDefault(r => r.IdReserva == id, includeProperties: "Publicacion,Usuario");

            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // Método opcional para cancelar una reserva
        public IActionResult CancelarReserva(int id)
        {
            var reserva = _unitOfWork.Reserva.GetFirstOrDefault(r => r.IdReserva == id);

            if (reserva == null)
            {
                return NotFound();
            }

            _unitOfWork.Reserva.Remove(reserva);
            _unitOfWork.Save();
            return RedirectToAction(nameof(MisReservas));
        }
    }
}
