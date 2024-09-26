using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IServiciosRepository
    {
        Task<bool> CrearServicioAsync(Servicio servicio);
        Task<Servicio?> ObtenerServicioPorIdAsync(int idServicio);
        Task<List<Servicio>?> ObtenerServiciosAsync();
        Task<bool> ActualizarServicioAsync(Servicio servicio);
        Task<bool> EliminarServicioAsync(int idServicio);
    }
}
