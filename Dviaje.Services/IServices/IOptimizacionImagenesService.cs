namespace Dviaje.Services.IServices
{
    public interface IOptimizacionImagenesService
    {
        Task<byte[]> ConvertirAWebPAsync(Stream imagenStream, int calidad);
    }
}
