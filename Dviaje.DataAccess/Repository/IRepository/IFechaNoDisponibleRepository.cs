using Dviaje.Models;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IFechaNoDisponibleRepository : IRepository<FechaNoDisponible>
    {
        void Update(FechaNoDisponible fechaNoDisponible);
    }
}
