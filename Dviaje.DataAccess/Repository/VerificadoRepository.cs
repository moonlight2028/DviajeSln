using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;

namespace Dviaje.DataAccess.Repository
{
    public class VerificadoRepository : Repository<Verificado>, IVerificadoRepository
    {
        private readonly ApplicationDbContext _db;
        public VerificadoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Verificado verificado)
        {
            _db.Verificados.Update(verificado);
        }
    }
}
