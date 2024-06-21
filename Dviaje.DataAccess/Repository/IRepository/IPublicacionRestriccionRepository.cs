using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPublicacionRestriccionRepository : IRepository<PublicacionRestriccion>
    {
        void Update(PublicacionRestriccion publicacionRestriccion);
    }
}
