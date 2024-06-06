using Microsoft.AspNetCore.Identity;

namespace Dviaje.Models
{
    public class Usuario : IdentityUser
    {
        public AliadoEstado AliadoEstado { get; set; }
    }
}
