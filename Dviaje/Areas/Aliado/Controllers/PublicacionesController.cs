using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Aliado.Controllers
{
    [Area("Aliado")]
    public class PublicacionesController : Controller
    {
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(PublicacionCrearVM publicacion)
        {
            return View();
        }

        public IActionResult MisPublicaciones(int? pagina)
        {
            // Consulta
            List<PublicacionTarjetaV2VM>? misPublicaciones = null;

            return View(misPublicaciones);
        }

        public IActionResult Editar(int? idPublicacion)
        {
            // Consulta
            PublicacionCrearVM publicacion = null;

            return View(publicacion);
        }

        [HttpPost]
        public IActionResult Editar(PublicacionCrearVM publicacion)
        {
            // Consulta editar

            return Redirect("/Dviaje/Publicaciones/Publicacion/1");
        }


        // Endpoints para JS
        [HttpDelete]
        public IActionResult Eliminar(int? idPublicacion)
        {
            // Consulta eliminar

            return Ok();
        }

        [HttpPut]
        public IActionResult Pausar(int? idPublicacion)
        {
            // Consulta pausar

            return Ok();
        }

    }
}
