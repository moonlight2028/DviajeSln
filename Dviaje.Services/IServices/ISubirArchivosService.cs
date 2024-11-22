using Dviaje.Models;
using Microsoft.AspNetCore.Http;

namespace Dviaje.Services.IServices
{
    public interface ISubirArchivosService
    {
        Task<string?> SubirArchivoPrivadoAsync(IFormFile archivo, string carpeta);
        Task<string?> SubirImagenPrivadaAsync(byte[] imagen, string nombre, string carpeta);
        Task<List<ImagenCloudinary?>> SubirImagenesAsync(List<(byte[] imagen, string nombre)> imagenes, string carpeta);
        Task<ImagenCloudinary?> SubirImagenAsync(byte[] imagen, string nombre, string carpeta);
        Task<string?> GenerarUrlAsync(string publicId, string formato = "webp");
        Task<List<ImagenCloudinary?>> SubirImagenesDesdeIFormFileAsync(List<IFormFile> imagenes, string carpeta, string nombreBase);
    }
}
