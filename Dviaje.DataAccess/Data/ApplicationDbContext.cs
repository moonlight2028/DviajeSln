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
                    PhoneNumberConfirmed = true
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
                    PhoneNumberConfirmed = true
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
                    PhoneNumberConfirmed = true
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
                    PhoneNumberConfirmed = true
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
                    PhoneNumberConfirmed = true
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
                    PhoneNumberConfirmed = true
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
                    PhoneNumberConfirmed = true
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
                    PhoneNumberConfirmed = true
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
                    PhoneNumberConfirmed = true
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
                    PhoneNumberConfirmed = true
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
            }


            /*
            new Publicacion
            {
                IdPublicacion = 2,
                Titulo = "Eco Lodge del Valle",
                Puntuacion = 4.7m,
                NumeroResenas = 98,
                Descripcion = "Sumérgete en la tranquilidad de la naturaleza en Eco Lodge del Valle. Ofrecemos cabañas ecológicas con vistas impresionantes, actividades al aire libre y un enfoque en la sostenibilidad. Perfecto para quienes buscan un escape relajante y responsable.",
                Precio = 925000,
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
                Precio = 675000,
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
                Precio = 1150000,
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
                Precio = 1500000,
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
                Precio = 720000,
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
                Precio = 860000,
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
                Precio = 1050000,
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
                Precio = 1300000,
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
                Precio = 930000,
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
                Precio = 785000,
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
                Precio = 590000,
                Fecha = new DateTime(2024, 08, 12, 08, 30, 00),
                Direccion = "Parque Nacional de los Nevados, Manizales, Colombia",
                IdAliado = "96067e6f-c29b-46ab-9ba1-18ec7b6534f4"
            }



            */
            );
























        }

    }
}
