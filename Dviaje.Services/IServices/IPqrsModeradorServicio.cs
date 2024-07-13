using Dviaje.Models;

namespace Dviaje.Services.IServices
{
    public interface IPqrsModeradorServicio
    {
        void ResponderPqrs(int idPqrs);

        IEnumerable<AtencionViajeroTipoPqrs> ListarPqrs(int numeroPaginacion, int pagina);
    }
}
