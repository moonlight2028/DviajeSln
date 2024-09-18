using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPublicacionesRepository
    {
        Task<int> PublicacionesTotales();
        Task<List<PublicacionTarjetaVM>> ObtenerPublicacionesAsync(int pagina, int numeroPublicaciones, string? ordenarPor = null);
        Task<PublicacionVM?> ObtenerPublicacionPorIdAsync(int idPublicacion);

        Task<PublicacionTarjetaV2VM> GetAll();
    }
}
