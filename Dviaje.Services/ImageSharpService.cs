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





        public async Task<byte[]> OptimizarImagenBase64AWebPAsync(string base64String, int calidad)
        {
            var base64Data = base64String.Split(',')[1];  // Esto obtiene solo la parte después de ','


            // Convierte la cadena base64 a un arreglo de bytes
            byte[] imagenBytes = Convert.FromBase64String(base64String);

            // Crea un MemoryStream a partir del arreglo de bytes
            using (var imagenStream = new MemoryStream(imagenBytes))
            {
                // Carga la imagen desde el flujo (stream)
                using (var imagen = await Image.LoadAsync(imagenStream))
                {
                    // Define las opciones de compresión para el formato WebP
                    var opciones = new WebpEncoder
                    {
                        Quality = calidad
                    };

                    // Crea un MemoryStream para guardar la imagen optimizada
                    using (var memoryStream = new MemoryStream())
                    {
                        // Guarda la imagen como WebP en el MemoryStream
                        await imagen.SaveAsWebpAsync(memoryStream, opciones);

                        // Devuelve los bytes de la imagen optimizada
                        return memoryStream.ToArray();
                    }
                }
            }
        }



        public async Task<List<byte[]>> OptimizarMultiplesImagenesBase64AWebPAsync(
    List<string> base64Imagenes, int calidad)
        {
            // Usamos Task.WhenAll para procesar todas las imágenes en paralelo
            var tareas = base64Imagenes.Select(base64String =>
                OptimizarImagenBase64AWebPAsync(base64String, calidad)).ToList();

            // Esperamos que todas las tareas se completen y obtenemos los resultados
            var imagenesOptimizada = await Task.WhenAll(tareas);

            // Convertimos el resultado de Task.WhenAll a una lista de bytes
            return imagenesOptimizada.ToList();
        }


    }
}
