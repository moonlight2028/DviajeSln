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


            // Restricción para campos únicos
            modelBuilder.Entity<Usuario>().HasIndex(u => u.RazonSocial).IsUnique();
            modelBuilder.Entity<Usuario>().HasIndex(u => u.Telefono).IsUnique();
            modelBuilder.Entity<Usuario>().HasIndex(u => u.Direccion).IsUnique();


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
            // Datos de prueba
            modelBuilder.Entity<Usuario>().HasData(
                // Usuarios sin el rol asignado
                // Correccion
                new Usuario
                {
                    Id = "f7ad1421-b744-4f4e-93d9-e51fe1120136",
                    Email = "jesus@gmail.com",
                    NormalizedEmail = "JESUS@GMAIL.COM",
                    Verificado = false,
                    AliadoEstado = AliadoEstado.Disponible,
                    Direccion = "",
                    RazonSocial = ""
                },
                new Usuario
                {
                    Id = "b652f0fb-95c4-40ed-81aa-8e1792d089f8",
                    Email = "maria@hotmail.com",
                    NormalizedEmail = "MARIA@HOTMAIL.COM",
                    Verificado = false,
                    AliadoEstado = AliadoEstado.Disponible,
                    Direccion = "",
                    RazonSocial = ""
                },
                new Usuario
                {
                    Id = "eb5daf52-3be0-4083-ac20-f4f5ad0028c6",
                    Email = "juan@yahoo.com",
                    NormalizedEmail = "JUAN@YAHOO.COM",
                    Verificado = false,
                    AliadoEstado = AliadoEstado.Disponible,
                    Direccion = "",
                    RazonSocial = ""
                },
                new Usuario
                {
                    Id = "02aef042-3060-4a52-9a09-e9c5583c840c",
                    Email = "pedro@outlook.com",
                    NormalizedEmail = "PEDRO@OUTLOOK.COM",
                    Verificado = false,
                    AliadoEstado = AliadoEstado.Disponible,
                    Direccion = "",
                    RazonSocial = ""
                },
                new Usuario
                {
                    Id = "299c3027-88a1-4c43-98fa-e1c460dbd885",
                    Email = "ana@icloud.com",
                    NormalizedEmail = "ANA@ICLOUD.COM",
                    Verificado = false,
                    AliadoEstado = AliadoEstado.Disponible,
                    Direccion = "",
                    RazonSocial = ""
                },
                new Usuario
                {
                    Id = "7b6fc7d7-804c-4063-b58a-83a2a6d9cb4c",
                    Email = "luis@aol.com",
                    NormalizedEmail = "LUIS@AOL.COM",
                    Verificado = false,
                    AliadoEstado = AliadoEstado.Disponible,
                    Direccion = "",
                    RazonSocial = ""
                },
                new Usuario
                {
                    Id = "5d9b8f6f-9750-4678-a91b-4001bc0a22b5",
                    Email = "carmen@gmail.com",
                    NormalizedEmail = "CARMEN@GMAIL.COM",
                    Verificado = false,
                    AliadoEstado = AliadoEstado.Disponible,
                    Direccion = ""
                },
                new Usuario
                {
                    Id = "329988fe-7243-49f4-98ef-cafc80d16789",
                    Email = "rosa@live.com",
                    NormalizedEmail = "ROSA@LIVE.COM",
                    Verificado = false,
                    AliadoEstado = AliadoEstado.Disponible,
                    Direccion = ""
                },
                new Usuario
                {
                    Id = "b6651473-663d-4225-b2a8-522c7f0dbba4",
                    Email = "jose@protonmail.com",
                    NormalizedEmail = "JOSE@PROTONMAIL.COM",
                    Verificado = false,
                    AliadoEstado = AliadoEstado.Disponible,
                    Direccion = ""
                },
                new Usuario
                {
                    Id = "447a628d-a118-44e0-bbb1-c2e40975283c",
                    Email = "paula@mail.com",
                    NormalizedEmail = "PAULA@MAIL.COM",
                    Verificado = false,
                    AliadoEstado = AliadoEstado.Disponible,
                    Direccion = ""
                },


                // Aliados sin el rol asignado
                new Usuario
                {
                    Id = "95d735f9-d14e-47de-a00e-2359d142646b",
                    RazonSocial = "Servicios Globales S.A.",
                    SitioWeb = "globalservices.com",
                    Telefono = "22814209",
                    Direccion = "Carrera 10 No. 25-67",
                    Verificado = true,
                    AliadoEstado = AliadoEstado.Disponible,
                    UserName = "GlobalServ",
                    NormalizedUserName = "GLOBALSERV",
                    Email = "info@globalservices.com",
                    NormalizedEmail = "INFO@GLOBALSERVICES.COM",
                    EmailConfirmed = true,
                },
                new Usuario
                {
                    Id = "4f4bbb47-8619-4523-a83c-2d18eb961ae7",
                    RazonSocial = "Tecnologías Avanzadas LTDA",
                    SitioWeb = "techadv.com",
                    Telefono = "22814310",
                    Direccion = "Avenida 45 No. 12-34",
                    Verificado = false,
                    AliadoEstado = AliadoEstado.Disponible,
                    UserName = "TechAdv",
                    NormalizedUserName = "TECHADV",
                    Email = "contact@techadv.com",
                    NormalizedEmail = "CONTACT@TECHADV.COM",
                    EmailConfirmed = true,
                },
                new Usuario
                {
                    Id = "9b6fedaf-0fa5-4c6a-9266-117650a4c2d8",
                    RazonSocial = "Construcciones del Norte S.A.",
                    SitioWeb = "nortebuild.com",
                    Telefono = "22814411",
                    Direccion = "Calle 67 No. 10-25",
                    Verificado = true,
                    AliadoEstado = AliadoEstado.Disponible,
                    UserName = "NorteBuild",
                    NormalizedUserName = "NORTEBUILD",
                    Email = "info@nortebuild.com",
                    NormalizedEmail = "INFO@NORTEBUILD.COM",
                    EmailConfirmed = true,
                },
                new Usuario
                {
                    Id = "995eb3b8-b7b8-418d-9eee-7eec0b39515d",
                    RazonSocial = "Comercializadora Internacional S.A.",
                    SitioWeb = "cominter.com",
                    Telefono = "22814512",
                    Direccion = "Carrera 30 No. 14-56",
                    Verificado = false,
                    AliadoEstado = AliadoEstado.Disponible,
                    UserName = "ComInter",
                    NormalizedUserName = "COMINTER",
                    Email = "sales@cominter.com",
                    NormalizedEmail = "SALES@COMINTER.COM",
                    EmailConfirmed = true,
                },
                new Usuario
                {
                    Id = "2e5bad99-bcde-4fe9-9e0f-3c1df844f336",
                    RazonSocial = "Inmobiliaria del Sur LTDA",
                    SitioWeb = "southrealestate.com",
                    Telefono = "22814613",
                    Direccion = "Avenida 70 No. 8-45",
                    Verificado = true,
                    AliadoEstado = AliadoEstado.Disponible,
                    UserName = "SouthRealEstate",
                    NormalizedUserName = "SOUTHREALESTATE",
                    Email = "contact@southrealestate.com",
                    NormalizedEmail = "CONTACT@SOUTHREALESTATE.COM",
                    EmailConfirmed = true,
                },
                new Usuario
                {
                    Id = "f9dc84e7-1c0c-47ee-ad99-b589db9163a0",
                    RazonSocial = "Innovación y Desarrollo S.A.",
                    SitioWeb = "innodev.com",
                    Telefono = "22814714",
                    Direccion = "Calle 80 No. 5-67",
                    Verificado = false,
                    AliadoEstado = AliadoEstado.Disponible,
                    UserName = "InnoDev",
                    NormalizedUserName = "INNODEV",
                    Email = "info@innodev.com",
                    NormalizedEmail = "INFO@INNODEV.COM",
                    EmailConfirmed = true,
                },
                new Usuario
                {
                    Id = "b3567b2f-4c23-4adf-ab76-206b7e1858ec",
                    RazonSocial = "Logística Integral S.A.",
                    SitioWeb = "integrallogistics.com",
                    Telefono = "22814815",
                    Direccion = "Carrera 5 No. 70-80",
                    Verificado = true,
                    AliadoEstado = AliadoEstado.Disponible,
                    UserName = "IntegralLogistics",
                    NormalizedUserName = "INTEGRALLOGISTICS",
                    Email = "contact@integrallogistics.com",
                    NormalizedEmail = "CONTACT@INTEGRALLOGISTICS.COM",
                    EmailConfirmed = true,
                },
                new Usuario
                {
                    Id = "964fcd99-99db-406b-9a52-eff38524afe8",
                    RazonSocial = "Producción Agropecuaria S.A.",
                    SitioWeb = "agroproduce.com",
                    Telefono = "22814916",
                    Direccion = "Calle 23 No. 4-56",
                    Verificado = false,
                    AliadoEstado = AliadoEstado.Disponible,
                    UserName = "AgroProduce",
                    NormalizedUserName = "AGROPRODUCE",
                    Email = "info@agroproduce.com",
                    NormalizedEmail = "INFO@AGROPRODUCE.COM",
                    EmailConfirmed = true,
                },
                new Usuario
                {
                    Id = "2c390f18-bbcf-4675-9859-8e4d3fa32571",
                    RazonSocial = "Soluciones Ambientales S.A.",
                    SitioWeb = "enviro-solutions.com",
                    Telefono = "22815017",
                    Direccion = "Carrera 40 No. 15-90",
                    Verificado = true,
                    AliadoEstado = AliadoEstado.Disponible,
                    UserName = "EnviroSolutions",
                    NormalizedUserName = "ENVIROSOLUTIONS",
                    Email = "contact@enviro-solutions.com",
                    NormalizedEmail = "CONTACT@ENVIRO-SOLUTIONS.COM",
                    EmailConfirmed = true,
                },
                new Usuario
                {
                    Id = "c7350e94-45ab-483c-9f3f-153e54e0198b",
                    RazonSocial = "Red de Servicios Médicos S.A.",
                    SitioWeb = "mednetwork.com",
                    Telefono = "22815118",
                    Direccion = "Calle 32 No. 6-78",
                    Verificado = false,
                    AliadoEstado = AliadoEstado.Disponible,
                    UserName = "MedNetwork",
                    NormalizedUserName = "MEDNETWORK",
                    Email = "info@mednetwork.com",
                    NormalizedEmail = "INFO@MEDNETWORK.COM",
                    EmailConfirmed = true,
                },
                new Usuario
                {
                    Id = "89537343-76cd-4739-a360-4c0c26ecfd4d",
                    RazonSocial = "Distribuciones Nacionales S.A.",
                    SitioWeb = "natdist.com",
                    Telefono = "22815219",
                    Direccion = "Carrera 50 No. 20-34",
                    Verificado = true,
                    AliadoEstado = AliadoEstado.Disponible,
                    UserName = "NatDist",
                    NormalizedUserName = "NATDIST",
                    Email = "contact@natdist.com",
                    NormalizedEmail = "CONTACT@NATDIST.COM",
                    EmailConfirmed = true,
                }
            );


            // Servicios
            modelBuilder.Entity<Servicio>().HasData(
                // Servicios de establecimiento
                new Servicio
                {
                    IdServicio = 1,
                    NombreServicio = "Piscina",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-water-ladder"
                },
                new Servicio
                {
                    IdServicio = 2,
                    NombreServicio = "Piscina techada",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-water-ladder"
                },
                new Servicio
                {
                    IdServicio = 3,
                    NombreServicio = "Parqueadero",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-square-parking"
                },
                new Servicio
                {
                    IdServicio = 4,
                    NombreServicio = "Restaurante",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-utensils"
                }, new Servicio
                {
                    IdServicio = 5,
                    NombreServicio = "Bañera de hidromasaje",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-bath"
                },
                new Servicio
                {
                    IdServicio = 6,
                    NombreServicio = "Spa",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-spa"
                },
                new Servicio
                {
                    IdServicio = 7,
                    NombreServicio = "Gimnasio",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-dumbbell"
                },
                new Servicio
                {
                    IdServicio = 8,
                    NombreServicio = "Sauna",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-hot-tub-person"
                },
                new Servicio
                {
                    IdServicio = 9,
                    NombreServicio = "Sombrillas de playa",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-umbrella-beach"
                },
                new Servicio
                {
                    IdServicio = 10,
                    NombreServicio = "Desayuno incluido",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-bacon"
                },
                new Servicio
                {
                    IdServicio = 11,
                    NombreServicio = "Centro de negocios",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-business-time"
                },
                new Servicio
                {
                    IdServicio = 12,
                    NombreServicio = "Acepta mascotas",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-paw"
                },
                new Servicio
                {
                    IdServicio = 13,
                    NombreServicio = "Recepción disponible 24 horas",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-bell-concierge"
                },
                new Servicio
                {
                    IdServicio = 14,
                    NombreServicio = "Servicio de lavandería",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-jug-detergent"
                }, new Servicio
                {
                    IdServicio = 15,
                    NombreServicio = "Salas de reuniones",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-people-roof"
                },
                new Servicio
                {
                    IdServicio = 16,
                    NombreServicio = "Cajero automático",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-money-bills"
                },
                new Servicio
                {
                    IdServicio = 17,
                    NombreServicio = "Piscina climatizada",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-water-ladder"
                },
                new Servicio
                {
                    IdServicio = 18,
                    NombreServicio = "Alquiler de bicicletas",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-bicycle"
                },
                new Servicio
                {
                    IdServicio = 19,
                    NombreServicio = "Sala de juegos",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-table-tennis-paddle-ball"
                },
                new Servicio
                {
                    IdServicio = 20,
                    NombreServicio = "Piscina al aire libre",
                    ServicioTipo = ServicioTipo.Establecimiento,
                    RutaIcono = "fa-solid fa-person-swimming"
                },

                // Servicios de habitacion
                new Servicio
                {
                    IdServicio = 21,
                    NombreServicio = "Wi-Fi",
                    ServicioTipo = ServicioTipo.Habitacion,
                    RutaIcono = "fa-solid fa-wifi"
                },
                new Servicio
                {
                    IdServicio = 22,
                    NombreServicio = "Internet",
                    ServicioTipo = ServicioTipo.Habitacion,
                    RutaIcono = "fa-solid fa-network-wired"
                },
                new Servicio
                {
                    IdServicio = 23,
                    NombreServicio = "Aire acondicionado",
                    ServicioTipo = ServicioTipo.Habitacion,
                    RutaIcono = "fa-solid fa-wind"
                },
                new Servicio
                {
                    IdServicio = 24,
                    NombreServicio = "Cocina",
                    ServicioTipo = ServicioTipo.Habitacion,
                    RutaIcono = "fa-solid fa-kitchen-set"
                },
                new Servicio
                {
                    IdServicio = 25,
                    NombreServicio = "Balcón/Terraza",
                    ServicioTipo = ServicioTipo.Habitacion,
                    RutaIcono = "fa-solid fa-house"
                },
                new Servicio
                {
                    IdServicio = 26,
                    NombreServicio = "Bañera",
                    ServicioTipo = ServicioTipo.Habitacion,
                    RutaIcono = "fa-solid fa-bath"
                },
                new Servicio
                {
                    IdServicio = 27,
                    NombreServicio = "Minibar",
                    ServicioTipo = ServicioTipo.Habitacion,
                    RutaIcono = "fa-solid fa-champagne-glasses"
                },
                new Servicio
                {
                    IdServicio = 28,
                    NombreServicio = "Servicio de limpieza",
                    ServicioTipo = ServicioTipo.Habitacion,
                    RutaIcono = "fa-solid fa-broom"
                },
                new Servicio
                {
                    IdServicio = 29,
                    NombreServicio = "Secador de pelo",
                    ServicioTipo = ServicioTipo.Habitacion,
                    RutaIcono = "fa-solid fa-wind"
                },
                new Servicio
                {
                    IdServicio = 30,
                    NombreServicio = "Teléfono",
                    ServicioTipo = ServicioTipo.Habitacion,
                    RutaIcono = "fa-solid fa-phone"
                },
                new Servicio
                {
                    IdServicio = 31,
                    NombreServicio = "Balcón privado",
                    ServicioTipo = ServicioTipo.Habitacion,
                    RutaIcono = "fa-solid fa-house"
                },
                new Servicio
                {
                    IdServicio = 32,
                    NombreServicio = "Horno",
                    ServicioTipo = ServicioTipo.Habitacion,
                    RutaIcono = "fa-solid fa-fire-burner"
                },

                // Servicios de accesibilidad
                new Servicio
                {
                    IdServicio = 33,
                    NombreServicio = "Acceso silla de ruedas",
                    ServicioTipo = ServicioTipo.Accesibilidad,
                    RutaIcono = "fa-solid fa-wheelchair"
                },
                new Servicio
                {
                    IdServicio = 34,
                    NombreServicio = "Hab. p/ personas con discapacidad",
                    ServicioTipo = ServicioTipo.Accesibilidad,
                    RutaIcono = "fa-solid fa-house-user"
                },
                new Servicio
                {
                    IdServicio = 35,
                    NombreServicio = "Parqueadero p/ personas con discapacidad",
                    ServicioTipo = ServicioTipo.Accesibilidad,
                    RutaIcono = "fa-solid fa-square-parking"
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
                    RutaIcono = "fa-solid fa-sign-hanging"
                },
                new Categoria
                {
                    IdCategoria = 2,
                    NombreCategoria = "Apartamento",
                    RutaIcono = "fa-solid fa-house-user"
                },
                new Categoria
                {
                    IdCategoria = 3,
                    NombreCategoria = "Casa",
                    RutaIcono = "fa-solid fa-house"
                },
                new Categoria
                {
                    IdCategoria = 4,
                    NombreCategoria = "Cabaña",
                    RutaIcono = "fa-solid fa-house-chimney"
                },
                new Categoria
                {
                    IdCategoria = 5,
                    NombreCategoria = "Hotel",
                    RutaIcono = "fa-solid fa-hotel"
                },
                new Categoria
                {
                    IdCategoria = 6,
                    NombreCategoria = "Hostal",
                    RutaIcono = "fa-solid fa-hotel"
                },
                new Categoria
                {
                    IdCategoria = 7,
                    NombreCategoria = "Villa",
                    RutaIcono = "fa-solid fa-house-chimney-window"
                },
                new Categoria
                {
                    IdCategoria = 8,
                    NombreCategoria = "Resort",
                    RutaIcono = "fa-solid fa-hotel"
                },
                new Categoria
                {
                    IdCategoria = 9,
                    NombreCategoria = "Piso compartido",
                    RutaIcono = "fa-solid fa-people-roof"
                },
                new Categoria
                {
                    IdCategoria = 10,
                    NombreCategoria = "Villa vacacional",
                    RutaIcono = "fa-solid fa-house-chimney-window"
                },
                new Categoria
                {
                    IdCategoria = 11,
                    NombreCategoria = "Casa de campo",
                    RutaIcono = "fa-solid fa-house-chimney"
                },
                new Categoria
                {
                    IdCategoria = 12,
                    NombreCategoria = "Campamentos",
                    RutaIcono = "fa-solid fa-campground"
                },
                new Categoria
                {
                    IdCategoria = 13,
                    NombreCategoria = "Pensión",
                    RutaIcono = "fa-solid fa-house"
                },
                new Categoria
                {
                    IdCategoria = 14,
                    NombreCategoria = "Motel",
                    RutaIcono = "fa-solid fa-hotel"
                },
                new Categoria
                {
                    IdCategoria = 15,
                    NombreCategoria = "Apartahotel",
                    RutaIcono = "fa-solid fa-hotel"
                },
                new Categoria
                {
                    IdCategoria = 16,
                    NombreCategoria = "Casa rural",
                    RutaIcono = "fa-solid fa-house-chimney"
                },
                new Categoria
                {
                    IdCategoria = 17,
                    NombreCategoria = "Posada",
                    RutaIcono = "fa-solid fa-house"
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
                    IdUsuario = "f7ad1421-b744-4f4e-93d9-e51fe1120136"
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
                    IdUsuario = "b652f0fb-95c4-40ed-81aa-8e1792d089f8"
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
                    IdUsuario = "eb5daf52-3be0-4083-ac20-f4f5ad0028c6"
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
                    IdUsuario = "02aef042-3060-4a52-9a09-e9c5583c840c"
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
                    IdUsuario = "299c3027-88a1-4c43-98fa-e1c460dbd885"
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
                    IdUsuario = "7b6fc7d7-804c-4063-b58a-83a2a6d9cb4c"
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
                    IdUsuario = "5d9b8f6f-9750-4678-a91b-4001bc0a22b5"
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
                    IdUsuario = "329988fe-7243-49f4-98ef-cafc80d16789"
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
                    IdUsuario = "b6651473-663d-4225-b2a8-522c7f0dbba4"
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
                    IdUsuario = "447a628d-a118-44e0-bbb1-c2e40975283c"
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


            // Verificados
            modelBuilder.Entity<Verificado>().HasData(
                new Verificado
                {
                    IdVerificado = 1,
                    FechaSolicitud = DateTime.Now,
                    FechaRespuesta = DateTime.Now,
                    VerificadoEstado = VerificadoEstado.Aprobado,
                    IdUsuario = "95d735f9-d14e-47de-a00e-2359d142646b"

                },
                new Verificado
                {
                    IdVerificado = 2,
                    FechaSolicitud = DateTime.Now,
                    FechaRespuesta = DateTime.Now,
                    VerificadoEstado = VerificadoEstado.Aprobado,
                    IdUsuario = "9b6fedaf-0fa5-4c6a-9266-117650a4c2d8"

                },
                new Verificado
                {
                    IdVerificado = 3,
                    FechaSolicitud = DateTime.Now,
                    FechaRespuesta = DateTime.Now,
                    VerificadoEstado = VerificadoEstado.Aprobado,
                    IdUsuario = "2e5bad99-bcde-4fe9-9e0f-3c1df844f336"

                },
                new Verificado
                {
                    IdVerificado = 4,
                    FechaSolicitud = DateTime.Now,
                    FechaRespuesta = DateTime.Now,
                    VerificadoEstado = VerificadoEstado.Aprobado,
                    IdUsuario = "b3567b2f-4c23-4adf-ab76-206b7e1858ec"

                },
                new Verificado
                {
                    IdVerificado = 5,
                    FechaSolicitud = DateTime.Now,
                    FechaRespuesta = DateTime.Now,
                    VerificadoEstado = VerificadoEstado.Aprobado,
                    IdUsuario = "2c390f18-bbcf-4675-9859-8e4d3fa32571"

                },
                new Verificado
                {
                    IdVerificado = 6,
                    FechaSolicitud = DateTime.Now,
                    FechaRespuesta = DateTime.Now,
                    VerificadoEstado = VerificadoEstado.Aprobado,
                    IdUsuario = "89537343-76cd-4739-a360-4c0c26ecfd4d"
                },
                new Verificado
                {
                    IdVerificado = 7,
                    FechaSolicitud = DateTime.Now,
                    FechaRespuesta = DateTime.Now,
                    VerificadoEstado = VerificadoEstado.Rechazado,
                    IdUsuario = "4f4bbb47-8619-4523-a83c-2d18eb961ae7"
                },
                new Verificado
                {
                    IdVerificado = 8,
                    FechaSolicitud = DateTime.Now,
                    FechaRespuesta = DateTime.Now,
                    VerificadoEstado = VerificadoEstado.Rechazado,
                    IdUsuario = "995eb3b8-b7b8-418d-9eee-7eec0b39515d"
                },
                new Verificado
                {
                    IdVerificado = 9,
                    FechaSolicitud = DateTime.Now,
                    VerificadoEstado = VerificadoEstado.Pendiente,
                    IdUsuario = "f9dc84e7-1c0c-47ee-ad99-b589db9163a0"
                },
                new Verificado
                {
                    IdVerificado = 10,
                    FechaSolicitud = DateTime.Now,
                    VerificadoEstado = VerificadoEstado.Pendiente,
                    IdUsuario = "964fcd99-99db-406b-9a52-eff38524afe8"
                },
                new Verificado
                {
                    IdVerificado = 11,
                    FechaSolicitud = DateTime.Now,
                    VerificadoEstado = VerificadoEstado.Pendiente,
                    IdUsuario = "c7350e94-45ab-483c-9f3f-153e54e0198b"
                }
            );

            
            // Publicaciones
            modelBuilder.Entity<Publicacion>().HasData(
                new Publicacion
                {
                    IdPublicacion = 1,
                    Titulo = "Descubre Cundinamarca",
                    Puntuacion = 4.3M,
                    NumeroResenas = 2,
                    Descripcion = "Las lujosas comodidades de cinco estrellas y el servicio personalizado crean la mejor escapada para una estrella de rock. 15 piscinas amplias, cuatro bares en la piscina, una piscina para niños y un río lento. La playa del hotel es elogiada por los huéspedes. Los huéspedes aprecian la amabilidad del personal del hotel. Nueve restaurantes, incluido Simon Mansion & Supper Club, del famoso chef de rock n roll Kerry Simon.",
                    Precio = 150000,
                    Fecha = DateTime.Now,
                    Direccion = "Carrera 10 No. 25-67",
                    IdUsuario = "95d735f9-d14e-47de-a00e-2359d142646b"
                },
                new Publicacion
                {
                    IdPublicacion = 2,
                    Titulo = "Aventura en Antioquia",
                    Puntuacion = 4.7M,
                    NumeroResenas = 5,
                    Descripcion = "Sumérgete en la naturaleza con caminatas por senderos exuberantes y excursiones a cascadas escondidas. Los visitantes elogian la belleza natural y las actividades al aire libre. Disfruta de recorridos guiados, observación de aves y visitas a fincas cafetaleras locales.",
                    Precio = 200000,
                    Fecha = DateTime.Now,
                    Direccion = "Calle 20 No. 30-40",
                    IdUsuario = "95d735f9-d14e-47de-a00e-2359d142646b"
                },
                new Publicacion
                {
                    IdPublicacion = 3,
                    Titulo = "Cultura en Bogotá",
                    Puntuacion = 4.1M,
                    NumeroResenas = 3,
                    Descripcion = "Descubre la vibrante vida cultural de Bogotá. Visita museos, parques y galerías de arte. Los visitantes aprecian la rica historia y la diversidad cultural. Disfruta de recorridos guiados por la ciudad y actividades culturales nocturnas.",
                    Precio = 120000,
                    Fecha = DateTime.Now,
                    Direccion = "Avenida 68 No. 45-70",
                    IdUsuario = "95d735f9-d14e-47de-a00e-2359d142646b"
                },

                new Publicacion
                {
                    IdPublicacion = 4,
                    Titulo = "Playas del Caribe",
                    Puntuacion = 3.8M,
                    NumeroResenas = 8,
                    Descripcion = "Relájate en las arenas blancas y aguas cristalinas del Caribe. Los huéspedes disfrutan de deportes acuáticos, paseos en bote y relajación en la playa. Visita restaurantes de mariscos y mercados locales para una experiencia auténtica.",
                    Precio = 250000,
                    Fecha = DateTime.Now,
                    Direccion = "Carrera 50 No. 10-20",
                    IdUsuario = "95d735f9-d14e-47de-a00e-2359d142646b"
                },

                new Publicacion
                {
                    IdPublicacion = 5,
                    Titulo = "Gastronomía en Medellín",
                    Puntuacion = 2.6M,
                    NumeroResenas = 4,
                    Descripcion = "Experimenta la rica gastronomía de Medellín. Disfruta de platos típicos en restaurantes locales y participa en talleres de cocina. Los visitantes elogian la calidad de la comida y la hospitalidad de los locales.",
                    Precio = 180000,
                    Fecha = DateTime.Now,
                    Direccion = "Calle 15 No. 30-50",
                    IdUsuario = ""
                },

                new Publicacion
                {
                    IdPublicacion = 6,
                    Titulo = "Ruta del Café en Quindío",
                    Puntuacion = 0.9M,
                    NumeroResenas = 10,
                    Descripcion = "Conoce el proceso del café desde la semilla hasta la taza. Visita fincas cafetaleras y participa en catas de café. Los visitantes disfrutan de la belleza del paisaje y la riqueza cultural de la región.",
                    Precio = 220000,
                    Fecha = DateTime.Now,
                    Direccion = "Avenida 40 No. 20-60",
                    IdUsuario = "95d735f9-d14e-47de-a00e-2359d142646b"
                },

                new Publicacion
                {
                    IdPublicacion = 7,
                    Titulo = "Ecoturismo en Amazonas",
                    Puntuacion = 1.7M,
                    NumeroResenas = 7,
                    Descripcion = "Explora la selva amazónica y su increíble biodiversidad. Participa en excursiones guiadas y visitas a comunidades indígenas. Los visitantes valoran la autenticidad de la experiencia y la belleza natural.",
                    Precio = 300000,
                    Fecha = DateTime.Now,
                    Direccion = "Carrera 60 No. 25-30",
                    IdUsuario = "95d735f9-d14e-47de-a00e-2359d142646b"
                },

                new Publicacion
                {
                    IdPublicacion = 8,
                    Titulo = "Senderismo en Boyacá",
                    Puntuacion = 3.4M,
                    NumeroResenas = 6,
                    Descripcion = "Recorre senderos naturales y disfruta de paisajes impresionantes. Los visitantes aprecian la tranquilidad y la oportunidad de conectarse con la naturaleza. Participa en excursiones y actividades al aire libre.",
                    Precio = 140000,
                    Fecha = DateTime.Now,
                    Direccion = "Calle 25 No. 15-35",
                    IdUsuario = "95d735f9-d14e-47de-a00e-2359d142646b"
                },

                new Publicacion
                {
                    IdPublicacion = 9,
                    Titulo = "Historia en Cartagena",
                    Puntuacion = 2.6M,
                    NumeroResenas = 5,
                    Descripcion = "Visita sitios históricos y aprende sobre la rica historia de Cartagena. Explora fortalezas, museos y el casco antiguo. Los visitantes valoran la arquitectura y la atmósfera histórica de la ciudad.",
                    Precio = 190000,
                    Fecha = DateTime.Now,
                    Direccion = "Avenida 30 No. 50-80",
                    IdUsuario = "4f4bbb47-8619-4523-a83c-2d18eb961ae7"
                },

                new Publicacion
                {
                    IdPublicacion = 10,
                    Titulo = "Naturaleza en Huila",
                    Puntuacion = 4.5M,
                    NumeroResenas = 4,
                    Descripcion = "Descubre parques naturales y disfruta de actividades al aire libre. Los visitantes valoran la biodiversidad y las oportunidades para la observación de aves. Participa en excursiones y visitas guiadas.",
                    Precio = 160000,
                    Fecha = DateTime.Now,
                    Direccion = "Carrera 70 No. 30-45",
                    IdUsuario = "4f4bbb47-8619-4523-a83c-2d18eb961ae7"
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
