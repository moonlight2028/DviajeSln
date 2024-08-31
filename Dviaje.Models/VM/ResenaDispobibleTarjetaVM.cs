namespace Dviaje.Models.VM
{
    public class ResenaDisponibleTarjetaVM
    {
        //public int IdReserva { get; set; }
        public string TituloPublicacion { get; set; }
        //public string DescripcionPublicacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string ImagenUrl { get; set; }
        //public bool PuedeReseñar { get; set; }  // Indica si el usuario puede hacer una reseña
    }
}
