﻿using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Resenas")]
    public class ResenaController : Controller
    {
        public IActionResult Reseñas()
        {
            return View();
        }
    }
}
