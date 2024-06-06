using Dviaje.Models;
using Dviaje.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dviaje.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Usuario> Usuarios { get; set; }
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


            // Registro de roles en la Db
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "c7c1674b-f34c-4229-9dff-649b5ce707c7",
                    Name = RolesUtility.RoleTurista,
                    NormalizedName = RolesUtility.RoleTurista.ToUpper()
                },
                new IdentityRole
                {
                    Id = "31b53ef9-fc25-4db7-82ca-500f69d60bab",
                    Name = RolesUtility.RoleAliado,
                    NormalizedName = RolesUtility.RoleAliado.ToUpper()
                },
                new IdentityRole
                {
                    Id = "6f2a20cf-8d09-4e1b-8ed5-603330f1a4a6",
                    Name = RolesUtility.RoleModerador,
                    NormalizedName = RolesUtility.RoleModerador.ToUpper()
                },
                new IdentityRole
                {
                    Id = "66a316e1-a6a0-47a2-93f9-57a151fdb6a7",
                    Name = RolesUtility.RoleAdministrador,
                    NormalizedName = RolesUtility.RoleAdministrador.ToUpper()
                }
            );



            /*
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
            modelBuilder.Entity<Aliado>().HasData(
                new Aliado
                {
                    IdAliado = 1,
                    RazonSocial = "quiero plata",
                    SitioWeb = "www.abueno.com",
                    Telefono = "3333332222",
                    Direccion = "calle me lo calana",
                    Verificado = true,
                    AliadoEstado = AliadoEstado.NoDisponible,
                    IdUsuario = 1
                },
                new Aliado
                {
                    IdAliado = 2,
                    RazonSocial = "Finanzas Seguras",
                    SitioWeb = "www.finseguras.com",
                    Telefono = "3111111111",
                    Direccion = "Avenida Siempre Viva 123",
                    Verificado = true,
                    AliadoEstado = AliadoEstado.NoDisponible,
                    IdUsuario = 2
                },
                new Aliado
                {
                    IdAliado = 3,
                    RazonSocial = "Crédito Fácil",
                    SitioWeb = "www.creditofacil.com",
                    Telefono = "3222222222",
                    Direccion = "Calle Luna 456",
                    Verificado = false,
                    AliadoEstado = 0,
                    IdUsuario = 3
                },
                new Aliado
                {
                    IdAliado = 4,
                    RazonSocial = "Préstamos Ya",
                    SitioWeb = "www.prestamosya.com",
                    Telefono = "3333333333",
                    Direccion = "Calle Sol 789",
                    Verificado = true,
                    AliadoEstado = AliadoEstado.NoDisponible,
                    IdUsuario = 4
                },
                new Aliado
                {
                    IdAliado = 5,
                    RazonSocial = "Dinero Rápido",
                    SitioWeb = "www.dinerorapido.com",
                    Telefono = "3444444444",
                    Direccion = "Avenida del Parque 101",
                    Verificado = false,
                    AliadoEstado = 0,
                    IdUsuario = 5
                },
                new Aliado
                {
                    IdAliado = 6,
                    RazonSocial = "Crédito Seguro",
                    SitioWeb = "www.creditoseguro.com",
                    Telefono = "3555555555",
                    Direccion = "Calle del Río 202",
                    Verificado = true,
                    AliadoEstado = AliadoEstado.NoDisponible,
                    IdUsuario = 6
                },
                new Aliado
                {
                    IdAliado = 7,
                    RazonSocial = "Préstamo Fácil",
                    SitioWeb = "www.prestamofacil.com",
                    Telefono = "3666666666",
                    Direccion = "Boulevard del Mar 303",
                    Verificado = false,
                    AliadoEstado = 0,
                    IdUsuario = 7
                },
                new Aliado
                {
                    IdAliado = 8,
                    RazonSocial = "Dinero Seguro",
                    SitioWeb = "www.dineroseguro.com",
                    Telefono = "3777777777",
                    Direccion = "Calle del Sol 404",
                    Verificado = true,
                    AliadoEstado = AliadoEstado.NoDisponible,
                    IdUsuario = 8
                },
                new Aliado
                {
                    IdAliado = 9,
                    RazonSocial = "Préstamos Rápidos",
                    SitioWeb = "www.prestamosrapidos.com",
                    Telefono = "3888888888",
                    Direccion = "Avenida de las Flores 505",
                    Verificado = false,
                    AliadoEstado = 0,
                    IdUsuario = 9
                },
                new Aliado
                {
                    IdAliado = 10,
                    RazonSocial = "Créditos al Instante",
                    SitioWeb = "www.creditosinstante.com",
                    Telefono = "3999999999",
                    Direccion = "Calle del Bosque 606",
                    Verificado = true,
                    AliadoEstado = AliadoEstado.NoDisponible,
                    IdUsuario = 10
                }
            );


            // Verificados
            modelBuilder.Entity<Verificado>().HasData(
                new Verificado
                {
                    IdVerificado = 1,
                    FechaSolicitud = DateTime.Now,
                    FechaRespuesta = DateTime.Now,
                    VerificadoEstado = VerificadoEstado.Pendiente,
                    IdAliado = 1

                },
                new Verificado
                {
                    IdVerificado = 2,
                    FechaSolicitud = DateTime.Now.AddDays(-1),
                    FechaRespuesta = DateTime.Now.AddDays(1),
                    VerificadoEstado = VerificadoEstado.Pendiente,
                    IdAliado = 2
                },
                new Verificado
                {
                    IdVerificado = 3,
                    FechaSolicitud = DateTime.Now.AddDays(-2),
                    FechaRespuesta = DateTime.Now.AddDays(2),
                    VerificadoEstado = VerificadoEstado.Aprobado,
                    IdAliado = 3
                },
                new Verificado
                {
                    IdVerificado = 4,
                    FechaSolicitud = DateTime.Now.AddDays(-3),
                    FechaRespuesta = DateTime.Now.AddDays(3),
                    VerificadoEstado = VerificadoEstado.Rechazado,
                    IdAliado = 4
                },
                new Verificado
                {
                    IdVerificado = 5,
                    FechaSolicitud = DateTime.Now.AddDays(-4),
                    FechaRespuesta = DateTime.Now.AddDays(4),
                    VerificadoEstado = VerificadoEstado.Pendiente,
                    IdAliado = 5
                },
                new Verificado
                {
                    IdVerificado = 6,
                    FechaSolicitud = DateTime.Now.AddDays(-5),
                    FechaRespuesta = DateTime.Now.AddDays(5),
                    VerificadoEstado = VerificadoEstado.Aprobado,
                    IdAliado = 6
                },
                new Verificado
                {
                    IdVerificado = 7,
                    FechaSolicitud = DateTime.Now.AddDays(-6),
                    FechaRespuesta = DateTime.Now.AddDays(6),
                    VerificadoEstado = VerificadoEstado.Rechazado,
                    IdAliado = 7
                },
                new Verificado
                {
                    IdVerificado = 8,
                    FechaSolicitud = DateTime.Now.AddDays(-7),
                    FechaRespuesta = DateTime.Now.AddDays(7),
                    VerificadoEstado = VerificadoEstado.Pendiente,
                    IdAliado = 8
                },
                new Verificado
                {
                    IdVerificado = 9,
                    FechaSolicitud = DateTime.Now.AddDays(-8),
                    FechaRespuesta = DateTime.Now.AddDays(8),
                    VerificadoEstado = VerificadoEstado.Aprobado,
                    IdAliado = 9
                },
                new Verificado
                {
                    IdVerificado = 10,
                    FechaSolicitud = DateTime.Now.AddDays(-9),
                    FechaRespuesta = DateTime.Now.AddDays(9),
                    VerificadoEstado = VerificadoEstado.Rechazado,
                    IdAliado = 10
                }
            );


            // Publicaciones
            modelBuilder.Entity<Publicacion>().HasData(
                new Publicacion
                {
                    IdPublicacion = 1,
                    Titulo = "hola colombia",
                    Puntuacion = 5,
                    NumeroResenas = 5,
                    CapacidadCamas = 5,
                    Descripcion = "una ona de relax",
                    Precio = 5000,
                    Fecha = DateTime.Now,
                    Direccion = "calle diomedez",
                    IdAliado = 5
                },
                new Publicacion
                {
                    IdPublicacion = 2,
                    Titulo = "Descubre México",
                    Puntuacion = 4,
                    NumeroResenas = 10,
                    CapacidadCamas = 3,
                    Descripcion = "Un lugar lleno de cultura",
                    Precio = 7000,
                    Fecha = DateTime.Now.AddDays(-1),
                    Direccion = "Avenida Reforma",
                    IdAliado = 6
                },
                new Publicacion
                {
                    IdPublicacion = 3,
                    Titulo = "Aventura en Perú",
                    Puntuacion = 5,
                    NumeroResenas = 8,
                    CapacidadCamas = 4,
                    Descripcion = "Explora la magia de los Andes",
                    Precio = 8000,
                    Fecha = DateTime.Now.AddDays(-2),
                    Direccion = "Calle de las Flores",
                    IdAliado = 7
                },
                new Publicacion
                {
                    IdPublicacion = 4,
                    Titulo = "Paraíso en Brasil",
                    Puntuacion = 4,
                    NumeroResenas = 12,
                    CapacidadCamas = 6,
                    Descripcion = "Disfruta del sol y la playa",
                    Precio = 9000,
                    Fecha = DateTime.Now.AddDays(-3),
                    Direccion = "Playa Copacabana",
                    IdAliado = 8
                },
                new Publicacion
                {
                    IdPublicacion = 5,
                    Titulo = "Relax en Argentina",
                    Puntuacion = 5,
                    NumeroResenas = 15,
                    CapacidadCamas = 5,
                    Descripcion = "Descansa en la Patagonia",
                    Precio = 10000,
                    Fecha = DateTime.Now.AddDays(-4),
                    Direccion = "Calle San Martín",
                    IdAliado = 9
                },
                new Publicacion
                {
                    IdPublicacion = 6,
                    Titulo = "Encanto en Chile",
                    Puntuacion = 4,
                    NumeroResenas = 6,
                    CapacidadCamas = 3,
                    Descripcion = "Explora el desierto de Atacama",
                    Precio = 6000,
                    Fecha = DateTime.Now.AddDays(-5),
                    Direccion = "Avenida del Mar",
                    IdAliado = 10
                },
                new Publicacion
                {
                    IdPublicacion = 7,
                    Titulo = "Aventura en Bolivia",
                    Puntuacion = 3,
                    NumeroResenas = 7,
                    CapacidadCamas = 4,
                    Descripcion = "Descubre el Salar de Uyuni",
                    Precio = 7500,
                    Fecha = DateTime.Now.AddDays(-6),
                    Direccion = "Calle Uyuni",
                    IdAliado = 2
                },
                new Publicacion
                {
                    IdPublicacion = 8,
                    Titulo = "Diversión en Uruguay",
                    Puntuacion = 5,
                    NumeroResenas = 9,
                    CapacidadCamas = 5,
                    Descripcion = "Visita Punta del Este",
                    Precio = 8500,
                    Fecha = DateTime.Now.AddDays(-7),
                    Direccion = "Avenida Gorlero",
                    IdAliado = 1
                },
                new Publicacion
                {
                    IdPublicacion = 9,
                    Titulo = "Tranquilidad en Paraguay",
                    Puntuacion = 4,
                    NumeroResenas = 5,
                    CapacidadCamas = 2,
                    Descripcion = "Relájate en Asunción",
                    Precio = 5500,
                    Fecha = DateTime.Now.AddDays(-8),
                    Direccion = "Calle Palma",
                    IdAliado = 3
                },
                new Publicacion
                {
                    IdPublicacion = 10,
                    Titulo = "Maravillas de Ecuador",
                    Puntuacion = 5,
                    NumeroResenas = 14,
                    CapacidadCamas = 6,
                    Descripcion = "Explora las Islas Galápagos",
                    Precio = 9500,
                    Fecha = DateTime.Now.AddDays(-9),
                    Direccion = "Avenida Amazonas",
                    IdAliado = 4
                }
            );


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
            modelBuilder.Entity<Reserva>().HasData(
                new Reserva
                {
                    IdReserva = 1,
                    FechaInicial = DateTime.Now,
                    FechaFinal = DateTime.Now,
                    ReservaEstado = ReservaEstado.Activo,
                    NumeroPersonas = 1,
                    IdUsuario = 4,
                    IdPublicacion = 1

                },
                new Reserva
                {
                    IdReserva = 2,
                    FechaInicial = DateTime.Now.AddDays(1),
                    FechaFinal = DateTime.Now.AddDays(2),
                    ReservaEstado = ReservaEstado.Activo,
                    NumeroPersonas = 2,
                    IdUsuario = 5,
                    IdPublicacion = 2
                },
                new Reserva
                {
                    IdReserva = 3,
                    FechaInicial = DateTime.Now.AddDays(3),
                    FechaFinal = DateTime.Now.AddDays(4),
                    ReservaEstado = ReservaEstado.Cancelado,
                    NumeroPersonas = 3,
                    IdUsuario = 6,
                    IdPublicacion = 3
                },
                new Reserva
                {
                    IdReserva = 4,
                    FechaInicial = DateTime.Now.AddDays(5),
                    FechaFinal = DateTime.Now.AddDays(6),
                    ReservaEstado = ReservaEstado.Aprobado,
                    NumeroPersonas = 4,
                    IdUsuario = 7,
                    IdPublicacion = 4
                },
                new Reserva
                {
                    IdReserva = 5,
                    FechaInicial = DateTime.Now.AddDays(7),
                    FechaFinal = DateTime.Now.AddDays(8),
                    ReservaEstado = ReservaEstado.Activo,
                    NumeroPersonas = 2,
                    IdUsuario = 8,
                    IdPublicacion = 5
                },
                new Reserva
                {
                    IdReserva = 6,
                    FechaInicial = DateTime.Now.AddDays(9),
                    FechaFinal = DateTime.Now.AddDays(10),
                    ReservaEstado = ReservaEstado.Cancelado,
                    NumeroPersonas = 1,
                    IdUsuario = 9,
                    IdPublicacion = 6
                },
                new Reserva
                {
                    IdReserva = 7,
                    FechaInicial = DateTime.Now.AddDays(11),
                    FechaFinal = DateTime.Now.AddDays(12),
                    ReservaEstado = ReservaEstado.Aprobado,
                    NumeroPersonas = 3,
                    IdUsuario = 10,
                    IdPublicacion = 7
                },
                new Reserva
                {
                    IdReserva = 8,
                    FechaInicial = DateTime.Now.AddDays(13),
                    FechaFinal = DateTime.Now.AddDays(14),
                    ReservaEstado = ReservaEstado.Activo,
                    NumeroPersonas = 4,
                    IdUsuario = 1,
                    IdPublicacion = 8
                },
                new Reserva
                {
                    IdReserva = 9,
                    FechaInicial = DateTime.Now.AddDays(15),
                    FechaFinal = DateTime.Now.AddDays(16),
                    ReservaEstado = ReservaEstado.Cancelado,
                    NumeroPersonas = 2,
                    IdUsuario = 2,
                    IdPublicacion = 9
                },
                new Reserva
                {
                    IdReserva = 10,
                    FechaInicial = DateTime.Now.AddDays(17),
                    FechaFinal = DateTime.Now.AddDays(18),
                    ReservaEstado = ReservaEstado.Aprobado,
                    NumeroPersonas = 1,
                    IdUsuario = 3,
                    IdPublicacion = 10
                }
            );


            // Resenas
            modelBuilder.Entity<Resena>().HasData(
                new Resena
                {
                    IdResena = 1,
                    Opinion = "que ondaaa",
                    Fecha = DateTime.Today,
                    Calificacion = 2,
                    MeGusta = 3,
                    IdPublicacion = 4,
                    IdReserva = 5,

                },
                new Resena
                {
                    IdResena = 2,
                    Opinion = "Excelente servicio y atención.",
                    Fecha = DateTime.Today.AddDays(-1),
                    Calificacion = 5,
                    MeGusta = 10,
                    IdPublicacion = 2,
                    IdReserva = 3,
                },
                new Resena
                {
                    IdResena = 3,
                    Opinion = "La comida estaba deliciosa.",
                    Fecha = DateTime.Today.AddDays(-2),
                    Calificacion = 4,
                    MeGusta = 7,
                    IdPublicacion = 5,
                    IdReserva = 1,
                },
                new Resena
                {
                    IdResena = 4,
                    Opinion = "El lugar es muy acogedor.",
                    Fecha = DateTime.Today.AddDays(-3),
                    Calificacion = 5,
                    MeGusta = 15,
                    IdPublicacion = 3,
                    IdReserva = 2,
                },
                new Resena
                {
                    IdResena = 5,
                    Opinion = "El servicio podría mejorar.",
                    Fecha = DateTime.Today.AddDays(-4),
                    Calificacion = 3,
                    MeGusta = 4,
                    IdPublicacion = 1,
                    IdReserva = 4,
                },
                new Resena
                {
                    IdResena = 6,
                    Opinion = "El precio es un poco alto.",
                    Fecha = DateTime.Today.AddDays(-5),
                    Calificacion = 3,
                    MeGusta = 2,
                    IdPublicacion = 6,
                    IdReserva = 5,
                },
                new Resena
                {
                    IdResena = 7,
                    Opinion = "Recomiendo totalmente este lugar.",
                    Fecha = DateTime.Today.AddDays(-6),
                    Calificacion = 5,
                    MeGusta = 20,
                    IdPublicacion = 4,
                    IdReserva = 7,
                },
                new Resena
                {
                    IdResena = 8,
                    Opinion = "No me gustó la atención recibida.",
                    Fecha = DateTime.Today.AddDays(-7),
                    Calificacion = 2,
                    MeGusta = 1,
                    IdPublicacion = 7,
                    IdReserva = 6,
                },
                new Resena
                {
                    IdResena = 9,
                    Opinion = "El ambiente es muy agradable.",
                    Fecha = DateTime.Today.AddDays(-8),
                    Calificacion = 4,
                    MeGusta = 8,
                    IdPublicacion = 8,
                    IdReserva = 8,
                },
                new Resena
                {
                    IdResena = 10,
                    Opinion = "Volvería sin dudarlo.",
                    Fecha = DateTime.Today.AddDays(-9),
                    Calificacion = 5,
                    MeGusta = 12,
                    IdPublicacion = 9,
                    IdReserva = 9,
                }
            );


            // PublicacionesFavoritas
            modelBuilder.Entity<PublicacionFavorita>().HasData(
                new PublicacionFavorita
                {
                    IdPublicacionFavorita = 1,
                    IdPublicacion = 1,
                },
                new PublicacionFavorita
                {
                    IdPublicacionFavorita = 2,
                    IdPublicacion = 2,
                },
                new PublicacionFavorita
                {
                    IdPublicacionFavorita = 3,
                    IdPublicacion = 3,
                },
                new PublicacionFavorita
                {
                    IdPublicacionFavorita = 4,
                    IdPublicacion = 4,
                },
                new PublicacionFavorita
                {
                    IdPublicacionFavorita = 5,
                    IdPublicacion = 5,
                },
                new PublicacionFavorita
                {
                    IdPublicacionFavorita = 6,
                    IdPublicacion = 6,
                },
                new PublicacionFavorita
                {
                    IdPublicacionFavorita = 7,
                    IdPublicacion = 7,
                },
                new PublicacionFavorita
                {
                    IdPublicacionFavorita = 8,
                    IdPublicacion = 8,
                },
                new PublicacionFavorita
                {
                    IdPublicacionFavorita = 9,
                    IdPublicacion = 9,
                },
                new PublicacionFavorita
                {
                    IdPublicacionFavorita = 10,
                    IdPublicacion = 10,
                }
            );


            // PublicacionesImagenes
            modelBuilder.Entity<PublicacionImagen>().HasData(
                new PublicacionImagen
                {
                    IdPublicacionImagen = 1,
                    Ruta = "img/nose/playboy",
                    IdPublicacion = 1
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 2,
                    Ruta = "img/nose/beachview",
                    IdPublicacion = 2
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 3,
                    Ruta = "img/nose/mountainview",
                    IdPublicacion = 3
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 4,
                    Ruta = "img/nose/cityscape",
                    IdPublicacion = 4
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 5,
                    Ruta = "img/nose/luxuryroom",
                    IdPublicacion = 5
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 6,
                    Ruta = "img/nose/poolview",
                    IdPublicacion = 6
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 7,
                    Ruta = "img/nose/gardenview",
                    IdPublicacion = 7
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 8,
                    Ruta = "img/nose/rooftopview",
                    IdPublicacion = 8
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 9,
                    Ruta = "img/nose/spa",
                    IdPublicacion = 9
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 10,
                    Ruta = "img/nose/historicalsite",
                    IdPublicacion = 10
                }
            );


            // PublicacionesServicios
            modelBuilder.Entity<PublicacionServicio>().HasData(
                new PublicacionServicio
                {
                    IdPublicacionServicio = 1,
                    IdPublicacion = 1,
                    IdServicio = 1,

                },
                new PublicacionServicio
                {
                    IdPublicacionServicio = 2,
                    IdPublicacion = 2,
                    IdServicio = 2,
                },
                new PublicacionServicio
                {
                    IdPublicacionServicio = 3,
                    IdPublicacion = 3,
                    IdServicio = 3,
                },
                new PublicacionServicio
                {
                    IdPublicacionServicio = 4,
                    IdPublicacion = 4,
                    IdServicio = 4,
                },
                new PublicacionServicio
                {
                    IdPublicacionServicio = 5,
                    IdPublicacion = 5,
                    IdServicio = 5,
                },
                new PublicacionServicio
                {
                    IdPublicacionServicio = 6,
                    IdPublicacion = 6,
                    IdServicio = 6,
                },
                new PublicacionServicio
                {
                    IdPublicacionServicio = 7,
                    IdPublicacion = 7,
                    IdServicio = 7,
                },
                new PublicacionServicio
                {
                    IdPublicacionServicio = 8,
                    IdPublicacion = 8,
                    IdServicio = 8,
                },
                new PublicacionServicio
                {
                    IdPublicacionServicio = 9,
                    IdPublicacion = 9,
                    IdServicio = 9,
                },
                new PublicacionServicio
                {
                    IdPublicacionServicio = 10,
                    IdPublicacion = 10,
                    IdServicio = 10,
                }
            );


            // PublicacionesRestricciones
            modelBuilder.Entity<PublicacionRestriccion>().HasData(
                new PublicacionRestriccion
                {
                    IdPublicacionRestriccion = 1,
                    IdPublicacion = 1,
                    IdRestriccion = 1,

                },
                new PublicacionRestriccion
                {
                    IdPublicacionRestriccion = 2,
                    IdPublicacion = 2,
                    IdRestriccion = 2,
                },
                new PublicacionRestriccion
                {
                    IdPublicacionRestriccion = 3,
                    IdPublicacion = 3,
                    IdRestriccion = 3,
                },
                new PublicacionRestriccion
                {
                    IdPublicacionRestriccion = 4,
                    IdPublicacion = 4,
                    IdRestriccion = 4,
                },
                new PublicacionRestriccion
                {
                    IdPublicacionRestriccion = 5,
                    IdPublicacion = 5,
                    IdRestriccion = 5,
                },
                new PublicacionRestriccion
                {
                    IdPublicacionRestriccion = 6,
                    IdPublicacion = 6,
                    IdRestriccion = 6,
                },
                new PublicacionRestriccion
                {
                    IdPublicacionRestriccion = 7,
                    IdPublicacion = 7,
                    IdRestriccion = 7,
                },
                new PublicacionRestriccion
                {
                    IdPublicacionRestriccion = 8,
                    IdPublicacion = 8,
                    IdRestriccion = 8,
                },
                new PublicacionRestriccion
                {
                    IdPublicacionRestriccion = 9,
                    IdPublicacion = 9,
                    IdRestriccion = 9,
                },
                new PublicacionRestriccion
                {
                    IdPublicacionRestriccion = 10,
                    IdPublicacion = 10,
                    IdRestriccion = 10,
                }
            );


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
            */


        }

    }
}
