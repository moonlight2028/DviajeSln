using Dviaje.Models;
namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IVerificadoRepository : IRepository<Verificado>
    {
        void Update(Verificado verificado);
    }
}
