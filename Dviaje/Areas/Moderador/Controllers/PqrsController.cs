using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Moderador.Controllers
{
    [Area("Moderador")]
    [Authorize(Roles = RolesUtility.RoleModerador)]
    public class PqrsController : Controller
    {
        [Route("pqrs/moderador")]
        public IActionResult Pqrs()
        {
            return View();
        }
    }
}
