using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriasRepository _categoriasRepository;


        public CategoriasController(ICategoriasRepository categoriasRepository)
        {
            _categoriasRepository = categoriasRepository;
        }


        [HttpGet]
        [Route("categorias")]
        public async Task<IActionResult> Categorias()
        {
            List<Categoria>? categorias = await _categoriasRepository.ObtenerCategoriasAsync();

            return Ok(categorias);
        }
    }
}
