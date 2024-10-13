using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPqrsRepository
    {
        Task<int?> CrearPqrsAsync(PqrsCrearVM pqrs);
        Task<bool> RegistrarAdjuntosAsync(List<AdjuntosVM> adjuntos);
        Task<bool> RegistrarMensajeAsync(MensajesPqrsPostVM mensaje);
        Task<List<MensajesPqrsVM>?> ObtenerMensajesPqrsVmAsync(int idAtencionViajero);
        Task<List<AtencionViajerosPqrsVM>?> ObtenerListaAtencionViajerosPqrsVMAsync(string idUsuario);
    }
}
