using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Dviaje.Services.IServices;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class PqrsController : Controller
    {
        private readonly IEnvioEmail _email;
        private readonly IPqrsRepository _pqrsRepository;
        private IValidator<PqrsCrearVM> _pqrsCrearVMValidator;


        // Inyección de dependencias
        public PqrsController(IEnvioEmail email, IPqrsRepository pqrsRepository, IValidator<PqrsCrearVM> pqrsCrearVMValidator)
        {
            _email = email;
            _pqrsRepository = pqrsRepository;
            _pqrsCrearVMValidator = pqrsCrearVMValidator;
        }


        [Route("pqrs")]
        public IActionResult Pqrs()
        {
            // Verificar si el usuario está autenticado
            ViewBag.SesionIniciada = User.Identity.IsAuthenticated;

            return View();
        }

        // POST: Procesa el envío de PQRS
        [HttpPost]
        [Route("pqrs")]
        public async Task<IActionResult> Pqrs(PqrsCrearVM pqrs, List<IFormFile> archivos)
        {
            var validacion = await _pqrsCrearVMValidator.ValidateAsync(pqrs);
            if (!validacion.IsValid)
            {
                validacion.AddToModelState(this.ModelState);

                ViewBag.SesionIniciada = User.Identity.IsAuthenticated;

                return View(pqrs);
            }


            return RedirectToAction(nameof(Pqrs));









            // Completar datos faltantes desde el controlador
            //pqrs.FechaAtencion = pqrs.FechaAtencion ?? DateTime.Now; // Asignar fecha actual si no está definida
            //pqrs.AtencionesViajerosEstado = AtencionesViajerosEstado.EsperaRespuestaUsuario; // Estado inicial
            //pqrs.AtencionesViajerosTipoPqrs = pqrs.AtencionesViajerosTipoPqrs; // Tipo de PQRS seleccionado por el usuario

            //// Procesar los archivos adjuntos si los hay
            //if (adjuntos != null && adjuntos.Any())
            //{
            //    pqrs.Adjuntos = new List<AdjuntosVM>();
            //    foreach (var file in adjuntos)
            //    {
            //        // Guardar el archivo en el servidor y generar la ruta
            //        var rutaAdjunto = Path.Combine("ruta/al/directorio", file.FileName);

            //        // Simulamos la escritura del archivo al sistema de archivos
            //        using (var stream = new FileStream(rutaAdjunto, FileMode.Create))
            //        {
            //            await file.CopyToAsync(stream);
            //        }

            //        // Añadimos el adjunto al ViewModel
            //        pqrs.Adjuntos.Add(new AdjuntosVM
            //        {
            //            RutaAdjunto = rutaAdjunto,
            //            IdMensaje = 0 // Este ID se asignará en el repositorio
            //        });
            //    }
            //}

            //// Enviar la PQRS al repositorio para registrarla en la base de datos
            //var resultado = await _pqrsRepository.CrearPqrsAsync(pqrs);
            //if (!resultado)
            //{
            //    // Si hubo un error al guardar la PQRS, agregar un mensaje de error
            //    ModelState.AddModelError("", "Error al enviar la PQRS.");
            //    return View(pqrs);
            //}

            //// Enviar correo de confirmación al usuario
            //// await _email.EnviarEmailAsync(pqrs.Correo, "Confirmación de PQRS", "Tu PQRS ha sido recibida exitosamente.");

            //// Redirigir a una página de confirmación o mostrar un mensaje de éxito
            //return RedirectToAction("Confirmacion");
        }
    }
}
