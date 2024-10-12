using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using Dviaje.Services.IServices;
using Dviaje.Utility;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class PqrsController : Controller
    {
        private readonly IEnvioEmailService _email;
        private readonly IPqrsRepository _pqrsRepository;
        private IValidator<PqrsCrearVM> _pqrsCrearVMValidator;
        private readonly ISubirArchivosService _subirArchivos;


        // Inyección de dependencias
        public PqrsController(IEnvioEmailService email, IPqrsRepository pqrsRepository, IValidator<PqrsCrearVM> pqrsCrearVMValidator, ISubirArchivosService subirArchivos)
        {
            _email = email;
            _pqrsRepository = pqrsRepository;
            _pqrsCrearVMValidator = pqrsCrearVMValidator;
            _subirArchivos = subirArchivos;
        }


        [Route("pqrs")]
        public IActionResult Pqrs()
        {
            // Verificar si el usuario está autenticado
            ViewBag.SesionIniciada = User.Identity.IsAuthenticated;

            return View();
        }

        [HttpPost]
        [Route("pqrs")]
        public async Task<IActionResult> Pqrs(PqrsCrearVM pqrs, List<IFormFile> archivos)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Validaciones
            var validacion = await _pqrsCrearVMValidator.ValidateAsync(pqrs);
            if (!validacion.IsValid)
            {
                validacion.AddToModelState(this.ModelState);

                ViewBag.SesionIniciada = userId == null ? false : true;

                return View(pqrs);
            }

            if (archivos != null && archivos.Any())
            {
                foreach (var archivo in archivos)
                {
                    if (!ArchivosUtility.ArchivosValidos.Contains(archivo.ContentType))
                    {
                        ViewBag.SesionIniciada = userId == null ? false : true;

                        return View(pqrs);
                    }
                }
            }

            // Registros
            pqrs.FechaAtencion = DateTime.UtcNow;
            pqrs.AtencionesViajerosEstado = AtencionesViajerosEstado.Proceso;
            pqrs.IdTurista = userId;
            var result = await _pqrsRepository.CrearPqrsAsync(pqrs);

            var s = "dasfasd";






            //// Registrar en la tabla AtencionViajeros y retornar el Id
            //pqrs.FechaAtencion = DateTime.UtcNow;
            //pqrs.AtencionesViajerosEstado = AtencionesViajerosEstado.EsperaRespuestaUsuario;
            //pqrs.IdTurista = userId;


            //// Registrar en la tabla Mensaje y retornar el Id
            //pqrs.IdAtencionViajero = 1;


            //// Registrar en la tabla Adjuntos
            //if (archivos != null && archivos.Any())
            //{
            //    foreach (var archivo in archivos)
            //    {
            //        if (archivo.ContentType == "application/pdf")
            //        {
            //            var url = await _subirArchivos.SubirArchivoAsync(archivo, ArchivosUtility.CarpetaPQRS(1));
            //            pqrs.Adjuntos.Add(new AdjuntosVM
            //            {
            //                IdMensaje = 1,
            //                RutaAdjunto = url,
            //                IdPublico = ""
            //            });
            //        }
            //        else
            //        {
            //            var url = await _subirArchivos.SubirArchivoAsync(archivo, ArchivosUtility.CarpetaPQRS(1));
            //            pqrs.Adjuntos.Add(new AdjuntosVM
            //            {
            //                IdMensaje = 1,
            //                RutaAdjunto = url,
            //                IdPublico = ""
            //            });
            //        }
            //    }
            //}

            return RedirectToAction(nameof(Pqrs));
        }
    }
}
