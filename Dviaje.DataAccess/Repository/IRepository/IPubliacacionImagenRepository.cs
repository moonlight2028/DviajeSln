using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPubliacacionImagenRepository : IRepository<PublicacionImagen>
    {
        void Update(PublicacionImagen publicacionImagen);
    }
}
