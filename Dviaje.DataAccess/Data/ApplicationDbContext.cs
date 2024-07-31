using Dviaje.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dviaje.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aliado> Aliados { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Restriccion> Restricciones { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<AtencionViajero> AtencionViajeros { get; set; }
        public DbSet<Adjunto> Adjuntos { get; set; }
        public DbSet<Verificado> Verificados { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Resena> Resenas { get; set; }
        public DbSet<PublicacionFavorita> PublicacionesFavoritas { get; set; }
        public DbSet<PublicacionImagen> PublicacionesImagenes { get; set; }
        public DbSet<PublicacionServicio> PublicacionesServicios { get; set; }
        public DbSet<PublicacionRestriccion> PublicacionesRestricciones { get; set; }
        public DbSet<PublicacionCategoria> PublicacionesCategorias { get; set; }
        public DbSet<FechaNoDisponible> FechasNoDisponibles { get; set; }
        public DbSet<ServicioAdicional> ServiciosAdicionales { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Restricción para campos únicos
            modelBuilder.Entity<Usuario>().HasIndex(u => u.Avatar).IsUnique();
            modelBuilder.Entity<Aliado>().HasIndex(a => a.RazonSocial).IsUnique();
            modelBuilder.Entity<Aliado>().HasIndex(a => a.Direccion).IsUnique();
            modelBuilder.Entity<Adjunto>().HasIndex(a => a.RutaAdjunto).IsUnique();
            modelBuilder.Entity<PublicacionImagen>().HasIndex(p => p.Ruta).IsUnique();
            modelBuilder.Entity<Servicio>().HasIndex(s => s.NombreServicio).IsUnique();
            modelBuilder.Entity<Restriccion>().HasIndex(r => r.NombreRestriccion).IsUnique();
            modelBuilder.Entity<Categoria>().HasIndex(c => c.NombreCategoria).IsUnique();




        }

    }
}
