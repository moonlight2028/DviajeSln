using Dviaje.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dviaje.DataAccess.Data
{
    /// <summary>
    /// Contexto de base de datos para la aplicación, basado en IdentityDbContext para manejar la autenticación y autorización.
    /// Incluye configuraciones específicas para las entidades y sus restricciones.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Usuario> Usuarios { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        /// <summary>
        /// Configuración adicional para el modelo de base de datos durante su creación.
        /// Define restricciones y propiedades únicas para ciertas entidades.
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo que define las entidades y sus relaciones.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Restricción para campos únicos
            modelBuilder.Entity<Usuario>().HasIndex(u => u.RazonSocial).IsUnique();
            modelBuilder.Entity<Usuario>().HasIndex(u => u.Direccion).IsUnique();
        }
    }
}
