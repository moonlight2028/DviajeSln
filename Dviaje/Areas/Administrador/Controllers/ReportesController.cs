using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    [Authorize(Roles = RolesUtility.RoleAdministrador)]
    public class ReportesController : Controller
    {
        public IActionResult Publicaciones()
        {
            return View();
        }

        public IActionResult Pqrs()
        {
            return View();
        }
    }
}
