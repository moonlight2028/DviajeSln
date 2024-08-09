namespace Dviaje.Services.IServices
{
    public interface IEnvioEmail
    {
        Task EnviarEmail(string asunto, string correoUser, string usuario, string cuerpoCorreo, string html);
    }
}