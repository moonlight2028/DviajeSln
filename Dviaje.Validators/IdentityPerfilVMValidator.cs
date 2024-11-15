using Dviaje.Models.VM;
using FluentValidation;

namespace Dviaje.Validators
{
    /// <summary>
    /// Validador personalizado para el modelo <see cref="IdentityPerfilVM"/> utilizando la librería FluentValidation.
    /// Realiza validaciones de los campos del modelo, como el nombre de usuario y el número de teléfono.
    /// </summary>
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
        }


        /// <summary>
        /// Método auxiliar para validar si un valor es una dirección de correo electrónico válida.
        /// </summary>
        /// <param name="valor">El valor a verificar como dirección de correo electrónico.</param>
        /// <returns>Devuelve <c>true</c> si el valor es un correo electrónico válido, <c>false</c> en caso contrario.</returns>
        private bool EsCorreo(string? valor)
        {
            if (string.IsNullOrEmpty(valor))
                return false;

            return System.Text.RegularExpressions.Regex.IsMatch(valor, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
