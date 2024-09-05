using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IResenasRepository
    {
        Task<List<ResenaDisponibleTarjetaVM>> ObtenerResenasDisponiblesAsync(string idUsuario, int paginaActual, int elementosPorPagina = 10);
        Task<List<ResenasTarjetaVM>> ObtenerMisResenasAsync(string idUsuario, int paginaActual, int elementosPorPagina = 10);
        Task<bool> ValidarReservaParaResenaAsync(int idReserva, string idUsuario);
        Task<bool> CrearResenaAsync(ResenaCrearVM resenaCrear);
        Task<bool> AgregarMeGustaAsync(int idResena, string idUsuario);
        Task<bool> EliminarMeGustaAsync(int idResena, string idUsuario);
        Task<List<ResenasTarjetaVM>> ObtenerResenasTopAsync(int cantidad); //pruba de top reseñas 
    }
}
