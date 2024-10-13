using Dviaje.Models.VM;
using FluentValidation;

namespace Dviaje.Validators
{
    public class PqrsCrearAutenticadoVMValidator : AbstractValidator<PqrsCrearVM>
    {
        public PqrsCrearAutenticadoVMValidator()
        {
            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La Descripción es obligatoria.")
                .Length(10, 500).WithMessage("La descripción debe tener entre 10 y 500 caracteres.");
        }
    }
}
