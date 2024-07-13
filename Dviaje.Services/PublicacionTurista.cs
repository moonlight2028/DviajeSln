using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Services.IServices;

namespace Dviaje.Services
{
    public class PublicacionTurista : IPublicacionTuristaServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public PublicacionTurista(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AgregarPublicacion(int idPublicacion)
        {
            throw new NotImplementedException();
        }

        public void EliminarPublicacion(int idPublicacion)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Publicacion> PublicacionesFavoritas(string idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
