using Dviaje.Models;
using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IFavoritoRepository : IRepository<Favorito>
    {
        void Update(Favorito favorito);
        Task<List<PublicacionTarjetaVM>>? ObtenerFavoritos(int pagina = 0);
    }
}
