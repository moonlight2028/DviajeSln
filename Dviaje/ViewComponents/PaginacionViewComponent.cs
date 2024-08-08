using Dviaje.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.ViewComponents
{
    public class PaginacionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(PaginacionVM paginacionVM)
        {
            //PaginacionVM paginacion = paginacionVM;

            return View(paginacionVM);
        }
    }
}
