using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IRestriccionRepository : IRepository<Restriccion>
    {
        void Udpate(Restriccion restriccion);
    }
}
