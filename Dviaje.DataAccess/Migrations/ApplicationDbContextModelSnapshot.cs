﻿// <auto-generated />
using System;
using Dviaje.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dviaje.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Dviaje.Models.Adjunto", b =>
                {
                    b.Property<int>("IdAdjunto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAdjunto"), 1L, 1);

                    b.Property<int>("IdAtencion")
                        .HasColumnType("int");

                    b.Property<string>("RutaAdjunto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAdjunto");

                    b.HasIndex("IdAtencion");

                    b.ToTable("Adjuntos");
                });

            modelBuilder.Entity("Dviaje.Models.AtencionViajero", b =>
                {
                    b.Property<int>("IdAtencion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAtencion"), 1L, 1);

                    b.Property<string>("Asunto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("text");

                    b.Property<int>("AtencionViajeroPrioridad")
                        .HasColumnType("int");

                    b.Property<int>("AtencionViajeroTipoPqrs")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaAtencion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRespuesta")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Respuesta")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("text");

                    b.HasKey("IdAtencion");

                    b.HasIndex("IdUsuario");

                    b.ToTable("AtencionViajeros");
                });

            modelBuilder.Entity("Dviaje.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"), 1L, 1);

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RutaIcono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Dviaje.Models.Favorito", b =>
                {
                    b.Property<int>("IdFavorito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFavorito"), 1L, 1);

                    b.Property<int>("IdPublicacion")
                        .HasColumnType("int");

                    b.Property<string>("IdUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdFavorito");

                    b.HasIndex("IdPublicacion");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Favoritos");
                });

            modelBuilder.Entity("Dviaje.Models.FechaNoDisponible", b =>
                {
                    b.Property<int>("IdFechaNoDisponible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFechaNoDisponible"), 1L, 1);

                    b.Property<DateTime>("FechaSinDisponible")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPublicacion")
                        .HasColumnType("int");

                    b.HasKey("IdFechaNoDisponible");

                    b.HasIndex("IdPublicacion");

                    b.ToTable("FechasNoDisponibles");
                });

            modelBuilder.Entity("Dviaje.Models.Publicacion", b =>
                {
                    b.Property<int>("IdPublicacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPublicacion"), 1L, 1);

                    b.Property<int>("CapacidadCamas")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("text");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("text");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NumeroResenas")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<int>("Puntuacion")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("text");

                    b.HasKey("IdPublicacion");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Publicaciones");
                });

            modelBuilder.Entity("Dviaje.Models.PublicacionCategoria", b =>
                {
                    b.Property<int>("IdPublicacionCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPublicacionCategoria"), 1L, 1);

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdPublicacion")
                        .HasColumnType("int");

                    b.HasKey("IdPublicacionCategoria");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdPublicacion");

                    b.ToTable("PublicacionesCategorias");
                });

            modelBuilder.Entity("Dviaje.Models.PublicacionFavorita", b =>
                {
                    b.Property<int>("IdPublicacionFavorita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPublicacionFavorita"), 1L, 1);

                    b.Property<int>("IdPublicacion")
                        .HasColumnType("int");

                    b.HasKey("IdPublicacionFavorita");

                    b.HasIndex("IdPublicacion");

                    b.ToTable("PublicacionesFavoritas");
                });

            modelBuilder.Entity("Dviaje.Models.PublicacionImagen", b =>
                {
                    b.Property<int>("IdPublicacionImagen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPublicacionImagen"), 1L, 1);

                    b.Property<int>("IdPublicacion")
                        .HasColumnType("int");

                    b.Property<string>("Ruta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPublicacionImagen");

                    b.HasIndex("IdPublicacion");

                    b.ToTable("PublicacionesImagenes");
                });

            modelBuilder.Entity("Dviaje.Models.PublicacionRestriccion", b =>
                {
                    b.Property<int>("IdPublicacionRestriccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPublicacionRestriccion"), 1L, 1);

                    b.Property<int>("IdPublicacion")
                        .HasColumnType("int");

                    b.Property<int>("IdRestriccion")
                        .HasColumnType("int");

                    b.HasKey("IdPublicacionRestriccion");

                    b.HasIndex("IdPublicacion");

                    b.HasIndex("IdRestriccion");

                    b.ToTable("PublicacionesRestricciones");
                });

            modelBuilder.Entity("Dviaje.Models.PublicacionServicio", b =>
                {
                    b.Property<int>("IdPublicacionServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPublicacionServicio"), 1L, 1);

                    b.Property<int>("IdPublicacion")
                        .HasColumnType("int");

                    b.Property<int>("IdServicio")
                        .HasColumnType("int");

                    b.HasKey("IdPublicacionServicio");

                    b.HasIndex("IdPublicacion");

                    b.HasIndex("IdServicio");

                    b.ToTable("PublicacionesServicios");
                });

            modelBuilder.Entity("Dviaje.Models.Resena", b =>
                {
                    b.Property<int>("IdResena")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdResena"), 1L, 1);

                    b.Property<int>("Calificacion")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPublicacion")
                        .HasColumnType("int");

                    b.Property<int>("IdReserva")
                        .HasColumnType("int");

                    b.Property<int>("MeGusta")
                        .HasColumnType("int");

                    b.Property<string>("Opinion")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("text");

                    b.HasKey("IdResena");

                    b.HasIndex("IdPublicacion");

                    b.HasIndex("IdReserva");

                    b.ToTable("Resenas");
                });

            modelBuilder.Entity("Dviaje.Models.Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReserva"), 1L, 1);

                    b.Property<DateTime>("FechaFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicial")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPublicacion")
                        .HasColumnType("int");

                    b.Property<string>("IdUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NumeroPersonas")
                        .HasColumnType("int");

                    b.Property<int>("ReservaEstado")
                        .HasColumnType("int");

                    b.HasKey("IdReserva");

                    b.HasIndex("IdPublicacion");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Dviaje.Models.Restriccion", b =>
                {
                    b.Property<int>("IdRestriccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRestriccion"), 1L, 1);

                    b.Property<string>("NombreRestriccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RutaIcono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRestriccion");

                    b.ToTable("Restricciones");
                });

            modelBuilder.Entity("Dviaje.Models.Servicio", b =>
                {
                    b.Property<int>("IdServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServicio"), 1L, 1);

                    b.Property<string>("NombreServicio")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RutaIcono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServicioTipo")
                        .HasColumnType("int");

                    b.HasKey("IdServicio");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("Dviaje.Models.ServicioAdicional", b =>
                {
                    b.Property<int>("IdServicioAdicional")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServicioAdicional"), 1L, 1);

                    b.Property<int>("IdPublicacion")
                        .HasColumnType("int");

                    b.Property<int>("IdServicio")
                        .HasColumnType("int");

                    b.Property<double>("PrecioServicioAdicional")
                        .HasColumnType("float");

                    b.HasKey("IdServicioAdicional");

                    b.HasIndex("IdPublicacion");

                    b.HasIndex("IdServicio");

                    b.ToTable("ServiciosAdicionales");
                });

            modelBuilder.Entity("Dviaje.Models.Verificado", b =>
                {
                    b.Property<int>("IdVerificado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVerificado"), 1L, 1);

                    b.Property<DateTime>("FechaRespuesta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSolicitud")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("VerificadoEstado")
                        .HasColumnType("int");

                    b.HasKey("IdVerificado");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Verificados");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c7c1674b-f34c-4229-9dff-649b5ce707c7",
                            ConcurrencyStamp = "c83baae3-e431-43d6-bd1c-92f633df830a",
                            Name = "Turista",
                            NormalizedName = "TURISTA"
                        },
                        new
                        {
                            Id = "31b53ef9-fc25-4db7-82ca-500f69d60bab",
                            ConcurrencyStamp = "d13f9750-bf96-4339-a306-01e6eccc1376",
                            Name = "Aliado",
                            NormalizedName = "ALIADO"
                        },
                        new
                        {
                            Id = "6f2a20cf-8d09-4e1b-8ed5-603330f1a4a6",
                            ConcurrencyStamp = "8be306e2-1c7e-416f-8c0b-26ebe2231532",
                            Name = "Moderador",
                            NormalizedName = "MODERADOR"
                        },
                        new
                        {
                            Id = "66a316e1-a6a0-47a2-93f9-57a151fdb6a7",
                            ConcurrencyStamp = "dca9c19b-fa82-4ee6-a011-c482ec16a462",
                            Name = "Administrador",
                            NormalizedName = "ADMINISTRADOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Dviaje.Models.Usuario", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<int>("AliadoEstado")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("SitioWeb")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("Verificado")
                        .HasColumnType("bit");

                    b.HasIndex("Direccion")
                        .IsUnique()
                        .HasFilter("[Direccion] IS NOT NULL");

                    b.HasIndex("RazonSocial")
                        .IsUnique()
                        .HasFilter("[RazonSocial] IS NOT NULL");

                    b.HasIndex("Telefono")
                        .IsUnique()
                        .HasFilter("[Telefono] IS NOT NULL");

                    b.HasDiscriminator().HasValue("Usuario");
                });

            modelBuilder.Entity("Dviaje.Models.Adjunto", b =>
                {
                    b.HasOne("Dviaje.Models.AtencionViajero", "AtencionViajero")
                        .WithMany()
                        .HasForeignKey("IdAtencion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AtencionViajero");
                });

            modelBuilder.Entity("Dviaje.Models.AtencionViajero", b =>
                {
                    b.HasOne("Dviaje.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Dviaje.Models.Favorito", b =>
                {
                    b.HasOne("Dviaje.Models.Publicacion", "Publicacion")
                        .WithMany()
                        .HasForeignKey("IdPublicacion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dviaje.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Publicacion");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Dviaje.Models.FechaNoDisponible", b =>
                {
                    b.HasOne("Dviaje.Models.Publicacion", "Publicacion")
                        .WithMany()
                        .HasForeignKey("IdPublicacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publicacion");
                });

            modelBuilder.Entity("Dviaje.Models.Publicacion", b =>
                {
                    b.HasOne("Dviaje.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Dviaje.Models.PublicacionCategoria", b =>
                {
                    b.HasOne("Dviaje.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dviaje.Models.Publicacion", "Publicacion")
                        .WithMany()
                        .HasForeignKey("IdPublicacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Publicacion");
                });

            modelBuilder.Entity("Dviaje.Models.PublicacionFavorita", b =>
                {
                    b.HasOne("Dviaje.Models.Publicacion", "Publicacion")
                        .WithMany()
                        .HasForeignKey("IdPublicacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publicacion");
                });

            modelBuilder.Entity("Dviaje.Models.PublicacionImagen", b =>
                {
                    b.HasOne("Dviaje.Models.Publicacion", "Publicacion")
                        .WithMany()
                        .HasForeignKey("IdPublicacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publicacion");
                });

            modelBuilder.Entity("Dviaje.Models.PublicacionRestriccion", b =>
                {
                    b.HasOne("Dviaje.Models.Publicacion", "Publicacion")
                        .WithMany()
                        .HasForeignKey("IdPublicacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dviaje.Models.Restriccion", "Restriccion")
                        .WithMany()
                        .HasForeignKey("IdRestriccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publicacion");

                    b.Navigation("Restriccion");
                });

            modelBuilder.Entity("Dviaje.Models.PublicacionServicio", b =>
                {
                    b.HasOne("Dviaje.Models.Publicacion", "Publicacion")
                        .WithMany()
                        .HasForeignKey("IdPublicacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dviaje.Models.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("IdServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publicacion");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("Dviaje.Models.Resena", b =>
                {
                    b.HasOne("Dviaje.Models.Publicacion", "Publicacion")
                        .WithMany()
                        .HasForeignKey("IdPublicacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dviaje.Models.Reserva", "Reserva")
                        .WithMany()
                        .HasForeignKey("IdReserva")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publicacion");

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("Dviaje.Models.Reserva", b =>
                {
                    b.HasOne("Dviaje.Models.Publicacion", "Publicacion")
                        .WithMany()
                        .HasForeignKey("IdPublicacion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dviaje.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Publicacion");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Dviaje.Models.ServicioAdicional", b =>
                {
                    b.HasOne("Dviaje.Models.Publicacion", "Publicacion")
                        .WithMany()
                        .HasForeignKey("IdPublicacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dviaje.Models.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("IdServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publicacion");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("Dviaje.Models.Verificado", b =>
                {
                    b.HasOne("Dviaje.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
