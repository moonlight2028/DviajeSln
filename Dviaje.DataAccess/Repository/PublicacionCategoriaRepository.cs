using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;

namespace Dviaje.DataAccess.Repository
{
    public class PublicacionCategoriaRepository : Repository<PublicacionCategoria>, IPublicacionCategoriaRepository
    {
        private readonly ApplicationDbContext _db;

        public PublicacionCategoriaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PublicacionCategoria publicacionCategoria)
        {
            _db.PublicacionesCategorias.Update(publicacionCategoria);
        }
    }
}
