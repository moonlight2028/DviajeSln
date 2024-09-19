using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPqrsRepository
    {
        Task<bool> CrearPqrsAsync(PqrsVM pqrs);
    }
}
