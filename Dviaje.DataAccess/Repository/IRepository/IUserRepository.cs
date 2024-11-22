using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<List<UsuarioVM>> ObtenerUsuariosAsync();
        Task<bool> CambiarRolUsuarioAsync(string idUsuario, string nuevoRol);
        Task<bool> BanearUsuarioAsync(string idUsuario);
        Task<bool> EliminarUsuarioAsync(string idUsuario);
    }

}
