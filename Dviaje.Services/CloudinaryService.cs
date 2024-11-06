using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Dviaje.Models;
using Dviaje.Services.IServices;
using Microsoft.AspNetCore.Http;

namespace Dviaje.Services
{
    public class CloudinaryService : ISubirArchivosService
    {
        private readonly Cloudinary _cloudinary;
        private string CloudName { get; } = "dgjjvf1g5";
        private string ApiKey { get; } = "551693267758256";
        private string ApiSecret { get; } = "IpjPuMVZapruMGPQW3KZvs1k4ZY";


        public CloudinaryService()
        {
            Account account = new Account(CloudName, ApiKey, ApiSecret);
            _cloudinary = new Cloudinary(account);
        }


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

        private async Task<ImagenCloudinary?> SubirImagenAsync(byte[] imagen, string nombre, string carpeta)
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
                    Type = "upload"
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                return new ImagenCloudinary
                {
                    PublicId = uploadResult.PublicId,
                    Url = uploadResult.SecureUrl?.ToString()
                };
            }
        }


    }
}
