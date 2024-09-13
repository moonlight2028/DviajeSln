using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IReservaRepository
    {
        Task<List<ReservaTarjetaV2VM>> GetAllReservasAsync(string idUsuario);
        Task<ReservaTarjetaV3VM> GetReservaByIdAsync(int idReserva);
        Task<bool> RegistrarReservaAsync(ReservaCrearVM reservaCrearVM);
        Task<bool> CancelarReservaAsync(int idReserva);
        Task<bool> SaveAsync();
        Task<List<ReservaTarjetaV2VM>> GetAll();




    }
}
