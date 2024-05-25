using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;

namespace Dviaje.DataAccess.Repository
{
    public class PublicacionImagenRepository : Repository<PublicacionImagen>, IPubliacaionImagenRepository
    {
        private readonly ApplicationDbContext _db;
        public PublicacionImagenRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PublicacionImagen publicacionImagen)
        {
            _db.PublicacionesImagenes.Update(publicacionImagen);
        }
    }
}
