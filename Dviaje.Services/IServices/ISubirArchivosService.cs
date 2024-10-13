using Microsoft.AspNetCore.Http;

namespace Dviaje.Services.IServices
{
    public interface ISubirArchivosService
    {
        Task<string?> SubirArchivoPrivadoAsync(IFormFile archivo, string carpeta);
        Task<string?> SubirImagenPrivadaAsync(byte[] imagen, string nombre, string carpeta);
    }
}
