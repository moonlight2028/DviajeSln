using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPubliacaionImagenRepository : IRepository<PublicacionImagen>
    {
        void Update(PublicacionImagen publicacionImagen);
    }
}
