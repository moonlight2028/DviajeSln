using Dviaje.Models.VM;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Encodings.Web;

namespace Dviaje.Areas.Identity.Pages.Account.Manage
{
    public class EmailModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IValidator<IdentityManageEmailVM> _identityManageEmailVMValidator;


        public EmailModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IEmailSender emailSender,
            IValidator<IdentityManageEmailVM> identityManageEmailVMValidator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _identityManageEmailVMValidator = identityManageEmailVMValidator;
        }


        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [BindProperty]
        public IdentityManageEmailVM ManageEmail { get; set; }

        [TempData]
        public string Notificacion { get; set; }

        [TempData]
        public string NotificacionTitulo { get; set; }

        [TempData]
        public string NotificacionMensaje { get; set; }


        private async Task LoadAsync(IdentityUser user)
        {
            var email = await _userManager.GetEmailAsync(user);
            Email = email;

            ManageEmail = new IdentityManageEmailVM
            {
                NewEmail = email
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Register");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostChangeEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Register");
            }

            var validacion = await _identityManageEmailVMValidator.ValidateAsync(ManageEmail);
            if (!validacion.IsValid)
            {
                foreach (var error in validacion.Errors)
                {
                    ModelState.AddModelError($"ManageEmail.{error.PropertyName}", error.ErrorMessage);
                }

                await LoadAsync(user);
                return Page();
            }


            var email = await _userManager.GetEmailAsync(user);
            if (ManageEmail.NewEmail != email)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateChangeEmailTokenAsync(user, ManageEmail.NewEmail);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmailChange",
                    pageHandler: null,
                    values: new { area = "Identity", userId = userId, email = ManageEmail.NewEmail, code = code },
                    protocol: Request.Scheme);
                await _emailSender.SendEmailAsync(
                    ManageEmail.NewEmail,
                    "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                Notificacion = "success";
                NotificacionTitulo = "Correo";
                NotificacionMensaje = "Se ha enviado el enlace de confirmación para cambiar el correo electrónico. Por favor, revise su correo electrónico.";
                return RedirectToPage();
            }

            Notificacion = "info";
            NotificacionTitulo = "Correo";
            NotificacionMensaje = "Su correo electrónico no ha cambiado.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Register");
            }

            var validacion = await _identityManageEmailVMValidator.ValidateAsync(ManageEmail);
            if (!validacion.IsValid)
            {
                foreach (var error in validacion.Errors)
                {
                    ModelState.AddModelError($"ManageEmail.{error.PropertyName}", error.ErrorMessage);
                }

                await LoadAsync(user);
                return Page();
            }

            var userId = await _userManager.GetUserIdAsync(user);
            //var email = await _userManager.GetEmailAsync(user);
            var email = "afbaronsena@gmail.com";
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            Notificacion = "success";
            NotificacionTitulo = "Correo";
            NotificacionMensaje = "Se ha enviado un correo electrónico de verificación. Por favor, revise su correo electrónico.";
            return RedirectToPage();
        }
    }
}
