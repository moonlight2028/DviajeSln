using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Moderador.Controllers
{
    [Area("Moderador")]
    public class TestController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public TestController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Usuarios()
        {
            // Obtiene todos los usuarios
            var users = _userManager.Users.ToList();

            // Lista para almacenar los usuarios y sus roles
            var usuariosConRoles = new List<UsuariosTestVM>();

            foreach (var user in users)
            {
                // Obtiene los roles del usuario actual
                var roles = await _userManager.GetRolesAsync(user);

                // Añade la información del usuario y sus roles a la lista
                usuariosConRoles.Add(new UsuariosTestVM
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Roles = roles.ToList()
                });
            }

            // Pasa la lista a la vista
            return View(usuariosConRoles);
        }


        // Con LINQ usando el metodo de sintaxis con metodos
        public async Task<IActionResult> UsuariosConLINQMetodos()
        {
            List<UsuariosTestVM> listaUsuarios = await _unitOfWork.UsuariosTest.ListaDeUsuarios();

            // Pasa la lista a la vista
            return View(listaUsuarios);
        }

        // Con LINQ usando la sintaxis parecida a SQL
        public async Task<IActionResult> UsuariosConLINQSQL()
        {
            List<UsuariosTestVM> listaUsuarios = await _unitOfWork.UsuariosTest.ListaDeUsuariosDos();

            // Pasa la lista a la vista
            return View(listaUsuarios);
        }


    }



}
