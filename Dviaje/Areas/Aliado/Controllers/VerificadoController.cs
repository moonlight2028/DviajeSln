using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dviaje.Areas.Aliado.Controllers
{
    /// <summary>
    /// Controlador responsable de proporcionar los endpoints para la verificación de cuentas desde el rol de aliado.
    /// Este controlador implementa la autorización necesaria para que solo los usuarios con el rol de aliado puedan acceder a estos endpoints.
    /// Requiere estar autenticado y tener el rol de aliado para realizar las acciones ofrecidas.
    /// </summary>
    [Area("Aliado")]
    [Authorize(Roles = RolesUtility.RoleAliado)]
    public class VerificadoController : Controller
    {
        private readonly IPerfilRepository _perfilRepository;


        public VerificadoController(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }


        /// <summary>
        /// Método POST para solicitar la verificación de una cuenta desde el rol de aliado.
        /// Permite que un usuario con rol de aliado solicite la verificación de su cuenta si no tiene una solicitud pendiente.
        /// </summary>
        /// <returns>Una respuesta de éxito si la solicitud se realiza correctamente, o un error si ya existe una solicitud pendiente o si ocurre un fallo en el proceso.</returns>
        [Route("verificado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Verificado()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return BadRequest();

            var verificadoPendiente = await _perfilRepository.VerificadoTieneEstadoPendienteAsync(userId);
            if (verificadoPendiente) return NotFound("El verificado ya fue solicitado, estamos procesando tu solicitud.");

            var resultado = await _perfilRepository.SolicitarVerificado(userId);
            if (!resultado) return NotFound("Error al solicitar el verificado.");

            return Ok("Verificado solicitado.");
        }
    }
}
