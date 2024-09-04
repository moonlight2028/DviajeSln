using Dviaje.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    public class CategoriasController : Controller
    {
        public IActionResult Categorias()
        {
            // Consulta
            List<Categoria>? categoriasLista = null;

            return Ok();
        }
    }
}
