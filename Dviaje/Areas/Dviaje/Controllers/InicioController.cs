using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class InicioController : Controller
    {
        private readonly ILandingPageRepository _landingPageRepository;

        public InicioController(ILandingPageRepository landingPageRepository)
        {
            _landingPageRepository = landingPageRepository;
        }

        public async Task<IActionResult> Index()
        {
            var landingPageData = new LandingPageVM
            {
                PublicacionesDestacadas = await _landingPageRepository.ObtenerPublicacionesDestacadasAsync(),
                Categorias = await _landingPageRepository.ObtenerCategoriasAsync()
            };

            return View(landingPageData);
        }
    }
}
