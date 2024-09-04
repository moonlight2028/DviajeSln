using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    public class ReseñaController : Controller
    {
        public ReseñaController()
        {
        }

        public async Task<IActionResult> Disponibles(int? pagina)
        {
            // Validacion ruta de pagina

            // Obtener el ID del usuario autenticado

            // Agregar logica de paginacion, en esta logica se necesita otra consulta

            // Validar en la consulta si la reserva esta en estado Aprovado
            // Validar en la consulta si la fecha final ya se cumplio
            // Validar si en la tabla Resenas no hay un registro con el idReserva de la reserva
            // Ordenar donde salga primero la fecha final más reciente
            // La consulta tiene que tener paginación
            List<ResenaDisponibleTarjetaVM>? resenasDisponibles = null; // Consulta

            return View(resenasDisponibles);
        }

        public async Task<IActionResult> MisReseñas(int? pagina)
        {
            // Validacion ruta de pagina

            // obtener el ID del usuario autenticado

            // Agregar logica de paginacion, en esta logica se necesita otra consulta

            // Consulta
            // No cargar el dato AvatarTurista
            List<ResenasTarjetaVM> resenas = null;

            return View(resenas);
        }

        public IActionResult Crear(int? IdReserva)
        {
            // Validacion ruta de pagina

            // Obtener el ID del usuario autenticado

            // Consulta
            // Validar si la reserva existe y la realizo el usuario si no retornar a Disponibles

            ResenaCrearVM formulario = new ResenaCrearVM { IdReserva = (int)IdReserva };

            return View(formulario);
        }

        [HttpPost]
        public IActionResult Crear(ResenaCrearVM resenaCrear)
        {
            // Validacion ruta de pagina

            // Validar modelo

            // obtener el ID del usuario autenticado

            // Consulta
            // Validar si la reserva esta en estado Aprovado
            // Validar si la fecha final ya se cumplio
            // Validar si en la tabla Resenas no hay un registro con el idReserva de la reserva
            // Si si no pasa las valiaciones retornar a MisReseñas
            // Ejecutar consulta crear Resena

            return RedirectToAction(nameof(MisReseñas), new { pagina = 1 });
        }


        // Endpoints para JS
        [HttpPost]
        [ActionName("MeGusta")]
        public async Task<IActionResult> CrearMeGusta(int? idResena)
        {
            // Validar idResena

            // Obtener el id del usuario

            // Consulta
            // Valiadar que exista la Reseña
            // Valiadar que no exista ya un registro en la tabla ResenasMeGusta
            // Crear consulta para registrar en la tabla ResenasMeGusta

            return Ok();
        }

        [HttpDelete]
        [ActionName("MeGusta")]
        public async Task<IActionResult> EliminarMeGusta(int? idResena)
        {
            // Validar idResena

            // Obtener el id del usuario

            // Consulta
            // Valiadar que exista la Reseña
            // Crear consulta para eliminar registro en la tabla ResenasMeGusta

            return Ok();
        }
    }
}
