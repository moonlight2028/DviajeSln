using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Services.IServices;

namespace Dviaje.Services
{
    internal class PqrsModeradorServicio : IPqrsModeradorServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public PqrsModeradorServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<AtencionViajeroTipoPqrs> ListarPqrs(int NumeroPaginacion, int Pagina)
        {
            throw new NotImplementedException();
        }

        public void ResponderPqrs(int IdPqrs)
        {
            throw new NotImplementedException();
        }
    }
}
