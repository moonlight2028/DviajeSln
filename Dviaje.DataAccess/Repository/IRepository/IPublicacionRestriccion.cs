using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPublicacionRestriccion : IRepository<PublicacionRestriccion>
    {
        void Update(PublicacionRestriccion publicacionRestriccion);
    }
}
