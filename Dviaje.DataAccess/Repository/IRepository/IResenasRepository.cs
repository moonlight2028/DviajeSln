using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IResenasRepository
    {
        Task<List<ResenasTarjetaVM>> ObtenerMisResenasAsync(string idUsuario, int paginaActual);
        Task<List<ResenaDisponibleTarjetaVM>> ObtenerResenasDisponiblesAsync(string idUsuario, int paginaActual);
        Task<List<ResenasTarjetaVM>> ObtenerResenasTopAsync(int cantidad);
        Task<bool> CrearResenaAsync(ResenaCrearVM resenaCrear);
        Task<bool> ValidarReservaParaResenaAsync(int idReserva, string idUsuario);
        Task<bool> AgregarMeGustaAsync(int idResena, string idUsuario);
        Task<bool> EliminarMeGustaAsync(int idResena, string idUsuario);
        Task<int> ObtenerMeGustaCountAsync(int idResena);
    }
}
