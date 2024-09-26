using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;

namespace Dviaje.DataAccess.Repository
{
    public class RestriccionesRepository : IRestriccionesRepository
    {
        public Task<bool> CrearRestriccionAsync(Restriccion restriccion)
        {
            throw new NotImplementedException();
        }

        public Task<Restriccion?> ObtenerRestriccionPorIdAsync(int idRestriccion)
        {
            throw new NotImplementedException();
        }

        public Task<List<Restriccion>?> ObtenerRestriccionesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ActualizarRestriccionAsync(Restriccion restriccion)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarRestriccionAsync(int idRestriccion)
        {
            throw new NotImplementedException();
        }
    }
}
