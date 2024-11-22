using Dviaje.Models.VM;
using FluentValidation;

namespace Dviaje.Validators
{
    public class PublicacionCrearVMValidator : AbstractValidator<PublicacionCrearVM>
    {
        public PublicacionCrearVMValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("El título es obligatorio.")
                .MaximumLength(50).WithMessage("El título no debe exceder los 50 caracteres.")
                .Must(titulo => !string.Equals(titulo, "titulo", StringComparison.OrdinalIgnoreCase))
                .WithMessage("El título no puede ser 'titulo'.");

            RuleFor(x => x.Direccion)
                .NotEmpty().WithMessage("La dirección es obligatoria.")
                .MaximumLength(100).WithMessage("La dirección no debe exceder los 100 caracteres.")
                .Must(direccion => !string.Equals(direccion, "direccion", StringComparison.OrdinalIgnoreCase))
                .WithMessage("La dirección no puede ser 'direccion'.");

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MaximumLength(500).WithMessage("La descripción no debe exceder los 500 caracteres.")
                .Must(descripcion => !string.Equals(descripcion, "descripcion", StringComparison.OrdinalIgnoreCase))
                .WithMessage("La descripción no puede ser 'descripcion'.");

            RuleFor(x => x.NumeroCamas)
                .GreaterThan(0).WithMessage("El número de camas debe ser mayor a 0.")
                .LessThanOrEqualTo(20).WithMessage("El número de camas no debe exceder las 20.");

            RuleFor(x => x.Precio)
                .GreaterThan(0).WithMessage("El precio debe ser mayor a 0.")
                .LessThanOrEqualTo(10000000).WithMessage("El precio no debe exceder los 10,000,000.");

            RuleFor(x => x.ServiciosHabitacionSeleccionados)
                .NotNull().WithMessage("Debe seleccionar al menos un servicio para la habitación.");

            RuleFor(x => x.ServiciosEstablecimientoSeleccionados)
                .NotNull().WithMessage("Debe seleccionar al menos un servicio para el establecimiento.");

            RuleFor(x => x.CategoriasSeleccionadas)
                .NotNull().WithMessage("Debe seleccionar al menos una categoría.");

            RuleForEach(x => x.FechasNoDisponibles)
                .ChildRules(fechas =>
                {
                    fechas.RuleFor(x => x.FechaInicial)
                        .GreaterThanOrEqualTo(DateTime.Today).WithMessage("La fecha inicial no puede ser anterior a hoy.");

                    fechas.RuleFor(x => x.FechaFinal)
                        .GreaterThanOrEqualTo(DateTime.Today).WithMessage("La fecha final no puede ser anterior a hoy.");

                    fechas.RuleFor(x => x.FechaInicial)
                        .LessThanOrEqualTo(x => x.FechaFinal).WithMessage("La fecha inicial debe ser anterior a la fecha final.");
                });
        }
    }
}
