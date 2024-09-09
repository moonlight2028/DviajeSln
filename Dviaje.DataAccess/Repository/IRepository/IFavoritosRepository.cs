using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IFavoritosRepository
    {
        Task<List<FavoritoTarjetaVM>> GetFavoritosByUsuarioAsync(string idUsuario);
        Task<bool> CrearFavoritoAsync(int idPublicacion, string idUsuario);
        Task<bool> EliminarFavoritoAsync(int idPublicacion, string idUsuario);
    }
}
