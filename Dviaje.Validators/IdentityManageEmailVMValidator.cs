using Dviaje.Models.VM;
using FluentValidation;

namespace Dviaje.Validators
{
    public class IdentityManageEmailVMValidator : AbstractValidator<IdentityManageEmailVM>
    {
        public IdentityManageEmailVMValidator()
        {
            RuleFor(x => x.NewEmail)
                .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                .EmailAddress().WithMessage("Debe ser un correo electrónico válido.")
                .MaximumLength(256).WithMessage("El correo electrónico no debe exceder los 256 caracteres.");
        }
    }
}
