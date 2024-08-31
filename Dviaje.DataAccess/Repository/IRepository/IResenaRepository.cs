using Dviaje.Models;
using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IResenaRepository : IRepository<Resena>
    {
        void Update(Resena resena);

        Task<List<ResenaTarjetaVM>> ObtenerResenasAsync(int idPublicacion, int? elementosPorPagina = null, int paginaActual = 0);

        Task<List<ResenaTarjetaVM>> ObtenerMisResenasAsync(string idUsuario, int? elementosPorPagina = null, int paginaActual = 0);
        Task<List<ResenaDisponibleTarjetaVM>> ObtenerMisResenasDisponiblesAsync(string idUsuario, int? elementosPorPagina = null, int paginaActual = 0);

        Task<bool> ValiadacionUsuarioResena(string idUsuario, int idReserva);
    }
}
