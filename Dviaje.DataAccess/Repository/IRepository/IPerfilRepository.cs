using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPerfilRepository
    {
        Task<PerfilPublicoVM?> ObtenerPerfilPublicoVMAsync(string idUsuario);
        Task<bool> ExisteRazonSocialAsync(string razonSocial);
        Task<bool> ExisteDireccionAsync(string direccion);
        Task<bool> VerificadoTieneEstadoPendienteAsync(string idAliado);
    }
}
