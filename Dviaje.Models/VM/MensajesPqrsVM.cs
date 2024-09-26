namespace Dviaje.Models.VM
{
    public class MensajesPqrsVM
    {
        public DateTime? Fecha { get; set; }
        public string? Descripcion { get; set; }
        public string? IdUsuario { get; set; }
        public string? AvatarUsuario { get; set; }
        List<Adjuntos>? Adjuntos { get; set; }
    }
}
