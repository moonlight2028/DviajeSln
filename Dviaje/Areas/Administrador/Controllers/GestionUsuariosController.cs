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

        public IActionResult GestionUsuario()
        {
            return View();
        }

        // Acción para devolver datos de usuarios en formato JSON para DataTables
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _userRepository.ObtenerUsuariosAsync();
            return Json(new { data = usuarios });
        }

        // Cambiar rol de usuario
        [HttpPost]
        public async Task<IActionResult> CambiarRol(string idUsuario, string nuevoRol)
        {
            // Verificar si el rol existe
            if (!await _roleManager.RoleExistsAsync(nuevoRol))
            {
                return BadRequest("El rol especificado no existe.");
            }

            var resultado = await _userRepository.CambiarRolUsuarioAsync(idUsuario, nuevoRol);

            if (resultado)
            {
                return Ok(new { success = true, message = "Rol actualizado correctamente." });
            }

            return BadRequest("Error al cambiar el rol del usuario.");
        }

        // Banear usuario
        [HttpPost]
        public async Task<IActionResult> BanearUsuario(string idUsuario)
        {
            var resultado = await _userRepository.BanearUsuarioAsync(idUsuario);

            if (resultado)
            {
                return Ok(new { success = true, message = "Usuario baneado correctamente." });
            }

            return BadRequest("Error al banear el usuario.");
        }

        // Eliminar usuario
        [HttpPost]
        public async Task<IActionResult> EliminarUsuario(string idUsuario)
        {
            var resultado = await _userRepository.EliminarUsuarioAsync(idUsuario);

            if (resultado)
            {
                return Ok(new { success = true, message = "Usuario eliminado correctamente." });
            }

            return BadRequest("Error al eliminar el usuario.");
        }
    }
}
