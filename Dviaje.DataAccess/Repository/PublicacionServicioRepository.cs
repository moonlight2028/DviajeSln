using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;

namespace Dviaje.DataAccess.Repository
{
    public class PublicacionServicioRepository : Repository<PublicacionServicio>, IPublicacionServicioRepository
    {
        private readonly ApplicationDbContext _db;

        public PublicacionServicioRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PublicacionServicio PublicacionServicio)
        {
            _db.PublicacionesServicios.Update(PublicacionServicio);
        }
    }
}
