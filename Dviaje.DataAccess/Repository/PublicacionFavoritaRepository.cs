using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
namespace Dviaje.DataAccess.Repository
{
    public class PublicacionFavoritaRepository : Repository<PublicacionFavorita>, IPublicacionFavoritaRepository
    {
        private readonly ApplicationDbContext _db;

        public PublicacionFavoritaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(PublicacionFavorita publicacionFavorita)
        {
            _db.PublicacionesFavoritas.Update(publicacionFavorita);
        }
    }
}
