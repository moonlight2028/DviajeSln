using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dviaje.Models;
using FluentValidation;

namespace Dviaje.Validators
{
    public class ResenaValidator : AbstractValidator<Resena>
    {
        public ResenaValidator() 
        {

            RuleFor(r => r.Calificacion).NotEmpty().WithMessage("debe selecionar una calificacion");
            RuleFor(r => r.Opinion).NotEmpty().WithMessage("debe ingresar una reseña valida");

        }
    }
}
