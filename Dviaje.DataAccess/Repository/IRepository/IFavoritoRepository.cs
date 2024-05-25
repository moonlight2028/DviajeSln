using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IFavoritoRepository : IRepository<Favorito>
    {
        void Update(Favorito favorito);
    }
}
