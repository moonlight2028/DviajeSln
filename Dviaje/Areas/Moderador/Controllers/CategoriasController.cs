using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Moderador.Controllers
{
    [Area("Moderador")]
    [Authorize(Roles = RolesUtility.RoleModerador)]
    public class CategoriasController : Controller
    {
        private readonly ICategoriasRepository _categoriasRepository;


        public CategoriasController(ICategoriasRepository categoriasRepository)
        {
            _categoriasRepository = categoriasRepository;
        }


        [HttpPost]
        [Route("categorias")]
        public async Task<IActionResult> CrearCategoria(Categoria categoria)
        {
            bool resultado = await _categoriasRepository.CrearCategoriaAsync(categoria);

            return Ok();
        }

        [HttpGet]
        [Route("categorias/{id?}")]
        public async Task<IActionResult> ObtenerCategoria(int? id)
        {
            Restriccion? restriccion = await _categoriasRepository.ObtenerCategoriaPorIdAsync((int)id);

            return Ok(restriccion);
        }

        [HttpPut]
        [Route("categorias")]
        public async Task<IActionResult> ActualizarCategoria(Categoria categoria)
        {
            bool resultado = await _categoriasRepository.ActualizarCategoriaAsync(categoria);

            return Ok();
        }

        [HttpDelete]
        [Route("categorias/{id?}")]
        public async Task<IActionResult> EliminarCategoria(int? id)
        {
            bool resultado = await _categoriasRepository.EliminarCategoriaAsync((int)id);

            return Ok();
        }
    }
}
