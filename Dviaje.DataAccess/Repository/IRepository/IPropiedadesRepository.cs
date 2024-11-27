using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPropiedadesRepository
    {
        Task<List<Propiedad>> ObtenerPropiedadesPorCategoriaAsync(int idCategoria);
    }
}
