using Dviaje.Models.VM;
using FluentValidation;

namespace Dviaje.Validators
{
    public class ReservaCrearVMValidator : AbstractValidator<ReservaCrearVM>
    {
        public ReservaCrearVMValidator()
        {
            RuleFor(x => x.FechaInicial)
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("La fecha inicial debe ser hoy o posterior.")
                .LessThan(x => x.FechaFinal).WithMessage("La fecha inicial debe ser menor que la fecha final.")
                .Must(fecha => fecha <= DateTime.Today.AddYears(1)).WithMessage("La fecha inicial no debe ser más de un año a partir de hoy.");

            RuleFor(x => x.FechaFinal)
                .GreaterThan(x => x.FechaInicial).WithMessage("La fecha final debe ser posterior a la fecha inicial.")
                .Must(fecha => fecha <= DateTime.Today.AddYears(1)).WithMessage("La fecha final no debe ser más de un año a partir de hoy.");
        }
    }
}
