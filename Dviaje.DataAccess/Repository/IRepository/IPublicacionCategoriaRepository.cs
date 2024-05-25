using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPublicacionCategoriaRepository : IRepository<PublicacionCategoria>
    {
        void Update(PublicacionCategoria publicacionCategoria);
    }
}
