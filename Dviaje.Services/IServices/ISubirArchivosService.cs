using Microsoft.AspNetCore.Http;

namespace Dviaje.Services.IServices
{
    public interface ISubirArchivosService
    {
        Task<string?> SubirArchivoAsync(IFormFile archivo, string folder);
    }
}
