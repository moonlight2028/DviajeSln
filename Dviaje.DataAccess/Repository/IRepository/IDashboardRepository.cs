using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IDashboardRepository
    {
        Task<DashboardVM> ObtenerDatosDashboardAsync();
        Task<List<ReservasMensualesVM>> ObtenerReservasMensualesAsync();
        Task<byte[]> GenerarReporteCompletoAsync();
    }
}
