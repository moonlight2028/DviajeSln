using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IRestriccionesRepository
    {
        Task<bool> CrearRestriccionAsync(Restriccion restriccion);
        Task<Restriccion?> ObtenerRestriccionPorIdAsync(int idRestriccion);
        Task<List<Restriccion>?> ObtenerRestriccionesAsync();
        Task<bool> ActualizarRestriccionAsync(Restriccion restriccion);
        Task<bool> EliminarRestriccionAsync(int idRestriccion);
    }
}
