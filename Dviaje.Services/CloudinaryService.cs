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


        public async Task<string?> SubirArchivoAsync(IFormFile archivo, string folder)
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
                    Folder = folder,
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                // Retorna la URL pública del archivo
                return uploadResult.SecureUrl.ToString();
            }
        }
    }
}
