using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        void Update(Usuario usuario);
    }
}
