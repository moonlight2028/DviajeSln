﻿using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Dviaje.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Dviaje.Areas.Dviaje.Controllers
{
    [Area("Dviaje")]
    public class PqrsController : Controller
    {
        private IEnvioEmail _email;
        private IUnitOfWork _unitOfWork;


        // Inyección en el controlador.
        public PqrsController(IEnvioEmail email, IUnitOfWork unitOfWork)
        {
            _email = email;
            _unitOfWork = unitOfWork;
        }


        public async Task<IActionResult> Pqrs()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Pqrs(PqrsRegistrarVM pqrsRegistrarVM)
        {
            return View();
        }

    }
}
