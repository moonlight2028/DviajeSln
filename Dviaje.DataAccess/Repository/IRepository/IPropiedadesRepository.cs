using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPropiedadesRepository
    {
        Task<List<Propiedad>> ObtenerPropiedadesPorCategoriaAsync(int idCategoria);
        Task<bool> VerificarCategoriaPropiedadAsync(int idCategoria, int idPropiedad);
        Task<List<Propiedad>> ObtenerPropiedadesAsync();
        Task<Propiedad?> ObtenerPropiedadPorIdAsync(int idPropiedad);
        Task<bool> CrearPropiedadAsync(Propiedad propiedad);
        Task<bool> ActualizarPropiedadAsync(Propiedad propiedad);
        Task<bool> EliminarPropiedadAsync(int idPropiedad);
    }
}
