using Dviaje.Models;
using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IReservaRepository
    {
        Task<ReservaMiReservaVM?> ObtenerReservaMiReservaAsync(int idReserva, string idUsuario);
        Task<ReservaMiReservaVM?> ObtenerReservaMiReservaPorAliadoAsync(int idReserva, string idAliado);
        Task<List<ReservaTarjetaBasicaVM>?> ObtenerListaReservaTarjetaBasicaVMAsync(string idUsuario, int pagina = 1, int resultadosMostrados = 10, string? estado = null);
        Task<int> ObtenerTotalReservas(string idUsuario, ReservaEstado? estado = null);
        Task<ReservaCrearVM?> ObtenerReservaCrearVMAsync(int idPublicacion);
        Task<bool> RegistrarReservaAsync(ReservaCrearVM reservaCrearVM);
        Task<bool> CancelarReservaAsync(int idReserva, string idUsuario);
        Task<ReservaTarjetaResumenVM?> ObtenerReservaTarjetaResumenVMAsync(int idReserva, string idUsuario);
        Task<List<ReservaTablaItemVM>?> ObtenerListaReservaTablaItemVMAsync(string idAliado);
    }
}
