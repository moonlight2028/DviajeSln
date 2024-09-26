using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Moderador.Controllers
{
    [Area("Moderador")]
    [Authorize(Roles = RolesUtility.RoleModerador)]
    public class GestionParametrosController : Controller
    {
        [Route("gestion/servicios")]
        public IActionResult Servicios()
        {
            return View();
        }

        [Route("gestion/restricciones")]
        public IActionResult Restricciones()
        {
            return View();
        }

        [Route("gestion/categorias")]
        public IActionResult Categorias()
        {
            return View();
        }
    }
}
