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
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error interno al obtener las categorías.",
                    details = ex.Message
                });
            }
        }

        /// <summary>
        /// Crea una nueva categoría.
        /// </summary>
        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearCategoria(Categoria categoria)
        {
            try
            {
                Console.WriteLine("Datos recibidos para CrearCategoria:");
                foreach (var key in Request.Form.Keys)
                {
                    Console.WriteLine($"{key}: {Request.Form[key]}");
                }

                Console.WriteLine($"IdCategoria: {categoria.IdCategoria}");
                Console.WriteLine($"NombreCategoria: {categoria.NombreCategoria}");
                Console.WriteLine($"Descripcion: {categoria.Descripcion}");
                Console.WriteLine($"RutaIcono: {categoria.RutaIcono}");
                Console.WriteLine($"UrlImagen: {categoria.UrlImagen}");
                Console.WriteLine($"IdImagen: {categoria.IdImagen}");

                if (!ModelState.IsValid)
                {
                    Console.WriteLine("Errores en el modelo:");
                    foreach (var error in ModelState)
                    {
                        Console.WriteLine($" - {error.Key}: {string.Join(", ", error.Value.Errors.Select(e => e.ErrorMessage))}");
                    }

                    return BadRequest(new
                    {
                        success = false,
                        message = "Datos inválidos.",
                        errors = ModelState.Values.SelectMany(v => v.Errors)
                                                  .Select(e => e.ErrorMessage)
                                                  .ToList()
                    });
                }

                var resultado = await _categoriasRepository.CrearCategoriaAsync(categoria);
                if (resultado)
                {
                    return Ok(new { success = true, message = "Categoría creada exitosamente." });
                }

                return BadRequest(new { success = false, message = "No se pudo crear la categoría." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear categoría: {ex.Message}");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error interno al crear la categoría.",
                    details = ex.Message
                });
            }
        }



        /// <summary>
        /// Obtiene una categoría por su ID.
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObtenerCategoria(int id)
        {
            try
            {
                var categoria = await _categoriasRepository.ObtenerCategoriaPorIdAsync(id);
                if (categoria == null)
                {
                    Console.WriteLine($"Categoría con ID {id} no encontrada.");
                    return NotFound(new { success = false, message = "Categoría no encontrada." });
                }

                return Ok(new { success = true, data = categoria });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener categoría con ID {id}: {ex.Message}");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error interno al obtener la categoría.",
                    details = ex.Message
                });
            }
        }

        /// <summary>
        /// Actualiza una categoría existente.
        /// </summary>
        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> ActualizarCategoria(Categoria categoria)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Console.WriteLine("Error en los datos enviados para ActualizarCategoria:");
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        Console.WriteLine($" - {error.ErrorMessage}");
                    }
                    return BadRequest(new { success = false, message = "Datos inválidos." });
                }

                var resultado = await _categoriasRepository.ActualizarCategoriaAsync(categoria);
                if (resultado)
                {
                    return Ok(new { success = true, message = "Categoría actualizada exitosamente." });
                }

                return BadRequest(new { success = false, message = "No se pudo actualizar la categoría." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción al actualizar categoría con ID {categoria.IdCategoria}: {ex.Message}");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error interno al actualizar la categoría.",
                    details = ex.Message
                });
            }
        }

        /// <summary>
        /// Elimina una categoría por su ID.
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> EliminarCategoria(int id)
        {
            try
            {
                var resultado = await _categoriasRepository.EliminarCategoriaAsync(id);
                if (resultado)
                {
                    return Ok(new { success = true, message = "Categoría eliminada exitosamente." });
                }

                Console.WriteLine($"Error al intentar eliminar la categoría con ID {id}.");
                return BadRequest(new { success = false, message = "No se pudo eliminar la categoría." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción al eliminar categoría con ID {id}: {ex.Message}");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error interno al eliminar la categoría.",
                    details = ex.Message
                });
            }
        }
    }
}
