using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Dviaje.Models;
using Dviaje.Models.VM;
using Dviaje.Services.IServices;
using Microsoft.AspNetCore.Http;

namespace Dviaje.Services
{
    /// <summary>
    /// Servicio encargado de gestionar la subida de archivos utilizando la API de Cloudinary.
    /// Este servicio proporciona métodos para cargar, obtener y gestionar archivos en la nube mediante la integración con Cloudinary.
    /// </summary>
    public class CloudinaryService : ISubirArchivosService
    {
        private readonly Cloudinary _cloudinary;
        private string CloudName { get; } = "dfpdbr5mk";
        private string ApiKey { get; } = "231467288445945";
        private string ApiSecret { get; } = "-ZvUlSdYz_OuksU8bWdXqohOiwA";


        public CloudinaryService()
        {
            Account account = new Account(CloudName, ApiKey, ApiSecret);
            _cloudinary = new Cloudinary(account);
        }


        /// <summary>
        /// Sube un archivo privado a Cloudinary, permitiendo la carga de archivos como PDF.
        /// El archivo se guarda en una carpeta específica y se marca como privado, lo que significa que no será accesible públicamente.
        /// </summary>
        /// <param name="archivo">El archivo que se desea subir, representado como un objeto <see cref="IFormFile"/>.</param>
        /// <param name="carpeta">La carpeta o "bucket" en Cloudinary donde se almacenará el archivo.</param>
        /// <returns>Devuelve el ID público del archivo subido en Cloudinary, o <c>null</c> si el archivo es nulo o está vacío.</returns>
        public async Task<string?> SubirArchivoPrivadoAsync(IFormFile archivo, string carpeta)
        {
            if (archivo == null || archivo.Length == 0)
            {
                return null;
            }

            using (var stream = archivo.OpenReadStream())
            {
                var uploadParams = new RawUploadParams
                {
                    File = new FileDescription(archivo.FileName, stream),
                    Folder = carpeta,
                    Type = "private"
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                return uploadResult.PublicId;
            }
        }

        /// <summary>
        /// Sube una imagen a Cloudinary como un archivo privado.
        /// El archivo de imagen se guarda en una carpeta específica y se marca como privado, lo que significa que no será accesible públicamente.
        /// </summary>
        /// <param name="imagen">El contenido de la imagen en forma de un arreglo de bytes.</param>
        /// <param name="nombre">El nombre del archivo de la imagen que se subirá a Cloudinary.</param>
        /// <param name="carpeta">La carpeta o "bucket" en Cloudinary donde se almacenará la imagen.</param>
        /// <returns>Devuelve el ID público de la imagen subida en Cloudinary, o <c>null</c> si la imagen es nula o está vacía.</returns>
        public async Task<string?> SubirImagenPrivadaAsync(byte[] imagen, string nombre, string carpeta)
        {
            if (imagen == null || imagen.Length == 0)
            {
                return null;
            }

            using (var stream = new MemoryStream(imagen))
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(nombre, stream),
                    Folder = carpeta,
                    Type = "private"
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                return uploadResult.PublicId;
            }
        }

        /// <summary>
        /// Sube múltiples imágenes a Cloudinary de manera asíncrona.
        /// Cada imagen se sube como un archivo privado y se almacena en una carpeta específica.
        /// </summary>
        /// <param name="imagenes">Lista de tuplas donde cada tupla contiene el contenido de la imagen (en formato byte[]) y el nombre del archivo.</param>
        /// <param name="carpeta">La carpeta en Cloudinary donde se almacenarán las imágenes.</param>
        /// <returns>Devuelve una lista con los resultados de las cargas, cada uno representando la información de una imagen subida.</returns>
        public async Task<List<ImagenCloudinary?>> SubirImagenesAsync(List<(byte[] imagen, string nombre)> imagenes, string carpeta)
        {
            var tareasDeSubida = new List<Task<ImagenCloudinary?>>();

            foreach (var (imagen, nombre) in imagenes)
            {
                tareasDeSubida.Add(SubirImagenAsync(imagen, nombre, carpeta));
            }

            var resultados = await Task.WhenAll(tareasDeSubida);

            return resultados.ToList();
        }

        /// <summary>
        /// Sube una imagen a Cloudinary como un archivo público.
        /// El archivo de imagen se guarda en una carpeta específica, con un nombre personalizado como su ID público.
        /// </summary>
        /// <param name="imagen">El contenido de la imagen en forma de un arreglo de bytes.</param>
        /// <param name="nombre">El nombre que se asignará como ID público del archivo en Cloudinary.</param>
        /// <param name="carpeta">La carpeta o "bucket" en Cloudinary donde se almacenará la imagen.</param>
        /// <returns>Devuelve un objeto <see cref="ImagenCloudinary"/> con el ID público y la URL segura de la imagen subida, o <c>null</c> si la imagen es nula o está vacía.</returns>
        public async Task<ImagenCloudinary?> SubirImagenAsync(byte[] imagen, string nombre, string carpeta)
        {
            if (imagen == null || imagen.Length == 0)
            {
                return null;
            }

            using (var stream = new MemoryStream(imagen))
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(nombre, stream),
                    Folder = carpeta,
                    Type = "upload",
                    PublicId = nombre
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                return new ImagenCloudinary
                {
                    PublicId = uploadResult.PublicId,
                    Url = uploadResult.SecureUrl?.ToString()
                };
            }
        }

        /// <summary>
        /// Genera la URL segura de una imagen en Cloudinary a partir de su ID público.
        /// La URL incluye la versión del archivo y puede especificarse el formato de imagen deseado (por defecto es "webp").
        /// </summary>
        /// <param name="publicId">El ID público de la imagen almacenada en Cloudinary.</param>
        /// <param name="formato">El formato de la imagen a generar en la URL (por defecto es "webp").</param>
        /// <returns>Devuelve la URL segura de la imagen en el formato especificado, o <c>null</c> si no se encuentra el recurso.</returns>
        public async Task<string?> GenerarUrlAsync(string publicId, string formato = "webp")
        {
            var resource = await _cloudinary.GetResourceAsync(new GetResourceParams(publicId));

            if (resource == null)
            {
                return null;
            }

            string version = resource.Version;

            return $"https://res.cloudinary.com/{CloudName}/image/upload/v{version}/{publicId}.{formato}";
        }


        public async Task<List<ImagenCloudinary?>> SubirImagenesDesdeIFormFileAsync(List<IFormFile> imagenes, string carpeta, string nombreBase)
        {
            var tareasDeSubida = new List<Task<ImagenCloudinary?>>();

            var contadorImagenes = 0;
            foreach (var imagen in imagenes)
            {
                contadorImagenes++;

                // Convertir IFormFile a byte[]
                using (var memoryStream = new MemoryStream())
                {
                    await imagen.CopyToAsync(memoryStream); // Copia el contenido del IFormFile al MemoryStream
                    var imagenBytes = memoryStream.ToArray(); // Obtiene el array de bytes

                    // Usamos el nombre original del archivo, pero puedes personalizarlo si es necesario
                    var nombreImagen = $"{nombreBase}-{contadorImagenes}";

                    // Agregar la tarea para subir la imagen a Cloudinary
                    tareasDeSubida.Add(SubirImagenAsync(imagenBytes, nombreImagen, carpeta));
                }
            }

            // Esperamos que todas las tareas de subida se completen
            var resultados = await Task.WhenAll(tareasDeSubida);

            return resultados.ToList();
        }








        public async Task<(string publicId, string secureUrl)> SubirImagenAsync(ImagenVM imagen)
        {
            if (imagen == null || string.IsNullOrEmpty(imagen.Content))
            {
                throw new ArgumentNullException("La imagen o el contenido no pueden ser nulos.");
            }

            // Decodifica la imagen en base64
            var base64Data = imagen.Content.Split(',')[1]; // Elimina el prefijo "data:image/..."
            var imagenBytes = Convert.FromBase64String(base64Data);

            using (var stream = new MemoryStream(imagenBytes))
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(imagen.Name, stream),
                    Type = imagen.Type ?? "upload" // Si no se proporciona el tipo, usa "upload" como valor predeterminado.
                };

                // Sube la imagen
                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                // Retorna el publicId y la URL segura con la versión
                return (uploadResult.PublicId, uploadResult.SecureUrl.ToString());
            }
        }


        public async Task<List<(string publicId, string secureUrl)>> SubirMultiplesImagenesAsync(List<ImagenVM> imagenes)
        {
            var tareasDeSubida = new List<Task<(string publicId, string secureUrl)>>();

            foreach (var imagen in imagenes)
            {
                tareasDeSubida.Add(SubirImagenAsync(imagen)); // Agrega cada tarea a la lista.
            }

            // Ejecuta todas las tareas en paralelo y espera el resultado
            var resultados = await Task.WhenAll(tareasDeSubida);

            // Retorna la lista de resultados
            return resultados.ToList();
        }










    }
}
