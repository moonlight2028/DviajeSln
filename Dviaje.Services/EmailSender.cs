using Microsoft.AspNetCore.Identity.UI.Services;

namespace Dviaje.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Lógica del envío del email de confirmación cuando se registra el usuario
            return Task.CompletedTask;
        }
    }
}
