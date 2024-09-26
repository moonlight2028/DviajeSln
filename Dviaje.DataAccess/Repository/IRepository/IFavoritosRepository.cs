using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IFavoritosRepository
    {
        Task<List<FavoritoTarjetaVM>?> ObtenerListaFavoritoTarjetaVMAsync(string idUsuario);
        Task<int> FavoritosGuardadosTotal(string idUsuario);
        Task<bool> CrearFavoritoAsync(int idPublicacion, string idUsuario);
        Task<bool> EliminarFavoritoAsync(int idPublicacion, string idUsuario);
    }
}
