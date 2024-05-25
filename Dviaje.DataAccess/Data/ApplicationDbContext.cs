using Dviaje.Models;
using Microsoft.EntityFrameworkCore;

namespace Dviaje.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Restriccion> Restricciones { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
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
        public DbSet<ServicioAdicional> ServiciosAdicionales { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

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


            // Datos Agregados


            // Usuarios


            // Servicios
            modelBuilder.Entity<Servicio>().HasData(
                new Servicio
                {
                    IdServicio = 1,
                    NombreServicio = "Cama",
                    ServicioTipo = ServicioTipo.Habitacion,
                    RutaIcono = ""
                },
                new Servicio
                {
                    IdServicio = 2,
                    NombreServicio = "Gimnasio",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "random"
                },
                new Servicio
                {
                    IdServicio = 3,
                    NombreServicio = "Spa",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "random"
                },
                new Servicio
                {
                    IdServicio = 4,
                    NombreServicio = "Restaurante",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "random"
                },
                new Servicio
                {
                    IdServicio = 5,
                    NombreServicio = "Sala de juegos",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "random"
                },
                new Servicio
                {
                    IdServicio = 6,
                    NombreServicio = "Cine",
                    ServicioTipo = ServicioTipo.Habitacion,
                    RutaIcono = "random"
                },
                new Servicio
                {
                    IdServicio = 7,
                    NombreServicio = "Cancha de tenis",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "random"
                },
                new Servicio
                {
                    IdServicio = 8,
                    NombreServicio = "Cancha de baloncesto",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "random"
                },
                new Servicio
                {
                    IdServicio = 9,
                    NombreServicio = "Sauna",
                    ServicioTipo = ServicioTipo.Habitacion,
                    RutaIcono = "random"
                },
                new Servicio
                {
                    IdServicio = 10,
                    NombreServicio = "Bar",
                    ServicioTipo = ServicioTipo.Habitacion,
                    RutaIcono = "random"
                }
            );

            // Restricciones
            modelBuilder.Entity<Restriccion>().HasData(
                new Restriccion
                {
                    IdRestriccion = 1,
                    NombreRestriccion = "Prohibido mascotas",
                    RutaIcono = "random"
                },
                new Restriccion
                {
                    IdRestriccion = 2,
                    NombreRestriccion = "Prohibido mascotas",
                    RutaIcono = "random"
                },
                new Restriccion
                {
                    IdRestriccion = 3,
                    NombreRestriccion = "No fumar",
                    RutaIcono = "random"
                },
                new Restriccion
                {
                    IdRestriccion = 4,
                    NombreRestriccion = "No se permiten fiestas o eventos",
                    RutaIcono = "random"
                },
                new Restriccion
                {
                    IdRestriccion = 5,
                    NombreRestriccion = "Hora de silencio después de las 10 PM",
                    RutaIcono = "random"
                },
                new Restriccion
                {
                    IdRestriccion = 6,
                    NombreRestriccion = "No se permite el acceso a personas no registradas",
                    RutaIcono = "random"
                },
                new Restriccion
                {
                    IdRestriccion = 7,
                    NombreRestriccion = "Máximo 2 personas por habitación",
                    RutaIcono = "random"
                },
                new Restriccion
                {
                    IdRestriccion = 8,
                    NombreRestriccion = "Uso obligatorio de mascarilla en áreas comunes",
                    RutaIcono = "random"
                },
                new Restriccion
                {
                    IdRestriccion = 9,
                    NombreRestriccion = "No se permiten visitantes después de las 8 PM",
                    RutaIcono = "random"
                },
                new Restriccion
                {
                    IdRestriccion = 10,
                    NombreRestriccion = "Lavarse las manos antes de entrar a la piscina",
                    RutaIcono = "random"
                }
            );

            // Categorias
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria
                {
                    IdCategoria = 1,
                    NombreCategoria = "Finca",
                    RutaIcono = "Ruta"
                },
                new Categoria
                {
                    IdCategoria = 2,
                    NombreCategoria = "Apartamento",
                    RutaIcono = "Ruta"
                },
                new Categoria
                {
                    IdCategoria = 3,
                    NombreCategoria = "Casa",
                    RutaIcono = "Ruta"
                },
                new Categoria
                {
                    IdCategoria = 4,
                    NombreCategoria = "Hotel",
                    RutaIcono = "Ruta"
                },
                new Categoria
                {
                    IdCategoria = 5,
                    NombreCategoria = "Hostal",
                    RutaIcono = "Ruta"
                },
                new Categoria
                {
                    IdCategoria = 6,
                    NombreCategoria = "Cabaña",
                    RutaIcono = "Ruta"
                },
                new Categoria
                {
                    IdCategoria = 7,
                    NombreCategoria = "Villa",
                    RutaIcono = "Ruta"
                },
                new Categoria
                {
                    IdCategoria = 8,
                    NombreCategoria = "Resort",
                    RutaIcono = "Ruta"
                },
                new Categoria
                {
                    IdCategoria = 9,
                    NombreCategoria = "Piso compartido",
                    RutaIcono = "Ruta"
                },
                new Categoria
                {
                    IdCategoria = 10,
                    NombreCategoria = "Finca",
                    RutaIcono = "Ruta"
                }
            );


            // AtencionViajeros


            // Adjuntos


            // Aliados


            // Verificados


            // Publicaciones


            // Favoritos


            // Reservas


            // Resenas


            // PublicacionesFavoritas


            // PublicacionesImagenes


            // PublicacionesServicios


            // PublicacionesRestricciones


            // PublicacionesCategorias
            modelBuilder.Entity<PublicacionCategoria>().HasData(
                new PublicacionCategoria
                {
                    IdPublicacionCategoria = 1,
                    IdPublicacion = 1,
                    IdCategoria = 1
                },
                new PublicacionCategoria
                {
                    IdPublicacionCategoria = 2,
                    IdPublicacion = 2,
                    IdCategoria = 2
                },
                new PublicacionCategoria
                {
                    IdPublicacionCategoria = 3,
                    IdPublicacion = 3,
                    IdCategoria = 3
                },
                new PublicacionCategoria
                {
                    IdPublicacionCategoria = 4,
                    IdPublicacion = 4,
                    IdCategoria = 4
                },
                new PublicacionCategoria
                {
                    IdPublicacionCategoria = 5,
                    IdPublicacion = 5,
                    IdCategoria = 5
                },
                new PublicacionCategoria
                {
                    IdPublicacionCategoria = 6,
                    IdPublicacion = 6,
                    IdCategoria = 6
                },
                new PublicacionCategoria
                {
                    IdPublicacionCategoria = 7,
                    IdPublicacion = 7,
                    IdCategoria = 7
                },
                new PublicacionCategoria
                {
                    IdPublicacionCategoria = 8,
                    IdPublicacion = 8,
                    IdCategoria = 8
                },
                new PublicacionCategoria
                {
                    IdPublicacionCategoria = 9,
                    IdPublicacion = 9,
                    IdCategoria = 9
                },
                new PublicacionCategoria
                {
                    IdPublicacionCategoria = 10,
                    IdPublicacion = 1,
                    IdCategoria = 1,
                }
            );

            // FechasNoDisponibles
            modelBuilder.Entity<FechaNoDisponible>().HasData(
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 1,
                    FechaSinDisponible = DateTime.Now,
                    IdPublicacion = 1
                },
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 2,
                    FechaSinDisponible = DateTime.Now.AddDays(1),
                    IdPublicacion = 2
                },
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 3,
                    FechaSinDisponible = DateTime.Now.AddDays(2),
                    IdPublicacion = 3
                },
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 4,
                    FechaSinDisponible = DateTime.Now.AddDays(3),
                    IdPublicacion = 4
                },
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 5,
                    FechaSinDisponible = DateTime.Now.AddDays(4),
                    IdPublicacion = 5
                },
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 6,
                    FechaSinDisponible = DateTime.Now.AddDays(5),
                    IdPublicacion = 6
                },
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 7,
                    FechaSinDisponible = DateTime.Now.AddDays(6),
                    IdPublicacion = 7
                },
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 8,
                    FechaSinDisponible = DateTime.Now.AddDays(7),
                    IdPublicacion = 8
                },
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 9,
                    FechaSinDisponible = DateTime.Now.AddDays(8),
                    IdPublicacion = 9
                },
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 10,
                    FechaSinDisponible = DateTime.Now,
                    IdPublicacion = 1
                }
            );

            // ServiciosAdicionales
            modelBuilder.Entity<ServicioAdicional>().HasData(
                new ServicioAdicional
                {
                    IdServicioAdicional = 1,
                    PrecioServicioAdicional = 50000,
                    IdServicio = 1,
                    IdPublicacion = 1,
                },
                new ServicioAdicional
                {
                    IdServicioAdicional = 2,
                    PrecioServicioAdicional = 50000,
                    IdServicio = 1,
                    IdPublicacion = 1
                },
                new ServicioAdicional
                {
                    IdServicioAdicional = 3,
                    PrecioServicioAdicional = 60000,
                    IdServicio = 2,
                    IdPublicacion = 2
                },
                new ServicioAdicional
                {
                    IdServicioAdicional = 4,
                    PrecioServicioAdicional = 70000,
                    IdServicio = 3,
                    IdPublicacion = 3
                },
                new ServicioAdicional
                {
                    IdServicioAdicional = 5,
                    PrecioServicioAdicional = 80000,
                    IdServicio = 4,
                    IdPublicacion = 4
                },
                new ServicioAdicional
                {
                    IdServicioAdicional = 6,
                    PrecioServicioAdicional = 90000,
                    IdServicio = 5,
                    IdPublicacion = 5
                },
                new ServicioAdicional
                {
                    IdServicioAdicional = 7,
                    PrecioServicioAdicional = 100000,
                    IdServicio = 6,
                    IdPublicacion = 6
                },
                new ServicioAdicional
                {
                    IdServicioAdicional = 8,
                    PrecioServicioAdicional = 110000,
                    IdServicio = 7,
                    IdPublicacion = 7
                },
                new ServicioAdicional
                {
                    IdServicioAdicional = 9,
                    PrecioServicioAdicional = 120000,
                    IdServicio = 8,
                    IdPublicacion = 8
                },
                new ServicioAdicional
                {
                    IdServicioAdicional = 10,
                    PrecioServicioAdicional = 130000,
                    IdServicio = 9,
                    IdPublicacion = 9
                }
            );


        }

    }
}
