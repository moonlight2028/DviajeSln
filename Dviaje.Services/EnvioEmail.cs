using Dviaje.Services.IServices;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Dviaje.Services
{
    public class EnvioEmail : IEnvioEmail
    {



        private string Key { get; } = "";

        private string Email { get; } = "dviajeusers@gmail.com";

        private string UserDViaje { get; } = "Users Dviaje";



        public async Task EnviarEmail(string asunto, string correoUser, string usuario, string cuerpoCorreo, string html)
        {
            //Cambiar a variable de entorno en produccion
            var apiKey = Key;

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(Email, UserDViaje);
            var subject = asunto;
            var to = new EmailAddress(correoUser, usuario);
            var plainTextContent = cuerpoCorreo;
            var htmlContent = html;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}