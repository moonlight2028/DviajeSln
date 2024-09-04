using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class PerfilController : Controller
    {
        // Repositorios necesitados


        // Inyección de repositorios
        public PerfilController()
        {

        }

        public IActionResult Index(string? idUsuario)
        {
            // Validacion ruta de pagina

            // Validar con Identity si el usuario tiene el rol turista, si no lo tiene redirigir a Landing
            // Validar con Identity si el usuario tiene el rol aliado y si lo tiene asigna valor despues al modelo perfil y ejecutar consulta correspondiente

            // Consulta perfil Aliado o Consulta perfil Turista
            // Una consulta carga los datos del perfil del turista otra del aliado
            PerfilPublicoVM? perfilPublico = null; // Consulta

            return View(perfilPublico);
        }
    }
}
