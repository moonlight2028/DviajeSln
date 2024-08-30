using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;

namespace Dviaje.DataAccess.Repository
{
    public class ResenaMeGustaRepository : Repository<ResenaMeGustaRepository>, IResenaMeGustaRepository
    {
        private readonly ApplicationDbContext _db;

        public ResenaMeGustaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Resena resena)
        {
            throw new NotImplementedException();
        }
    }
}
