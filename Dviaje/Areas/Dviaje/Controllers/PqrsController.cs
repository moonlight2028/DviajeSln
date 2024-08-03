﻿using Dviaje.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class PqrsController : Controller
    {
        public IActionResult Pqrs()
        {

            return View();
        }




        [HttpPost]
        public IActionResult Pqrs(AtencionViajero atencionViajero)
        {
            if (!ModelState.IsValid)
            {
                return View(atencionViajero);

            }

            return View();
        }
    }
}
