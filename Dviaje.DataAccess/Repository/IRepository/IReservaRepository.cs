using Dviaje.Models;
namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IReservaRepository : IRepository<Reserva>
    {
        void Update(Reserva reserva);
    }
}
