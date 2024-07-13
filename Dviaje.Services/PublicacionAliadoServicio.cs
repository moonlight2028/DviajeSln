using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Services.IServices;

namespace Dviaje.Services
{
    public class PublicacionAliadoServicio : IPublicacionAliadoServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public PublicacionAliadoServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CrearPublicacion(Publicacion publicacion)
        {
            throw new NotImplementedException();
        }

        public void EditarPublicacion(Publicacion publicacion)
        {
            throw new NotImplementedException();
        }

        public void EliminarPublicacion(int idPublicacion)
        {
            throw new NotImplementedException();
        }

        public void PausarPublicacion(int idPublicacion)
        {
            throw new NotImplementedException();
        }
    }
}
