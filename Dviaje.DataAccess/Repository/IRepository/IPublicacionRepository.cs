using Dviaje.Models;
using Dviaje.Models.VM;
using System.Linq.Expressions;
namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPublicacionRepository : IRepository<Publicacion>
    {
        void Update(Publicacion publicacion);
        Task<List<PublicacionTarjetaVM>> GetPublicacionesAsync(int page, int pageSize, Expression<Func<Publicacion, object>>? orderBy = null);
        Task<PublicacionVM?> GetPublicacionAsync(int idPublicacion);
        Task<int> GetTotalPublicacionesAsync();
    }
}
