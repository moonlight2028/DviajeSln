using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class UsuariosController : Controller
    {
        // Repositorios necesitados


        // Inyección de repositorios
        public UsuariosController()
        {

        }


        public IActionResult Perfil(string? idUsuario)
        {
            UsuarioPerfilPublicoVM? usuarioPerfil = null; // Consulta

            return View(usuarioPerfil);
        }
    }
}
