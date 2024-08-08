using Dviaje.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Turista.Controllers
{
    public class ResenaController : Controller
    {

        [Area("Turista")]
        public IActionResult Resena()
        {
            return View();

        }


        [HttpPost]
        public IActionResult Crear(int publicacionId, Resena resena)
        {
            if (ModelState.IsValid)
            {
                // resena.PublicacionId = publicacionId;
                //_context.Add(resena);
                //_context.SaveChanges();
            }

            return RedirectToAction("Detalles", "Publicaciones", new { id = publicacionId });
        }
    }
}
