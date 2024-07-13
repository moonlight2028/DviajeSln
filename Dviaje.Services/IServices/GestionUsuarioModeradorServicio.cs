using Dviaje.DataAccess.Repository.IRepository;

namespace Dviaje.Services.IServices
{
    public class GestionUsuarioModeradorServicio : IGestionUsuarioModeradorServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public GestionUsuarioModeradorServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Banear(string idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
