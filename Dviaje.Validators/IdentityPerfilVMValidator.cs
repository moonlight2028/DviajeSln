using Dviaje.Models.VM;
using FluentValidation;

namespace Dviaje.Validators
{
    public class IdentityPerfilVMValidator : AbstractValidator<IdentityPerfilVM>
    {
        public IdentityPerfilVMValidator()
        {
            RuleFor(x => x.NombreUsuario)
                .NotEmpty().WithMessage("El nombre de usuario es obligatorio.")
                .MaximumLength(256).WithMessage("El nombre de usuario no debe exceder los 256 caracteres.")
                .Must((model, nombreUsuario) =>
                    model.NombreUsuarioOriginal == nombreUsuario || !EsCorreo(nombreUsuario))
                .WithMessage("El nombre de usuario no debe ser un correo electrónico si se modifica.");

            RuleFor(x => x.NumeroTelefono)
                .Matches(@"^\+?[0-9]{7,15}$")
                .When(x => !string.IsNullOrEmpty(x.NumeroTelefono))
                .WithMessage("El número de teléfono debe ser válido y contener entre 7 y 15 dígitos.");

            //RuleFor(x => x.InputBanner)
            //    .Must(ValidarInputImagenONull)
            //    .WithMessage("El banner debe ser una imagen en formato JPG, JPEG, WEBP o PNG.");

            //RuleFor(x => x.InputAvatar)
            //    .Must(ValidarInputImagenONull)
            //    .WithMessage("El avatar debe ser una imagen en formato JPG, JPEG, WEBP o PNG.");
        }


        private bool EsCorreo(string? valor)
        {
            if (string.IsNullOrEmpty(valor))
                return false;

            return System.Text.RegularExpressions.Regex.IsMatch(valor, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }


        //private bool ValidarInputImagenONull(string? ruta)
        //{
        //    if (string.IsNullOrEmpty(ruta))
        //        return true;

        //    var extenciones = new[] { ".jpg", ".jpeg", ".png", ".webp" };
        //    var fileExtension = System.IO.Path.GetExtension(ruta).ToLower();
        //    return extenciones.Contains(fileExtension);
        //}
    }
}
