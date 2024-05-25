using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        void Update(Categoria categoria);
    }
}
