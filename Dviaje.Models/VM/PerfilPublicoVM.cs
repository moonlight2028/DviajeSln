namespace Dviaje.Models.VM
{
    public class PerfilPublicoVM
    {
        // Datos Turista
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Avatar { get; set; }
        public int NumeroReservas { get; set; }
        public int NumeroResenas { get; set; }
        public string? Banner { get; set; }


        // Datos Aliado
        public bool EsAliado { get; set; } = false;
        public int NumeroPulicaciones { get; set; }
        public bool Verificado { get; set; } = false;
        public string? RazonSocial { get; set; }
        public string? SitioWeb { get; set; }
        public string? Direccion { get; set; }
        public AliadoEstado AliadoEstado { get; set; }
        public decimal Puntuacion { get; set; }
    }
}
