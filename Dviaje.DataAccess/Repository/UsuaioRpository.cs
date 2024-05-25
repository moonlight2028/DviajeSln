using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;

namespace Dviaje.DataAccess.Repository
{
    internal class UsuaioRpository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly ApplicationDbContext _db;

        public UsuaioRpository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Usuario usuario)
        {
            _db.Usuarios.Update(usuario);
        }
    }
}
