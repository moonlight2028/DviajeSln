namespace Dviaje.Models.VM
{
    public class UsuarioVM
    {
        public string IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string PhoneNumber { get; set; }
        public string Roles { get; set; } // roles actuales
    }
}
