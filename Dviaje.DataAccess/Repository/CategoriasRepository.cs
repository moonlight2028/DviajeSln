using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;

namespace Dviaje.DataAccess.Repository
{
    public class CategoriasRepository : ICategoriasRepository
    {
        public Task<bool> CrearCategoriaAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<Restriccion?> ObtenerCategoriaPorIdAsync(int idCategoria)
        {
            throw new NotImplementedException();
        }

        public Task<List<Categoria>> ObtenerCategoriasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ActualizarCategoriaAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarCategoriaAsync(int idCategoria)
        {
            throw new NotImplementedException();
        }
    }
}
