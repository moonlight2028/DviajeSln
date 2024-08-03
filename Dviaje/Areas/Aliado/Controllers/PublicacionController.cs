using Dviaje.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Aliado.Controllers
{
    [Area("Aliado")]
    public class PublicacionController : Controller
    {
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Publicacion publicacion)
        {
            if (!ModelState.IsValid)
            {
                if (ModelState["Precio"].Errors.Any(e => e.ErrorMessage.Contains("is invalid")))
                {
                    ModelState["Precio"].Errors.Clear(); // Elimina el error anterior
                    ModelState.AddModelError("Precio", "El precio debe ser un número válido."); // Agrega un mensaje personalizado
                }

                return View(publicacion);
            }

            return View();
        }
    }
}
