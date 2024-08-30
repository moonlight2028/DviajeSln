using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IResenaMeGustaRepository : IRepository<ResenaMeGustaRepository>
    {
        void Update(Resena resena);
    }
}
