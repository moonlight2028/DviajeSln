using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using Dviaje.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dviaje.Areas.Turista.Controllers
{
    [Area("Turista")]
    [Authorize(Roles = "Turista")]
    public class VerificacionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEnvioEmail _envioEmail;

        public VerificacionController(IUnitOfWork unitOfWork, IEnvioEmail envioEmail)
        {
            _unitOfWork = unitOfWork;
            _envioEmail = envioEmail;
        }

        // GET: Mostrar formulario de solicitud de verificación
        public IActionResult SolicitarVerificacion()
        {
            return View();
        }

        // POST: Enviar solicitud de verificación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SolicitarVerificacion(VerificacionVM verificacionVM)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var verificado = new Verificado
                {
                    IdAliado = userId,
                    FechaSolicitud = DateTime.Now,
                    VerificadoEstado = VerificadoEstado.Pendiente,
                    Motivo = verificacionVM.Motivo,
                    Direccion = verificacionVM.Direccion,
                    DocumentosAdjuntos = verificacionVM.DocumentosAdjuntos,
                    DetallesPropiedad = verificacionVM.DetallesPropiedad
                };

                await _unitOfWork.VerificadoRepository.AddAsync(verificado);
                await _unitOfWork.Save();

                // Enviar correo electrónico usando SendGrid
                var cuerpoCorreo = $"El usuario {User.Identity.Name} ha solicitado ser aliado. Por favor revisa la solicitud.";
                await _envioEmail.EnviarEmail("Nueva solicitud de verificación de aliado", "admin@dviaje.com", "Administrador", cuerpoCorreo, cuerpoCorreo);

                TempData["Success"] = "Tu solicitud ha sido enviada y está pendiente de revisión.";
                return RedirectToAction("Index", "Home");
            }
            return View(verificacionVM);
        }

        // GET: Administrador cambia el estado de la verificación
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CambiarEstado(int id, VerificadoEstado estado)
        {
            var verificado = await _unitOfWork.VerificadoRepository.GetAsync(v => v.IdVerificado == id);
            if (verificado == null)
            {
                return NotFound();
            }

            verificado.VerificadoEstado = estado;
            verificado.FechaRespuesta = DateTime.Now;
            _unitOfWork.VerificadoRepository.Update(verificado);
            await _unitOfWork.Save();

            TempData["Success"] = "El estado de la verificación ha sido actualizado.";
            return RedirectToAction("ListaSolicitudes", "Admin");
        }
    }
}
