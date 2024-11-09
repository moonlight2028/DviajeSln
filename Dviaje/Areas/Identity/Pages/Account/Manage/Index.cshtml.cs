using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using Dviaje.Services.IServices;
using Dviaje.Utility;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dviaje.Areas.Identity.Pages.Account.Manage
{
    /// <summary>
    /// Representa la página de inicio del módulo de gestión de usuarios. 
    /// Esta página sirve como punto de entrada al panel de administración de usuarios y muestra 
    /// los datos básicos del usuario actualmente autenticado, permitiendo gestionar su información y configuración.
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IReservaRepository _reservaRepository;
        private readonly IResenasRepository _resenasRepository;
        private IValidator<IdentityPerfilVM> _identityPerfilVMValidator;
        private IOptimizacionImagenesService _optimizacionImagenes;
        private ISubirArchivosService _subirArchivos;


        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IReservaRepository reservaRepository,
            IResenasRepository resenasRepository,
            IValidator<IdentityPerfilVM> identityPerfilVMValidator,
            IOptimizacionImagenesService optimizacionImagenes,
            ISubirArchivosService subirArchivos)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _reservaRepository = reservaRepository;
            _resenasRepository = resenasRepository;
            _identityPerfilVMValidator = identityPerfilVMValidator;
            _optimizacionImagenes = optimizacionImagenes;
            _subirArchivos = subirArchivos;
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


        /// <summary>
        /// Carga de forma asíncrona la información del perfil de un usuario.
        /// Este método obtiene los datos básicos del usuario, como el nombre de usuario, 
        /// número de teléfono, banner, avatar, número de reservas y número de reseñas,
        /// y los asigna a una instancia del modelo de vista <see cref="IdentityPerfilVM"/>.
        /// </summary>
        /// <param name="user">El usuario cuya información se va a cargar.</param>
        /// <returns>Carga y procesa la informacion del usuario.</returns>
        private async Task LoadAsync(Usuario user)
        {
            var nombreUsuario = await _userManager.GetUserNameAsync(user);

            IdentityPerfil = new IdentityPerfilVM
            {
                NombreUsuario = nombreUsuario,
                NombreUsuarioOriginal = nombreUsuario,
                NumeroTelefono = await _userManager.GetPhoneNumberAsync(user),
                Banner = await _subirArchivos.GenerarUrlAsync(user.Banner),
                Avatar = await _subirArchivos.GenerarUrlAsync($"{user.Avatar}-200"),
                NumeroReservas = await _reservaRepository.ObtenerTotalReservas(user.Id),
                NumeroReseñas = await _resenasRepository.ObtenerTotalResenas(user.Id)
            };
        }

        /// <summary>
        /// Solicitud GET para cargar la página de perfil de usuario.
        /// Obtiene el usuario actual a partir de la identidad autenticada, y si no se encuentra un usuario, 
        /// redirige al usuario a la página de registro. Si el usuario es válido, carga su información de perfil.
        /// </summary>
        /// <returns>Una instancia de <see cref="IActionResult"/> que puede redirigir a la página de registro o mostrar la página actual.</returns>
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

        /// <summary>
        /// Solicitud POST para procesar los cambios en el perfil de usuario.
        /// Este método recibe los datos enviados desde la página y actualiza la información del usuario,
        /// actualiza el UserName, PhoneNumber, Avatar y Banner
        /// luego guarda los cambios y redirige al usuario a la página de perfil.
        /// </summary>
        /// <returns>Una instancia de <see cref="IActionResult"/> que redirige a la página de perfil.</returns>
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


            // Actualización de imágenes
            if (InputAvatar != null)
            {
                var imagenes = await _optimizacionImagenes.OptimizarMultiplesImagenesAWebPAsync(InputAvatar.OpenReadStream(), 75, $"avatar-{user.Id}", ArchivosUtility.ResolucionesAvatar);

                var resultado = await _subirArchivos.SubirImagenesAsync(imagenes, ArchivosUtility.CarpetaAvatares);

                user.Avatar = $"avatares/avatar-{user.Id}";

                var resultadoAvatar = await _userManager.UpdateAsync(user);
                if (!resultadoAvatar.Succeeded)
                {
                    Notificacion = "error";
                    NotificacionTitulo = "Perfil";
                    NotificacionMensaje = "Error inesperado al intentar actualizar el avatar.";
                    return RedirectToPage();
                }
            }
            if (InputBanner != null)
            {
                var imagen = await _optimizacionImagenes.OptimizarImagenAWebPAsync(InputBanner.OpenReadStream(), 75, $"banner-{user.Id}", ArchivosUtility.ResolucionAnchoBanner, ArchivosUtility.ResolucionAltoBanner);

                var resultado = await _subirArchivos.SubirImagenAsync(imagen.imagen, imagen.nombre, ArchivosUtility.CarpetaBanners);

                user.Banner = resultado.PublicId;

                var resultadoBanner = await _userManager.UpdateAsync(user);
                if (!resultadoBanner.Succeeded)
                {
                    Notificacion = "error";
                    NotificacionTitulo = "Perfil";
                    NotificacionMensaje = "Error inesperado al intentar actualizar el banner.";
                    return RedirectToPage();
                }
            }


            await _signInManager.RefreshSignInAsync(user);
            Notificacion = "success";
            NotificacionTitulo = "Perfil";
            NotificacionMensaje = "Tu perfil ha sido actualizado.";
            return RedirectToPage();
        }

        /// <summary>
        /// Valida si el archivo de imagen tiene una extensión soportada por el sistema.
        /// Las extensiones válidas incluyen JPG, JPEG, PNG y WEBP.
        /// </summary>
        /// <param name="imagen">El archivo de imagen a validar.</param>
        /// <returns>Devuelve <c>true</c> si la imagen tiene una extensión soportada, de lo contrario <c>false</c>.</returns>
        private bool ValidarInputImagen(IFormFile imagen)
        {
            var extenciones = new[] { ".jpg", ".jpeg", ".png", ".webp" };
            var extencion = Path.GetExtension(imagen.FileName).ToLower();

            return extenciones.Contains(extencion);
        }
    }
}
