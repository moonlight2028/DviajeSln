using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;

namespace Dviaje.DataAccess.Repository
{
    public class PublicacionRestriccionRepository : Repository<PublicacionRestriccion>, IPublicacionRestriccion
    {
        private readonly ApplicationDbContext _db;

        public PublicacionRestriccionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PublicacionRestriccion publicacionRestriccion)
        {
            _db.PublicacionesRestricciones.Update(publicacionRestriccion);
        }
    }
}
