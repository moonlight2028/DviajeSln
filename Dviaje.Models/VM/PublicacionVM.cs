﻿namespace Dviaje.Models.VM
{
    public class PublicacionVM
    {
        public int IdPublicacion { get; set; }
        public decimal Puntuacion { get; set; }
        public int NumeroResenas { get; set; }
        public string? Descripcion { get; set; }
        public string? IdAliado { get; set; }
        public string? AvatarAliado { get; set; }
        public string? NombreAliado { get; set; }
        public int PublicacionesAliado { get; set; }
        public List<PublicacionImagenVM>? Imagenes { get; set; }
        public List<CategoriaVM>? Categorias { get; set; }
        public List<ServicioVM>? Servicios { get; set; }
        public List<ServicioAdicionalVM>? ServiciosAdicionales { get; set; }
        public List<RestriccionVM>? Restricciones { get; set; }
    }
}
