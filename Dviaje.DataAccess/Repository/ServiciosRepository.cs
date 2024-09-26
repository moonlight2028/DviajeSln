using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;

namespace Dviaje.DataAccess.Repository
{
    public class ServiciosRepository : IServiciosRepository
    {
        public Task<bool> CrearServicioAsync(Servicio servicio)
        {
            throw new NotImplementedException();
        }

        public Task<Servicio?> ObtenerServicioPorIdAsync(int idServicio)
        {
            throw new NotImplementedException();
        }

        public Task<List<Servicio>?> ObtenerServiciosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ActualizarServicioAsync(Servicio servicio)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarServicioAsync(int idServicio)
        {
            throw new NotImplementedException();
        }
    }
}
