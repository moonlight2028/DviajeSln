using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    internal interface IUsuarioRepository : IRepository<Usuario>
    {
        void Update(Usuario usuario);
    }
}
