namespace Dviaje.Services.IServices
{
    public interface IEnvioEmailService
    {
        Task EnviarEmailAsync(string asunto, string correoUser, string usuario, string cuerpoCorreo, string html);
    }
}