namespace Dviaje.Services.IServices
{
    public interface IOptimizacionImagenesService
    {
        Task<byte[]> OptimizarImagenAWebPAsync(Stream imagenStream, int calidad);
        Task<(byte[] imagen, string nombre)> OptimizarImagenAWebPAsync(
    Stream imagenStream, int calidad, string nombre, int ancho, int alto);
        Task<List<(byte[] imagen, string nombre)>> OptimizarMultiplesImagenesAWebPAsync(
    Stream imagenStream, int calidad, string nombreBase, IEnumerable<(int ancho, int alto)> dimensiones);
    }
}
