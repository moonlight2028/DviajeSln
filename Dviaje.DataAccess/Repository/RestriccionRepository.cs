using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
namespace Dviaje.DataAccess.Repository
{
    public class RestriccionRepository : Repository<Restriccion>, IRestriccionRepository
    {
        private readonly ApplicationDbContext _db;

        public RestriccionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Restriccion restriccion)
        {
            _db.Restricciones.Update(restriccion);
        }
    }
}
