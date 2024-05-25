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
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    IdUsuario = 1,
                },
                new Usuario
                {
                    IdUsuario = 2,
                },
                new Usuario
                {
                    IdUsuario = 3,
                },
                new Usuario
                {
                    IdUsuario = 4,
                },
                new Usuario
                {
                    IdUsuario = 5,
                },
                new Usuario
                {
                    IdUsuario = 6,
                },
                new Usuario
                {
                    IdUsuario = 7,
                },
                new Usuario
                {
                    IdUsuario = 8,
                },
                new Usuario
                {
                    IdUsuario = 9,
                },
                new Usuario
                {
                    IdUsuario = 10,
                }
                );

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
            modelBuilder.Entity<AtencionViajero>().HasData(
                new AtencionViajero
                {
                    IdAtencion = 1,
                    FechaAtencion = DateTime.Today,
                    Descripcion = "No sivre",
                    Respuesta = "A bueno",
                    Asunto = "No funciona la pagina",
                    FechaRespuesta = DateTime.Today,
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Pregunta,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Completado,
                    IdUsuario = 1
                },
                new AtencionViajero
                {
                    IdAtencion = 2,
                    FechaAtencion = DateTime.Today,
                    Descripcion = "Problema con la reserva",
                    Respuesta = "Resuelto",
                    Asunto = "No puedo hacer una reserva",
                    FechaRespuesta = DateTime.Today,
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Queja,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Pendiente,
                    IdUsuario = 2
                },
                new AtencionViajero
                {
                    IdAtencion = 3,
                    FechaAtencion = DateTime.Today,
                    Descripcion = "Consulta sobre el itinerario",
                    Respuesta = "Información enviada",
                    Asunto = "¿Cuál es mi itinerario?",
                    FechaRespuesta = DateTime.Today,
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Pregunta,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Proceso,
                    IdUsuario = 3
                },
                new AtencionViajero
                {
                    IdAtencion = 4,
                    FechaAtencion = DateTime.Today,
                    Descripcion = "Sugerencia para mejorar",
                    Respuesta = "Gracias por la sugerencia",
                    Asunto = "Podrían mejorar el servicio",
                    FechaRespuesta = DateTime.Today,
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Sugerencia,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Proceso,
                    IdUsuario = 4
                },
                new AtencionViajero
                {
                    IdAtencion = 5,
                    FechaAtencion = DateTime.Today,
                    Descripcion = "Incidente con el equipaje",
                    Respuesta = "Lo sentimos mucho",
                    Asunto = "Perdí mi equipaje",
                    FechaRespuesta = DateTime.Today,
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Reclamo,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Completado,
                    IdUsuario = 5
                },
                new AtencionViajero
                {
                    IdAtencion = 6,
                    FechaAtencion = DateTime.Today,
                    Descripcion = "Consulta sobre el servicio de comida",
                    Respuesta = "Información proporcionada",
                    Asunto = "¿Qué comida se ofrece a bordo?",
                    FechaRespuesta = DateTime.Today,
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Pregunta,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Proceso,
                    IdUsuario = 6
                },
                new AtencionViajero
                {
                    IdAtencion = 7,
                    FechaAtencion = DateTime.Today,
                    Descripcion = "Problema con el check-in",
                    Respuesta = "Solucionado",
                    Asunto = "No puedo hacer el check-in online",
                    FechaRespuesta = DateTime.Today,
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Queja,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Completado,
                    IdUsuario = 7
                },
                new AtencionViajero
                {
                    IdAtencion = 8,
                    FechaAtencion = DateTime.Today,
                    Descripcion = "Sugerencia sobre el entretenimiento",
                    Respuesta = "Apreciamos su feedback",
                    Asunto = "Más opciones de entretenimiento a bordo",
                    FechaRespuesta = DateTime.Today,
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Sugerencia,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Completado,
                    IdUsuario = 8
                },
                new AtencionViajero
                {
                    IdAtencion = 9,
                    FechaAtencion = DateTime.Today,
                    Descripcion = "Consulta sobre tarifas",
                    Respuesta = "Información enviada",
                    Asunto = "¿Cuáles son las tarifas para el próximo mes?",
                    FechaRespuesta = DateTime.Today,
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Pregunta,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Pendiente,
                    IdUsuario = 9
                },
                new AtencionViajero
                {
                    IdAtencion = 10,
                    FechaAtencion = DateTime.Today,
                    Descripcion = "Reclamo por vuelo cancelado",
                    Respuesta = "Estamos investigando",
                    Asunto = "Mi vuelo fue cancelado sin previo aviso",
                    FechaRespuesta = DateTime.Today,
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Reclamo,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Pendiente,
                    IdUsuario = 10
                }

                );

            // Adjuntos 
            modelBuilder.Entity<Adjunto>().HasData(
                new Adjunto
                {
                    IdAdjunto = 1,
                    RutaAdjunto = "PDF",
                    IdAtencion = 1
                },
                new Adjunto
                {
                    IdAdjunto = 2,
                    RutaAdjunto = "Image",
                    IdAtencion = 2
                },
                new Adjunto
                {
                    IdAdjunto = 3,
                    RutaAdjunto = "Document",
                    IdAtencion = 3
                },
                new Adjunto
                {
                    IdAdjunto = 4,
                    RutaAdjunto = "Spreadsheet",
                    IdAtencion = 4
                },
                new Adjunto
                {
                    IdAdjunto = 5,
                    RutaAdjunto = "Presentation",
                    IdAtencion = 5
                },
                new Adjunto
                {
                    IdAdjunto = 6,
                    RutaAdjunto = "PDF",
                    IdAtencion = 6
                },
                new Adjunto
                {
                    IdAdjunto = 7,
                    RutaAdjunto = "Image",
                    IdAtencion = 7
                },
                new Adjunto
                {
                    IdAdjunto = 8,
                    RutaAdjunto = "Document",
                    IdAtencion = 8
                },
                new Adjunto
                {
                    IdAdjunto = 9,
                    RutaAdjunto = "Spreadsheet",
                    IdAtencion = 9
                },
                new Adjunto
                {
                    IdAdjunto = 10,
                    RutaAdjunto = "Presentation",
                    IdAtencion = 10
                }

                );

            // Aliados


            // Verificados


            // Publicaciones


            // Favoritos
            modelBuilder.Entity<Favorito>().HasData(
                new Favorito
                {
                    IdFavorito = 1,
                    IdUsuario = 1,
                    IdPublicacion = 1,
                },
                new Favorito
                {
                    IdFavorito = 2,
                    IdUsuario = 2,
                    IdPublicacion = 2
                },
                new Favorito
                {
                    IdFavorito = 3,
                    IdUsuario = 3,
                    IdPublicacion = 3
                },
                new Favorito
                {
                    IdFavorito = 4,
                    IdUsuario = 4,
                    IdPublicacion = 4
                },
                new Favorito
                {
                    IdFavorito = 5,
                    IdUsuario = 5,
                    IdPublicacion = 5
                },
                new Favorito
                {
                    IdFavorito = 6,
                    IdUsuario = 6,
                    IdPublicacion = 6
                },
                new Favorito
                {
                    IdFavorito = 7,
                    IdUsuario = 7,
                    IdPublicacion = 7
                },
                new Favorito
                {
                    IdFavorito = 8,
                    IdUsuario = 8,
                    IdPublicacion = 8
                },
                new Favorito
                {
                    IdFavorito = 9,
                    IdUsuario = 9,
                    IdPublicacion = 9
                },
                new Favorito
                {
                    IdFavorito = 10,
                    IdUsuario = 10,
                    IdPublicacion = 10
                }
            );

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
