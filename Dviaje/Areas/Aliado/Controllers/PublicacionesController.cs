using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Aliado.Controllers
{
    [Area("Aliado")]
    [Authorize(Roles = RolesUtility.RoleAliado)]
    public class PublicacionesController : Controller
    {
        private readonly IPublicacionesRepository _publicacionesRepository;


        public PublicacionesController(IPublicacionesRepository publicacionesRepository)
        {
            _publicacionesRepository = publicacionesRepository;
        }


        [Route("publicacion/crear")]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(PublicacionCrearVM publicacion)
        {
            bool resultado = await _publicacionesRepository.CrearPublicacionAsync(publicacion);

            return View();
        }

        [Route("publicacion/editar/{id?}")]
        public async Task<IActionResult> Editar(int? id)
        {
            PublicacionCrearVM? publicacion = await _publicacionesRepository.ObtenerPublicacionCrearVMAsync((int)id);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(PublicacionCrearVM publicacion)
        {
            bool resultado = await _publicacionesRepository.EditarPublicacionAsync(publicacion);

            return View();
        }

        [Route("publicaciones/mis-publicaciones")]
        public async Task<IActionResult> MisPublicaciones(int? pagina, string? ordenar)
        {
            // Consulta
            List<PublicacionTarjetaBusquedaVM>? misPublicaciones = await _publicacionesRepository.ObtenerListaPublicacionTarjetaBusquedaVMAsync(1, 2, "puntuacion");

            return View(misPublicaciones);
        }


        [HttpDelete]
        [Route("publicacion/estado")]
        public async Task<IActionResult> Eliminar(int? id)
        {
            // Consulta eliminar en el estado
            bool resultado = await _publicacionesRepository.EstadoEliminarPublicacionAsync((int)id, 2);

            return Ok();
        }

        [HttpPut]
        [Route("publicacion/estado")]
        public async Task<IActionResult> CambiarEstado(int? id, string? estado)
        {
            // Consulta pausar y activar en el estado
            bool resultado = await _publicacionesRepository.EstadoCambiarPublicacionAsync((int)id, 2, "activa");

            return Ok();
        }
    }
}
