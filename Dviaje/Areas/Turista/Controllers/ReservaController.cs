using Dviaje.Models.VM;
using Dviaje.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    public class ReservaController : Controller
    {
        private readonly IEnvioEmail _envioEmail;

        public ReservaController(IEnvioEmail envioEmail)
        {
            _envioEmail = envioEmail;
        }


        public async Task<IActionResult> Reservar(int? idPublicacion)
        {
            // Validacion ruta de pagina

            ReservaCrearVM reservaFormulario = new ReservaCrearVM { IdPublicacion = (int)idPublicacion };

            // Consulta
            // Cargar servicios adicionales de la publicacion
            reservaFormulario.ServiciosAdicionales = null;

            return View(reservaFormulario);
        }

        [HttpPost]
        public async Task<IActionResult> Reservar(ReservaCrearVM reservaFormCrear)
        {
            // Validar Modelo

            // Obtener Id Usuario

            // Validar si existe la publicación
            // Validar si la publicacion si tiene los servicios adicionales
            // Si no pasa las validaciones retornar a Publicaciones

            // LLenar campos faltantes del modelo y calcular precio total

            // Consulta
            // Registrar en la tabla Reservas
            // Si tiene ServiciosAdicionales registrar en la tabla ReservasServiciosAdicionales

            return RedirectToAction(nameof(MisReservas));
        }

        public async Task<IActionResult> MisReservas(int? pagina, string? estado)
        {
            // Consulta
            List<ReservaTarjetaV2VM>? listaReservas = null;

            return View(listaReservas);
        }

        public async Task<IActionResult> MiReserva(int? idReserva)
        {
            // Consulta
            ReservaTarjetaV3VM reservaDetalles = null;

            return View(reservaDetalles);
        }


        // Endpoints para JS
        [HttpGet]
        public IActionResult ReservaTarjeta(int? idReserva)
        {
            // Validacion ruta de pagina

            // Obtener el ID del usuario autenticado

            // Cosulta
            // Validar si el Id del usuario es igual al registrado en la reserva
            ReservaTarjetaVM? resenaTarjeta = null;

            // Retornar JSON, si es null retornar NoContent

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> CancelarReserva(int reservaId)
        {
            return Ok();
        }

    }
}
