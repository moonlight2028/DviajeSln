namespace Dviaje.Models.VM
{
    public class ReservaMiReservaVM
    {
        public string? TituloPublicacion { get; set; }
        public string? Direccion { get; set; }
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int NumeroCamas { get; set; }
        public int Huespedes { get; set; }
        public int Racamaras { get; set; }
        public int Banios { get; set; }
        public ReservaEstado ReservaEstado { get; set; }
        public decimal Precio { get; set; }
        public string? DescripcionPublicacion { get; set; }
        public int IdPublicacion { get; set; }




        public decimal PuntuacionPublicacion { get; set; }
        public int NumeroResenasPublicacion { get; set; }
        public List<ServicioVM>? ServiciosPublicacion { get; set; }
        public List<PublicacionImagenVM>? ImagenesPublicacion { get; set; }
        public string? IdAliado { get; set; }
        public string? NombreAliado { get; set; }
        public string? AvatarAliado { get; set; }
        public int NumeroPublicacionesAliado { get; set; }
        public bool VerificadoAliado { get; set; }
    }
}
