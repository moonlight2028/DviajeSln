using Dviaje.Models;
using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IUsuariosTest : IRepository<Usuario>
    {
        Task<List<UsuariosTestVM>>? ListaDeUsuarios();
        Task<List<UsuariosTestVM>>? ListaDeUsuariosDos();
        void UpdateUsuario(Usuario usuario);
    }
}
