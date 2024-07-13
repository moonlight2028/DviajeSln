using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Services.IServices;

namespace Dviaje.Services
{
    public class ReporteAdministradorServicio : IResenasModeradorServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReporteAdministradorServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void EliminarResena(int IdResena)
        {
            throw new NotImplementedException();
        }
    }
}
