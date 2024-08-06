using Dviaje.Models;
using Dviaje.Models.VM;
namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPublicacionRepository : IRepository<Publicacion>
    {
        void Update(Publicacion publicacion);
        Task<List<PublicacionPublicacionesVM>> GetPublicacionesAsync(int page, int pageSize);
    }
}
