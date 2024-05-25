using Dviaje.Models;
namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPublicacionRepository : IRepository<Publicacion>
    {
        void Update(Publicacion publicacion);
    }
}
