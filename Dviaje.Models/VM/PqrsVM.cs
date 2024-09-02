namespace Dviaje.Models.VM
{
    public class PqrsVM
    {
        // Campos de la tabla AtencionViajeros
        public string? IdAtencionViajero { get; set; }
        public DateTime? FechaAtencion { get; set; }
        public AtencionesViajerosTipoPqrs AtencionesViajerosTipoPqrs { get; set; }
        public AtencionesViajerosEstado AtencionesViajerosEstado { get; set; }


        // Campos de la tabla Mensajes
        public string? IdMensaje { get; set; }
        public DateTime? FechaMensaje { get; set; }
        public string? Descripcion { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }


        // Archivos adjuntos
        public List<AdjuntosVM>? Adjuntos { get; set; }
    }
}
