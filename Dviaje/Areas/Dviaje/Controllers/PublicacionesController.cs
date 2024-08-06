using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class PublicacionesController : Controller
    {
        private IUnitOfWork _unitOfWork;


        public PublicacionesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IActionResult> Publicaciones()
        {
            List<PublicacionPublicacionesVM> publicaciones = await _unitOfWork.PublicacionRepository.GetPublicacionesAsync(1, 20);

            return View(publicaciones);
        }

        public IActionResult Publicacion()
        {
            return View();
        }
    }
}
