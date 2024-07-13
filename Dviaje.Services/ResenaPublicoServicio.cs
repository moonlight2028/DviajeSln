using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Services.IServices;

namespace Dviaje.Services
{
    public class ResenaPublicoServicio : IResenasPublicoServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResenaPublicoServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void ObtenerPorId(int idResena)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Resena> ObtenerTodas(int numeroPaginacion, int pagina)
        {
            throw new NotImplementedException();
        }
    }
}
