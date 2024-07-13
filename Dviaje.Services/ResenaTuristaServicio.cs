using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Services.IServices;

namespace Dviaje.Services
{
    public class ResenaTuristaServicio : IResenasTuristaServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResenaTuristaServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CrearResenia(Resena resena)
        {
            throw new NotImplementedException();
        }
    }
}
