using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;

namespace Dviaje.DataAccess.Repository
{
    public class ServicioAdicionalRepository : Repository<ServicioAdicional>, IServicioAdicionalRepository
    {
        private readonly ApplicationDbContext _db;

        public ServicioAdicionalRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ServicioAdicional servicioAdicional)
        {
            _db.ServiciosAdicionales.Update(servicioAdicional);
        }
    }
}
