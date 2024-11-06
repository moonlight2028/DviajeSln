namespace Dviaje.Services.IServices
{
    public interface IOptimizacionImagenesService
    {
        Task<byte[]> ConvertirAWebPAsync(Stream imagenStream, int calidad);
        Task<byte[]> ConvertirAWebPCuadradoAsync(Stream imagenStream, int calidad, int tamanioCadrado);
        Task<Dictionary<string, byte[]>> GenerarVariacionesWebPCuadradoAsync(Stream imagenStream, int calidad, IEnumerable<int> tamanios);
    }
}
