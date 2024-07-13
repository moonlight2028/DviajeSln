using Dviaje.Models;

namespace Dviaje.Services.IServices
{
    public interface IReservasTuristaServicio
    {
        void Reservar(Reserva reserva);
        void CancelarReserva(int idReserva);

        IEnumerable<Reserva> MisReservas(int numeroPaginacion, string idUsuario);
    }
}
