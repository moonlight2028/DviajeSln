using Dviaje.Models.VM.Dviaje.Models.VM;
using Dviaje.Models.VM.Dviaje.Models.VM.Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface ILandingPageRepository
    {
        Task<List<CategoriaVM>> ObtenerCategoriasAsync();
        Task<List<PublicacionDestacadaVM>> ObtenerPublicacionesDestacadasAsync();
    }

}
