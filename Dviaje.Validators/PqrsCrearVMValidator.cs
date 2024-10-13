using Dviaje.Models.VM;
using FluentValidation;

namespace Dviaje.Validators
{
    public class PqrsCrearVMValidator : AbstractValidator<PqrsCrearVM>
    {
        public PqrsCrearVMValidator()
        {
            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La Descripción es obligatoria.")
                .Length(10, 500).WithMessage("La descripción debe tener entre 10 y 500 caracteres.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El Nombre es obligatorio.")
                .Length(2, 50).WithMessage("El nombre debe tener entre 2 y 50 caracteres.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("El nombre solo puede contener letras.");

            RuleFor(x => x.Apellidos)
                .NotEmpty().WithMessage("Los Apellidos son obligatorios.")
                .Length(2, 50).WithMessage("Los apellidos deben tener entre 2 y 50 caracteres.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Los apellidos solo pueden contener letras.");

            RuleFor(x => x.Correo)
                .NotEmpty().WithMessage("El Correo es obligatorio.")
                .EmailAddress().WithMessage("El correo no es válido.")
                .Length(5, 100).WithMessage("El correo debe tener entre 5 y 100 caracteres.");

            RuleFor(x => x.Telefono)
                .NotEmpty().WithMessage("El Teléfono es obligatorio.")
                .Matches(@"^\+?[0-9\s]+$").WithMessage("El teléfono no es válido.")
                .Length(7, 15).WithMessage("El teléfono debe tener entre 7 y 15 dígitos.");
        }
    }
}
