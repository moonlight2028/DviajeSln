using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class PublicacionesController : Controller
    {

        public PublicacionesController()
        {
        }


        public async Task<IActionResult> Publicaciones(int? pagina, string? ordenar)
        {
            // Paginación.
            int numeroPublicaciones = 10;
            //int publicacionesTotales = await _unitOfWork.PublicacionRepository.GetTotalPublicacionesAsync();
            //int paginasTotales = Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(publicacionesTotales) / Convert.ToDecimal(numeroPublicaciones)));

            // Filtro ordenar
            ordenar = ordenar == null ? "" : ordenar.ToUpper();

            // Validaciones.
            if (pagina is null or <= 0) pagina = 1;
            //if (pagina > paginasTotales) pagina = 1;

            // Lista de publicaciones
            /*
            List<PublicacionTarjetaVM> listaPublicaciones = ordenar switch
            {
                "PRECIOMAYOR" => await _unitOfWork.PublicacionRepository.GetPublicacionesAsync((int)pagina, numeroPublicaciones, orderBy: p => -p.Precio),
                "PRECIOMENOR" => await _unitOfWork.PublicacionRepository.GetPublicacionesAsync((int)pagina, numeroPublicaciones, orderBy: p => p.Precio),
                _ => await _unitOfWork.PublicacionRepository.GetPublicacionesAsync((int)pagina, numeroPublicaciones),
            };
            */


            return View(
                /*
                new PublicacionesVM
            {
                PublicacionTarjetas = listaPublicaciones,
                Paginacion = new PaginacionVM { ResultadosMostrados = numeroPublicaciones, ResultadosTotales = publicacionesTotales, PaginasTotales = paginasTotales }
            }
                */
                );
        }

        public async Task<IActionResult> Publicacion(int? id)
        {
            // Validaciones.
            if (id is null or <= 0) return RedirectToAction(nameof(Publicaciones));

            // Publicacion
            //PublicacionVM? publicacionBuscada = await _unitOfWork.PublicacionRepository.GetPublicacionAsync((int)id);
            //if (publicacionBuscada == null) return RedirectToAction(nameof(Publicaciones));

            return View(/*publicacionBuscada*/);
        }
    }
}
