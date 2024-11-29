using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Moderador.Controllers
{
    [Area("Moderador")]
    [Route("Moderador/categorias")]
    [Authorize(Roles = RolesUtility.RoleModerador)]
    public class CategoriasController : Controller
    {
        private readonly ICategoriasRepository _categoriasRepository;

        public CategoriasController(ICategoriasRepository categoriasRepository)
        {
            _categoriasRepository = categoriasRepository;
        }

        /// <summary>
        /// Obtiene el listado de todas las categorías (para el DataTable).
        /// </summary>
        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ObtenerCategorias()
        {
            try
            {
                var categorias = await _categoriasRepository.ObtenerCategoriasAsync();
                if (categorias == null || !categorias.Any())
                {
                    return Ok(new { data = new List<object>(), message = "No hay categorías disponibles." });
                }

                return Ok(new { data = categorias });
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al obtener categorías: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Error al obtener categorías.", details = ex.Message });
            }
        }


        /// <summary>
        /// Crea una nueva categoría.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CrearCategoria(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _categoriasRepository.CrearCategoriaAsync(categoria);
            if (resultado)
            {
                return Ok(new { success = true, message = "Categoría creada exitosamente." });
            }

            return BadRequest(new { success = false, message = "Error al crear la categoría." });
        }

        /// <summary>
        /// Obtiene una categoría por su ID.
        /// </summary>
        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> ObtenerCategoria(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest(new { success = false, message = "ID de categoría no proporcionado." });
            }

            var categoria = await _categoriasRepository.ObtenerCategoriaPorIdAsync(id.Value);
            if (categoria == null)
            {
                return NotFound(new { success = false, message = "Categoría no encontrada." });
            }

            return Ok(new { success = true, data = categoria });
        }

        /// <summary>
        /// Actualiza una categoría existente.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> ActualizarCategoria(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _categoriasRepository.ActualizarCategoriaAsync(categoria);
            if (resultado)
            {
                return Ok(new { success = true, message = "Categoría actualizada exitosamente." });
            }

            return BadRequest(new { success = false, message = "Error al actualizar la categoría." });
        }

        /// <summary>
        /// Elimina una categoría por su ID.
        /// </summary>
        [HttpDelete]
        [Route("{id?}")]
        public async Task<IActionResult> EliminarCategoria(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest(new { success = false, message = "ID de categoría no proporcionado." });
            }

            var resultado = await _categoriasRepository.EliminarCategoriaAsync(id.Value);
            if (resultado)
            {
                return Ok(new { success = true, message = "Categoría eliminada exitosamente." });
            }

            return BadRequest(new { success = false, message = "Error al eliminar la categoría." });
        }
    }
}
