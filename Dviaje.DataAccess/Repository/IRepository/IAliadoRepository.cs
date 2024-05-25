using Dviaje.Models;
namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IAliadoRepository : IRepository<Aliado>
    {
        void Update(Aliado aliado);
    }
}
