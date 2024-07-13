using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Services.IServices;

namespace Dviaje.Services
{
    public class ReservaTuristaServicio : IReservasTuristaServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservaTuristaServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CancelarReserva(int IdReserva)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reserva> MisReservas(int numeroPaginacion, string idUsuario)
        {
            throw new NotImplementedException();
        }

        public void Reservar(Reserva reserva)
        {
            throw new NotImplementedException();
        }
    }
}
