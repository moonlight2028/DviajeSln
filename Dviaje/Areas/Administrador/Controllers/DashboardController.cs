using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Admin.Controllers
{
    [Area("Administrador")]
    [Authorize(Roles = "Administrador")] // Solo administradores pueden acceder
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;

        // Constructor para la inyección de dependencias
        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        // Acción principal del dashboard
        public async Task<IActionResult> PanelControl()
        {
            // Obtener los datos del dashboard desde el repositorio
            var dashboardData = await _dashboardRepository.ObtenerDatosDashboardAsync();

            // Verificar si los datos están disponibles
            if (dashboardData == null)
            {
                TempData["Error"] = "No se pudieron cargar los datos del dashboard.";
                return View(new DashboardVM()); // Enviar un modelo vacío si hay error
            }

            return View(dashboardData);
        }

        // Acción para obtener datos específicos como parte de las gráficas
        public async Task<IActionResult> ObtenerDatosReservasMensuales()
        {
            // Consulta de reservas agrupadas por mes
            var reservasPorMes = await _dashboardRepository.ObtenerReservasMensualesAsync();

            if (reservasPorMes == null || !reservasPorMes.Any())
            {
                return Json(new { success = false, message = "No se encontraron datos." });
            }

            return Json(new { success = true, data = reservasPorMes });
        }

        // Acción para generar reportes de usuarios, reservas y publicaciones
        public async Task<IActionResult> GenerarReporte()
        {
            var reporte = await _dashboardRepository.GenerarReporteCompletoAsync();

            if (reporte == null)
            {
                TempData["Error"] = "Error al generar el reporte.";
                return RedirectToAction(nameof(Index));
            }

            // Descarga el archivo generado
            return File(reporte, "application/pdf", "ReporteAdministrador.pdf");
        }
    }
}
