namespace Dviaje.Models.VM
{
    public class MensajesPqrsPostVM
    {
        public DateTime? Fecha { get; set; }
        public string? Descripcion { get; set; }
        public string? IdUsuario { get; set; }
        public string? IdAtencionViajero { get; set; }
        List<Adjuntos>? Adjuntos { get; set; }
    }
}
