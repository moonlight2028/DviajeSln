using Dviaje.Models.VM;
using FluentValidation;

namespace Dviaje.Validators
{
    public class IdentityManageAliadoVMValidator : AbstractValidator<IdentityManageAliadoVM>
    {
        public IdentityManageAliadoVMValidator()
        {
            RuleFor(x => x.RazonSocial)
           .NotEmpty().WithMessage("La razón social es obligatoria.")
           .MaximumLength(40).WithMessage("La razón social no debe exceder los 40 caracteres.");

            RuleFor(x => x.SitioWeb)
                .MaximumLength(255).WithMessage("El sitio web no debe exceder los 255 caracteres.")
                .Matches(@"^(https?:\/\/)?([\w\-])+\.{1}([a-zA-Z]{2,63})([\/\w\.\-]*)*\/?$")
                .When(x => !string.IsNullOrEmpty(x.SitioWeb))
                .WithMessage("El sitio web no es válido.");

            RuleFor(x => x.Direccion)
                .NotEmpty().WithMessage("La dirección es obligatoria.")
                .MaximumLength(50).WithMessage("La dirección no debe exceder los 50 caracteres.");
        }
    }
}
