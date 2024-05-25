using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
namespace Dviaje.DataAccess.Repository
{
    public class ResenaRepository : Repository<Resena>, IResenaRepository
    {
        private readonly ApplicationDbContext _db;

        public ResenaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Resena resena)
        {
            _db.Resenas.Update(resena);
        }
    }
}
