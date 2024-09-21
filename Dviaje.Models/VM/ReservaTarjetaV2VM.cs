namespace Dviaje.Models.VM
{
    public class ReservaTarjetaV2VM
    {
        public int IdReserva { get; set; }
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public ReservaEstado ReservaEstado { get; set; }

        public int IdPublicacion { get; set; }
        public string? TituloPublicacion { get; set; }
        public decimal PuntuacionPublicacion { get; set; }
        public int NumeroResenasPublicacion { get; set; }
        public string? imagenPublicacion { get; set; }

        public string? IdAliado { get; set; }
        public string? NombreAliado { get; set; }
        public string? AvatarAliado { get; set; }
        public bool VerificadoAliado { get; set; }
        public int NumeroPublicacionesAliado { get; set; }
    }
}
