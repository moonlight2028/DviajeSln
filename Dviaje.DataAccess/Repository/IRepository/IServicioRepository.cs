using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IServicioRepository : IRepository<Servicio>
    {
        void Update(Servicio servicio);
    }
}
