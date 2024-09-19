using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IResenasRepository
    {
        // Obtener las reseñas disponibles para que el usuario las pueda reseñar
        Task<List<ResenaDisponibleTarjetaVM>> ObtenerResenasDisponiblesAsync(string idUsuario, int paginaActual, int elementosPorPagina = 10);

        // Obtener las reseñas ya realizadas por el usuario
        Task<List<ResenasTarjetaVM>> ObtenerMisResenasAsync(string idUsuario, int paginaActual, int elementosPorPagina = 10);

        // Validar si una reserva puede ser reseñada
        Task<bool> ValidarReservaParaResenaAsync(int idReserva, string idUsuario);

        // Crear una nueva reseña
        Task<bool> CrearResenaAsync(ResenaCrearVM resenaCrear);

        // Añadir "Me Gusta" a una reseña
        Task<bool> AgregarMeGustaAsync(int idResena, string idUsuario);

        // Eliminar "Me Gusta" de una reseña
        Task<bool> EliminarMeGustaAsync(int idResena, string idUsuario);

        // Obtener las reseñas con más "Me Gusta"
        Task<List<ResenasTarjetaVM>> ObtenerResenasTopAsync(int cantidad);

        // Obtener las reseñas públicas de una publicación
        Task<List<ResenasTarjetaVM>> ObtenerResenasPorPublicacionAsync(int idPublicacion, int paginaActual, int elementosPorPagina = 10);

        // Obtener las mejores 3 reseñas de una publicación
        Task<List<ResenasTarjetaVM>> ObtenerTopResenasPorPublicacionAsync(int idPublicacion, int cantidad = 3);

        Task<int> ObtenerMeGustaCountAsync(int idResena);
    }
}