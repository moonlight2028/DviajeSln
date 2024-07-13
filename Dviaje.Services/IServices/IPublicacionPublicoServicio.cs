using Dviaje.Models;

namespace Dviaje.Services.IServices
{
    public interface IPublicacionPublicoServicio
    {
        IEnumerable<Publicacion> ObtenerPublicaciones(int numeroPaginacion, int pagina);
        void ObtenerPublicacion(int idPublicacion);
        IEnumerable<Publicacion> ObtenerPublicacionesFavoritas();
    }
}
