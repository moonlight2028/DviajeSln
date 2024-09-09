using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        // Muestra el perfil público del usuario
        public async Task<IActionResult> Index(string? idUsuario)
        {
            // Si no hay usuario autenticado, redirige al inicio
            if (string.IsNullOrEmpty(idUsuario))
            {
                idUsuario = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            if (string.IsNullOrEmpty(idUsuario))
            {
                return RedirectToAction("Index", "Home");
            }

            // Obtener los roles del usuario
            var esAliado = User.IsInRole("Aliado");
            var esTurista = User.IsInRole("Turista");

            // Validar el rol y ejecutar la consulta correspondiente
            PerfilPublicoVM perfilPublico = null;

            if (esAliado)
            {
                // Consulta para obtener el perfil del aliado
                perfilPublico = await _perfilRepository.GetPerfilAliadoAsync(idUsuario);
            }
            else if (esTurista)
            {
                // Consulta para obtener el perfil del turista
                perfilPublico = await _perfilRepository.GetPerfilTuristaAsync(idUsuario);
            }

            // Si no se encuentra el perfil, redirige a la página de inicio
            if (perfilPublico == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(perfilPublico); // Muestra la vista del perfil con los datos obtenidos
        }
    }
}
