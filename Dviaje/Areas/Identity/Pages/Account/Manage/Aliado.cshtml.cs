using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using Dviaje.Utility;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dviaje.Areas.Identity.Pages.Account.Manage
{
    /// <summary>
    /// Modelo de p�gina para gestionar las acciones del aliado dentro de la aplicaci�n.
    /// Permite al usuario convertirse en aliado, actualizar sus datos y solicitar la verificaci�n de su cuenta.
    /// </summary>
    public class AliadoModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private IValidator<IdentityManageAliadoVM> _identityManageAliadoVMValidator;
        private IPerfilRepository _perfilRepository;

        public AliadoModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IValidator<IdentityManageAliadoVM> identityManageAliadoVMValidator,
            IPerfilRepository perfilRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _identityManageAliadoVMValidator = identityManageAliadoVMValidator;
            _perfilRepository = perfilRepository;
        }

        [BindProperty]
        public IdentityManageAliadoVM ManageAliado { get; set; }

        public int NumeroPublicaciones { get; set; }

        public decimal Puntuacion { get; set; }

        public IdentityAliadoEstado AliadoEstado { get; set; }

        [TempData]
        public string Notificacion { get; set; }

        [TempData]
        public string NotificacionTitulo { get; set; }

        [TempData]
        public string NotificacionMensaje { get; set; }


        /// <summary>
        /// Determina y asigna el estado actual del usuario en relaci�n con su rol de aliado.
        /// </summary>
        /// <param name="user">Objeto de usuario que contiene la informaci�n del estado actual.</param>
        /// <returns>Tarea asincr�nica que asigna el valor correspondiente a la propiedad <c>AliadoEstado</c>.</returns>
        private async Task CargarAliadoEstadoAsync(Usuario user)
        {
            var esAliado = User.IsInRole(RolesUtility.RoleAliado);
            if (esAliado)
            {
                AliadoEstado = IdentityAliadoEstado.Aliado;

                var verificado = user.Verificado;
                if (verificado) AliadoEstado = IdentityAliadoEstado.AliadoVerificado;

                var verificadoPendiente = await _perfilRepository.VerificadoTieneEstadoPendienteAsync(user.Id);
                if (verificadoPendiente) AliadoEstado = IdentityAliadoEstado.AliadoVerificadoSolicitado;
            }
            else
            {
                AliadoEstado = IdentityAliadoEstado.NoEsAliado;
            }
        }


        /// <summary>
        /// Carga los datos de inicio necesarios para la vista del usuario aliado, incluyendo el estado de aliado,
        /// el n�mero de publicaciones, la puntuaci�n y los detalles del perfil de aliado.
        /// </summary>
        /// <param name="user">Objeto <see cref="Usuario"/> que representa el usuario actual y sus datos.</param>
        /// <returns>Tarea asincr�nica que realiza la carga de los datos.</returns>
        private async Task CargarDatosAsync(Usuario user)
        {
            await CargarAliadoEstadoAsync(user);

            var esAliado = User.IsInRole(RolesUtility.RoleAliado);
            if (esAliado)
            {
                NumeroPublicaciones = user.NumeroPublicaciones;
                Puntuacion = user.Puntuacion;
                ManageAliado = new IdentityManageAliadoVM
                {
                    RazonSocial = user.RazonSocial,
                    Direccion = user.Direccion,
                    SitioWeb = user.SitioWeb
                };
            }
        }


        /// <summary>
        /// Maneja la solicitud GET de la p�gina Razor para cargar la vista inicial del aliado. 
        /// Recupera los datos del usuario actual y los prepara para ser visualizados en la p�gina.
        /// </summary>
        /// <returns>Un objeto <see cref="IActionResult"/> que redirige a la p�gina de registro si el usuario no est� autenticado; 
        /// de lo contrario, carga la p�gina con los datos del usuario.</returns>
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User) as Usuario;
            if (user == null)
            {
                return RedirectToPage("/Account/Register");
            }

            await CargarDatosAsync(user);
            return Page();
        }


        /// <summary>
        /// Maneja la solicitud POST para actualizar la informaci�n del usuario en su rol de aliado.
        /// Permite convertir al usuario en aliado y valida los datos enviados para actualizar su perfil.
        /// </summary>
        /// <returns>Un objeto <see cref="IActionResult"/> que redirige a la p�gina de registro si el usuario no est� autenticado; 
        /// de lo contrario, procesa y guarda las actualizaciones del perfil de aliado.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User) as Usuario;
            if (user == null)
            {
                return RedirectToPage("/Account/Register");
            }


            await CargarAliadoEstadoAsync(user);
            if (ManageAliado.RazonSocial != user.RazonSocial || ManageAliado.Direccion != user.Direccion || !string.IsNullOrEmpty(ManageAliado.SitioWeb))
            {
                if (AliadoEstado == IdentityAliadoEstado.NoEsAliado || AliadoEstado == IdentityAliadoEstado.Aliado)
                {
                    // Validaciones
                    var validacion = await _identityManageAliadoVMValidator.ValidateAsync(ManageAliado);
                    if (!validacion.IsValid)
                    {
                        foreach (var error in validacion.Errors)
                        {
                            ModelState.AddModelError($"ManageAliado.{error.PropertyName}", error.ErrorMessage);
                        }

                        return Page();
                    }

                    if (ManageAliado.RazonSocial != user.RazonSocial)
                    {
                        var validacionRazonSocial = await _perfilRepository.ExisteRazonSocialAsync(ManageAliado.RazonSocial);
                        if (validacionRazonSocial)
                        {
                            ModelState.AddModelError($"ManageAliado.RazonSocial", "La raz�n social ya est� en uso.");
                        }
                        else
                        {
                            user.RazonSocial = ManageAliado.RazonSocial;
                        }
                    }

                    if (ManageAliado.Direccion != user.Direccion)
                    {
                        var validacionDireccion = await _perfilRepository.ExisteDireccionAsync(ManageAliado.Direccion); ;
                        if (validacionDireccion)
                        {
                            ModelState.AddModelError($"ManageAliado.Direccion", "La direcci�n ya est� en uso.");
                        }
                        else
                        {
                            user.Direccion = ManageAliado.Direccion;
                        }
                    }

                    if (!ModelState.IsValid) return Page();

                    if (ManageAliado.SitioWeb != user.SitioWeb) user.SitioWeb = ManageAliado.SitioWeb;


                    var resultadoActualizacion = await _userManager.UpdateAsync(user);
                    if (!resultadoActualizacion.Succeeded)
                    {
                        Notificacion = "error";
                        NotificacionTitulo = "Aliado";
                        NotificacionMensaje = "Error inesperado al intentar actualizar los datos.";
                        return RedirectToPage();
                    }

                    if (AliadoEstado == IdentityAliadoEstado.NoEsAliado)
                    {
                        var resultadoAgregarRol = await _userManager.AddToRoleAsync(user, RolesUtility.RoleAliado);
                        if (!resultadoAgregarRol.Succeeded)
                        {
                            Notificacion = "error";
                            NotificacionTitulo = "Aliado";
                            NotificacionMensaje = "Error inesperado al intentar actualizar los datos.";

                            await CargarDatosAsync(user);
                            return RedirectToPage();
                        }
                    }


                    await _signInManager.RefreshSignInAsync(user);
                    Notificacion = "success";
                    NotificacionTitulo = "Aliado";
                    if (AliadoEstado == IdentityAliadoEstado.NoEsAliado)
                    {
                        NotificacionMensaje = "Felicidades te convertiste en Aliado.";
                    }
                    else
                    {
                        NotificacionMensaje = "Datos actualizados.";
                    }

                    return RedirectToPage();
                }

                if (AliadoEstado == IdentityAliadoEstado.AliadoVerificado || AliadoEstado == IdentityAliadoEstado.AliadoVerificadoSolicitado && ManageAliado.SitioWeb != user.SitioWeb)
                {
                    if (ManageAliado.SitioWeb != user.SitioWeb && !string.IsNullOrEmpty(ManageAliado.SitioWeb))
                    {
                        // Validaciones
                        var validacion = await _identityManageAliadoVMValidator.ValidateAsync(ManageAliado, options => options.IncludeProperties(x => x.SitioWeb));
                        if (!validacion.IsValid)
                        {
                            foreach (var error in validacion.Errors)
                            {
                                ModelState.AddModelError($"ManageAliado.{error.PropertyName}", error.ErrorMessage);
                            }

                            await CargarDatosAsync(user);
                            return Page();
                        }


                        user.SitioWeb = ManageAliado.SitioWeb;
                        var resultadoActualizacion = await _userManager.UpdateAsync(user);
                        if (!resultadoActualizacion.Succeeded)
                        {
                            Notificacion = "error";
                            NotificacionTitulo = "Aliado";
                            NotificacionMensaje = "Error inesperado al intentar actualizar los datos.";
                            return RedirectToPage();
                        }


                        await _signInManager.RefreshSignInAsync(user);
                        Notificacion = "success";
                        NotificacionTitulo = "Aliado";
                        NotificacionMensaje = "Datos actualizados.";
                    }

                    return RedirectToPage();
                }
            }

            return RedirectToPage();
        }
    }
}
