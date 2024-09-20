using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class PerfilController : Controller
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilController(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }


        [Route("Perfil/{id?}")]
        public IActionResult Index(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Inicio");
            }

            // Corregir consulta
            //PerfilPublicoVM? perfilPublico = await _perfilRepository.ObtenerPerfilPublicoAsync(id);

            // Si no se encuentra el perfil, redirige a la página de inicio
            //if (perfilPublico == null)
            //{
            //    return RedirectToAction("Index", "Inicio");
            //}




            // Datos de test borrar cuando esté la consulta
            PerfilPublicoVM datosTest = new PerfilPublicoVM
            {
                Nombre = "Juan Pérez",
                Avatar = "https://plus.unsplash.com/premium_photo-1658527049634-15142565537a?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8YXZhdGFyfGVufDB8fDB8fHww",
                NumeroReservas = 115,
                NumeroResenas = 468,
                Banner = "https://images.unsplash.com/photo-1504221507732-5246c045949b?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                EsAliado = true,
                NumeroPulicaciones = 1515,
                Verificado = true,
                RazonSocial = "Juan Pérez S.A.S.",
                SitioWeb = "https://www.youtube.com/",
                Direccion = "Calle Falsa 123, Ciudad, País",
                AliadoEstado = AliadoEstado.Disponible,
                Puntuacion = 4.3m
            };
            return View(datosTest);
        }
    }
}
