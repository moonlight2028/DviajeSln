using Dviaje.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    public class FavoritosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        // Inyección en el controlador.
        public FavoritosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Favoritos(int? pagina)
        {
            return View();
        }
    }
}
