using Dviaje.Services.IServices;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Dviaje.Services
{
    public class SendGridService : IEmailSender, IEnvioEmailService
    {
        private string Email { get; } = "dviajeusers@gmail.com";
        private string UserDViaje { get; } = "Dviaje";
        private string Key = "";

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(Key);
            var from = new EmailAddress(Email, UserDViaje);
            var to = new EmailAddress(email, "");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, htmlMessage, htmlMessage);
            var response = await client.SendEmailAsync(msg);
        }

        public async Task EnviarEmailAsync(string asunto, string correoUsuario, string usuario, string cuerpoCorreo, string html)
        {
            var apiKey = Key;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(Email, UserDViaje);
            var subject = asunto;
            var to = new EmailAddress(correoUsuario, usuario);
            var plainTextContent = cuerpoCorreo;
            var htmlContent = html;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}