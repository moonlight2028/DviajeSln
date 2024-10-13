using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using Dviaje.Services.IServices;
using Dviaje.Utility;
using Dviaje.Validators;
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
        private IEnumerable<IValidator<PqrsCrearVM>> _pqrsCrearVMValidator;
        private readonly ISubirArchivosService _subirArchivos;
        private readonly IOptimizacionImagenesService _optimizarImagen;


        // Inyección de dependencias
        public PqrsController(
            IEnvioEmailService email,
            IPqrsRepository pqrsRepository,
            IEnumerable<IValidator<PqrsCrearVM>> pqrsCrearVMValidator,
            ISubirArchivosService subirArchivos,
            IOptimizacionImagenesService optimizarImagen)
        {
            _email = email;
            _pqrsRepository = pqrsRepository;
            _pqrsCrearVMValidator = pqrsCrearVMValidator;
            _subirArchivos = subirArchivos;
            _optimizarImagen = optimizarImagen;
        }


        [Route("pqrs")]
        public IActionResult Pqrs()
        {
            ViewBag.SesionIniciada = User.Identity.IsAuthenticated;

            return View();
        }

        [HttpPost]
        [Route("pqrs")]
        public async Task<IActionResult> Pqrs(PqrsCrearVM pqrs, List<IFormFile> archivos)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Validaciones
            IValidator<PqrsCrearVM> validador = userId == null
                ? _pqrsCrearVMValidator.OfType<PqrsCrearVMValidator>().FirstOrDefault()
                : _pqrsCrearVMValidator.OfType<PqrsCrearAutenticadoVMValidator>().FirstOrDefault();

            var validacion = await validador.ValidateAsync(pqrs);
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
            var resultado = await _pqrsRepository.CrearPqrsAsync(pqrs);

            // Registro Adjuntos
            if (resultado != null && archivos != null && archivos.Any())
            {
                var adjuntos = new List<AdjuntosVM>();

                // Guardado de archivos en Cloudinary
                foreach (var archivo in archivos)
                {
                    if (archivo.ContentType == "application/pdf")
                    {
                        var publicId = await _subirArchivos.SubirArchivoPrivadoAsync(archivo, ArchivosUtility.CarpetaPQRS((int)resultado));
                        adjuntos.Add(new AdjuntosVM
                        {
                            IdMensaje = (int)resultado,
                            IdPublico = publicId
                        });
                    }
                    else
                    {
                        var imagenOptimizada = await _optimizarImagen.ConvertirAWebPAsync(archivo.OpenReadStream(), 75);

                        var publicId = await _subirArchivos.SubirImagenPrivadaAsync(imagenOptimizada, archivo.FileName, ArchivosUtility.CarpetaPQRS((int)resultado));

                        adjuntos.Add(new AdjuntosVM
                        {
                            IdMensaje = (int)resultado,
                            IdPublico = publicId
                        });
                    }
                }

                // Guardado de adjuntos en la DB
                var resultadoRegistroAdjuntos = await _pqrsRepository.RegistrarAdjuntosAsync(adjuntos);
            }

            return RedirectToAction(nameof(Pqrs));
        }
    }
}
