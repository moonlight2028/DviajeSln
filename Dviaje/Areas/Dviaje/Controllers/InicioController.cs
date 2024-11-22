using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class InicioController : Controller
    {
        private readonly ILandingPageRepository _landingPageRepository;
        private readonly IPublicacionesRepository _publicacionesRepository;

        public InicioController(ILandingPageRepository landingPageRepository, IPublicacionesRepository publicacionesRepository)
        {
            _landingPageRepository = landingPageRepository;
            _publicacionesRepository = publicacionesRepository;
        }

        // Acción para la página de inicio (landing)
        public async Task<IActionResult> Index()
        {
            var landingPageData = new LandingPageVM
            {
                PublicacionesDestacadas = await _landingPageRepository.ObtenerPublicacionesDestacadasAsync(),
                Categorias = await _landingPageRepository.ObtenerCategoriasAsync()
            };

            return View(landingPageData);
        }

        // Acción para listar publicaciones por categoría
        [HttpGet]
        public async Task<IActionResult> PorCategoria(int id)
        {
            var publicaciones = await _publicacionesRepository.ObtenerPublicacionesPorCategoriaAsync(id);
            if (publicaciones == null || !publicaciones.Any())
            {
                TempData["Info"] = "No hay publicaciones disponibles en esta categoría.";
                return RedirectToAction("Index");
            }

            return View(publicaciones);
        }
    }
}
