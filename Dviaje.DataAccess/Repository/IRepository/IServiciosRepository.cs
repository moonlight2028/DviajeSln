using Dviaje.Models;
using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IServiciosRepository
    {
        Task<bool> CrearServicioAsync(Servicio servicio);
        Task<Servicio?> ObtenerServicioPorIdAsync(int idServicio);
        Task<List<ServicioTipoStringVM>?> ObtenerServiciosAsync();
        Task<bool> ActualizarServicioAsync(Servicio servicio);
        Task<bool> EliminarServicioAsync(int idServicio);
    }
}
