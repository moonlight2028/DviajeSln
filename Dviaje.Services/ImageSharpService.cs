using Dviaje.Services.IServices;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;

namespace Dviaje.Services
{
    /// <summary>
    /// Servicio encargado de la optimización de imágenes, utilizando la biblioteca ImageSharp.
    /// Este servicio permite reducir el tamaño de las imágenes manteniendo su calidad visual mediante técnicas de compresión.
    /// </summary>
    public class ImageSharpService : IOptimizacionImagenesService
    {
        /// <summary>
        /// Optimiza la imagen a formato WebP con la calidad especificada.
        /// </summary>
        /// <param name="imagenStream">Flujo de datos de la imagen original.</param>
        /// <param name="calidad">Calidad deseada para la imagen final, un valor entre 0 y 100.</param>
        /// <returns>Una representación de bytes de la imagen optimizada en formato WebP.</returns>
        public async Task<byte[]> OptimizarImagenAWebPAsync(Stream imagenStream, int calidad)
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

        /// <summary>
        /// Optimiza una imagen a formato WebP con la calidad especificada, reescala la imagen a las dimensiones dadas y retorna el nombre de la imagen.
        /// </summary>
        /// <param name="imagenStream">Flujo de datos de la imagen original.</param>
        /// <param name="calidad">Calidad deseada para la imagen final, un valor entre 0 y 100.</param>
        /// <param name="nombre">Nombre de la imagen resultante.</param>
        /// <param name="ancho">Ancho en píxeles deseado para la imagen.</param>
        /// <param name="alto">Alto en píxeles deseado para la imagen.</param>
        /// <returns>Una tupla que contiene el arreglo de bytes de la imagen optimizada y el nombre asignado a la imagen.</returns>
        public async Task<(byte[] imagen, string nombre)> OptimizarImagenAWebPAsync(
    Stream imagenStream, int calidad, string nombre, int ancho, int alto)
        {
            using (var imagen = await Image.LoadAsync(imagenStream))
            {
                var tamanioOpciones = new ResizeOptions
                {
                    Size = new Size(ancho, alto),
                    Mode = ResizeMode.Crop
                };

                imagen.Mutate(x => x.Resize(tamanioOpciones));

                var opcionesWebp = new WebpEncoder
                {
                    Quality = calidad
                };

                using (var memoryStream = new MemoryStream())
                {
                    await imagen.SaveAsWebpAsync(memoryStream, opcionesWebp);
                    return (memoryStream.ToArray(), nombre);
                }
            }
        }

        /// <summary>
        /// Optimiza varias imágenes a formato WebP de forma simultánea con la calidad y dimensiones especificadas.
        /// </summary>
        /// <param name="imagenStream">Flujo de datos de la imagen original.</param>
        /// <param name="calidad">Calidad deseada para las imágenes finales, un valor entre 0 y 100.</param>
        /// <param name="nombreBase">Nombre base o patrón para las imágenes resultantes, que se usará como prefijo para cada imagen optimizada.</param>
        /// <param name="dimensiones">Colección de tuplas que definen las dimensiones (ancho, alto) para las imágenes optimizadas.</param>
        /// <returns>Una lista de tuplas que contienen los arreglos de bytes de las imágenes optimizadas y sus respectivos nombres.</returns>
        public async Task<List<(byte[] imagen, string nombre)>> OptimizarMultiplesImagenesAWebPAsync(
    Stream imagenStream, int calidad, string nombreBase, IEnumerable<(int ancho, int alto)> dimensiones)
        {
            var tareas = new List<Task<(byte[] imagen, string nombre)>>();

            foreach (var (ancho, alto) in dimensiones)
            {
                var copiaStream = new MemoryStream();
                await imagenStream.CopyToAsync(copiaStream);
                copiaStream.Position = 0;

                var nombre = $"{nombreBase}-{ancho}";
                tareas.Add(OptimizarImagenAWebPAsync(copiaStream, calidad, nombre, ancho, alto));

                imagenStream.Position = 0;
            }

            var resultados = await Task.WhenAll(tareas);
            return resultados.ToList();
        }
    }
}
