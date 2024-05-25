using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPublicacionServicioRepository : IRepository<PublicacionServicio>
    {
        void Update(PublicacionServicio PublicacionServicio);
    }
}
