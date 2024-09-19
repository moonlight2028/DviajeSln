using Dviaje.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    //[Authorize(Roles = RolesUtility.RoleAdministrador)]
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
            // Espera la lista de reservas antes de aplicar LINQ
            var reservasList = await _reservaRepository.GetAll(); // Asegúrate de que GetAll() devuelva una lista de ReservaTarjetaV2VM

            // Luego puedes aplicar LINQ sobre la lista
            var reservasData = reservasList
                .GroupBy(r => r.FechaInicial.Value.Date)  // Agrupar por la fecha inicial de la reserva
                .Select(grp => new
                {
                    Fecha = grp.Key,
                    Cantidad = grp.Count()
                })
                .ToList();

            return Json(reservasData);
        }


        // Reporte de Publicaciones por Cantidad
        [HttpGet]
        public async Task<IActionResult> PublicacionesReporte()
        {
            //var publicacionesList = await _publicacionRepository.GetAll();
            //var publicacionesData = publicacionesList
            //    .GroupBy(p => p.Categoria)
            //    .Select(grp => new
            //    {
            //        Categoria = grp.Key,
            //        Cantidad = grp.Count()
            //    })
            //    .ToList();

            //return Json(publicacionesData);
            return Ok();
        }


        // Reporte de PQRS por Tipo
        [HttpGet]
        public async Task<IActionResult> Pqrs()
        {
            //var pqrsData = await _pqrsRepository.GetAll()
            //    .GroupBy(p => p.TipoPqrs)
            //    .Select(grp => new
            //    {
            //        Tipo = grp.Key,
            //        Cantidad = grp.Count()
            //    })
            //    .ToListAsync();

            //return Json(pqrsData);

            return Ok();
        }

        // Reporte de Reseñas por Publicación
        [HttpGet]
        public async Task<IActionResult> Resenas()
        {
            //var resenasData = await _resenaRepository.GetAll()
            //    .GroupBy(r => r.PublicacionId)
            //    .Select(grp => new
            //    {
            //        PublicacionId = grp.Key,
            //        Cantidad = grp.Count()
            //    })
            //    .ToListAsync();

            //return Json(resenasData);

            return Ok();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
