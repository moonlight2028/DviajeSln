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



            // Registro de Datos
            // Registro de Roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1717add7-89b4-4bf7-990f-a9f10f18aa39", Name = RolesUtility.RoleTurista, NormalizedName = RolesUtility.RoleTurista.ToUpper() },
                new IdentityRole { Id = "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894", Name = RolesUtility.RoleAliado, NormalizedName = RolesUtility.RoleAliado.ToUpper() },
                new IdentityRole { Id = "4751f532-04d5-497f-b48d-b9e26bcffe6f", Name = RolesUtility.RoleModerador, NormalizedName = RolesUtility.RoleModerador.ToUpper() },
                new IdentityRole { Id = "e5cd3d4a-2687-49cd-b57c-c8eddfbf2e19", Name = RolesUtility.RoleAdministrador, NormalizedName = RolesUtility.RoleAdministrador.ToUpper() }
            );


            // Registro de Turistas
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = "11bc73ce-dbe2-4370-bc92-0d57e5b366d7",
                    Avatar = "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8YXZhdGFyfGVufDB8fDB8fHww",
                    UserName = "Andres",
                    NormalizedUserName = "ANDRES",
                    Email = "andres@gmail.com",
                    NormalizedEmail = "ANDRES@GMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3159725595",
                    PhoneNumberConfirmed = true
                },
                new Usuario
                {
                    Id = "26cfe5c9-00f8-411e-b589-df3405a8b798",
                    Avatar = "https://plus.unsplash.com/premium_photo-1658527049634-15142565537a?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8YXZhdGFyfGVufDB8fDB8fHww",
                    UserName = "Maria",
                    NormalizedUserName = "MARIA",
                    Email = "maria@gmail.com",
                    NormalizedEmail = "MARIA@GMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3101234567",
                    PhoneNumberConfirmed = true
                },
                new Usuario
                {
                    Id = "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1",
                    Avatar = "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8YXZhdGFyfGVufDB8fDB8fHww",
                    UserName = "Carlos",
                    NormalizedUserName = "CARLOS",
                    Email = "carlos@yahoo.com",
                    NormalizedEmail = "CARLOS@YAHOO.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3189876543",
                    PhoneNumberConfirmed = true
                },
                new Usuario
                {
                    Id = "e4309639-4588-4553-8c14-5ce4426e0dd7",
                    Avatar = "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8YXZhdGFyfGVufDB8fDB8fHww",
                    UserName = "Sofia",
                    NormalizedUserName = "SOFIA",
                    Email = "sofia@hotmail.com",
                    NormalizedEmail = "SOFIA@HOTMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3123456789",
                    PhoneNumberConfirmed = true
                },
                new Usuario
                {
                    Id = "3a895383-b546-4693-8246-924a9fc5289f",
                    Avatar = "https://images.unsplash.com/photo-1535713875002-d1d0cf377fde?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8YXZhdGFyfGVufDB8fDB8fHww",
                    UserName = "Luis",
                    NormalizedUserName = "LUIS",
                    Email = "luis@outlook.com",
                    NormalizedEmail = "LUIS@OUTLOOK.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3112345678",
                    PhoneNumberConfirmed = true
                },
                new Usuario
                {
                    Id = "1c8e89f7-7db6-4cd5-907d-f01b058cd784",
                    Avatar = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OHx8YXZhdGFyfGVufDB8fDB8fHww",
                    UserName = "Isabella",
                    NormalizedUserName = "ISABELLA",
                    Email = "isabella@gmail.com",
                    NormalizedEmail = "ISABELLA@GMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3179876543",
                    PhoneNumberConfirmed = true
                },
                new Usuario
                {
                    Id = "13825fa6-5c27-4303-ab17-6e13aac24c12",
                    Avatar = "https://images.unsplash.com/photo-1543610892-0b1f7e6d8ac1?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    UserName = "Fernando",
                    NormalizedUserName = "FERNANDO",
                    Email = "fernando@yahoo.com",
                    NormalizedEmail = "FERNANDO@YAHOO.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3198765432",
                    PhoneNumberConfirmed = true
                },
                new Usuario
                {
                    Id = "230d9aeb-6bca-4faa-b867-2d49e1a8c12e",
                    Avatar = "https://plus.unsplash.com/premium_photo-1670884441012-c5cf195c062a?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OXx8YXZhdGFyfGVufDB8fDB8fHww",
                    UserName = "Ana",
                    NormalizedUserName = "ANA",
                    Email = "ana@hotmail.com",
                    NormalizedEmail = "ANA@HOTMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3149876543",
                    PhoneNumberConfirmed = true
                },
                new Usuario
                {
                    Id = "2e59aa62-61bd-4c8d-9a3d-13f461696eab",
                    Avatar = "https://images.unsplash.com/photo-1623582854588-d60de57fa33f?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fGF2YXRhcnxlbnwwfHwwfHx8MA%3D%3D",
                    UserName = "Jorge",
                    NormalizedUserName = "JORGE",
                    Email = "jorge@outlook.com",
                    NormalizedEmail = "JORGE@OUTLOOK.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3151234567",
                    PhoneNumberConfirmed = true
                },
                new Usuario
                {
                    Id = "ca0a0328-0f5b-4ff3-b40e-6ffa8d145abb",
                    Avatar = "https://images.unsplash.com/photo-1706885093487-7eda37b48a60?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTl8fGF2YXRhcnxlbnwwfHwwfHx8MA%3D%3D",
                    UserName = "Gabriela",
                    NormalizedUserName = "GABRIELA",
                    Email = "gabriela@gmail.com",
                    NormalizedEmail = "GABRIELA@GMAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3169876543",
                    PhoneNumberConfirmed = true
                }
            );


            // Asignación rol Turista a usuarios.
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "11bc73ce-dbe2-4370-bc92-0d57e5b366d7", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" },
                new IdentityUserRole<string> { UserId = "26cfe5c9-00f8-411e-b589-df3405a8b798", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" },
                new IdentityUserRole<string> { UserId = "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" },
                new IdentityUserRole<string> { UserId = "e4309639-4588-4553-8c14-5ce4426e0dd7", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" },
                new IdentityUserRole<string> { UserId = "3a895383-b546-4693-8246-924a9fc5289f", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" },
                new IdentityUserRole<string> { UserId = "1c8e89f7-7db6-4cd5-907d-f01b058cd784", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" },
                new IdentityUserRole<string> { UserId = "13825fa6-5c27-4303-ab17-6e13aac24c12", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" },
                new IdentityUserRole<string> { UserId = "230d9aeb-6bca-4faa-b867-2d49e1a8c12e", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" },
                new IdentityUserRole<string> { UserId = "2e59aa62-61bd-4c8d-9a3d-13f461696eab", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" },
                new IdentityUserRole<string> { UserId = "ca0a0328-0f5b-4ff3-b40e-6ffa8d145abb", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" }
            );


            // Registro de Aliados(
            modelBuilder.Entity<Aliado>().HasData(
                new Aliado
                {
                    Id = "01bfd429-16ea-44b3-902c-794e2c78dfa7",
                    RazonSocial = "Colombia Adventure",
                    SitioWeb = "www.colombiaadventure.com",
                    Direccion = "Carrera 7 # 45-23",
                    Verificado = true,
                    AliadoEstado = AliadoEstado.Disponible,
                    Avatar = "https://images.unsplash.com/photo-1609137144813-7d9921338f24?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8dHVyaXNtfGVufDB8fDB8fHwy",
                    UserName = "ColombiaAdv",
                    NormalizedUserName = "COLOMBIAADV",
                    Email = "info@colombiaadventure.com",
                    NormalizedEmail = "INFO@COLOMBIAADVENTURE.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3216549870",
                    PhoneNumberConfirmed = true,
                    NumeroPublicaciones = 4
                },
                new Aliado
                {
                    Id = "9cd842af-b711-44cc-aa5e-3863e3c30b76",
                    RazonSocial = "Bogotá Tours",
                    SitioWeb = "www.bogotatours.co",
                    Direccion = "Avenida 6 # 12-34",
                    Verificado = true,
                    AliadoEstado = AliadoEstado.Disponible,
                    Avatar = "https://images.unsplash.com/photo-1678009859747-9f4620e0c355?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8dHVyaXNtfGVufDB8fDB8fHwy",
                    UserName = "BogotaTours",
                    NormalizedUserName = "BOGOTATOURS",
                    Email = "contact@bogotatours.co",
                    NormalizedEmail = "CONTACT@BOGOTATOURS.CO",
                    EmailConfirmed = true,
                    PhoneNumber = "3123456789",
                    PhoneNumberConfirmed = true,
                    NumeroPublicaciones = 445
                },
                new Aliado
                {
                    Id = "c654adef-5f0c-48e6-946a-52706f8ac520",
                    RazonSocial = "Medellín Explore",
                    SitioWeb = "www.medellinexplore.com",
                    Direccion = "Calle 80 # 25-67",
                    Verificado = true,
                    AliadoEstado = AliadoEstado.Disponible,
                    Avatar = "https://images.unsplash.com/photo-1673213314908-5b1863e742d1?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8dHVyaXNtfGVufDB8fDB8fHwy",
                    UserName = "MedellinExplore",
                    NormalizedUserName = "MEDELLINEXPLORE",
                    Email = "hello@medellinexplore.com",
                    NormalizedEmail = "HELLO@MEDELLINEXPLORE.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3198765432",
                    PhoneNumberConfirmed = true,
                    NumeroPublicaciones = 89
                },
                new Aliado
                {
                    Id = "8142c33b-ee02-4a13-b0c1-1e941387433d",
                    RazonSocial = "Cartagena Getaways",
                    SitioWeb = "www.cartagenagetaways.com",
                    Direccion = "Bocagrande, Avenida San Martín # 11-43",
                    Verificado = true,
                    AliadoEstado = AliadoEstado.Disponible,
                    Avatar = "https://images.unsplash.com/photo-1691225409811-a64942a0596a?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8dHVyaXNtfGVufDB8fDB8fHwy",
                    UserName = "CartagenaGetaways",
                    NormalizedUserName = "CARTAGENAGETAWAYS",
                    Email = "support@cartagenagetaways.com",
                    NormalizedEmail = "SUPPORT@CARTAGENAGETAWAYS.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3176543210",
                    PhoneNumberConfirmed = true,
                    NumeroPublicaciones = 478
                },
                new Aliado
                {
                    Id = "39e10980-4df3-494a-bbe7-410e105f6551",
                    RazonSocial = "Santa Marta Adventures",
                    SitioWeb = "www.santamartaadventures.com",
                    Direccion = "Centro Histórico, Carrera 2 # 10-55",
                    Verificado = true,
                    AliadoEstado = AliadoEstado.Disponible,
                    Avatar = "https://images.unsplash.com/photo-1543746746-46047c4f4bb0?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8dHVyaXNtfGVufDB8fDB8fHwy",
                    UserName = "SantaMartaAdv",
                    NormalizedUserName = "SANTAMARTAADV",
                    Email = "info@santamartaadventures.com",
                    NormalizedEmail = "INFO@SANTAMARTAADVENTURES.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3154321098",
                    PhoneNumberConfirmed = true,
                    NumeroPublicaciones = 48
                },
                new Aliado
                {
                    Id = "c3733288-b354-445d-95da-4c655c3220b3",
                    RazonSocial = "Cali Experiences",
                    SitioWeb = "www.caliexperiences.com",
                    Direccion = "Barrio San Antonio, Carrera 10 # 5-32",
                    Verificado = true,
                    AliadoEstado = AliadoEstado.Disponible,
                    Avatar = "https://images.unsplash.com/photo-1523345863760-5b7f3472d14f?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OHx8dHVyaXNtfGVufDB8fDB8fHwy",
                    UserName = "CaliExp",
                    NormalizedUserName = "CALIEXP",
                    Email = "contact@caliexperiences.com",
                    NormalizedEmail = "CONTACT@CALIEXPERIENCES.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3132109876",
                    PhoneNumberConfirmed = true,
                    NumeroPublicaciones = 8
                },
                new Aliado
                {
                    Id = "4c03648f-7727-4e5c-b096-fcbe3b9e3059",
                    RazonSocial = "Barranquilla Escapes",
                    SitioWeb = "www.barranquillaescapes.com",
                    Direccion = "Vía 40 # 72-20",
                    Verificado = false,
                    AliadoEstado = AliadoEstado.Disponible,
                    Avatar = "https://images.unsplash.com/photo-1492294112339-ea831887e5d7?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OXx8dHVyaXNtfGVufDB8fDB8fHwy",
                    UserName = "BquillaEscapes",
                    NormalizedUserName = "BQUILLAESCAPES",
                    Email = "hello@barranquillaescapes.com",
                    NormalizedEmail = "HELLO@BARRANQUILLAESCAPES.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3140987654",
                    PhoneNumberConfirmed = true,
                    NumeroPublicaciones = 7
                },
                new Aliado
                {
                    Id = "6e291ab8-a9b5-4a7a-afbc-bbbd71b6291b",
                    RazonSocial = "Bucaramanga Journeys",
                    SitioWeb = "www.bucaramangajourneys.com",
                    Direccion = "Cabecera, Carrera 33 # 45-67",
                    Verificado = false,
                    AliadoEstado = AliadoEstado.Disponible,
                    Avatar = "https://images.unsplash.com/photo-1463839346397-8e9946845e6d?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTB8fHR1cmlzbXxlbnwwfHwwfHx8Mg%3D%3D",
                    UserName = "BucaraJourneys",
                    NormalizedUserName = "BUCARAJOURNEYS",
                    Email = "support@bucaramangajourneys.com",
                    NormalizedEmail = "SUPPORT@BUCARAMANGAJOURNEYS.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3229876543",
                    PhoneNumberConfirmed = true,
                    NumeroPublicaciones = 76
                },
                new Aliado
                {
                    Id = "96067e6f-c29b-46ab-9ba1-18ec7b6534f4",
                    RazonSocial = "Pereira Travels",
                    SitioWeb = "www.pereiratravels.com",
                    Direccion = "Avenida Circunvalar # 18-10",
                    Verificado = false,
                    AliadoEstado = AliadoEstado.Disponible,
                    Avatar = "https://images.unsplash.com/photo-1519998334409-c7c6b1147f65?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fHR1cmlzbXxlbnwwfHwwfHx8Mg%3D%3D",
                    UserName = "PereiraTravels",
                    NormalizedUserName = "PEREIRATRAVELS",
                    Email = "info@pereiratravels.com",
                    NormalizedEmail = "INFO@PEREIRATRAVELS.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3107654321",
                    PhoneNumberConfirmed = true,
                    NumeroPublicaciones = 3
                },
                new Aliado
                {
                    Id = "5cf9f86f-36db-4d17-8ec3-cad66cd7f10f",
                    RazonSocial = "Manizales Wonders",
                    SitioWeb = "www.manizaleswonders.com",
                    Direccion = "Centro, Carrera 23 # 17-18",
                    Verificado = false,
                    AliadoEstado = AliadoEstado.Disponible,
                    Avatar = "https://images.unsplash.com/photo-1532878056386-1e96eb5221ad?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fHR1cmlzbXxlbnwwfHwwfHx8Mg%3D%3D",
                    UserName = "ManizalesWonders",
                    NormalizedUserName = "MANIZALESWONDERS",
                    Email = "contact@manizaleswonders.com",
                    NormalizedEmail = "CONTACT@MANIZALESWONDERS.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "3165432109",
                    PhoneNumberConfirmed = true,
                    NumeroPublicaciones = 7
                }
            );


            // Asignación rol Turista a Aliados.
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "01bfd429-16ea-44b3-902c-794e2c78dfa7", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" },
                new IdentityUserRole<string> { UserId = "9cd842af-b711-44cc-aa5e-3863e3c30b76", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" },
                new IdentityUserRole<string> { UserId = "c654adef-5f0c-48e6-946a-52706f8ac520", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" },
                new IdentityUserRole<string> { UserId = "8142c33b-ee02-4a13-b0c1-1e941387433d", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" },
                new IdentityUserRole<string> { UserId = "39e10980-4df3-494a-bbe7-410e105f6551", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" },
                new IdentityUserRole<string> { UserId = "c3733288-b354-445d-95da-4c655c3220b3", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" },
                new IdentityUserRole<string> { UserId = "4c03648f-7727-4e5c-b096-fcbe3b9e3059", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" },
                new IdentityUserRole<string> { UserId = "6e291ab8-a9b5-4a7a-afbc-bbbd71b6291b", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" },
                new IdentityUserRole<string> { UserId = "96067e6f-c29b-46ab-9ba1-18ec7b6534f4", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" },
                new IdentityUserRole<string> { UserId = "5cf9f86f-36db-4d17-8ec3-cad66cd7f10f", RoleId = "1717add7-89b4-4bf7-990f-a9f10f18aa39" }
            );


            // Asignación rol Aliado a Aliados.
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "01bfd429-16ea-44b3-902c-794e2c78dfa7", RoleId = "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894" },
                new IdentityUserRole<string> { UserId = "9cd842af-b711-44cc-aa5e-3863e3c30b76", RoleId = "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894" },
                new IdentityUserRole<string> { UserId = "c654adef-5f0c-48e6-946a-52706f8ac520", RoleId = "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894" },
                new IdentityUserRole<string> { UserId = "8142c33b-ee02-4a13-b0c1-1e941387433d", RoleId = "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894" },
                new IdentityUserRole<string> { UserId = "39e10980-4df3-494a-bbe7-410e105f6551", RoleId = "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894" },
                new IdentityUserRole<string> { UserId = "c3733288-b354-445d-95da-4c655c3220b3", RoleId = "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894" },
                new IdentityUserRole<string> { UserId = "4c03648f-7727-4e5c-b096-fcbe3b9e3059", RoleId = "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894" },
                new IdentityUserRole<string> { UserId = "6e291ab8-a9b5-4a7a-afbc-bbbd71b6291b", RoleId = "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894" },
                new IdentityUserRole<string> { UserId = "96067e6f-c29b-46ab-9ba1-18ec7b6534f4", RoleId = "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894" },
                new IdentityUserRole<string> { UserId = "5cf9f86f-36db-4d17-8ec3-cad66cd7f10f", RoleId = "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894" }
            );


            // Registros de AtencionViajero.
            modelBuilder.Entity<AtencionViajero>().HasData(
                new AtencionViajero
                {
                    IdAtencion = 1,
                    FechaAtencion = new DateTime(2024, 07, 25, 10, 30, 50),
                    Descripcion = "Me gustaría presentar una queja sobre el servicio recibido el pasado 25 de julio de 2024 a través de su plataforma de turismo. Ese día, tenía programada una visita guiada para las 10:00 a.m. en el centro histórico, pero la guía no llegó hasta las 11:30 a.m., sin ninguna explicación por parte del equipo de soporte. Además, la atención recibida fue poco profesional, ya que la guía no pudo responder adecuadamente a mis preguntas sobre los lugares visitados. Agradecería una revisión de este caso y una explicación sobre lo ocurrido, así como las medidas que se tomarán para evitar que situaciones similares se repitan en el futuro. /n Adjunto capturas de pantalla de los correos de confirmación de mi reserva y del pago realizado como referencia.",
                    Respuesta = "Gracias por comunicarse con nosotros y por informarnos sobre su experiencia con nuestro servicio el 25 de julio de 2024. Lamentamos sinceramente los inconvenientes que experimentó durante su visita guiada y cualquier insatisfacción que esto le haya causado. /n Hemos revisado su caso y constatamos que hubo un problema de programación inesperado que retrasó la llegada de la guía. Apreciamos su paciencia y comprensión en esta situación. Hemos tomado medidas para mejorar nuestros procesos de planificación y comunicación con el equipo de guías para asegurarnos de que este tipo de incidentes no se repitan. /n Además, como gesto de disculpa, nos gustaría ofrecerle un reembolso completo del costo de su reserva y un descuento del 20% en su próxima visita con nosotros. Un representante de nuestro equipo se pondrá en contacto con usted en breve para gestionar el reembolso. /n Gracias por su comprensión y por darnos la oportunidad de corregir este error. Valoramos mucho su opinión y esperamos poder servirle mejor en el futuro.",
                    Asunto = "Queja por Servicio de Visita Guiada Retrasada el 25 de Julio",
                    FechaRespuesta = new DateTime(2024, 07, 30, 07, 39, 20),
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Queja,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Completado,
                    IdUsuario = "11bc73ce-dbe2-4370-bc92-0d57e5b366d7"
                },
                new AtencionViajero
                {
                    IdAtencion = 2,
                    FechaAtencion = new DateTime(2024, 07, 20, 15, 45, 00),
                    Descripcion = "Durante mi visita al museo el 20 de julio de 2024, experimenté varios problemas técnicos con la aplicación de audio-guía. La aplicación se cerraba inesperadamente, y no pude escuchar la mayoría de las explicaciones. Adjunto capturas de pantalla de los errores.",
                    Respuesta = "Gracias por informarnos sobre los problemas técnicos que experimentó el 20 de julio de 2024. Hemos identificado el problema y estamos trabajando para solucionarlo. Como compensación, le ofrecemos un pase gratuito para su próxima visita.",
                    Asunto = "Problemas Técnicos con la Aplicación de Audio-Guía",
                    FechaRespuesta = new DateTime(2024, 07, 21, 09, 00, 00),
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Queja,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Completado,
                    IdUsuario = "26cfe5c9-00f8-411e-b589-df3405a8b798"
                },
                new AtencionViajero
                {
                    IdAtencion = 3,
                    FechaAtencion = new DateTime(2024, 07, 15, 12, 10, 30),
                    Descripcion = "Solicito información adicional sobre el tour ecológico programado para el 15 de agosto de 2024. Me gustaría conocer más sobre las actividades incluidas y el equipo necesario.",
                    Respuesta = "Gracias por su interés en nuestro tour ecológico. El tour incluye caminatas guiadas, observación de fauna y flora, y un taller de reciclaje. Se recomienda llevar ropa cómoda, repelente y cámara.",
                    Asunto = "Información sobre Tour Ecológico",
                    FechaRespuesta = new DateTime(2024, 07, 16, 08, 45, 00),
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Pregunta,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Completado,
                    IdUsuario = "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1"
                },
                new AtencionViajero
                {
                    IdAtencion = 4,
                    FechaAtencion = new DateTime(2024, 07, 18, 14, 00, 00),
                    Descripcion = "Deseo cancelar mi reserva para el tour gastronómico del 22 de julio de 2024 debido a un cambio de planes. Adjunto el número de reserva.",
                    Respuesta = "Hemos procesado la cancelación de su reserva para el tour gastronómico del 22 de julio de 2024. Se ha iniciado el reembolso correspondiente, que debería reflejarse en su cuenta en 5-7 días hábiles.",
                    Asunto = "Cancelación de Reserva de Tour Gastronómico",
                    FechaRespuesta = new DateTime(2024, 07, 19, 10, 00, 00),
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Pregunta,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Proceso,
                    IdUsuario = "e4309639-4588-4553-8c14-5ce4426e0dd7"
                },
                new AtencionViajero
                {
                    IdAtencion = 5,
                    FechaAtencion = new DateTime(2024, 07, 10, 09, 30, 00),
                    Descripcion = "Me gustaría felicitar al equipo por el excelente servicio recibido durante el tour de aventura el 8 de julio de 2024. La guía fue muy profesional y las actividades bien organizadas.",
                    Respuesta = "Gracias por sus amables palabras y por reconocer el esfuerzo de nuestro equipo. Compartiremos sus comentarios con la guía y el resto del equipo. Nos alegra que haya disfrutado de su experiencia.",
                    Asunto = "Agradecimiento por Excelente Servicio en Tour de Aventura",
                    FechaRespuesta = new DateTime(2024, 07, 11, 08, 15, 00),
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Sugerencia,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Proceso,
                    IdUsuario = "3a895383-b546-4693-8246-924a9fc5289f"
                },
                new AtencionViajero
                {
                    IdAtencion = 6,
                    FechaAtencion = new DateTime(2024, 07, 22, 11, 15, 00),
                    Descripcion = "El vehículo asignado para el traslado al aeropuerto el 22 de julio de 2024 no llegó a tiempo, y casi perdí mi vuelo. Agradecería una explicación y compensación por este inconveniente.",
                    Respuesta = "Lamentamos sinceramente el retraso en su traslado al aeropuerto el 22 de julio de 2024. Investigamos el incidente y estamos mejorando nuestros procesos de logística. Le ofrecemos un descuento del 30% en su próximo servicio de traslado.",
                    Asunto = "Retraso en el Servicio de Traslado al Aeropuerto",
                    FechaRespuesta = new DateTime(2024, 07, 23, 10, 30, 00),
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Queja,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Proceso,
                    IdUsuario = "01bfd429-16ea-44b3-902c-794e2c78dfa7"
                },
                new AtencionViajero
                {
                    IdAtencion = 7,
                    FechaAtencion = new DateTime(2024, 07, 17, 13, 45, 00),
                    Descripcion = "Me gustaría saber si hay disponibilidad de tours privados para familias en agosto de 2024 y cuáles serían las opciones y precios.",
                    Asunto = "Consulta sobre Disponibilidad de Tours Privados para Familias",
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Pregunta,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Pendiente,
                    IdUsuario = "9cd842af-b711-44cc-aa5e-3863e3c30b76"
                },
                new AtencionViajero
                {
                    IdAtencion = 8,
                    FechaAtencion = new DateTime(2024, 07, 12, 16, 00, 00),
                    Descripcion = "Me gustaría proponer una mejora en su aplicación móvil. Sería útil poder descargar itinerarios y mapas para usarlos sin conexión.",
                    Asunto = "Sugerencia para Mejorar la Aplicación Móvil",
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Sugerencia,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Pendiente,
                    IdUsuario = "c654adef-5f0c-48e6-946a-52706f8ac520"
                },
                new AtencionViajero
                {
                    IdAtencion = 9,
                    FechaAtencion = new DateTime(2024, 07, 08, 08, 20, 00),
                    Descripcion = "No recibí el correo de confirmación para mi reserva del tour de playa el 15 de julio de 2024. Adjunto el recibo de pago como comprobante.",
                    Asunto = "Falta de Confirmación de Reserva para Tour de Playa",
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Reclamo,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Pendiente,
                    IdUsuario = "8142c33b-ee02-4a13-b0c1-1e941387433d"
                },
                new AtencionViajero
                {
                    IdAtencion = 10,
                    FechaAtencion = new DateTime(2024, 07, 05, 10, 00, 00),
                    Descripcion = "Quisiera expresar mi satisfacción por el excelente servicio recibido durante el tour cultural el 3 de julio de 2024. La organización fue impecable y la guía muy conocedora.",
                    Asunto = "Agradecimiento por Tour Cultural",
                    AtencionViajeroTipoPqrs = AtencionViajeroTipoPqrs.Sugerencia,
                    AtencionViajeroPrioridad = AtencionViajeroPrioridad.Pendiente,
                    IdUsuario = "39e10980-4df3-494a-bbe7-410e105f6551"
                }
            );


            // Registros de Adjunto.
            modelBuilder.Entity<Adjunto>().HasData(
                new Adjunto
                {
                    IdAdjunto = 1,
                    RutaAdjunto = "https://DViaje.com/adjuntos/queja_tourrtt.jpg",
                    IdAtencion = 1,
                },
                new Adjunto
                {
                    IdAdjunto = 2,
                    RutaAdjunto = "https://DViaje.com/adjuntos/queja_tour.jpg",
                    IdAtencion = 2,
                },
                new Adjunto
                {
                    IdAdjunto = 3,
                    RutaAdjunto = "https://DViaje.com/adjuntos/confirmacion_pago.pdf",
                    IdAtencion = 3,
                },
                new Adjunto
                {
                    IdAdjunto = 4,
                    RutaAdjunto = "https://DViaje.com/adjuntos/itinerario_tour.pdf",
                    IdAtencion = 3,
                },
                new Adjunto
                {
                    IdAdjunto = 5,
                    RutaAdjunto = "https://DViaje.com/adjuntos/felicitacion_tour.jpg",
                    IdAtencion = 4,
                },
                new Adjunto
                {
                    IdAdjunto = 6,
                    RutaAdjunto = "https://DViaje.com/adjuntos/reembolso_traslado.pdf",
                    IdAtencion = 4,
                },
                new Adjunto
                {
                    IdAdjunto = 7,
                    RutaAdjunto = "https://DViaje.com/adjuntos/informacion_tour.pdf",
                    IdAtencion = 9,
                },
                new Adjunto
                {
                    IdAdjunto = 8,
                    RutaAdjunto = "https://DViaje.com/adjuntos/sugerencia_app.jpg",
                    IdAtencion = 6,
                },
                new Adjunto
                {
                    IdAdjunto = 9,
                    RutaAdjunto = "https://DViaje.com/adjuntos/comprobante_reserva.jpg",
                    IdAtencion = 7,
                },
                new Adjunto
                {
                    IdAdjunto = 10,
                    RutaAdjunto = "https://DViaje.com/adjuntos/agradecimiento_tour.jpg",
                    IdAtencion = 1,
                },
                new Adjunto
                {
                    IdAdjunto = 11,
                    RutaAdjunto = "https://DViaje.com/adjuntos/problema_pago.jpg",
                    IdAtencion = 8,
                },
                new Adjunto
                {
                    IdAdjunto = 12,
                    RutaAdjunto = "https://DViaje.com/adjuntos/comprobantesde_reserva.jpg",
                    IdAtencion = 3,
                },
                new Adjunto
                {
                    IdAdjunto = 13,
                    RutaAdjunto = "https://DViaje.com/adjuntos/agradecimientosss_tour.jpg",
                    IdAtencion = 3,
                },
                new Adjunto
                {
                    IdAdjunto = 14,
                    RutaAdjunto = "https://DViaje.com/adjuntos/problemaconid_pago.jpg",
                    IdAtencion = 9,
                }
            );


            // Registros de Verificado.
            modelBuilder.Entity<Verificado>().HasData(
                new Verificado
                {
                    IdVerificado = 1,
                    FechaSolicitud = new DateTime(2024, 07, 08, 08, 20, 00),
                    FechaRespuesta = new DateTime(2024, 07, 15, 10, 10, 54),
                    VerificadoEstado = VerificadoEstado.Aprobado,
                    IdAliado = "01bfd429-16ea-44b3-902c-794e2c78dfa7"
                },
                new Verificado
                {
                    IdVerificado = 2,
                    FechaSolicitud = new DateTime(2024, 07, 10, 09, 00, 00),
                    FechaRespuesta = new DateTime(2024, 07, 18, 11, 30, 00),
                    VerificadoEstado = VerificadoEstado.Aprobado,
                    IdAliado = "9cd842af-b711-44cc-aa5e-3863e3c30b76"
                },
                new Verificado
                {
                    IdVerificado = 3,
                    FechaSolicitud = new DateTime(2024, 07, 12, 14, 45, 00),
                    FechaRespuesta = new DateTime(2024, 07, 20, 16, 25, 00),
                    VerificadoEstado = VerificadoEstado.Aprobado,
                    IdAliado = "c654adef-5f0c-48e6-946a-52706f8ac520"
                },
                new Verificado
                {
                    IdVerificado = 4,
                    FechaSolicitud = new DateTime(2024, 07, 15, 10, 30, 00),
                    FechaRespuesta = new DateTime(2024, 07, 22, 12, 00, 00),
                    VerificadoEstado = VerificadoEstado.Aprobado,
                    IdAliado = "8142c33b-ee02-4a13-b0c1-1e941387433d"
                },
                new Verificado
                {
                    IdVerificado = 5,
                    FechaSolicitud = new DateTime(2024, 07, 18, 11, 00, 00),
                    FechaRespuesta = new DateTime(2024, 07, 25, 14, 15, 00),
                    VerificadoEstado = VerificadoEstado.Aprobado,
                    IdAliado = "39e10980-4df3-494a-bbe7-410e105f6551"
                },
                new Verificado
                {
                    IdVerificado = 6,
                    FechaSolicitud = new DateTime(2024, 07, 20, 09, 15, 00),
                    FechaRespuesta = new DateTime(2024, 07, 27, 10, 30, 00),
                    VerificadoEstado = VerificadoEstado.Aprobado,
                    IdAliado = "c3733288-b354-445d-95da-4c655c3220b3"
                },
                new Verificado
                {
                    IdVerificado = 7,
                    FechaSolicitud = new DateTime(2024, 07, 22, 13, 20, 00),
                    FechaRespuesta = new DateTime(2024, 07, 29, 15, 45, 00),
                    VerificadoEstado = VerificadoEstado.Rechazado,
                    IdAliado = "4c03648f-7727-4e5c-b096-fcbe3b9e3059"
                },
                new Verificado
                {
                    IdVerificado = 8,
                    FechaSolicitud = new DateTime(2024, 07, 25, 08, 00, 00),
                    FechaRespuesta = new DateTime(2024, 08, 01, 09, 30, 00),
                    VerificadoEstado = VerificadoEstado.Rechazado,
                    IdAliado = "6e291ab8-a9b5-4a7a-afbc-bbbd71b6291b"
                },
                new Verificado
                {
                    IdVerificado = 9,
                    FechaSolicitud = new DateTime(2024, 07, 28, 10, 45, 00),
                    FechaRespuesta = new DateTime(2024, 08, 04, 12, 00, 00),
                    VerificadoEstado = VerificadoEstado.Rechazado,
                    IdAliado = "96067e6f-c29b-46ab-9ba1-18ec7b6534f4"
                },
                new Verificado
                {
                    IdVerificado = 10,
                    FechaSolicitud = new DateTime(2024, 07, 30, 11, 30, 00),
                    FechaRespuesta = new DateTime(2024, 08, 06, 14, 15, 00),
                    VerificadoEstado = VerificadoEstado.Rechazado,
                    IdAliado = "5cf9f86f-36db-4d17-8ec3-cad66cd7f10f"
                },
                new Verificado
                {
                    IdVerificado = 11,
                    FechaSolicitud = new DateTime(2024, 08, 03, 09, 00, 00),
                    FechaRespuesta = null,
                    VerificadoEstado = VerificadoEstado.Pendiente,
                    IdAliado = "96067e6f-c29b-46ab-9ba1-18ec7b6534f4"
                },
                new Verificado
                {
                    IdVerificado = 12,
                    FechaSolicitud = new DateTime(2024, 08, 03, 09, 00, 00),
                    FechaRespuesta = null,
                    VerificadoEstado = VerificadoEstado.Pendiente,
                    IdAliado = "5cf9f86f-36db-4d17-8ec3-cad66cd7f10f"
                }
            );


            // Registros de Publicacion.
            modelBuilder.Entity<Publicacion>().HasData(
                new Publicacion
                {
                    IdPublicacion = 1,
                    Titulo = "Casa Quincha Glamping",
                    Puntuacion = 4.3m,
                    NumeroResenas = 150,
                    Descripcion = "Descubre la magia de la naturaleza sin renunciar a las comodidades del hogar en Casa Quincha Glamping. Ubicada en un entorno sereno y pintoresco, nuestra experiencia de glamping combina el lujo y la aventura, ofreciendo una estancia inolvidable para quienes buscan relajarse y reconectar con el entorno natural.",
                    Precio = 813000m,
                    Fecha = new DateTime(2024, 08, 01, 14, 15, 00),
                    Direccion = "Km 5 Via San Francisco - Supatá, San Francisco 253601 Colombia",
                    IdAliado = "01bfd429-16ea-44b3-902c-794e2c78dfa7"
                },
                new Publicacion
                {
                    IdPublicacion = 2,
                    Titulo = "Eco Lodge del Valle",
                    Puntuacion = 4.7m,
                    NumeroResenas = 98,
                    Descripcion = "Sumérgete en la tranquilidad de la naturaleza en Eco Lodge del Valle. Ofrecemos cabañas ecológicas con vistas impresionantes, actividades al aire libre y un enfoque en la sostenibilidad. Perfecto para quienes buscan un escape relajante y responsable.",
                    Precio = 925000m,
                    Fecha = new DateTime(2024, 08, 02, 10, 00, 00),
                    Direccion = "Vereda El Dorado, Valle de Cauca, Colombia",
                    IdAliado = "01bfd429-16ea-44b3-902c-794e2c78dfa7"
                },
                new Publicacion
                {
                    IdPublicacion = 3,
                    Titulo = "Refugio del Bosque",
                    Puntuacion = 4.2m,
                    NumeroResenas = 76,
                    Descripcion = "Refugio del Bosque ofrece una experiencia única en medio de un bosque encantado. Disfruta de nuestras cabañas acogedoras, senderos para caminatas y actividades al aire libre. Ideal para familias y aventureros.",
                    Precio = 675000m,
                    Fecha = new DateTime(2024, 08, 03, 12, 30, 00),
                    Direccion = "Km 10 Via Manizales - Chinchina, Manizales, Colombia",
                    IdAliado = "01bfd429-16ea-44b3-902c-794e2c78dfa7"
                },
                new Publicacion
                {
                    IdPublicacion = 4,
                    Titulo = "Oasis de la Sierra",
                    Puntuacion = 4.6m,
                    NumeroResenas = 120,
                    Descripcion = "Descubre el lujo y la serenidad en Oasis de la Sierra. Nuestra propiedad ofrece vistas espectaculares, instalaciones de primera clase y actividades exclusivas en un entorno montañoso inigualable.",
                    Precio = 1150000m,
                    Fecha = new DateTime(2024, 08, 04, 14, 45, 00),
                    Direccion = "Avenida de los Andes, Cúcuta, Colombia",
                    IdAliado = "c654adef-5f0c-48e6-946a-52706f8ac520"
                },
                new Publicacion
                {
                    IdPublicacion = 5,
                    Titulo = "Villas del Mar",
                    Puntuacion = 4.8m,
                    NumeroResenas = 134,
                    Descripcion = "Villas del Mar ofrece una experiencia de lujo frente al mar con villas privadas, piscina infinita y servicios personalizados. Ideal para escapadas románticas o celebraciones especiales.",
                    Precio = 1500000m,
                    Fecha = new DateTime(2024, 08, 05, 16, 00, 00),
                    Direccion = "Playa de San Andrés, San Andrés, Colombia",
                    IdAliado = "c654adef-5f0c-48e6-946a-52706f8ac520"
                },
                new Publicacion
                {
                    IdPublicacion = 6,
                    Titulo = "Cabañas del Río",
                    Puntuacion = 4.4m,
                    NumeroResenas = 85,
                    Descripcion = "Disfruta de una estancia relajante en Cabañas del Río, rodeado de la belleza natural de la región. Ofrecemos cabañas rústicas con acceso directo al río y actividades de pesca y senderismo.",
                    Precio = 720000m,
                    Fecha = new DateTime(2024, 08, 06, 09, 15, 00),
                    Direccion = "Vereda El Río, Medellín, Colombia",
                    IdAliado = "8142c33b-ee02-4a13-b0c1-1e941387433d"
                },
                new Publicacion
                {
                    IdPublicacion = 7,
                    Titulo = "Rincón del Viento",
                    Puntuacion = 4.1m,
                    NumeroResenas = 63,
                    Descripcion = "Rincón del Viento ofrece una experiencia de glamping en medio de la naturaleza con tiendas de lujo, fogatas y una vista impresionante de las montañas. Perfecto para una escapada romántica o una aventura familiar.",
                    Precio = 860000m,
                    Fecha = new DateTime(2024, 08, 07, 11, 30, 00),
                    Direccion = "Km 20 Via Villa de Leyva, Boyacá, Colombia",
                    IdAliado = "39e10980-4df3-494a-bbe7-410e105f6551"
                },
                new Publicacion
                {
                    IdPublicacion = 8,
                    Titulo = "Hotel del Lago",
                    Puntuacion = 4.5m,
                    NumeroResenas = 142,
                    Descripcion = "Hotel del Lago ofrece una estancia lujosa con vistas al lago, spa, y restaurante gourmet. Ideal para una experiencia de relax y confort con servicios de alta calidad.",
                    Precio = 1050000m,
                    Fecha = new DateTime(2024, 08, 08, 13, 00, 00),
                    Direccion = "Río Guatapé, Antioquia, Colombia",
                    IdAliado = "39e10980-4df3-494a-bbe7-410e105f6551"
                },
                new Publicacion
                {
                    IdPublicacion = 9,
                    Titulo = "Centro de Bienestar Natural",
                    Puntuacion = 1.0m,
                    NumeroResenas = 167,
                    Descripcion = "Vive una experiencia de bienestar total en nuestro centro de bienestar natural. Ofrecemos retiros de meditación, yoga, y spa en un entorno tranquilo y rejuvenecedor.",
                    Precio = 1300000m,
                    Fecha = new DateTime(2024, 08, 09, 10, 15, 00),
                    Direccion = "Vereda La Primavera, Bogotá, Colombia",
                    IdAliado = "c3733288-b354-445d-95da-4c655c3220b3"
                },
                new Publicacion
                {
                    IdPublicacion = 10,
                    Titulo = "Aventura en la Selva",
                    Puntuacion = 1.3m,
                    NumeroResenas = 110,
                    Descripcion = "Aventura en la Selva ofrece una experiencia única de ecoturismo con cabañas en la selva, guías especializados y actividades de exploración en la biodiversidad local.",
                    Precio = 930000m,
                    Fecha = new DateTime(2024, 08, 10, 15, 00, 00),
                    Direccion = "Reserva Natural del Amazonas, Leticia, Colombia",
                    IdAliado = "4c03648f-7727-4e5c-b096-fcbe3b9e3059"
                },
                new Publicacion
                {
                    IdPublicacion = 11,
                    Titulo = "Casas del Valle",
                    Puntuacion = 2.4m,
                    NumeroResenas = 95,
                    Descripcion = "Casas del Valle ofrece una estancia encantadora en casas de campo tradicionales con acceso a actividades al aire libre, incluyendo paseos a caballo y rutas de senderismo.",
                    Precio = 785000m,
                    Fecha = new DateTime(2024, 08, 11, 12, 45, 00),
                    Direccion = "Vereda El Valle, Tunja, Colombia",
                    IdAliado = "6e291ab8-a9b5-4a7a-afbc-bbbd71b6291b"
                },
                new Publicacion
                {
                    IdPublicacion = 12,
                    Titulo = "Camping de Montaña",
                    Puntuacion = 3.0m,
                    NumeroResenas = 80,
                    Descripcion = "Camping de Montaña ofrece una experiencia auténtica de campamento con acceso a rutas de senderismo y vistas panorámicas de las montañas. Perfecto para los amantes de la naturaleza y la aventura.",
                    Precio = 590000m,
                    Fecha = new DateTime(2024, 08, 12, 08, 30, 00),
                    Direccion = "Parque Nacional de los Nevados, Manizales, Colombia",
                    IdAliado = "96067e6f-c29b-46ab-9ba1-18ec7b6534f4"
                }
            );


            // Registros de PublicacionFavorita.
            modelBuilder.Entity<PublicacionFavorita>().HasData(
                new PublicacionFavorita { IdPublicacionFavorita = 1, IdPublicacion = 1 },
                new PublicacionFavorita { IdPublicacionFavorita = 2, IdPublicacion = 2 },
                new PublicacionFavorita { IdPublicacionFavorita = 3, IdPublicacion = 3 },
                new PublicacionFavorita { IdPublicacionFavorita = 4, IdPublicacion = 4 },
                new PublicacionFavorita { IdPublicacionFavorita = 5, IdPublicacion = 5 }
            );


            // Registros de PublicacionImagen.
            modelBuilder.Entity<PublicacionImagen>().HasData(
                new PublicacionImagen
                {
                    IdPublicacionImagen = 1,
                    Ruta = "https://images.unsplash.com/photo-1707343848552-893e05dba6ac?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 1
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 2,
                    Ruta = "https://images.unsplash.com/photo-1500835556837-99ac94a94552?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 1
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 3,
                    Ruta = "https://images.unsplash.com/photo-1469854523086-cc02fe5d8800?q=80&w=1421&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 1
                },

                new PublicacionImagen
                {
                    IdPublicacionImagen = 4,
                    Ruta = "https://unsplash.com/es/fotos/avion-en-el-cielo-durante-la-hora-dorada-M0AWNxnLaMw",
                    IdPublicacion = 1
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 5,
                    Ruta = "https://images.unsplash.com/photo-1504598318550-17eba1008a68?q=80&w=1372&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 1
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 6,
                    Ruta = "https://images.unsplash.com/photo-1476514525535-07fb3b4ae5f1?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 2
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 7,
                    Ruta = "https://images.unsplash.com/photo-1473163928189-364b2c4e1135?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 2
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 8,
                    Ruta = "https://images.unsplash.com/photo-1483683804023-6ccdb62f86ef?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 2
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 9,
                    Ruta = "https://images.unsplash.com/photo-1512100356356-de1b84283e18?q=80&w=1375&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 3
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 10,
                    Ruta = "https://images.unsplash.com/photo-1533104816931-20fa691ff6ca?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 3
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 11,
                    Ruta = "https://images.unsplash.com/photo-1494783367193-149034c05e8f?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 3
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 12,
                    Ruta = "https://images.unsplash.com/photo-1533105079780-92b9be482077?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 3
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 13,
                    Ruta = "https://images.unsplash.com/photo-1719937206491-ed673f64be1f?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 3
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 14,
                    Ruta = "https://images.unsplash.com/photo-1499063078284-f78f7d89616a?q=80&w=1528&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 3
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 15,
                    Ruta = "https://images.unsplash.com/photo-1522199710521-72d69614c702?q=80&w=1472&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 3
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 16,
                    Ruta = "https://images.unsplash.com/photo-1500530855697-b586d89ba3ee?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 4
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 17,
                    Ruta = "https://images.unsplash.com/photo-1512757776214-26d36777b513?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 4
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 18,
                    Ruta = "https://images.unsplash.com/photo-1496950866446-3253e1470e8e?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 4
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 19,
                    Ruta = "https://images.unsplash.com/photo-1476900543704-4312b78632f8?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 4
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 20,
                    Ruta = "https://images.unsplash.com/photo-1707344088547-3cf7cea5ca49?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 4
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 21,
                    Ruta = "https://images.unsplash.com/photo-1530841377377-3ff06c0ca713?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 5
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 22,
                    Ruta = "https://images.unsplash.com/photo-1506929562872-bb421503ef21?q=80&w=1368&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 5
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 23,
                    Ruta = "https://images.unsplash.com/photo-1568849676085-51415703900f?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 6
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 24,
                    Ruta = "https://images.unsplash.com/photo-1467269204594-9661b134dd2b?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 6
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 25,
                    Ruta = "https://images.unsplash.com/photo-1516483638261-f4dbaf036963?q=80&w=1372&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 6
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 26,
                    Ruta = "https://images.unsplash.com/photo-1504150558240-0b4fd8946624?q=80&w=1528&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 6
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 27,
                    Ruta = "https://images.unsplash.com/photo-1527631746610-bca00a040d60?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 6
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 28,
                    Ruta = "https://images.unsplash.com/photo-1446160657592-4782fb76fb99?q=80&w=1469&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 6
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 29,
                    Ruta = "https://images.unsplash.com/photo-1500301111609-42f1aa6df72a?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 6
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 30,
                    Ruta = "https://images.unsplash.com/photo-1500815845799-7748ca339f27?q=80&w=1527&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 6
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 31,
                    Ruta = "https://images.unsplash.com/photo-1507525428034-b723cf961d3e?q=80&w=1473&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 8
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 32,
                    Ruta = "https://images.unsplash.com/photo-1526784725085-c69e947bf92e?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 8
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 33,
                    Ruta = "https://images.unsplash.com/photo-1471623320832-752e8bbf8413?q=80&w=1410&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 8
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 34,
                    Ruta = "https://images.unsplash.com/photo-1528164344705-47542687000d?q=80&w=1492&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 8
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 35,
                    Ruta = "https://images.unsplash.com/photo-1491800943052-1059ce1e1012?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 8
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 36,
                    Ruta = "https://images.unsplash.com/photo-1551918120-9739cb430c6d?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 8
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 37,
                    Ruta = "https://images.unsplash.com/photo-1548625149-720134d51a3a?q=80&w=1528&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 9
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 38,
                    Ruta = "https://images.unsplash.com/photo-1492693429561-1c283eb1b2e8?q=80&w=1480&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 9
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 39,
                    Ruta = "https://images.unsplash.com/photo-1532347922424-c652d9b7208e?q=80&w=1372&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 9
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 40,
                    Ruta = "https://images.unsplash.com/photo-1567069160354-f25b26e62fa1?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 9
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 41,
                    Ruta = "https://images.unsplash.com/photo-1705588217460-d548807940ad?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 9
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 42,
                    Ruta = "https://images.unsplash.com/photo-1558352541-95f7ac02fff2?q=80&w=1632&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 10
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 43,
                    Ruta = "https://images.unsplash.com/photo-1558461670-abf3421e18b6?q=80&w=1632&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 10
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 44,
                    Ruta = "https://images.unsplash.com/photo-1480497209098-7b9e9555bcee?q=80&w=1376&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 10
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 45,
                    Ruta = "https://images.unsplash.com/photo-1502489597346-dad15683d4c2?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 10
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 46,
                    Ruta = "https://images.unsplash.com/photo-1679420438051-19bd5aad4d67?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 10
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 47,
                    Ruta = "https://images.unsplash.com/photo-1692308516530-5ffc490476a8?q=80&w=1528&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 10
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 48,
                    Ruta = "https://images.unsplash.com/photo-1704803269187-d6eb334ea5fe?q=80&w=1472&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 10
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 49,
                    Ruta = "https://images.unsplash.com/photo-1643234804946-7ae71ca3aea3?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 7
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 50,
                    Ruta = "https://images.unsplash.com/photo-1688321998704-e5bba733728c?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 7
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 51,
                    Ruta = "https://images.unsplash.com/photo-1622343782402-94ea774c4f61?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 7
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 52,
                    Ruta = "https://images.unsplash.com/photo-1707073687377-fbda787a7db9?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 7
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 53,
                    Ruta = "https://images.unsplash.com/photo-1646672571916-453b48d71710?q=80&w=1978&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 7
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 54,
                    Ruta = "https://images.unsplash.com/photo-1649807944854-a7b57dd6afb5?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 7
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 55,
                    Ruta = "https://images.unsplash.com/photo-1577741553317-7f231343599a?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 7
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 56,
                    Ruta = "https://images.unsplash.com/photo-1573435708546-32beaff245c1?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 11
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 57,
                    Ruta = "https://images.unsplash.com/photo-1708187181457-8bafec80833a?q=80&w=2077&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 11
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 58,
                    Ruta = "https://images.unsplash.com/photo-1683384546413-d207b5677dc0?q=80&w=2076&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 11
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 59,
                    Ruta = "https://images.unsplash.com/photo-1610228328499-53c36a14dbc1?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 11
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 60,
                    Ruta = "https://images.unsplash.com/photo-1656371559747-1ca93a271206?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 11
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 61,
                    Ruta = "https://images.unsplash.com/photo-1635222722123-fd2b74b6bc9d?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 11
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 62,
                    Ruta = "https://images.unsplash.com/photo-1707073687052-0edc1463d1f8?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 12
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 63,
                    Ruta = "https://images.unsplash.com/photo-1705373069474-e01b8b18b6f6?q=80&w=2073&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 12
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 64,
                    Ruta = "https://images.unsplash.com/photo-1688254708497-732d5a8d923b?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 12
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 65,
                    Ruta = "https://images.unsplash.com/photo-1663948017079-2906ed90a5d6?q=80&w=1936&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 12
                },
                new PublicacionImagen
                {
                    IdPublicacionImagen = 66,
                    Ruta = "https://images.unsplash.com/photo-1573435708534-6b6dbc589bfc?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdPublicacion = 12
                }
            );


            // Registros de FechaNoDisponible.
            modelBuilder.Entity<FechaNoDisponible>().HasData(
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 1,
                    FechaInicial = new DateTime(2024, 07, 20, 15, 45, 00),
                    FechaFinal = new DateTime(2024, 07, 30, 15, 45, 00),
                    IdPublicacion = 1
                },
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 2,
                    FechaInicial = new DateTime(2024, 08, 01, 12, 00, 00),
                    FechaFinal = new DateTime(2024, 08, 07, 12, 00, 00),
                    IdPublicacion = 2
                },
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 3,
                    FechaInicial = new DateTime(2024, 08, 10, 09, 00, 00),
                    FechaFinal = new DateTime(2024, 08, 15, 18, 00, 00),
                    IdPublicacion = 3
                },
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 4,
                    FechaInicial = new DateTime(2024, 08, 12, 10, 00, 00),
                    FechaFinal = new DateTime(2024, 08, 18, 14, 00, 00),
                    IdPublicacion = 4
                },
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 5,
                    FechaInicial = new DateTime(2024, 08, 20, 16, 00, 00),
                    FechaFinal = new DateTime(2024, 08, 25, 11, 00, 00),
                    IdPublicacion = 5
                },
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 6,
                    FechaInicial = new DateTime(2024, 08, 22, 08, 30, 00),
                    FechaFinal = new DateTime(2024, 08, 29, 09, 30, 00),
                    IdPublicacion = 6
                },
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 7,
                    FechaInicial = new DateTime(2024, 08, 25, 15, 00, 00),
                    FechaFinal = new DateTime(2024, 09, 02, 10, 00, 00),
                    IdPublicacion = 7
                },
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 8,
                    FechaInicial = new DateTime(2024, 09, 01, 11, 00, 00),
                    FechaFinal = new DateTime(2024, 09, 10, 11, 00, 00),
                    IdPublicacion = 8
                },
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 9,
                    FechaInicial = new DateTime(2024, 09, 05, 14, 00, 00),
                    FechaFinal = new DateTime(2024, 09, 12, 17, 00, 00),
                    IdPublicacion = 9
                },
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 10,
                    FechaInicial = new DateTime(2024, 09, 10, 09, 00, 00),
                    FechaFinal = new DateTime(2024, 09, 15, 12, 00, 00),
                    IdPublicacion = 10
                },
                new FechaNoDisponible
                {
                    IdFechaNoDisponible = 11,
                    FechaInicial = new DateTime(2024, 11, 12, 13, 00, 00),
                    FechaFinal = new DateTime(2024, 11, 20, 14, 00, 00),
                    IdPublicacion = 1
                }
            );


            // Registros de Reserva.
            modelBuilder.Entity<Reserva>().HasData(
                new Reserva
                {
                    IdReserva = 1,
                    FechaInicial = new DateTime(2024, 09, 20, 15, 45, 00),
                    FechaFinal = new DateTime(2024, 09, 24, 15, 45, 00),
                    ReservaEstado = ReservaEstado.Aprobado,
                    NumeroPersonas = 3,
                    IdUsuario = "11bc73ce-dbe2-4370-bc92-0d57e5b366d7",
                    IdPublicacion = 1
                },
                new Reserva
                {
                    IdReserva = 2,
                    FechaInicial = new DateTime(2024, 09, 25, 10, 00, 00),
                    FechaFinal = new DateTime(2024, 09, 30, 11, 00, 00),
                    ReservaEstado = ReservaEstado.Activo,
                    NumeroPersonas = 2,
                    IdUsuario = "26cfe5c9-00f8-411e-b589-df3405a8b798",
                    IdPublicacion = 1
                },
                new Reserva
                {
                    IdReserva = 3,
                    FechaInicial = new DateTime(2024, 10, 01, 14, 00, 00),
                    FechaFinal = new DateTime(2024, 10, 07, 12, 00, 00),
                    ReservaEstado = ReservaEstado.Cancelado,
                    NumeroPersonas = 4,
                    IdUsuario = "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1",
                    IdPublicacion = 1
                },
                new Reserva
                {
                    IdReserva = 4,
                    FechaInicial = new DateTime(2024, 10, 10, 16, 00, 00),
                    FechaFinal = new DateTime(2024, 10, 15, 10, 00, 00),
                    ReservaEstado = ReservaEstado.Aprobado,
                    NumeroPersonas = 5,
                    IdUsuario = "e4309639-4588-4553-8c14-5ce4426e0dd7",
                    IdPublicacion = 1
                },
                new Reserva
                {
                    IdReserva = 5,
                    FechaInicial = new DateTime(2024, 10, 12, 11, 00, 00),
                    FechaFinal = new DateTime(2024, 10, 18, 14, 00, 00),
                    ReservaEstado = ReservaEstado.Activo,
                    NumeroPersonas = 2,
                    IdUsuario = "11bc73ce-dbe2-4370-bc92-0d57e5b366d7",
                    IdPublicacion = 2
                },
                new Reserva
                {
                    IdReserva = 6,
                    FechaInicial = new DateTime(2024, 10, 15, 09, 00, 00),
                    FechaFinal = new DateTime(2024, 10, 20, 12, 00, 00),
                    ReservaEstado = ReservaEstado.Cancelado,
                    NumeroPersonas = 4,
                    IdUsuario = "1c8e89f7-7db6-4cd5-907d-f01b058cd784",
                    IdPublicacion = 2
                },
                new Reserva
                {
                    IdReserva = 7,
                    FechaInicial = new DateTime(2024, 10, 18, 08, 30, 00),
                    FechaFinal = new DateTime(2024, 10, 22, 15, 00, 00),
                    ReservaEstado = ReservaEstado.Aprobado,
                    NumeroPersonas = 3,
                    IdUsuario = "13825fa6-5c27-4303-ab17-6e13aac24c12",
                    IdPublicacion = 2
                },
                new Reserva
                {
                    IdReserva = 8,
                    FechaInicial = new DateTime(2024, 10, 20, 10, 00, 00),
                    FechaFinal = new DateTime(2024, 10, 25, 16, 00, 00),
                    ReservaEstado = ReservaEstado.Activo,
                    NumeroPersonas = 6,
                    IdUsuario = "230d9aeb-6bca-4faa-b867-2d49e1a8c12e",
                    IdPublicacion = 2
                },
                new Reserva
                {
                    IdReserva = 9,
                    FechaInicial = new DateTime(2024, 10, 22, 14, 00, 00),
                    FechaFinal = new DateTime(2024, 10, 28, 11, 00, 00),
                    ReservaEstado = ReservaEstado.Aprobado,
                    NumeroPersonas = 2,
                    IdUsuario = "3a895383-b546-4693-8246-924a9fc5289f",
                    IdPublicacion = 3
                },
                new Reserva
                {
                    IdReserva = 10,
                    FechaInicial = new DateTime(2024, 10, 25, 12, 00, 00),
                    FechaFinal = new DateTime(2024, 10, 30, 13, 00, 00),
                    ReservaEstado = ReservaEstado.Cancelado,
                    NumeroPersonas = 5,
                    IdUsuario = "11bc73ce-dbe2-4370-bc92-0d57e5b366d7",
                    IdPublicacion = 3
                },
                new Reserva
                {
                    IdReserva = 11,
                    FechaInicial = new DateTime(2024, 10, 28, 09, 00, 00),
                    FechaFinal = new DateTime(2024, 11, 02, 10, 00, 00),
                    ReservaEstado = ReservaEstado.Aprobado,
                    NumeroPersonas = 4,
                    IdUsuario = "26cfe5c9-00f8-411e-b589-df3405a8b798",
                    IdPublicacion = 4
                },
                new Reserva
                {
                    IdReserva = 12,
                    FechaInicial = new DateTime(2024, 10, 30, 11, 00, 00),
                    FechaFinal = new DateTime(2024, 11, 05, 12, 00, 00),
                    ReservaEstado = ReservaEstado.Activo,
                    NumeroPersonas = 3,
                    IdUsuario = "e4309639-4588-4553-8c14-5ce4426e0dd7",
                    IdPublicacion = 5
                },
                new Reserva
                {
                    IdReserva = 13,
                    FechaInicial = new DateTime(2024, 11, 01, 15, 00, 00),
                    FechaFinal = new DateTime(2024, 11, 08, 11, 00, 00),
                    ReservaEstado = ReservaEstado.Aprobado,
                    NumeroPersonas = 2,
                    IdUsuario = "13825fa6-5c27-4303-ab17-6e13aac24c12",
                    IdPublicacion = 6
                },
                new Reserva
                {
                    IdReserva = 14,
                    FechaInicial = new DateTime(2024, 11, 05, 10, 00, 00),
                    FechaFinal = new DateTime(2024, 11, 12, 16, 00, 00),
                    ReservaEstado = ReservaEstado.Cancelado,
                    NumeroPersonas = 6,
                    IdUsuario = "230d9aeb-6bca-4faa-b867-2d49e1a8c12e",
                    IdPublicacion = 6
                },
                new Reserva
                {
                    IdReserva = 15,
                    FechaInicial = new DateTime(2024, 11, 10, 14, 00, 00),
                    FechaFinal = new DateTime(2024, 11, 15, 13, 00, 00),
                    ReservaEstado = ReservaEstado.Aprobado,
                    NumeroPersonas = 5,
                    IdUsuario = "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1",
                    IdPublicacion = 9
                }
            );


            // Registros de Resena.
            modelBuilder.Entity<Resena>().HasData(
                new Resena
                {
                    IdResena = 1,
                    Opinion = "Muy tranquilo, privado y atención personalizada, muy atentos a nuestras necesidades y solicitudes, la llegada fácil a borde de la carretera lo cual es una ventaja para carros bajitos, la comida deliciosa y un personal atento, amable y respetuoso.",
                    Fecha = new DateTime(2024, 11, 05, 10, 00, 00),
                    Calificacion = 4,
                    MeGusta = 3,
                    IdReserva = 1
                },
                new Resena
                {
                    IdResena = 2,
                    Opinion = "La estancia fue excelente, el lugar es hermoso y muy bien cuidado. La atención del personal fue impecable y siempre estuvieron disponibles para cualquier solicitud. La ubicación es perfecta para quienes buscan paz y tranquilidad.",
                    Fecha = new DateTime(2024, 11, 07, 14, 30, 00),
                    Calificacion = 5,
                    MeGusta = 8,
                    IdReserva = 4
                },
                new Resena
                {
                    IdResena = 3,
                    Opinion = "El alojamiento es bastante bueno, aunque el servicio podría mejorar en términos de tiempo de respuesta. La limpieza estaba bien, pero la comida no cumplió completamente con nuestras expectativas.",
                    Fecha = new DateTime(2024, 11, 10, 16, 15, 00),
                    Calificacion = 3,
                    MeGusta = 2,
                    IdReserva = 7
                },
                new Resena
                {
                    IdResena = 4,
                    Opinion = "Un lugar acogedor con un ambiente muy relajante. El personal es amable y la comida es deliciosa. Sin embargo, hubo algunos problemas con la conexión a internet durante nuestra estancia.",
                    Fecha = new DateTime(2024, 11, 12, 09, 45, 00),
                    Calificacion = 4,
                    MeGusta = 5,
                    IdReserva = 9
                },
                new Resena
                {
                    IdResena = 5,
                    Opinion = "La experiencia fue muy buena en general. Las instalaciones estaban limpias y bien mantenidas. El check-in fue rápido y sin problemas, pero el precio es un poco alto para lo que ofrecen.",
                    Fecha = new DateTime(2024, 11, 15, 11, 00, 00),
                    Calificacion = 4,
                    MeGusta = 6,
                    IdReserva = 11
                },
                new Resena
                {
                    IdResena = 6,
                    Opinion = "El lugar es encantador y muy cómodo. La atención del personal fue muy buena y hicieron todo lo posible para que nuestra estancia fuera agradable. Recomendado para una escapada de fin de semana.",
                    Fecha = new DateTime(2024, 11, 18, 13, 30, 00),
                    Calificacion = 5,
                    MeGusta = 7,
                    IdReserva = 13
                },
                new Resena
                {
                    IdResena = 7,
                    Opinion = "Buena ubicación, pero la habitación necesitaba una mejor limpieza. La comida estaba bien, pero no había muchas opciones en el menú. El personal fue amable, aunque a veces parecía desorganizado.",
                    Fecha = new DateTime(2024, 11, 20, 15, 00, 00),
                    Calificacion = 3,
                    MeGusta = 3,
                    IdReserva = 15
                }
            );


            // Registros de Servicio.
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


            // Registros de ServicioAdicional.
            modelBuilder.Entity<ServicioAdicional>().HasData(
                new ServicioAdicional { IdServicioAdicional = 1, PrecioServicioAdicional = 50000m, IdServicio = 1, IdPublicacion = 1 },
                new ServicioAdicional { IdServicioAdicional = 3, PrecioServicioAdicional = 60000m, IdServicio = 2, IdPublicacion = 2 },
                new ServicioAdicional { IdServicioAdicional = 4, PrecioServicioAdicional = 70000m, IdServicio = 3, IdPublicacion = 3 },
                new ServicioAdicional { IdServicioAdicional = 5, PrecioServicioAdicional = 80000m, IdServicio = 4, IdPublicacion = 4 },
                new ServicioAdicional { IdServicioAdicional = 6, PrecioServicioAdicional = 90000m, IdServicio = 5, IdPublicacion = 5 },
                new ServicioAdicional { IdServicioAdicional = 7, PrecioServicioAdicional = 100000m, IdServicio = 6, IdPublicacion = 6 },
                new ServicioAdicional { IdServicioAdicional = 8, PrecioServicioAdicional = 110000m, IdServicio = 7, IdPublicacion = 7 },
                new ServicioAdicional { IdServicioAdicional = 9, PrecioServicioAdicional = 120000m, IdServicio = 8, IdPublicacion = 8 },
                new ServicioAdicional { IdServicioAdicional = 10, PrecioServicioAdicional = 130000m, IdServicio = 9, IdPublicacion = 9 }
            );


            // Registros de PublicacionServicio.
            modelBuilder.Entity<PublicacionServicio>().HasData(
                new PublicacionServicio { IdPublicacionServicio = 1, IdPublicacion = 1, IdServicio = 2 },
                new PublicacionServicio { IdPublicacionServicio = 2, IdPublicacion = 1, IdServicio = 3 },
                new PublicacionServicio { IdPublicacionServicio = 3, IdPublicacion = 1, IdServicio = 4 },
                new PublicacionServicio { IdPublicacionServicio = 4, IdPublicacion = 1, IdServicio = 5 },
                new PublicacionServicio { IdPublicacionServicio = 5, IdPublicacion = 1, IdServicio = 8 },
                new PublicacionServicio { IdPublicacionServicio = 6, IdPublicacion = 1, IdServicio = 10 },
                new PublicacionServicio { IdPublicacionServicio = 7, IdPublicacion = 1, IdServicio = 11 },
                new PublicacionServicio { IdPublicacionServicio = 8, IdPublicacion = 2, IdServicio = 12 },
                new PublicacionServicio { IdPublicacionServicio = 9, IdPublicacion = 2, IdServicio = 13 },
                new PublicacionServicio { IdPublicacionServicio = 10, IdPublicacion = 2, IdServicio = 14 },
                new PublicacionServicio { IdPublicacionServicio = 11, IdPublicacion = 2, IdServicio = 15 },
                new PublicacionServicio { IdPublicacionServicio = 12, IdPublicacion = 2, IdServicio = 16 },
                new PublicacionServicio { IdPublicacionServicio = 13, IdPublicacion = 2, IdServicio = 17 },
                new PublicacionServicio { IdPublicacionServicio = 14, IdPublicacion = 2, IdServicio = 18 },
                new PublicacionServicio { IdPublicacionServicio = 15, IdPublicacion = 2, IdServicio = 19 },
                new PublicacionServicio { IdPublicacionServicio = 16, IdPublicacion = 3, IdServicio = 20 },
                new PublicacionServicio { IdPublicacionServicio = 17, IdPublicacion = 3, IdServicio = 21 },
                new PublicacionServicio { IdPublicacionServicio = 18, IdPublicacion = 3, IdServicio = 22 },
                new PublicacionServicio { IdPublicacionServicio = 19, IdPublicacion = 3, IdServicio = 23 },
                new PublicacionServicio { IdPublicacionServicio = 20, IdPublicacion = 3, IdServicio = 24 },
                new PublicacionServicio { IdPublicacionServicio = 21, IdPublicacion = 3, IdServicio = 25 },
                new PublicacionServicio { IdPublicacionServicio = 22, IdPublicacion = 3, IdServicio = 26 },
                new PublicacionServicio { IdPublicacionServicio = 23, IdPublicacion = 3, IdServicio = 27 },
                new PublicacionServicio { IdPublicacionServicio = 24, IdPublicacion = 3, IdServicio = 28 },
                new PublicacionServicio { IdPublicacionServicio = 25, IdPublicacion = 4, IdServicio = 29 },
                new PublicacionServicio { IdPublicacionServicio = 26, IdPublicacion = 4, IdServicio = 30 },
                new PublicacionServicio { IdPublicacionServicio = 27, IdPublicacion = 4, IdServicio = 31 },
                new PublicacionServicio { IdPublicacionServicio = 28, IdPublicacion = 4, IdServicio = 32 },
                new PublicacionServicio { IdPublicacionServicio = 29, IdPublicacion = 4, IdServicio = 33 },
                new PublicacionServicio { IdPublicacionServicio = 30, IdPublicacion = 4, IdServicio = 34 },
                new PublicacionServicio { IdPublicacionServicio = 31, IdPublicacion = 4, IdServicio = 35 },
                new PublicacionServicio { IdPublicacionServicio = 32, IdPublicacion = 4, IdServicio = 1 },
                new PublicacionServicio { IdPublicacionServicio = 33, IdPublicacion = 4, IdServicio = 2 },
                new PublicacionServicio { IdPublicacionServicio = 34, IdPublicacion = 4, IdServicio = 3 },
                new PublicacionServicio { IdPublicacionServicio = 35, IdPublicacion = 4, IdServicio = 5 },
                new PublicacionServicio { IdPublicacionServicio = 36, IdPublicacion = 4, IdServicio = 6 },
                new PublicacionServicio { IdPublicacionServicio = 37, IdPublicacion = 4, IdServicio = 7 },
                new PublicacionServicio { IdPublicacionServicio = 38, IdPublicacion = 5, IdServicio = 8 },
                new PublicacionServicio { IdPublicacionServicio = 39, IdPublicacion = 5, IdServicio = 9 },
                new PublicacionServicio { IdPublicacionServicio = 40, IdPublicacion = 5, IdServicio = 10 },
                new PublicacionServicio { IdPublicacionServicio = 41, IdPublicacion = 5, IdServicio = 11 },
                new PublicacionServicio { IdPublicacionServicio = 42, IdPublicacion = 6, IdServicio = 12 },
                new PublicacionServicio { IdPublicacionServicio = 43, IdPublicacion = 6, IdServicio = 13 },
                new PublicacionServicio { IdPublicacionServicio = 44, IdPublicacion = 6, IdServicio = 14 },
                new PublicacionServicio { IdPublicacionServicio = 45, IdPublicacion = 6, IdServicio = 15 },
                new PublicacionServicio { IdPublicacionServicio = 46, IdPublicacion = 6, IdServicio = 16 },
                new PublicacionServicio { IdPublicacionServicio = 47, IdPublicacion = 6, IdServicio = 17 },
                new PublicacionServicio { IdPublicacionServicio = 48, IdPublicacion = 6, IdServicio = 18 },
                new PublicacionServicio { IdPublicacionServicio = 49, IdPublicacion = 6, IdServicio = 19 },
                new PublicacionServicio { IdPublicacionServicio = 50, IdPublicacion = 6, IdServicio = 20 },
                new PublicacionServicio { IdPublicacionServicio = 51, IdPublicacion = 6, IdServicio = 21 },
                new PublicacionServicio { IdPublicacionServicio = 52, IdPublicacion = 6, IdServicio = 22 },
                new PublicacionServicio { IdPublicacionServicio = 53, IdPublicacion = 7, IdServicio = 23 },
                new PublicacionServicio { IdPublicacionServicio = 54, IdPublicacion = 7, IdServicio = 24 },
                new PublicacionServicio { IdPublicacionServicio = 55, IdPublicacion = 7, IdServicio = 25 },
                new PublicacionServicio { IdPublicacionServicio = 56, IdPublicacion = 7, IdServicio = 26 },
                new PublicacionServicio { IdPublicacionServicio = 57, IdPublicacion = 8, IdServicio = 27 },
                new PublicacionServicio { IdPublicacionServicio = 58, IdPublicacion = 8, IdServicio = 28 },
                new PublicacionServicio { IdPublicacionServicio = 59, IdPublicacion = 8, IdServicio = 29 },
                new PublicacionServicio { IdPublicacionServicio = 60, IdPublicacion = 9, IdServicio = 30 },
                new PublicacionServicio { IdPublicacionServicio = 61, IdPublicacion = 9, IdServicio = 31 },
                new PublicacionServicio { IdPublicacionServicio = 62, IdPublicacion = 9, IdServicio = 32 },
                new PublicacionServicio { IdPublicacionServicio = 63, IdPublicacion = 9, IdServicio = 33 },
                new PublicacionServicio { IdPublicacionServicio = 64, IdPublicacion = 9, IdServicio = 34 },
                new PublicacionServicio { IdPublicacionServicio = 65, IdPublicacion = 9, IdServicio = 35 },
                new PublicacionServicio { IdPublicacionServicio = 66, IdPublicacion = 9, IdServicio = 1 },
                new PublicacionServicio { IdPublicacionServicio = 67, IdPublicacion = 9, IdServicio = 2 },
                new PublicacionServicio { IdPublicacionServicio = 68, IdPublicacion = 9, IdServicio = 3 },
                new PublicacionServicio { IdPublicacionServicio = 69, IdPublicacion = 10, IdServicio = 4 },
                new PublicacionServicio { IdPublicacionServicio = 70, IdPublicacion = 10, IdServicio = 5 },
                new PublicacionServicio { IdPublicacionServicio = 71, IdPublicacion = 10, IdServicio = 6 },
                new PublicacionServicio { IdPublicacionServicio = 72, IdPublicacion = 10, IdServicio = 7 },
                new PublicacionServicio { IdPublicacionServicio = 73, IdPublicacion = 10, IdServicio = 8 },
                new PublicacionServicio { IdPublicacionServicio = 74, IdPublicacion = 10, IdServicio = 9 },
                new PublicacionServicio { IdPublicacionServicio = 75, IdPublicacion = 10, IdServicio = 11 },
                new PublicacionServicio { IdPublicacionServicio = 76, IdPublicacion = 10, IdServicio = 12 },
                new PublicacionServicio { IdPublicacionServicio = 77, IdPublicacion = 10, IdServicio = 13 },
                new PublicacionServicio { IdPublicacionServicio = 78, IdPublicacion = 10, IdServicio = 14 },
                new PublicacionServicio { IdPublicacionServicio = 79, IdPublicacion = 11, IdServicio = 15 },
                new PublicacionServicio { IdPublicacionServicio = 80, IdPublicacion = 11, IdServicio = 16 },
                new PublicacionServicio { IdPublicacionServicio = 81, IdPublicacion = 11, IdServicio = 17 },
                new PublicacionServicio { IdPublicacionServicio = 82, IdPublicacion = 11, IdServicio = 18 },
                new PublicacionServicio { IdPublicacionServicio = 83, IdPublicacion = 11, IdServicio = 19 },
                new PublicacionServicio { IdPublicacionServicio = 84, IdPublicacion = 12, IdServicio = 20 },
                new PublicacionServicio { IdPublicacionServicio = 85, IdPublicacion = 12, IdServicio = 21 },
                new PublicacionServicio { IdPublicacionServicio = 86, IdPublicacion = 12, IdServicio = 22 },
                new PublicacionServicio { IdPublicacionServicio = 87, IdPublicacion = 12, IdServicio = 23 },
                new PublicacionServicio { IdPublicacionServicio = 88, IdPublicacion = 12, IdServicio = 24 },
                new PublicacionServicio { IdPublicacionServicio = 89, IdPublicacion = 12, IdServicio = 25 }
            );


            // Registros de Restriccion.
            modelBuilder.Entity<Restriccion>().HasData(
                new Restriccion { IdRestriccion = 1, NombreRestriccion = "Mascotas", RutaIcono = "" },
                new Restriccion { IdRestriccion = 2, NombreRestriccion = "No Fumar", RutaIcono = "" },
                new Restriccion { IdRestriccion = 3, NombreRestriccion = "Accesibilidad", RutaIcono = "" },
                new Restriccion { IdRestriccion = 4, NombreRestriccion = "Prohibido Ruido", RutaIcono = "" },
                new Restriccion { IdRestriccion = 5, NombreRestriccion = "No Fiestas", RutaIcono = "" },
                new Restriccion { IdRestriccion = 6, NombreRestriccion = "Niños Bienvenidos", RutaIcono = "" },
                new Restriccion { IdRestriccion = 7, NombreRestriccion = "No Comida", RutaIcono = "" },
                new Restriccion { IdRestriccion = 8, NombreRestriccion = "Horario Silencioso", RutaIcono = "" },
                new Restriccion { IdRestriccion = 9, NombreRestriccion = "Uso de Piscina", RutaIcono = "" },
                new Restriccion { IdRestriccion = 10, NombreRestriccion = "Zonas Comunes", RutaIcono = "" },
                new Restriccion { IdRestriccion = 11, NombreRestriccion = "No Alcohol", RutaIcono = "" }
            );


            // Registros de PublicacionRestriccion.
            modelBuilder.Entity<PublicacionRestriccion>().HasData(
                new PublicacionRestriccion { IdPublicacionRestriccion = 1, IdPublicacion = 1, IdRestriccion = 1 },
                new PublicacionRestriccion { IdPublicacionRestriccion = 2, IdPublicacion = 1, IdRestriccion = 2 },
                new PublicacionRestriccion { IdPublicacionRestriccion = 3, IdPublicacion = 2, IdRestriccion = 3 },
                new PublicacionRestriccion { IdPublicacionRestriccion = 4, IdPublicacion = 3, IdRestriccion = 4 },
                new PublicacionRestriccion { IdPublicacionRestriccion = 5, IdPublicacion = 3, IdRestriccion = 5 },
                new PublicacionRestriccion { IdPublicacionRestriccion = 6, IdPublicacion = 5, IdRestriccion = 6 },
                new PublicacionRestriccion { IdPublicacionRestriccion = 7, IdPublicacion = 7, IdRestriccion = 7 },
                new PublicacionRestriccion { IdPublicacionRestriccion = 8, IdPublicacion = 8, IdRestriccion = 8 },
                new PublicacionRestriccion { IdPublicacionRestriccion = 9, IdPublicacion = 8, IdRestriccion = 9 },
                new PublicacionRestriccion { IdPublicacionRestriccion = 10, IdPublicacion = 9, IdRestriccion = 10 },
                new PublicacionRestriccion { IdPublicacionRestriccion = 11, IdPublicacion = 10, IdRestriccion = 11 },
                new PublicacionRestriccion { IdPublicacionRestriccion = 12, IdPublicacion = 11, IdRestriccion = 1 },
                new PublicacionRestriccion { IdPublicacionRestriccion = 13, IdPublicacion = 12, IdRestriccion = 2 }
            );


            // Registros de Categoria.
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { IdCategoria = 1, NombreCategoria = "Finca", RutaIcono = "fa-solid fa-sign-hanging" },
                new Categoria { IdCategoria = 2, NombreCategoria = "Apartamento", RutaIcono = "fa-solid fa-house-user" },
                new Categoria { IdCategoria = 3, NombreCategoria = "Casa", RutaIcono = "fa-solid fa-house" },
                new Categoria { IdCategoria = 4, NombreCategoria = "Cabaña", RutaIcono = "fa-solid fa-house-chimney" },
                new Categoria { IdCategoria = 5, NombreCategoria = "Hotel", RutaIcono = "fa-solid fa-hotel" },
                new Categoria { IdCategoria = 6, NombreCategoria = "Hostal", RutaIcono = "fa-solid fa-hotel" },
                new Categoria { IdCategoria = 7, NombreCategoria = "Villa", RutaIcono = "fa-solid fa-house-chimney-window" },
                new Categoria { IdCategoria = 8, NombreCategoria = "Resort", RutaIcono = "fa-solid fa-hotel" },
                new Categoria { IdCategoria = 9, NombreCategoria = "Piso compartido", RutaIcono = "fa-solid fa-people-roof" },
                new Categoria { IdCategoria = 10, NombreCategoria = "Villa vacacional", RutaIcono = "fa-solid fa-house-chimney-window" },
                new Categoria { IdCategoria = 11, NombreCategoria = "Casa de campo", RutaIcono = "fa-solid fa-house-chimney" },
                new Categoria { IdCategoria = 12, NombreCategoria = "Campamentos", RutaIcono = "fa-solid fa-campground" },
                new Categoria { IdCategoria = 13, NombreCategoria = "Pensión", RutaIcono = "fa-solid fa-house" },
                new Categoria { IdCategoria = 14, NombreCategoria = "Motel", RutaIcono = "fa-solid fa-hotel" },
                new Categoria { IdCategoria = 15, NombreCategoria = "Apartahotel", RutaIcono = "fa-solid fa-hotel" },
                new Categoria { IdCategoria = 16, NombreCategoria = "Casa rural", RutaIcono = "fa-solid fa-house-chimney" },
                new Categoria { IdCategoria = 17, NombreCategoria = "Posada", RutaIcono = "fa-solid fa-house" }
            );


            // Registros de Categoria.
            modelBuilder.Entity<PublicacionCategoria>().HasData(
                new PublicacionCategoria { IdPublicacionCategoria = 1, IdPublicacion = 1, IdCategoria = 1 },
                new PublicacionCategoria { IdPublicacionCategoria = 2, IdPublicacion = 1, IdCategoria = 2 },
                new PublicacionCategoria { IdPublicacionCategoria = 3, IdPublicacion = 1, IdCategoria = 3 },
                new PublicacionCategoria { IdPublicacionCategoria = 4, IdPublicacion = 1, IdCategoria = 4 },
                new PublicacionCategoria { IdPublicacionCategoria = 5, IdPublicacion = 2, IdCategoria = 4 },
                new PublicacionCategoria { IdPublicacionCategoria = 6, IdPublicacion = 2, IdCategoria = 5 },
                new PublicacionCategoria { IdPublicacionCategoria = 7, IdPublicacion = 2, IdCategoria = 6 },
                new PublicacionCategoria { IdPublicacionCategoria = 8, IdPublicacion = 3, IdCategoria = 7 },
                new PublicacionCategoria { IdPublicacionCategoria = 9, IdPublicacion = 4, IdCategoria = 8 },
                new PublicacionCategoria { IdPublicacionCategoria = 10, IdPublicacion = 5, IdCategoria = 9 },
                new PublicacionCategoria { IdPublicacionCategoria = 11, IdPublicacion = 5, IdCategoria = 10 },
                new PublicacionCategoria { IdPublicacionCategoria = 12, IdPublicacion = 5, IdCategoria = 11 },
                new PublicacionCategoria { IdPublicacionCategoria = 13, IdPublicacion = 5, IdCategoria = 12 },
                new PublicacionCategoria { IdPublicacionCategoria = 14, IdPublicacion = 5, IdCategoria = 13 },
                new PublicacionCategoria { IdPublicacionCategoria = 15, IdPublicacion = 5, IdCategoria = 14 },
                new PublicacionCategoria { IdPublicacionCategoria = 16, IdPublicacion = 6, IdCategoria = 15 },
                new PublicacionCategoria { IdPublicacionCategoria = 17, IdPublicacion = 6, IdCategoria = 16 },
                new PublicacionCategoria { IdPublicacionCategoria = 18, IdPublicacion = 7, IdCategoria = 17 },
                new PublicacionCategoria { IdPublicacionCategoria = 19, IdPublicacion = 8, IdCategoria = 1 },
                new PublicacionCategoria { IdPublicacionCategoria = 20, IdPublicacion = 9, IdCategoria = 2 },
                new PublicacionCategoria { IdPublicacionCategoria = 21, IdPublicacion = 9, IdCategoria = 3 },
                new PublicacionCategoria { IdPublicacionCategoria = 22, IdPublicacion = 9, IdCategoria = 4 },
                new PublicacionCategoria { IdPublicacionCategoria = 23, IdPublicacion = 10, IdCategoria = 5 },
                new PublicacionCategoria { IdPublicacionCategoria = 24, IdPublicacion = 10, IdCategoria = 6 },
                new PublicacionCategoria { IdPublicacionCategoria = 25, IdPublicacion = 11, IdCategoria = 7 },
                new PublicacionCategoria { IdPublicacionCategoria = 26, IdPublicacion = 12, IdCategoria = 8 }
            );


            // Registros de Favorito.
            modelBuilder.Entity<Favorito>().HasData(
                new Favorito { IdFavorito = 1, IdUsuario = "11bc73ce-dbe2-4370-bc92-0d57e5b366d7", IdPublicacion = 1 },
                new Favorito { IdFavorito = 2, IdUsuario = "11bc73ce-dbe2-4370-bc92-0d57e5b366d7", IdPublicacion = 2 },
                new Favorito { IdFavorito = 3, IdUsuario = "11bc73ce-dbe2-4370-bc92-0d57e5b366d7", IdPublicacion = 3 },
                new Favorito { IdFavorito = 4, IdUsuario = "11bc73ce-dbe2-4370-bc92-0d57e5b366d7", IdPublicacion = 4 },
                new Favorito { IdFavorito = 5, IdUsuario = "26cfe5c9-00f8-411e-b589-df3405a8b798", IdPublicacion = 5 },
                new Favorito { IdFavorito = 6, IdUsuario = "26cfe5c9-00f8-411e-b589-df3405a8b798", IdPublicacion = 6 },
                new Favorito { IdFavorito = 7, IdUsuario = "26cfe5c9-00f8-411e-b589-df3405a8b798", IdPublicacion = 7 },
                new Favorito { IdFavorito = 8, IdUsuario = "26cfe5c9-00f8-411e-b589-df3405a8b798", IdPublicacion = 8 },
                new Favorito { IdFavorito = 9, IdUsuario = "26cfe5c9-00f8-411e-b589-df3405a8b798", IdPublicacion = 9 },
                new Favorito { IdFavorito = 10, IdUsuario = "26cfe5c9-00f8-411e-b589-df3405a8b798", IdPublicacion = 10 },
                new Favorito { IdFavorito = 11, IdUsuario = "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1", IdPublicacion = 11 },
                new Favorito { IdFavorito = 12, IdUsuario = "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1", IdPublicacion = 11 },
                new Favorito { IdFavorito = 13, IdUsuario = "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1", IdPublicacion = 1 },
                new Favorito { IdFavorito = 14, IdUsuario = "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1", IdPublicacion = 2 },
                new Favorito { IdFavorito = 15, IdUsuario = "e4309639-4588-4553-8c14-5ce4426e0dd7", IdPublicacion = 3 },
                new Favorito { IdFavorito = 16, IdUsuario = "e4309639-4588-4553-8c14-5ce4426e0dd7", IdPublicacion = 4 },
                new Favorito { IdFavorito = 17, IdUsuario = "e4309639-4588-4553-8c14-5ce4426e0dd7", IdPublicacion = 5 },
                new Favorito { IdFavorito = 18, IdUsuario = "e4309639-4588-4553-8c14-5ce4426e0dd7", IdPublicacion = 6 },
                new Favorito { IdFavorito = 19, IdUsuario = "e4309639-4588-4553-8c14-5ce4426e0dd7", IdPublicacion = 7 },
                new Favorito { IdFavorito = 20, IdUsuario = "e4309639-4588-4553-8c14-5ce4426e0dd7", IdPublicacion = 8 },
                new Favorito { IdFavorito = 21, IdUsuario = "e4309639-4588-4553-8c14-5ce4426e0dd7", IdPublicacion = 9 },
                new Favorito { IdFavorito = 22, IdUsuario = "e4309639-4588-4553-8c14-5ce4426e0dd7", IdPublicacion = 10 },
                new Favorito { IdFavorito = 23, IdUsuario = "3a895383-b546-4693-8246-924a9fc5289f", IdPublicacion = 11 },
                new Favorito { IdFavorito = 24, IdUsuario = "3a895383-b546-4693-8246-924a9fc5289f", IdPublicacion = 12 }
            );


        }

    }
}
