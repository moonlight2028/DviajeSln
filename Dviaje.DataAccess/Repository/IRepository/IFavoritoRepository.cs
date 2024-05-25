using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    internal interface IFavoritoRepository : IRepository<Favorito>
    {
        void Update(Favorito favorito);
    }
}
