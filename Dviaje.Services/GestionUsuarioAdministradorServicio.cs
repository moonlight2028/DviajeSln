using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Services.IServices;

namespace Dviaje.Services
{
    public class GestionUsuarioAdministradorServicio : IGestionUsuariosAdministradorServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public GestionUsuarioAdministradorServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void ModificarRol(string IdUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
