using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Services.IServices;

namespace Dviaje.Services
{
    public class PqrsPublicoServicio : IPqrsPublicoServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public PqrsPublicoServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void RegistrarPqrs(AtencionViajero atencionViajero)
        {
            throw new NotImplementedException();
        }
    }
}
