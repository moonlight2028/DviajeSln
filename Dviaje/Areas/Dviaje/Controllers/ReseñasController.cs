using Dviaje.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class ReseñasController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        // Inyección en el controlador.
        public ReseñasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Reseñas(int? idPublicacion, int? paginaActual)
        {
            return View();
        }
    }
}
