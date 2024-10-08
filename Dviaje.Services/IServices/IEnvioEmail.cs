namespace Dviaje.Services.IServices
{
    public interface IEnvioEmail
    {
        Task EnviarEmailAsync(string asunto, string correoUser, string usuario, string cuerpoCorreo, string html);
    }
}