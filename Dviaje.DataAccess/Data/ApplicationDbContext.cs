using Dviaje.Models;
using Microsoft.EntityFrameworkCore;

namespace Dviaje.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Restriccion> Restriccions { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ServicioAdicional> serviciosAdicionales { get; set; }
        public DbSet<AtencionViajero> AtencionViajeros { get; set; }
        public DbSet<Adjunto> Adjuntos { get; set; }
        public DbSet<Aliado> Aliados { get; set; }
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

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            //Desabilitando la eliminacion en cascada

            modelBuilder.Entity<Favorito>()
                .HasOne(f => f.Usuario)
                .WithMany()
                .HasForeignKey(f => f.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Favorito>()
                .HasOne(f => f.Publicacion)
                .WithMany()
                .HasForeignKey(f => f.IdPublicacion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne(f => f.Usuario)
                .WithMany()
                .HasForeignKey(f => f.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne(f => f.Publicacion)
                .WithMany()
                .HasForeignKey(f => f.IdPublicacion)
                .OnDelete(DeleteBehavior.Restrict);


        }

    }
}
