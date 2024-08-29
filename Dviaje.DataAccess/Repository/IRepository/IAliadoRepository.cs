using Dviaje.Models;
using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IAliadoRepository : IRepository<Aliado>
    {
        Task<AliadoPerfilPublicoVM>? ObtenerPerfilAliadoAsync(string idAliado);
    }
}
