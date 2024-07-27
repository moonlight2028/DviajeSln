using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class PqrsController : Controller
    {
        public IActionResult PQRS()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PQRS(PqrsVM pqrsVM)
        {
            if (!ModelState.IsValid)
            {
                return View(pqrsVM);

            }

            return View();
        }
    }
}
