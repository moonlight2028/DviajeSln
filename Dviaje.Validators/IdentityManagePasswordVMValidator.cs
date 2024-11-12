using Dviaje.Models.VM;
using FluentValidation;

namespace Dviaje.Validators
{
    public class IdentityManagePasswordVMValidator : AbstractValidator<IdentityManagePasswordVM>
    {
        public IdentityManagePasswordVMValidator()
        {
            RuleFor(x => x.OldPassword)
                .NotEmpty().WithMessage("La contraseña actual es obligatoria.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("La nueva contraseña es obligatoria.")
                .Length(6, 100).WithMessage("La nueva contraseña debe tener entre 6 y 100 caracteres.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.NewPassword).WithMessage("La nueva contraseña y la contraseña de confirmación no coinciden.");
        }
    }
}
