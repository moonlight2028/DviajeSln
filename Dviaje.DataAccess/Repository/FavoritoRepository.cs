using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;

namespace Dviaje.DataAccess.Repository
{
    public class FavoritoRepository : Repository<Favorito>, IFavoritoRepository
    {
        private readonly ApplicationDbContext _db;

        public FavoritoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Favorito favorito)
        {
            _db.Favoritos.Update(favorito);
        }
    }
}
