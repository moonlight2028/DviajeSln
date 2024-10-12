using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPqrsRepository
    {
        Task<int[]?> CrearPqrsAsync(PqrsCrearVM pqrs);
        Task<bool> RegistrarMensajeAsync(MensajesPqrsPostVM mensaje);
        Task<List<MensajesPqrsVM>?> ObtenerMensajesPqrsVmAsync(int idAtencionViajero);
        Task<List<AtencionViajerosPqrsVM>?> ObtenerListaAtencionViajerosPqrsVM(string idUsuario);
    }
}
