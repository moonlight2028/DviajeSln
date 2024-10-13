using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
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

            // Convierte el archivo en un stream para subirlo
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
                    Type = "private" // Tipo de acceso privado
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                return uploadResult.PublicId;
            }
        }




    }
}
