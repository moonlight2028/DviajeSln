using Dviaje.Models.VM;
using FluentValidation;

namespace Dviaje.Validators
{
    public class PublicacionCrearVMValidator : AbstractValidator<PublicacionCrearFrontVM>
    {
        public PublicacionCrearVMValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("El título es obligatorio.")
                .MinimumLength(5).WithMessage("El título debe contener minimo 5 caracteres.")
                .MaximumLength(50).WithMessage("El título no debe exceder los 50 caracteres.");

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MinimumLength(10).WithMessage("La descripción debe contener minimo 10 caracteres.")
                .MaximumLength(500).WithMessage("La descripción no debe exceder los 500 caracteres.");

            RuleFor(x => x.Direccion)
                .NotEmpty().WithMessage("La dirección es obligatoria.")
                .MinimumLength(5).WithMessage("La dirección debe contener minimo 5 caracteres.")
                .MaximumLength(300).WithMessage("La dirección no debe exceder los 300 caracteres.");

            RuleFor(x => x.CategoriaSeleccionada)
                .GreaterThan(0).WithMessage("Debe seleccionar una categoría válida.");

            RuleFor(x => x.PropiedadSeleccionada)
                .GreaterThan(0).WithMessage("Debe seleccionar una propiedad válida.");

            RuleFor(x => x.ServiciosSeleccionados)
                .NotNull().WithMessage("Debe seleccionar al menos un servicio.")
                .Must(x => x != null && x.All(s => s > 0)).WithMessage("Cada servicio seleccionado debe tener un ID válido.");

            RuleFor(x => x.Huespedes)
                .GreaterThan(0).WithMessage("El número de huéspedes debe ser mayor a 0.")
                .LessThanOrEqualTo(50).WithMessage("El número de huéspedes no debe exceder los 50.");

            RuleFor(x => x.Recamaras)
                .Must(x => x == null || (x >= 0 && x <= 50))
                .WithMessage("El número de recámaras debe ser 0 o un valor entre 0 y 50.");

            RuleFor(x => x.NumeroCamas)
                .Must(x => x == null || (x >= 0 && x <= 50))
                .WithMessage("El número de camas debe ser 0 o un valor entre 0 y 50.");

            RuleFor(x => x.Banios)
                .Must(x => x == null || (x >= 0 && x <= 50))
                .WithMessage("El número de baños debe ser 0 o un valor entre 0 y 50.");

            RuleFor(x => x.PrecioNoche)
                .GreaterThan(0).WithMessage("El precio por noche debe ser mayor a 0.")
                .LessThanOrEqualTo(1000000000).WithMessage("El precio por noche no debe exceder 1,000,000,000");

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
