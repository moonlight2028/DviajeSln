using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Moderador.Controllers
{
    [Area("Moderador")]
    [Authorize(Roles = RolesUtility.RoleModerador)]
    public class PublicacionesController : Controller
    {
        private readonly IPublicacionesRepository _publicacionesRepository;


        public PublicacionesController(IPublicacionesRepository publicacionesRepository)
        {
            _publicacionesRepository = publicacionesRepository;
        }


        [Route("publicaciones/administrar")]
        public IActionResult Publicaciones()
        {
            return View();
        }


        [HttpGet]
        [Route("publicaciones/lista")]
        public async Task<IActionResult> ListaPublicaciones()
        {
            List<PublicacionTablaItemVM>? publicaciones = await _publicacionesRepository.ObtenerListaPublicacionTablaItemVMAsync();

            return View(publicaciones);
        }
    }
}
