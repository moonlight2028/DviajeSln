using Dviaje.Services.IServices;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;

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

        public async Task<byte[]> ConvertirAWebPCuadradoAsync(Stream imagenStream, int calidad, int tamanioCadrado)
        {
            using (var imagen = await Image.LoadAsync(imagenStream))
            {
                int tamaño = Math.Min(imagen.Width, imagen.Height);
                imagen.Mutate(x => x.Crop(new Rectangle((imagen.Width - tamaño) / 2, (imagen.Height - tamaño) / 2, tamaño, tamaño)));

                imagen.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new Size(tamanioCadrado, tamanioCadrado),
                    Mode = ResizeMode.Crop
                }));

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

        public async Task<Dictionary<string, byte[]>> GenerarVariacionesWebPCuadradoAsync(Stream imagenStream, int calidad, IEnumerable<int> tamanios)
        {
            var resultados = new Dictionary<string, byte[]>();

            foreach (var tamanio in tamanios)
            {
                var imagenRedimensionada = await ConvertirAWebPCuadradoAsync(imagenStream, calidad, tamanio);
                resultados.Add($"{tamanio}x{tamanio}", imagenRedimensionada);
                imagenStream.Position = 0;
            }

            return resultados;
        }
    }
}
