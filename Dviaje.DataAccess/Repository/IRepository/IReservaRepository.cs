using Dviaje.Models;
using Dviaje.Models.VM;
namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IReservaRepository : IRepository<Reserva>
    {
        void Update(Reserva reserva);
        Task<List<ReservaTarjetaVM>?> GetReservaTarjetas();
        Task<ReservaTarjetaVM?> GetReservaTarjetaPorId(int id);
    }



}
