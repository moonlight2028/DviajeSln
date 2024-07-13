using Dviaje.Models;

namespace Dviaje.Services.IServices
{
    public interface IResenasPublicoServicio
    {
        IEnumerable<Resena> ObtenerTodas(int numeroPaginacion, int pagina);
        void ObtenerPorId(int idResena);
    }
}
