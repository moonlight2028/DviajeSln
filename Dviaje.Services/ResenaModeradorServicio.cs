using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Services.IServices;

namespace Dviaje.Services
{
    public class ResenaModeradorServicio : IResenasModeradorServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResenaModeradorServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void EliminarResena(int IdResena)
        {
            throw new NotImplementedException();
        }
    }
}
