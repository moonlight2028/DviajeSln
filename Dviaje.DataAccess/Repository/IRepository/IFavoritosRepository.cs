using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IFavoritosRepository
    {
        Task<List<FavoritoTarjetaVM>?> ObtenerListaFavoritoTarjetaVMAsync(string idUsuario, int pagina = 1, int resultadosPorPagina = 10);
        Task<int> FavoritosGuardadosTotal(string idUsuario);
        Task<bool> CrearFavoritoAsync(int idPublicacion, string idUsuario);
        Task<bool> EliminarFavoritoAsync(int idPublicacion, string idUsuario);
    }
}
