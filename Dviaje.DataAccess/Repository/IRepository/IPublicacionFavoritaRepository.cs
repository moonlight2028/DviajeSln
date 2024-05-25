using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPublicacionFavoritaRepository : IRepository<PublicacionFavorita>
    {
        void Update(PublicacionFavorita publicacionFavorita);
    }
}
