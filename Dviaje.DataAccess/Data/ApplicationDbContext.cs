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


            // Restricciones


            // Categorias


            // AtencionViajeros


            // Adjuntos


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
                     NumeroRsenas = 5,
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
                     NumeroRsenas = 10,
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
                     NumeroRsenas = 8,
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
                     NumeroRsenas = 12,
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
                     NumeroRsenas = 15,
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
                     NumeroRsenas = 6,
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
                     NumeroRsenas = 7,
                     CapacidadCamas = 4,
                     Descripcion = "Descubre el Salar de Uyuni",
                     Precio = 7500,
                     Fecha = DateTime.Now.AddDays(-6),
                     Direccion = "Calle Uyuni",
                     IdAliado = 11
                 },
                 new Publicacion
                 {
                     IdPublicacion = 8,
                     Titulo = "Diversión en Uruguay",
                     Puntuacion = 5,
                     NumeroRsenas = 9,
                     CapacidadCamas = 5,
                     Descripcion = "Visita Punta del Este",
                     Precio = 8500,
                     Fecha = DateTime.Now.AddDays(-7),
                     Direccion = "Avenida Gorlero",
                     IdAliado = 12
                 },
                 new Publicacion
                 {
                     IdPublicacion = 9,
                     Titulo = "Tranquilidad en Paraguay",
                     Puntuacion = 4,
                     NumeroRsenas = 5,
                     CapacidadCamas = 2,
                     Descripcion = "Relájate en Asunción",
                     Precio = 5500,
                     Fecha = DateTime.Now.AddDays(-8),
                     Direccion = "Calle Palma",
                     IdAliado = 13
                 },
                 new Publicacion
                 {
                     IdPublicacion = 10,
                     Titulo = "Maravillas de Ecuador",
                     Puntuacion = 5,
                     NumeroRsenas = 14,
                     CapacidadCamas = 6,
                     Descripcion = "Explora las Islas Galápagos",
                     Precio = 9500,
                     Fecha = DateTime.Now.AddDays(-9),
                     Direccion = "Avenida Amazonas",
                     IdAliado = 14
                 }
                 );



            // Favoritos


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
                     IdUsuario = 11,
                     IdPublicacion = 8
                 },
                 new Reserva
                 {
                     IdReserva = 9,
                     FechaInicial = DateTime.Now.AddDays(15),
                     FechaFinal = DateTime.Now.AddDays(16),
                     ReservaEstado = ReservaEstado.Cancelado,
                     NumeroPersonas = 2,
                     IdUsuario = 12,
                     IdPublicacion = 9
                 },
                 new Reserva
                 {
                     IdReserva = 10,
                     FechaInicial = DateTime.Now.AddDays(17),
                     FechaFinal = DateTime.Now.AddDays(18),
                     ReservaEstado = ReservaEstado.Aprobado,
                     NumeroPersonas = 1,
                     IdUsuario = 13,
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


            // FechasNoDisponibles


            // ServiciosAdicionales



        }

    }
}
