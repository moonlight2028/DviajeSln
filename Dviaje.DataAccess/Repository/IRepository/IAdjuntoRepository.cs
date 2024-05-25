using Dviaje.Models;
namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IAdjuntoRepository : IRepository<Adjunto>
    {
        void Update(Adjunto adjunto);
    }
}
