using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dviaje.Models;
using FluentValidation;

namespace Dviaje.Validators
{
    public class ReservaValidator : AbstractValidator<Reserva>
    {
        public ReservaValidator()
        {
            RuleFor(r => r.NumeroPersonas)
                 .NotEmpty().WithMessage("Error, ingresa un número válido de personas.")
                 .GreaterThanOrEqualTo(1).WithMessage("El número de personas debe ser mayor o igual a 1.")
                  .WithMessage("El número de personas debe contener solo dígitos.");

            RuleFor(r => r.FechaInicial).NotEmpty().WithMessage("Ingresa una fecha inicial válida.");
            RuleFor(r => r.FechaFinal).NotEmpty().WithMessage("Ingresa una fecha final válida.");

            // Nueva regla para validar fechas
            RuleFor(r => r)
              .Custom((reserva, context) =>
              {
                  if (reserva.FechaInicial >= reserva.FechaFinal)
                  {
                      context.AddFailure("FechaFinal", "La fecha final debe ser posterior a la fecha inicial.");
                  }
              });
        }
    }
}
