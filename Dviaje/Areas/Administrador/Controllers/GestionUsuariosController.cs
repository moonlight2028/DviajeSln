using Dviaje.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
        [Route("gestion/GestionUsuarios")]
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
            var usuarios = await _userRepository.ObtenerUsuariosAsync();

            if (usuarios == null || !usuarios.Any())
            {
                return Json(new { data = new List<object>() });
            }

            return Json(new { data = usuarios });
        }

        /// <summary>
        /// Cambia el rol de un usuario.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CambiarRol(string idUsuario, string nuevoRol)
        {
            Console.WriteLine($"ID Usuario: {idUsuario}, Nuevo Rol: {nuevoRol}");

            if (string.IsNullOrWhiteSpace(idUsuario) || string.IsNullOrWhiteSpace(nuevoRol))
            {
                return BadRequest(new { success = false, message = "El ID de usuario o el rol no pueden estar vacíos." });
            }

            if (!await _roleManager.RoleExistsAsync(nuevoRol))
            {
                Console.WriteLine($"El rol {nuevoRol} no existe.");
                return BadRequest(new { success = false, message = "El rol especificado no existe." });
            }

            try
            {
                var resultado = await _userRepository.CambiarRolUsuarioAsync(idUsuario, nuevoRol);
                if (resultado)
                {
                    Console.WriteLine("Rol actualizado correctamente.");
                    return Ok(new { success = true, message = "Rol actualizado correctamente." });
                }

                Console.WriteLine("Error al cambiar el rol.");
                return BadRequest(new { success = false, message = "Error al cambiar el rol del usuario." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cambiar el rol: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Error interno del servidor." });
            }
        }



        /// <summary>
        /// Banea un usuario.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> BanearUsuario(string idUsuario)
        {
            if (string.IsNullOrWhiteSpace(idUsuario))
            {
                return BadRequest(new { success = false, message = "El ID de usuario no puede estar vacío." });
            }

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
            if (string.IsNullOrWhiteSpace(idUsuario))
            {
                return BadRequest(new { success = false, message = "El ID de usuario no puede estar vacío." });
            }

            var resultado = await _userRepository.EliminarUsuarioAsync(idUsuario);

            if (resultado)
            {
                return Ok(new { success = true, message = "Usuario eliminado correctamente." });
            }

            return BadRequest(new { success = false, message = "Error al eliminar el usuario." });
        }
    }
}
