using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class PerfilController : Controller
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilController(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }


        [Route("perfil/{id?}")]
        public async Task<IActionResult> Index(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Inicio");
            }

            // Corregir consulta
            PerfilPublicoVM? perfilPublico = await _perfilRepository.ObtenerPerfilPublicoVMAsync(id);

            // Si no se encuentra el perfil, redirige a la página de inicio
            if (perfilPublico == null)
            {
                return RedirectToAction("Index", "Inicio");
            }

            return View(perfilPublico);
        }
    }
}
