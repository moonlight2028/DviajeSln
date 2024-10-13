using Dviaje.Services.IServices;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;

namespace Dviaje.Services
{
    public class ImageSharpService : IOptimizacionImagenesService
    {
        public async Task<byte[]> ConvertirAWebPAsync(Stream imagenStream, int calidad)
        {
            using (var imagen = await Image.LoadAsync(imagenStream))
            {
                var opciones = new WebpEncoder
                {
                    Quality = calidad
                };

                using (var memoryStream = new MemoryStream())
                {
                    await imagen.SaveAsWebpAsync(memoryStream, opciones);
                    return memoryStream.ToArray();
                }
            }
        }
    }
}
