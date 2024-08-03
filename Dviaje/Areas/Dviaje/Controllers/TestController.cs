using Dviaje.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class TestController : Controller
    {
        public IActionResult Tee()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Tee(AtencionViajero atencionViajero)
        {
            if (!ModelState.IsValid)
            {

                return View(atencionViajero);
            }


            return View();
        }



    }
}
