﻿namespace Dviaje.Models.VM
{
    public class PublicacionResenasVM
    {
        public int IdPublicacion { get; set; }
        public string? TituloPublicacion { get; set; }
        public decimal PuntuacionPublicacion { get; set; }
        public string? DescripcionPublicacion { get; set; }
        public string? DireccionPublicacion { get; set; }
        public string? ImagenPublicacion { get; set; }
    }
}