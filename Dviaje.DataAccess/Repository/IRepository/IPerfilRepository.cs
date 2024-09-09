using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPerfilRepository
    {
        Task<PerfilPublicoVM> GetPerfilTuristaAsync(string idUsuario);
        Task<PerfilPublicoVM> GetPerfilAliadoAsync(string idUsuario);
    }
}
