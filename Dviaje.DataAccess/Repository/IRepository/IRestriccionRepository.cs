using Dviaje.Models;
namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IRestriccionRepository : IRepository<Restriccion>
    {
        void Update(Restriccion restriccion);
    }
}
