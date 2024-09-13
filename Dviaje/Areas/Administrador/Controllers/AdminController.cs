using Dviaje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Admin.Controllers
{
    [Area("Administrador")]
    [Authorize(Roles = "Administrador")] // Solo administradores pueden acceder
    public class UsuarioController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        // Inyección de dependencias
        public UsuarioController(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Muestra la tabla de usuarios y sus roles
        public async Task<IActionResult> UserTable()
        {
            var usuarios = _userManager.Users.ToList(); // Obtener todos los usuarios

            var usuariosConRoles = usuarios.Select(async usuario =>
            {
                var roles = await _userManager.GetRolesAsync(usuario); // Obtener roles de cada usuario
                return new UsuarioViewModel
                {
                    Usuario = usuario,
                    Roles = string.Join(", ", roles)
                };
            });

            var usuariosFinal = await Task.WhenAll(usuariosConRoles); // Esperar todas las tareas
            return View(usuariosFinal);
        }

        // Cambiar el rol del usuario
        public async Task<IActionResult> CambiarRol(string id, string nuevoRol)
        {
            var usuario = await _userManager.FindByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            var rolesActuales = await _userManager.GetRolesAsync(usuario);
            if (rolesActuales.Any())
            {
                await _userManager.RemoveFromRolesAsync(usuario, rolesActuales); // Remover roles actuales
            }

            if (!await _roleManager.RoleExistsAsync(nuevoRol))
            {
                TempData["Error"] = "El rol no existe.";
                return RedirectToAction(nameof(UserTable));
            }

            await _userManager.AddToRoleAsync(usuario, nuevoRol); // Asignar el nuevo rol
            TempData["Success"] = "El rol ha sido actualizado.";
            return RedirectToAction(nameof(UserTable));
        }

        // Banear a un usuario (establecer LockoutEnd)
        public async Task<IActionResult> BanearUsuario(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.LockoutEnd = DateTimeOffset.UtcNow.AddYears(1000); // Banear indefinidamente
            await _userManager.UpdateAsync(usuario); // Actualizar el estado del usuario
            TempData["Success"] = "El usuario ha sido baneado.";
            return RedirectToAction(nameof(UserTable));
        }

        // Eliminar un usuario
        public async Task<IActionResult> EliminarUsuario(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            await _userManager.DeleteAsync(usuario); // Eliminar usuario
            TempData["Success"] = "El usuario ha sido eliminado.";
            return RedirectToAction(nameof(UserTable));
        }
    }

    // ViewModel para pasar los datos del usuario y sus roles a la vista
    public class UsuarioViewModel
    {
        public Usuario Usuario { get; set; }
        public string Roles { get; set; }
    }
}
