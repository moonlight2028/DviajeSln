using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPerfilRepository
    {
        Task<PerfilPublicoVM?> ObtenerPerfilPublicoVMAsync(string idUsuario);
        Task<bool> ExisteRazonSocialAsync(string razonSocial);
        Task<bool> ExisteDireccionAsync(string direccion);
        Task<bool> VerificadoTieneEstadoPendienteAsync(string idAliado);
        Task<bool> SolicitarVerificado(string idAliado);
        Task<bool> SetBanner(string url, string idTurista, string? idPublico = null);
        Task<bool> SetAvatar(string urlCincuentaPx, string urlDoscientosPx, string idTurista, string? idPublico = null);
        Task<(string Avatar, string Banner)?> ObtenerBannerAvatar(string idTurista);
    }
}
