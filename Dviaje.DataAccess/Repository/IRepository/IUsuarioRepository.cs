using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task CambiarRol(Usuario usuario, string nuevoRol);
        Task<IList<string>> GetRolesAsync(Usuario usuario);
        void Update(Usuario usuario);
    }
}
