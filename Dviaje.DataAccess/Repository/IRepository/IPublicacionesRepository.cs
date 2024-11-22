using Dviaje.Models;
using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPublicacionesRepository
    {
        Task<int> PublicacionesTotales();
        Task<List<PublicacionTarjetaBusquedaVM>> ObtenerListaPublicacionTarjetaBusquedaVMAsync(int pagina, int numeroPublicaciones, string? ordenarPor = null);
        Task<PublicacionDetalleVM?> ObtenerPublicacionDetalleVMAsync(int idPublicacion);
        Task<PublicacionResenasVM?> ObtenerPublicacionResenasVMAsync(int idPublicacion);
        Task<PublicacionTarjetaImagenVM?> ObtenerPublicacionTarjetaImagenVMAsync(int idPublicacion);
        Task<PublicacionCrearVM?> ObtenerPublicacionCrearVMAsync(int idPublicacion);
        Task<PublicacionCrearVM?> ObtenerPublicacionCrearVMAsync();
        Task<int?> CrearPublicacionAsync(PublicacionCrearVM publicacion);
        Task<bool> EditarPublicacionAsync(PublicacionCrearVM publicacion);
        Task<bool> EstadoEliminarPublicacionAsync(int idPublicacion, int idAliado);
        Task<bool> EstadoCambiarPublicacionAsync(int idPublicacion, int idAliado, string estado);
        Task<List<PublicacionTablaItemVM>?> ObtenerListaPublicacionTablaItemVMAsync();
        Task<List<PublicacionCategoriaVM>> ObtenerPublicacionesPorCategoriaAsync(int idCategoria);
        Task<List<ReportesPublicacionesPorMesVM>?> ReportePublicacionesPorMesAsync();
        Task<List<ReportesPublicacionesTopCategoriaVM>?> ReporteTopCategoriasAsync();
        Task<List<ReportesPublicacionesActivasVM>?> ReportePublicacionesActivasAsync();
        Task<List<ReportesPublicacionesPreciosVM>?> ReportePreciosPromediosAsync();
        Task<List<ReportesPublicacionesTopPublicacionesVM>?> ReporteTopPublicacionesAsync();
        Task<ReportesPublicacionesDetallesVM?> ReporteDetallesAsync(DateTime FechaActual);
        Task<bool> RegistrarImagenes(List<PublicacionesImagenes> imagenes);
    }
}
