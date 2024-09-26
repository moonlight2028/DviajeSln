namespace Dviaje.Models.VM
{
    public class AtencionViajerosPqrsVM
    {
        public int IdAtencion { get; set; }
        public DateTime? FechaAtencion { get; set; }
        public AtencionesViajerosTipoPqrs TipoPqrs { get; set; }
        public AtencionesViajerosEstado Estado { get; set; }
        // Descripción del último mensaje enviado
        public string? DescripcionMensajes { get; set; }
    }
}
