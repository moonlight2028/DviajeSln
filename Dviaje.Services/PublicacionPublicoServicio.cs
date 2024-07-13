using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Services.IServices;

namespace Dviaje.Services
{
    public class PublicacionPublicoServicio : IPublicacionPublicoServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public PublicacionPublicoServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void ObtenerPublicacion(int idPublicacion)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Publicacion> ObtenerPublicaciones(int numeroPaginacion, int pagina)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Publicacion> ObtenerPublicacionesFavoritas()
        {
            throw new NotImplementedException();
        }
    }
}
