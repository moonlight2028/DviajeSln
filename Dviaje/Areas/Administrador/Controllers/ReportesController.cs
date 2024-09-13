using Dviaje.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dviaje.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    [Authorize(Roles = "Administrador")] // Solo accesible para administradores
    public class ReportesController : Controller
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IPublicacionesRepository _publicacionRepository;
        private readonly IPqrsRepository _pqrsRepository;
        private readonly IResenasRepository _resenaRepository;

        // Inyección de dependencias
        public ReportesController(IReservaRepository reservaRepository,
                                  IPublicacionesRepository publicacionRepository,
        IPqrsRepository pqrsRepository,
                                  IResenasRepository resenaRepository)
        {
            _reservaRepository = reservaRepository;
            _publicacionRepository = publicacionRepository;
            _pqrsRepository = pqrsRepository;
            _resenaRepository = resenaRepository;
        }

        // Reporte de Reservas por Fecha
        [HttpGet]
        public async Task<IActionResult> Reservas()
        {
            var reservasData = await _reservaRepository.GetAll()
                .GroupBy(r => r.FechaReserva.Date)
                .Select(grp => new
                {
                    Fecha = grp.Key,
                    Cantidad = grp.Count()
                })
                .ToListAsync();

            return Json(reservasData);
        }

        // Reporte de Publicaciones por Cantidad
        [HttpGet]
        public async Task<IActionResult> PublicacionesReporte()
        {
            var publicacionesData = await _publicacionRepository.GetAll()
                .GroupBy(p => p.Categoria)
                .Select(grp => new
                {
                    Categoria = grp.Key,
                    Cantidad = grp.Count()
                })
                .ToListAsync();

            return Json(publicacionesData);
        }

        // Reporte de PQRS por Tipo
        [HttpGet]
        public async Task<IActionResult> Pqrs()
        {
            var pqrsData = await _pqrsRepository.GetAll()
                .GroupBy(p => p.TipoPqrs)
                .Select(grp => new
                {
                    Tipo = grp.Key,
                    Cantidad = grp.Count()
                })
                .ToListAsync();

            return Json(pqrsData);
        }

        // Reporte de Reseñas por Publicación
        [HttpGet]
        public async Task<IActionResult> Resenas()
        {
            var resenasData = await _resenaRepository.GetAll()
                .GroupBy(r => r.PublicacionId)
                .Select(grp => new
                {
                    PublicacionId = grp.Key,
                    Cantidad = grp.Count()
                })
                .ToListAsync();

            return Json(resenasData);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
