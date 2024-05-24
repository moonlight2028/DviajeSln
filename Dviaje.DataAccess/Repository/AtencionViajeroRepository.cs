using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;

namespace Dviaje.DataAccess.Repository
{
    public class AtencionViajeroRepository : Repository<AtencionViajero>, IAtencionViajeroRepository
    {
        private readonly ApplicationDbContext _db;
        public AtencionViajeroRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AtencionViajero atencionViajero)
        {
            _db.AtencionViajeros.Update(atencionViajero);
        }
    }
}
