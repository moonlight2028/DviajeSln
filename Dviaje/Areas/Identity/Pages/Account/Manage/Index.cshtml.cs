using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using Dviaje.Services.IServices;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dviaje.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IReservaRepository _reservaRepository;
        private readonly IResenasRepository _resenasRepository;
        private IValidator<IdentityPerfilVM> _identityPerfilVMValidator;
        private IOptimizacionImagenesService _optimizacionImagenes;


        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IReservaRepository reservaRepository,
            IResenasRepository resenasRepository,
            IValidator<IdentityPerfilVM> identityPerfilVMValidator,
            IOptimizacionImagenesService optimizacionImagenes)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _reservaRepository = reservaRepository;
            _resenasRepository = resenasRepository;
            _identityPerfilVMValidator = identityPerfilVMValidator;
            _optimizacionImagenes = optimizacionImagenes;
        }


        [BindProperty]
        public IdentityPerfilVM IdentityPerfil { get; set; }

        [BindProperty]
        [ValidateNever]
        public IFormFile InputAvatar { get; set; }

        [BindProperty]
        [ValidateNever]
        public IFormFile InputBanner { get; set; }

        [TempData]
        public string Notificacion { get; set; }

        [TempData]
        public string NotificacionTitulo { get; set; }

        [TempData]
        public string NotificacionMensaje { get; set; }


        private async Task LoadAsync(Usuario user)
        {
            var nombreUsuario = await _userManager.GetUserNameAsync(user);

            IdentityPerfil = new IdentityPerfilVM
            {
                NombreUsuario = nombreUsuario,
                NombreUsuarioOriginal = nombreUsuario,
                NumeroTelefono = await _userManager.GetPhoneNumberAsync(user),
                Banner = user.Banner,
                Avatar = user.Avatar,
                NumeroReservas = await _reservaRepository.ObtenerTotalReservas(user.Id),
                NumeroReseñas = await _resenasRepository.ObtenerTotalResenas(user.Id)
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User) as Usuario;
            if (user == null)
            {
                return RedirectToPage("/Account/Register");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User) as Usuario;
            if (user == null)
            {
                return RedirectToPage("/Account/Register");
            }

            // Validaciones
            IdentityPerfil.NombreUsuarioOriginal = user.UserName;
            ModelState.Remove("InputAvatar");
            ModelState.Remove("InputBanner");

            var validacion = await _identityPerfilVMValidator.ValidateAsync(IdentityPerfil);
            if (!validacion.IsValid)
            {
                foreach (var error in validacion.Errors)
                {
                    ModelState.AddModelError($"IdentityPerfil.{error.PropertyName}", error.ErrorMessage);
                }
            }
            if (InputAvatar != null)
            {
                var validacionImagen = ValidarInputImagen(InputAvatar);
                if (!validacionImagen) ModelState.AddModelError("InputAvatar", "El avatar debe ser una imagen en formato JPG, JPEG, WEBP o PNG.");
            }
            if (InputBanner != null)
            {
                var validacionImagen = ValidarInputImagen(InputBanner);
                if (!validacionImagen) ModelState.AddModelError("InputBanner", "El banner debe ser una imagen en formato JPG, JPEG, WEBP o PNG.");
            }
            if (!ModelState.IsValid)
            {
                string d = "df";
                await LoadAsync(user);
                return Page();
            }


            // Registro de datos
            var numeroTelefono = await _userManager.GetPhoneNumberAsync(user);
            if (IdentityPerfil.NumeroTelefono != numeroTelefono)
            {
                var resultado = await _userManager.SetPhoneNumberAsync(user, IdentityPerfil.NumeroTelefono);
                if (!resultado.Succeeded)
                {
                    Notificacion = "error";
                    NotificacionTitulo = "Perfil";
                    NotificacionMensaje = "Error inesperado al intentar cambiar el número de teléfono.";
                    return RedirectToPage();
                }
            }

            var nombreUsuarioActual = await _userManager.GetUserNameAsync(user);
            var nuevoNombreUsuario = IdentityPerfil.NombreUsuario;
            if (nuevoNombreUsuario != nombreUsuarioActual)
            {
                var existeUsuario = await _userManager.FindByNameAsync(nuevoNombreUsuario);
                if (existeUsuario == null)
                {
                    var resultado = await _userManager.SetUserNameAsync(user, nuevoNombreUsuario);
                    if (!resultado.Succeeded)
                    {
                        Notificacion = "error";
                        NotificacionTitulo = "Perfil";
                        NotificacionMensaje = "Error inesperado al intentar cambiar el nombre de usuario.";
                        return RedirectToPage();
                    }
                }
                else
                {
                    ModelState.AddModelError("IdentityPerfil.NombreUsuario", "El nombre de usuario ya está en uso");

                    await LoadAsync(user);
                    return Page();
                }
            }

            if (InputAvatar != null)
            {
                var imagenes = await _optimizacionImagenes.GenerarVariacionesWebPCuadradoAsync(InputAvatar.OpenReadStream(), 75, new[] { 50, 200 });


                string d = "sdf";
            }




            await _signInManager.RefreshSignInAsync(user);
            Notificacion = "success";
            NotificacionTitulo = "Perfil";
            NotificacionMensaje = "Tu perfil ha sido actualizado.";
            return RedirectToPage();
        }

        private bool ValidarInputImagen(IFormFile imagen)
        {
            var extenciones = new[] { ".jpg", ".jpeg", ".png", ".webp" };
            var extencion = Path.GetExtension(imagen.FileName).ToLower();

            return extenciones.Contains(extencion);
        }
    }
}
