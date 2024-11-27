using Dviaje.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dviaje.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    [Authorize(Roles = "Administrador")]
    public class GestionUsuariosController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly RoleManager<IdentityRole> _roleManager;

        public GestionUsuariosController(IUserRepository userRepository, RoleManager<IdentityRole> roleManager)
        {
            _userRepository = userRepository;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Vista principal para la gestión de usuarios.
        /// </summary>
        public IActionResult GestionUsuario()
        {
            return View();
        }

        /// <summary>
        /// Obtiene los usuarios para DataTables.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            // Obtiene los usuarios desde el repositorio.
            var usuarios = await _userRepository.ObtenerUsuariosAsync();

            // Asegúrate de incluir los roles disponibles para cada usuario.
            foreach (var usuario in usuarios)
            {
                usuario.RolesDisponibles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            }

            // Devuelve los datos en el formato esperado por DataTables.
            return Json(new { data = usuarios });
        }

        /// <summary>
        /// Cambia el rol de un usuario.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CambiarRol(string idUsuario, string nuevoRol)
        {
            // Verifica si el rol existe.
            if (!await _roleManager.RoleExistsAsync(nuevoRol))
            {
                return BadRequest(new { success = false, message = "El rol especificado no existe." });
            }

            var resultado = await _userRepository.CambiarRolUsuarioAsync(idUsuario, nuevoRol);

            if (resultado)
            {
                return Ok(new { success = true, message = "Rol actualizado correctamente." });
            }

            return BadRequest(new { success = false, message = "Error al cambiar el rol del usuario." });
        }

        /// <summary>
        /// Banea un usuario.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> BanearUsuario(string idUsuario)
        {
            var resultado = await _userRepository.BanearUsuarioAsync(idUsuario);

            if (resultado)
            {
                return Ok(new { success = true, message = "Usuario baneado correctamente." });
            }

            return BadRequest(new { success = false, message = "Error al banear el usuario." });
        }

        /// <summary>
        /// Elimina un usuario.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> EliminarUsuario(string idUsuario)
        {
            var resultado = await _userRepository.EliminarUsuarioAsync(idUsuario);

            if (resultado)
            {
                return Ok(new { success = true, message = "Usuario eliminado correctamente." });
            }

            return BadRequest(new { success = false, message = "Error al eliminar el usuario." });
        }
    }
}
