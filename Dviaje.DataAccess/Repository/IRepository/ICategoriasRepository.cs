using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface ICategoriasRepository
    {
        Task<bool> CrearCategoriaAsync(Categoria categoria);
        Task<Categoria> ObtenerCategoriaPorIdAsync(int idCategoria);
        Task<List<Categoria>> ObtenerCategoriasAsync();
        Task<bool> ActualizarCategoriaAsync(Categoria categoria);
        Task<bool> EliminarCategoriaAsync(int idCategoria);
    }
}
