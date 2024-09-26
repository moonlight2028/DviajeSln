using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    [Authorize(Roles = RolesUtility.RoleAdministrador)]
    public class ReportesController : Controller
    {
        private readonly IPublicacionesRepository _publicacionRepository;


        public ReportesController(IPublicacionesRepository publicacionRepository)
        {
            _publicacionRepository = publicacionRepository;
        }


        [Route("reportes/publicaciones")]
        public IActionResult Publicaciones()
        {
            return View();
        }


        [HttpGet]
        [Route("publicaciones/reportes")]
        public async Task<IActionResult> ReportePublicaciones()
        {
            List<ReportesPublicacionesPorMesVM>? publicacionesPorMes = await _publicacionRepository.ReportePublicacionesPorMesAsync();
            List<ReportesPublicacionesTopCategoriaVM>? topCategorias = await _publicacionRepository.ReporteTopCategoriasAsync();
            List<ReportesPublicacionesActivasVM>? publicacionesActivas = await _publicacionRepository.ReportePublicacionesActivasAsync();
            List<ReportesPublicacionesPreciosVM>? preciosPromedios = await _publicacionRepository.ReportePreciosPromediosAsync();
            List<ReportesPublicacionesTopPublicacionesVM>? topPublicaciones = await _publicacionRepository.ReporteTopPublicacionesAsync();
            ReportesPublicacionesDetallesVM? detalles = await _publicacionRepository.ReporteDetallesAsync(DateTime.Now);

            var resultado = new
            {
                PublicacionesPorMes = publicacionesPorMes,
                TopCategorias = topCategorias,
                PublicacionesActivas = publicacionesActivas,
                PreciosPromedios = preciosPromedios,
                TopPublicaciones = topPublicaciones,
                Detalles = detalles
            };

            return Ok(resultado);
        }
    }
}
