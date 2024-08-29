using Dviaje.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class AliadosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        // Inyección en el controlador.
        public AliadosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // Muestra el perfil del aliado con las publicaciones realizadas.
        public IActionResult Aliado(string? idAliado)
        {
            return View();
        }
    }
}
