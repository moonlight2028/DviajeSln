namespace Dviaje.Models.VM
{
    public class UsuarioPerfilPublicoVM
    {
        public string? Nombre { get; set; }
        public string? Avatar { get; set; }
        public bool Aliado { get; set; } = false;
        public int NumeroReservas { get; set; }

        // En esta consulta no es necesario cargar el AvatarTurista
        public List<ResenasTarjetaVM>? ResenasTarjetas { get; set; }

        // Datos si es aliado
        public int NumeroPulicaciones { get; set; }
        public bool Verificado { get; set; } = false;
        public string? RazonSocial { get; set; }
        public string? SitioWeb { get; set; }
        public string? Direccion { get; set; }
        public AliadoEstado AliadoEstado { get; set; }
        public decimal Puntuacion { get; set; } // Este campo no está en la DB falta agregarlo

    }
}
