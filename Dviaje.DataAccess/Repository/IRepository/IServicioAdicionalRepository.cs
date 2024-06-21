using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IServicioAdicionalRepository : IRepository<ServicioAdicional>
    {
        void Update(ServicioAdicional servicioAdicional);
    }
}
