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


        }

    }
}
