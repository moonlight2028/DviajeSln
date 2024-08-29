using Dviaje.Models;
using Dviaje.Models.VM;
namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IResenaRepository : IRepository<Resena>
    {
        void Update(Resena resena);
        Task<List<ResenaTarjetaVM>>? ObtenerResenasAsync(int idPublicacion, int? elementoPorPagina = null, int paginaActual = 0);
        Task<List<ResenaTarjetaVM>>? ObtenerMisResenasAsync(int idUsuario, int? elementoPorPagina = null, int paginaActual = 0);
    }
}
