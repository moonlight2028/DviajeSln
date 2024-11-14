using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IResenasRepository
    {
        Task<bool> CrearResenaAsync(ResenaCrearVM resenaCrear);
        Task<List<ResenaTarjetaBasicaVM>?> ObtenerListaResenaTarjetaBasicaVMAsync(int idPublicacion, int pagina = 1, int resultadosMostrados = 10);
        Task<List<ResenaTarjetaDisponibleVM>?> ObtenerListaResenaTarjetaDisponibleVMAsync(string idUsuario, int pagina = 1, int resultadosMostrados = 10);
        Task<List<ResenaTarjetaDetalleVM>?> ObtenerListaResenaTarjetaDetalleAsync(string idUsuario, int pagina = 1, int resultadosMostrados = 10);
        Task<List<ResenaTarjetaRecibidaVM>?> ObtenerListaResenaTarjetaRecibidaVMAsync(string idAliado, int pagina = 1, int resultadosMostrados = 10, string? ordenar = null);
        Task<bool> AgregarMeGustaAsync(int idResena, string idUsuario);
        Task<bool> EliminarMeGustaAsync(int idResena, string idUsuario);
        Task<int> ObtenerMeGustaCountAsync(int idResena);
        Task<bool> ValidarReservaParaResenaAsync(int idReserva, string idUsuario);
        Task<bool> VerificarSiUsuarioLeDioLike(int idResena, string idUsuario);
    }
}