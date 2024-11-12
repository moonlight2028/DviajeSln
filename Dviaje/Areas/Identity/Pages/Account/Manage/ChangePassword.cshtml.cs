using Dviaje.Models.VM;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dviaje.Areas.Identity.Pages.Account.Manage
{
    public class ChangePasswordModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<ChangePasswordModel> _logger;
        private IValidator<IdentityManagePasswordVM> _identityManagePasswordVMValidator;


        public ChangePasswordModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<ChangePasswordModel> logger,
            IValidator<IdentityManagePasswordVM> IdentityManagePasswordVMValidator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _identityManagePasswordVMValidator = IdentityManagePasswordVMValidator;
        }


        [BindProperty]
        public IdentityManagePasswordVM ManagePassword { get; set; }

        [TempData]
        public string Notificacion { get; set; }

        [TempData]
        public string NotificacionTitulo { get; set; }

        [TempData]
        public string NotificacionMensaje { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Register");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToPage("./SetPassword");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var validacion = await _identityManagePasswordVMValidator.ValidateAsync(ManagePassword);
            if (!validacion.IsValid)
            {
                foreach (var error in validacion.Errors)
                {
                    ModelState.AddModelError($"ManagePassword.{error.PropertyName}", error.ErrorMessage);
                }

                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Register");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, ManagePassword.OldPassword, ManagePassword.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("User changed their password successfully.");
            Notificacion = "success";
            NotificacionTitulo = "Contraseña";
            NotificacionMensaje = "Su contraseña ha sido cambiada.";

            return RedirectToPage();
        }
    }
}
