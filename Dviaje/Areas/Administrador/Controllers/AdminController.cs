using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Admin.Controllers
{
    [Area("Administrador")]
    [Authorize(Roles = "Administrador")]
    public class UsuarioController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<IActionResult> UserTable()
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetAllAsync();

            // Obtener los roles de los usuarios
            var usuariosConRoles = usuarios.Select(async usuario =>
            {
                var roles = await _unitOfWork.UsuarioRepository.GetRolesAsync(usuario);
                return new UsuarioViewModel
                {
                    Usuario = usuario,
                    Roles = string.Join(", ", roles)
                };
            });

            var usuariosFinal = await Task.WhenAll(usuariosConRoles); // Ejecuta todas las tareas y espera por todas
            return View(usuariosFinal);
        }

        public async Task<IActionResult> CambiarRol(string id, string nuevoRol)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetAsync(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            // Cambiar el rol del usuario
            await _unitOfWork.UsuarioRepository.CambiarRol(usuario, nuevoRol);
            await _unitOfWork.Save();
            TempData["Success"] = "El rol ha sido actualizado.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> BanearUsuario(string id)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetAsync(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.LockoutEnd = DateTime.Now.AddYears(1000); // Ban indefinido
            _unitOfWork.UsuarioRepository.Update(usuario);
            await _unitOfWork.Save();

            TempData["Success"] = "El usuario ha sido baneado.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EliminarUsuario(string id)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetAsync(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            _unitOfWork.UsuarioRepository.Remove(usuario);
            await _unitOfWork.Save();

            TempData["Success"] = "El usuario ha sido eliminado.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GenerarReporte()
        {
            // lógica para generar un reporte en PDF o gráficos
            return View();
        }
    }

    // ViewModel para pasar los datos del usuario y sus roles a la vista
    public class UsuarioViewModel
    {
        public Usuario Usuario { get; set; }
        public string Roles { get; set; }
    }
}
