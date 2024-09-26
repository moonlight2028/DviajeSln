using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Aliado.Controllers
{
    [Area("Aliado")]
    [Authorize(Roles = RolesUtility.RoleAliado)]
    public class ResenasController : Controller
    {
        private readonly IResenasRepository _resenasRepository;


        public ResenasController(IResenasRepository resenasRepository)
        {
            _resenasRepository = resenasRepository;
        }


        [Route("reseñas/recibidas")]
        public async Task<IActionResult> ResenasRecibidas(int? pagina, string? ordenar)
        {
            List<ResenaTarjetaRecibidaVM>? resenas = await _resenasRepository.ObtenerListaResenaTarjetaRecibidaVMAsync("IDALIADO");

            return View(resenas);
        }
    }
}
