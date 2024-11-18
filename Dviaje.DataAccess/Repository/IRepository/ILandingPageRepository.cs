using Dviaje.Models.VM;


namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface ILandingPageRepository
    {
        Task<List<CategoriaVM>> ObtenerCategoriasAsync();
        Task<List<PublicacionDestacadaVM>> ObtenerPublicacionesDestacadasAsync();
    }

}
