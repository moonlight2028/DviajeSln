using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dviaje.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    Aliado_Avatar = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    RazonSocial = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    SitioWeb = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Direccion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Verificado = table.Column<bool>(type: "boolean", nullable: true),
                    NumeroPublicaciones = table.Column<int>(type: "integer", nullable: true),
                    AliadoEstado = table.Column<int>(type: "integer", nullable: true),
                    Avatar = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AtencionViajeros",
                columns: table => new
                {
                    IdAtencion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaAtencion = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Asunto = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AtencionViajeroTipoPqrs = table.Column<int>(type: "integer", nullable: false),
                    AtencionViajeroEstado = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtencionViajeros", x => x.IdAtencion);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreCategoria = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RutaIcono = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Restricciones",
                columns: table => new
                {
                    IdRestriccion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreRestriccion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    RutaIcono = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restricciones", x => x.IdRestriccion);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    IdServicio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreServicio = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ServicioTipo = table.Column<int>(type: "integer", nullable: false),
                    RutaIcono = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.IdServicio);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    IdPublicacion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Puntuacion = table.Column<decimal>(type: "numeric(2,1)", nullable: false),
                    NumeroResenas = table.Column<int>(type: "integer", nullable: false),
                    Descripcion = table.Column<string>(type: "text", maxLength: 1500, nullable: false),
                    Precio = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Direccion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IdAliado = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.IdPublicacion);
                    table.ForeignKey(
                        name: "FK_Publicaciones_AspNetUsers_IdAliado",
                        column: x => x.IdAliado,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Verificados",
                columns: table => new
                {
                    IdVerificado = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaSolicitud = table.Column<DateTime>(type: "timestamp", nullable: false),
                    FechaRespuesta = table.Column<DateTime>(type: "timestamp", nullable: true),
                    VerificadoEstado = table.Column<int>(type: "integer", nullable: false),
                    IdAliado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verificados", x => x.IdVerificado);
                    table.ForeignKey(
                        name: "FK_Verificados_AspNetUsers_IdAliado",
                        column: x => x.IdAliado,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mensajes",
                columns: table => new
                {
                    IdMensaje = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    MensajeDescripcion = table.Column<string>(type: "text", maxLength: 250, nullable: true),
                    Nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Apellidos = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Correo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IdUsuario = table.Column<string>(type: "text", nullable: true),
                    IdAtencionViajero = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensajes", x => x.IdMensaje);
                    table.ForeignKey(
                        name: "FK_Mensajes_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mensajes_AtencionViajeros_IdAtencionViajero",
                        column: x => x.IdAtencionViajero,
                        principalTable: "AtencionViajeros",
                        principalColumn: "IdAtencion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    IdFavorito = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUsuario = table.Column<string>(type: "text", nullable: false),
                    IdPublicacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => x.IdFavorito);
                    table.ForeignKey(
                        name: "FK_Favoritos_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoritos_Publicaciones_IdPublicacion",
                        column: x => x.IdPublicacion,
                        principalTable: "Publicaciones",
                        principalColumn: "IdPublicacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FechasNoDisponibles",
                columns: table => new
                {
                    IdFechaNoDisponible = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaInicial = table.Column<DateTime>(type: "timestamp", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "timestamp", nullable: false),
                    IdPublicacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FechasNoDisponibles", x => x.IdFechaNoDisponible);
                    table.ForeignKey(
                        name: "FK_FechasNoDisponibles_Publicaciones_IdPublicacion",
                        column: x => x.IdPublicacion,
                        principalTable: "Publicaciones",
                        principalColumn: "IdPublicacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicacionesCategorias",
                columns: table => new
                {
                    IdPublicacionCategoria = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPublicacion = table.Column<int>(type: "integer", nullable: false),
                    IdCategoria = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicacionesCategorias", x => x.IdPublicacionCategoria);
                    table.ForeignKey(
                        name: "FK_PublicacionesCategorias_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicacionesCategorias_Publicaciones_IdPublicacion",
                        column: x => x.IdPublicacion,
                        principalTable: "Publicaciones",
                        principalColumn: "IdPublicacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicacionesFavoritas",
                columns: table => new
                {
                    IdPublicacionFavorita = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPublicacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicacionesFavoritas", x => x.IdPublicacionFavorita);
                    table.ForeignKey(
                        name: "FK_PublicacionesFavoritas_Publicaciones_IdPublicacion",
                        column: x => x.IdPublicacion,
                        principalTable: "Publicaciones",
                        principalColumn: "IdPublicacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicacionesImagenes",
                columns: table => new
                {
                    IdPublicacionImagen = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ruta = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Alt = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IdPublicacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicacionesImagenes", x => x.IdPublicacionImagen);
                    table.ForeignKey(
                        name: "FK_PublicacionesImagenes_Publicaciones_IdPublicacion",
                        column: x => x.IdPublicacion,
                        principalTable: "Publicaciones",
                        principalColumn: "IdPublicacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicacionesRestricciones",
                columns: table => new
                {
                    IdPublicacionRestriccion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPublicacion = table.Column<int>(type: "integer", nullable: false),
                    IdRestriccion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicacionesRestricciones", x => x.IdPublicacionRestriccion);
                    table.ForeignKey(
                        name: "FK_PublicacionesRestricciones_Publicaciones_IdPublicacion",
                        column: x => x.IdPublicacion,
                        principalTable: "Publicaciones",
                        principalColumn: "IdPublicacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicacionesRestricciones_Restricciones_IdRestriccion",
                        column: x => x.IdRestriccion,
                        principalTable: "Restricciones",
                        principalColumn: "IdRestriccion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicacionesServicios",
                columns: table => new
                {
                    IdPublicacionServicio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPublicacion = table.Column<int>(type: "integer", nullable: false),
                    IdServicio = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicacionesServicios", x => x.IdPublicacionServicio);
                    table.ForeignKey(
                        name: "FK_PublicacionesServicios_Publicaciones_IdPublicacion",
                        column: x => x.IdPublicacion,
                        principalTable: "Publicaciones",
                        principalColumn: "IdPublicacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicacionesServicios_Servicios_IdServicio",
                        column: x => x.IdServicio,
                        principalTable: "Servicios",
                        principalColumn: "IdServicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaInicial = table.Column<DateTime>(type: "timestamp", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "timestamp", nullable: false),
                    ReservaEstado = table.Column<int>(type: "integer", nullable: false),
                    NumeroPersonas = table.Column<int>(type: "integer", nullable: false),
                    IdUsuario = table.Column<string>(type: "text", nullable: false),
                    IdPublicacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reservas_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Publicaciones_IdPublicacion",
                        column: x => x.IdPublicacion,
                        principalTable: "Publicaciones",
                        principalColumn: "IdPublicacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosAdicionales",
                columns: table => new
                {
                    IdServicioAdicional = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrecioServicioAdicional = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    IdServicio = table.Column<int>(type: "integer", nullable: false),
                    IdPublicacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosAdicionales", x => x.IdServicioAdicional);
                    table.ForeignKey(
                        name: "FK_ServiciosAdicionales_Publicaciones_IdPublicacion",
                        column: x => x.IdPublicacion,
                        principalTable: "Publicaciones",
                        principalColumn: "IdPublicacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiciosAdicionales_Servicios_IdServicio",
                        column: x => x.IdServicio,
                        principalTable: "Servicios",
                        principalColumn: "IdServicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adjuntos",
                columns: table => new
                {
                    IdAdjunto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RutaAdjunto = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IdMensaje = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adjuntos", x => x.IdAdjunto);
                    table.ForeignKey(
                        name: "FK_Adjuntos_Mensajes_IdMensaje",
                        column: x => x.IdMensaje,
                        principalTable: "Mensajes",
                        principalColumn: "IdMensaje",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resenas",
                columns: table => new
                {
                    IdResena = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Opinion = table.Column<string>(type: "text", maxLength: 1500, nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Calificacion = table.Column<int>(type: "integer", nullable: false),
                    MeGusta = table.Column<int>(type: "integer", nullable: false),
                    IdReserva = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resenas", x => x.IdResena);
                    table.ForeignKey(
                        name: "FK_Resenas_Reservas_IdReserva",
                        column: x => x.IdReserva,
                        principalTable: "Reservas",
                        principalColumn: "IdReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResenasMeGusta",
                columns: table => new
                {
                    IdResenaMeGusta = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdResena = table.Column<int>(type: "integer", nullable: false),
                    IdUsuario = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResenasMeGusta", x => x.IdResenaMeGusta);
                    table.ForeignKey(
                        name: "FK_ResenasMeGusta_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResenasMeGusta_Resenas_IdResena",
                        column: x => x.IdResena,
                        principalTable: "Resenas",
                        principalColumn: "IdResena",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", null, "Turista", "TURISTA" },
                    { "4751f532-04d5-497f-b48d-b9e26bcffe6f", null, "Moderador", "MODERADOR" },
                    { "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894", null, "Aliado", "ALIADO" },
                    { "e5cd3d4a-2687-49cd-b57c-c8eddfbf2e19", null, "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AliadoEstado", "Aliado_Avatar", "ConcurrencyStamp", "Direccion", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "NumeroPublicaciones", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RazonSocial", "SecurityStamp", "SitioWeb", "TwoFactorEnabled", "UserName", "Verificado" },
                values: new object[] { "01bfd429-16ea-44b3-902c-794e2c78dfa7", 0, 0, "https://images.unsplash.com/photo-1609137144813-7d9921338f24?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8dHVyaXNtfGVufDB8fDB8fHwy", "f9e343a6-2577-4978-a1b0-b072a529a3c8", "Carrera 7 # 45-23", "Aliado", "info@colombiaadventure.com", true, false, null, "INFO@COLOMBIAADVENTURE.COM", "COLOMBIAADV", 4, null, "3216549870", true, "Colombia Adventure", "8c5b4d7e-af69-4130-ab51-014990bc358a", "www.colombiaadventure.com", false, "ColombiaAdv", true });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11bc73ce-dbe2-4370-bc92-0d57e5b366d7", 0, "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8YXZhdGFyfGVufDB8fDB8fHww", "fe5ee8d5-6abf-4f53-996d-9a28b8f750f6", "Usuario", "andres@gmail.com", true, false, null, "ANDRES@GMAIL.COM", "ANDRES", null, "3159725595", true, "ad17de56-2062-41e6-bb7a-3f2a01a4516c", false, "Andres" },
                    { "13825fa6-5c27-4303-ab17-6e13aac24c12", 0, "https://images.unsplash.com/photo-1543610892-0b1f7e6d8ac1?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww", "d55c1f93-5eba-4adf-a346-a3a2573e48a7", "Usuario", "fernando@yahoo.com", true, false, null, "FERNANDO@YAHOO.COM", "FERNANDO", null, "3198765432", true, "3fada490-919d-427d-8691-426012260bf7", false, "Fernando" },
                    { "1c8e89f7-7db6-4cd5-907d-f01b058cd784", 0, "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OHx8YXZhdGFyfGVufDB8fDB8fHww", "2f07fafa-6bef-4973-b5a2-1653728fd31e", "Usuario", "isabella@gmail.com", true, false, null, "ISABELLA@GMAIL.COM", "ISABELLA", null, "3179876543", true, "b0dbac05-ea00-4385-9f44-5bf374ed8223", false, "Isabella" },
                    { "230d9aeb-6bca-4faa-b867-2d49e1a8c12e", 0, "https://plus.unsplash.com/premium_photo-1670884441012-c5cf195c062a?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OXx8YXZhdGFyfGVufDB8fDB8fHww", "7300c8f9-84fc-49e1-b238-dd4d4f440047", "Usuario", "ana@hotmail.com", true, false, null, "ANA@HOTMAIL.COM", "ANA", null, "3149876543", true, "6e115365-65d4-4db4-ba15-07dc310845c5", false, "Ana" },
                    { "26cfe5c9-00f8-411e-b589-df3405a8b798", 0, "https://plus.unsplash.com/premium_photo-1658527049634-15142565537a?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8YXZhdGFyfGVufDB8fDB8fHww", "29fd4643-ce3f-4984-9932-6cca55d43c8d", "Usuario", "maria@gmail.com", true, false, null, "MARIA@GMAIL.COM", "MARIA", null, "3101234567", true, "51e9836e-fd14-4b41-aafe-17031a29d5b5", false, "Maria" },
                    { "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1", 0, "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8YXZhdGFyfGVufDB8fDB8fHww", "d3686b99-9c70-4123-879e-07b74df1cc67", "Usuario", "carlos@yahoo.com", true, false, null, "CARLOS@YAHOO.COM", "CARLOS", null, "3189876543", true, "d633bf62-4ddd-450b-8c50-e69e79b22cb1", false, "Carlos" },
                    { "2e59aa62-61bd-4c8d-9a3d-13f461696eab", 0, "https://images.unsplash.com/photo-1623582854588-d60de57fa33f?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fGF2YXRhcnxlbnwwfHwwfHx8MA%3D%3D", "4bc51b04-4e0d-44dd-a85d-de729a2a654b", "Usuario", "jorge@outlook.com", true, false, null, "JORGE@OUTLOOK.COM", "JORGE", null, "3151234567", true, "c8a36ce3-d28c-47d0-a21d-c4fa5d079b7f", false, "Jorge" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AliadoEstado", "Aliado_Avatar", "ConcurrencyStamp", "Direccion", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "NumeroPublicaciones", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RazonSocial", "SecurityStamp", "SitioWeb", "TwoFactorEnabled", "UserName", "Verificado" },
                values: new object[] { "39e10980-4df3-494a-bbe7-410e105f6551", 0, 0, "https://images.unsplash.com/photo-1543746746-46047c4f4bb0?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8dHVyaXNtfGVufDB8fDB8fHwy", "8e6d2a8b-b4f0-4c5c-9f91-03578c89428d", "Centro Histórico, Carrera 2 # 10-55", "Aliado", "info@santamartaadventures.com", true, false, null, "INFO@SANTAMARTAADVENTURES.COM", "SANTAMARTAADV", 48, null, "3154321098", true, "Santa Marta Adventures", "9e9a34f9-7a4d-44cd-a322-9382fe02e72c", "www.santamartaadventures.com", false, "SantaMartaAdv", true });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3a895383-b546-4693-8246-924a9fc5289f", 0, "https://images.unsplash.com/photo-1535713875002-d1d0cf377fde?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8YXZhdGFyfGVufDB8fDB8fHww", "ef5c6c56-8836-45ce-b959-41c03a492540", "Usuario", "luis@outlook.com", true, false, null, "LUIS@OUTLOOK.COM", "LUIS", null, "3112345678", true, "e439a694-deab-4636-bd4c-e4e5af118fae", false, "Luis" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AliadoEstado", "Aliado_Avatar", "ConcurrencyStamp", "Direccion", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "NumeroPublicaciones", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RazonSocial", "SecurityStamp", "SitioWeb", "TwoFactorEnabled", "UserName", "Verificado" },
                values: new object[] { "4c03648f-7727-4e5c-b096-fcbe3b9e3059", 0, 0, "https://images.unsplash.com/photo-1492294112339-ea831887e5d7?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OXx8dHVyaXNtfGVufDB8fDB8fHwy", "5e3607b9-5b39-4827-b8c8-d8ddd6826090", "Vía 40 # 72-20", "Aliado", "hello@barranquillaescapes.com", true, false, null, "HELLO@BARRANQUILLAESCAPES.COM", "BQUILLAESCAPES", 7, null, "3140987654", true, "Barranquilla Escapes", "882877d3-4cc7-47f1-b0fc-11428f62b4ce", "www.barranquillaescapes.com", false, "BquillaEscapes", false });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "51503d52-0841-49c0-a737-0e7a4c624f16", 0, "crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8YXZhdGFyfGVufDB8fDB8fHww", "4fe5c8d6-dc92-460d-9d41-08ff14260472", "Usuario", "carlosModerador@gmail.com", true, false, null, "CARLOSMODERADOR@GMAIL.COM", "CARLOSMODERADOR", null, "3159725596", true, "4c2e36ff-ee86-401a-9e54-a4f00878c786", false, "CarlosModerador" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AliadoEstado", "Aliado_Avatar", "ConcurrencyStamp", "Direccion", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "NumeroPublicaciones", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RazonSocial", "SecurityStamp", "SitioWeb", "TwoFactorEnabled", "UserName", "Verificado" },
                values: new object[,]
                {
                    { "5cf9f86f-36db-4d17-8ec3-cad66cd7f10f", 0, 0, "https://images.unsplash.com/photo-1532878056386-1e96eb5221ad?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fHR1cmlzbXxlbnwwfHwwfHx8Mg%3D%3D", "2d1323cc-5e0a-44d6-87df-f567a1b29987", "Centro, Carrera 23 # 17-18", "Aliado", "contact@manizaleswonders.com", true, false, null, "CONTACT@MANIZALESWONDERS.COM", "MANIZALESWONDERS", 7, null, "3165432109", true, "Manizales Wonders", "3fca92c6-05c0-43bd-bdaf-8ded28dba045", "www.manizaleswonders.com", false, "ManizalesWonders", false },
                    { "6e291ab8-a9b5-4a7a-afbc-bbbd71b6291b", 0, 0, "https://images.unsplash.com/photo-1463839346397-8e9946845e6d?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTB8fHR1cmlzbXxlbnwwfHwwfHx8Mg%3D%3D", "ffc360ab-38df-4500-80d8-68ee51e20e8a", "Cabecera, Carrera 33 # 45-67", "Aliado", "support@bucaramangajourneys.com", true, false, null, "SUPPORT@BUCARAMANGAJOURNEYS.COM", "BUCARAJOURNEYS", 76, null, "3229876543", true, "Bucaramanga Journeys", "561ac65c-094a-4ee2-8fbc-5de290cc30b6", "www.bucaramangajourneys.com", false, "BucaraJourneys", false },
                    { "8142c33b-ee02-4a13-b0c1-1e941387433d", 0, 0, "https://images.unsplash.com/photo-1691225409811-a64942a0596a?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8dHVyaXNtfGVufDB8fDB8fHwy", "da581c7b-5ad8-446d-9f54-e5965d01fa3a", "Bocagrande, Avenida San Martín # 11-43", "Aliado", "support@cartagenagetaways.com", true, false, null, "SUPPORT@CARTAGENAGETAWAYS.COM", "CARTAGENAGETAWAYS", 478, null, "3176543210", true, "Cartagena Getaways", "52ca61b4-6f9e-4bf5-af2d-db30b4abcec6", "www.cartagenagetaways.com", false, "CartagenaGetaways", true },
                    { "96067e6f-c29b-46ab-9ba1-18ec7b6534f4", 0, 0, "https://images.unsplash.com/photo-1519998334409-c7c6b1147f65?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fHR1cmlzbXxlbnwwfHwwfHx8Mg%3D%3D", "b981b3c4-7cf4-49fa-9674-5f2ab900123e", "Avenida Circunvalar # 18-10", "Aliado", "info@pereiratravels.com", true, false, null, "INFO@PEREIRATRAVELS.COM", "PEREIRATRAVELS", 3, null, "3107654321", true, "Pereira Travels", "9ae9e651-b3a2-4c07-bb95-953e1fbd95af", "www.pereiratravels.com", false, "PereiraTravels", false },
                    { "9cd842af-b711-44cc-aa5e-3863e3c30b76", 0, 0, "https://images.unsplash.com/photo-1678009859747-9f4620e0c355?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8dHVyaXNtfGVufDB8fDB8fHwy", "3049e617-b202-4acb-b8a2-3ea114e9d972", "Avenida 6 # 12-34", "Aliado", "contact@bogotatours.co", true, false, null, "CONTACT@BOGOTATOURS.CO", "BOGOTATOURS", 445, null, "3123456789", true, "Bogotá Tours", "699b7459-626b-4ea8-8eda-cc12c21e109c", "www.bogotatours.co", false, "BogotaTours", true },
                    { "c3733288-b354-445d-95da-4c655c3220b3", 0, 0, "https://images.unsplash.com/photo-1523345863760-5b7f3472d14f?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OHx8dHVyaXNtfGVufDB8fDB8fHwy", "d63b695e-5dac-4d46-a90f-0f63b3e0453b", "Barrio San Antonio, Carrera 10 # 5-32", "Aliado", "contact@caliexperiences.com", true, false, null, "CONTACT@CALIEXPERIENCES.COM", "CALIEXP", 8, null, "3132109876", true, "Cali Experiences", "3ce23e8b-5824-43d1-995e-52803ad9770f", "www.caliexperiences.com", false, "CaliExp", true },
                    { "c654adef-5f0c-48e6-946a-52706f8ac520", 0, 0, "https://images.unsplash.com/photo-1673213314908-5b1863e742d1?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8dHVyaXNtfGVufDB8fDB8fHwy", "55e83fcf-2c2f-4153-b124-4b03b4ad9c7a", "Calle 80 # 25-67", "Aliado", "hello@medellinexplore.com", true, false, null, "HELLO@MEDELLINEXPLORE.COM", "MEDELLINEXPLORE", 89, null, "3198765432", true, "Medellín Explore", "f8684ed6-5f17-479b-bcbf-81f279937834", "www.medellinexplore.com", false, "MedellinExplore", true }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "ca0a0328-0f5b-4ff3-b40e-6ffa8d145abb", 0, "https://images.unsplash.com/photo-1706885093487-7eda37b48a60?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTl8fGF2YXRhcnxlbnwwfHwwfHx8MA%3D%3D", "abebd15f-3e72-481b-9def-26430fc80ff5", "Usuario", "gabriela@gmail.com", true, false, null, "GABRIELA@GMAIL.COM", "GABRIELA", null, "3169876543", true, "cbdca7c6-f036-453c-961c-7d6a8f75f5f3", false, "Gabriela" },
                    { "d88d60a8-a9c5-484a-9c1c-af2e5d3447a0", 0, "https://images.unsplash.com/photo-1535713875002-d1d0cf377fde?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8YXZhdGFyfGVufDB8fDB8fHww", "618997ec-bfff-436a-b376-f85550fc70e1", "Usuario", "luisModerador@gmail.com", true, false, null, "LUISMODERADOR@GMAIL.COM", "LUISMODERADOR", null, "3159725600", true, "bb01009a-e78b-4283-a715-50b3fed042a5", false, "LuisModerador" },
                    { "df48dcf8-198f-4c4a-878c-d50e6eb0cf7a", 0, "https://plus.unsplash.com/premium_photo-1658527049634-15142565537a?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8YXZhdGFyfGVufDB8fDB8fHww", "eb254926-2f9f-4a94-9484-811e90e3bd73", "Usuario", "mariaModerador@gmail.com", true, false, null, "MARIAMODERADOR@GMAIL.COM", "MARIAMODERADOR", null, "3159725597", true, "2846b401-f699-4adf-9652-2ed25a70a6dd", false, "MariaModerador" },
                    { "e4309639-4588-4553-8c14-5ce4426e0dd7", 0, "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8YXZhdGFyfGVufDB8fDB8fHww", "6294d862-84cc-4eb4-a3de-ee6e349b1e8e", "Usuario", "sofia@hotmail.com", true, false, null, "SOFIA@HOTMAIL.COM", "SOFIA", null, "3123456789", true, "8f5d97f2-b1db-4ced-97ec-1577c335a700", false, "Sofia" },
                    { "ea4e325c-b58a-47e4-8c29-f69bb0d5b7e8", 0, "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8YXZhdGFyfGVufDB8fDB8fHww", "ed8d810b-d2bb-4a7d-a774-a7fbab6fce0c", "Usuario", "anaModerador@gmail.com", true, false, null, "ANAMODERADOR@GMAIL.COM", "ANAMODERADOR", null, "3159725599", true, "c63ed683-284b-496b-83be-39cd597574b8", false, "AnaModerador" },
                    { "f4613409-a53e-446d-854d-db0f9d652864", 0, "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8YXZhdGFyfGVufDB8fDB8fHww", "255f34eb-71a7-4b78-93e7-5d76a684770f", "Usuario", "jorgeModerador@gmail.com", true, false, null, "JORGEMODERADOR@GMAIL.COM", "JORGEMODERADOR", null, "3159725598", true, "3f15f612-7e40-4075-8434-3391b3021439", false, "JorgeModerador" },
                    { "fd0953f0-b46b-4070-9958-4a841eba3af7", 0, "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OHx8YXZhdGFyfGVufDB8fDB8fHww", "446d6d34-3dc2-4d21-9590-07fbea56e704", "Usuario", "sofiaModerador@gmail.com", true, false, null, "SOFIAMODERADOR@GMAIL.COM", "SOFIAMODERADOR", null, "3159725601", true, "f44bd72c-9396-4f43-9bf3-f6373ab225ca", false, "SofiaModerador" }
                });

            migrationBuilder.InsertData(
                table: "AtencionViajeros",
                columns: new[] { "IdAtencion", "Asunto", "AtencionViajeroEstado", "AtencionViajeroTipoPqrs", "FechaAtencion" },
                values: new object[] { 1, "Queja por Servicio de Visita Guiada Retrasada el 25 de Julio", 2, 1, new DateTimeOffset(new DateTime(2024, 7, 25, 10, 30, 50, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "NombreCategoria", "RutaIcono" },
                values: new object[,]
                {
                    { 1, "Finca", "fa-solid fa-sign-hanging" },
                    { 2, "Apartamento", "fa-solid fa-house-user" },
                    { 3, "Casa", "fa-solid fa-house" },
                    { 4, "Cabaña", "fa-solid fa-house-chimney" },
                    { 5, "Hotel", "fa-solid fa-hotel" },
                    { 6, "Hostal", "fa-solid fa-hotel" },
                    { 7, "Villa", "fa-solid fa-house-chimney-window" },
                    { 8, "Resort", "fa-solid fa-hotel" },
                    { 9, "Piso compartido", "fa-solid fa-people-roof" },
                    { 10, "Villa vacacional", "fa-solid fa-house-chimney-window" },
                    { 11, "Casa de campo", "fa-solid fa-house-chimney" },
                    { 12, "Campamentos", "fa-solid fa-campground" },
                    { 13, "Pensión", "fa-solid fa-house" },
                    { 14, "Motel", "fa-solid fa-hotel" },
                    { 15, "Apartahotel", "fa-solid fa-hotel" },
                    { 16, "Casa rural", "fa-solid fa-house-chimney" },
                    { 17, "Posada", "fa-solid fa-house" }
                });

            migrationBuilder.InsertData(
                table: "Restricciones",
                columns: new[] { "IdRestriccion", "NombreRestriccion", "RutaIcono" },
                values: new object[,]
                {
                    { 1, "Mascotas", "fa-solid fa-paw" },
                    { 2, "No Fumar", "fa-solid fa-ban-smoking" },
                    { 3, "Accesibilidad", "fa-solid fa-wheelchair" },
                    { 4, "Prohibido Ruido", "fa-solid fa-volume-xmark" },
                    { 5, "No Fiestas", "fa-solid fa-champagne-glasses" },
                    { 6, "No Niños", "fa-solid fa-children" },
                    { 7, "No Comida", "fa-solid fa-plate-wheat" },
                    { 8, "Horario Silencioso", "fa-solid fa-bell-slash" },
                    { 9, "Uso de Piscina", "fa-solid fa-water-ladder" },
                    { 10, "Zonas Comunes", "fa-solid fa-tree-city" },
                    { 11, "No Alcohol", "fa-solid fa-martini-glass-citrus" }
                });

            migrationBuilder.InsertData(
                table: "Servicios",
                columns: new[] { "IdServicio", "NombreServicio", "RutaIcono", "ServicioTipo" },
                values: new object[,]
                {
                    { 1, "Piscina", "fa-solid fa-water-ladder", 2 },
                    { 2, "Piscina techada", "fa-solid fa-water-ladder", 2 },
                    { 3, "Parqueadero", "fa-solid fa-square-parking", 2 },
                    { 4, "Restaurante", "fa-solid fa-utensils", 2 },
                    { 5, "Bañera de hidromasaje", "fa-solid fa-bath", 2 },
                    { 6, "Spa", "fa-solid fa-spa", 2 },
                    { 7, "Gimnasio", "fa-solid fa-dumbbell", 2 },
                    { 8, "Sauna", "fa-solid fa-hot-tub-person", 2 },
                    { 9, "Sombrillas de playa", "fa-solid fa-umbrella-beach", 2 },
                    { 10, "Desayuno incluido", "fa-solid fa-bacon", 2 },
                    { 11, "Centro de negocios", "fa-solid fa-business-time", 2 },
                    { 12, "Acepta mascotas", "fa-solid fa-paw", 2 },
                    { 13, "Recepción disponible 24 horas", "fa-solid fa-bell-concierge", 2 },
                    { 14, "Servicio de lavandería", "fa-solid fa-jug-detergent", 2 },
                    { 15, "Salas de reuniones", "fa-solid fa-people-roof", 2 },
                    { 16, "Cajero automático", "fa-solid fa-money-bills", 2 },
                    { 17, "Piscina climatizada", "fa-solid fa-water-ladder", 2 },
                    { 18, "Alquiler de bicicletas", "fa-solid fa-bicycle", 2 },
                    { 19, "Sala de juegos", "fa-solid fa-table-tennis-paddle-ball", 2 },
                    { 20, "Piscina al aire libre", "fa-solid fa-person-swimming", 2 },
                    { 21, "Wi-Fi", "fa-solid fa-wifi", 0 },
                    { 22, "Internet", "fa-solid fa-network-wired", 0 },
                    { 23, "Aire acondicionado", "fa-solid fa-wind", 0 },
                    { 24, "Cocina", "fa-solid fa-kitchen-set", 0 },
                    { 25, "Balcón/Terraza", "fa-solid fa-house", 0 },
                    { 26, "Bañera", "fa-solid fa-bath", 0 },
                    { 27, "Minibar", "fa-solid fa-champagne-glasses", 0 },
                    { 28, "Servicio de limpieza", "fa-solid fa-broom", 0 },
                    { 29, "Secador de pelo", "fa-solid fa-wind", 0 },
                    { 30, "Teléfono", "fa-solid fa-phone", 0 },
                    { 31, "Balcón privado", "fa-solid fa-house", 0 },
                    { 32, "Horno", "fa-solid fa-fire-burner", 0 },
                    { 33, "Acceso silla de ruedas", "fa-solid fa-wheelchair", 1 },
                    { 34, "Hab. p/ personas con discapacidad", "fa-solid fa-house-user", 1 },
                    { 35, "Parqueadero p/ personas con discapacidad", "fa-solid fa-square-parking", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "01bfd429-16ea-44b3-902c-794e2c78dfa7" },
                    { "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894", "01bfd429-16ea-44b3-902c-794e2c78dfa7" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "11bc73ce-dbe2-4370-bc92-0d57e5b366d7" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "13825fa6-5c27-4303-ab17-6e13aac24c12" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "1c8e89f7-7db6-4cd5-907d-f01b058cd784" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "230d9aeb-6bca-4faa-b867-2d49e1a8c12e" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "26cfe5c9-00f8-411e-b589-df3405a8b798" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "2e59aa62-61bd-4c8d-9a3d-13f461696eab" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "39e10980-4df3-494a-bbe7-410e105f6551" },
                    { "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894", "39e10980-4df3-494a-bbe7-410e105f6551" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "3a895383-b546-4693-8246-924a9fc5289f" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "4c03648f-7727-4e5c-b096-fcbe3b9e3059" },
                    { "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894", "4c03648f-7727-4e5c-b096-fcbe3b9e3059" },
                    { "4751f532-04d5-497f-b48d-b9e26bcffe6f", "51503d52-0841-49c0-a737-0e7a4c624f16" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "5cf9f86f-36db-4d17-8ec3-cad66cd7f10f" },
                    { "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894", "5cf9f86f-36db-4d17-8ec3-cad66cd7f10f" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "6e291ab8-a9b5-4a7a-afbc-bbbd71b6291b" },
                    { "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894", "6e291ab8-a9b5-4a7a-afbc-bbbd71b6291b" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "8142c33b-ee02-4a13-b0c1-1e941387433d" },
                    { "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894", "8142c33b-ee02-4a13-b0c1-1e941387433d" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "96067e6f-c29b-46ab-9ba1-18ec7b6534f4" },
                    { "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894", "96067e6f-c29b-46ab-9ba1-18ec7b6534f4" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "9cd842af-b711-44cc-aa5e-3863e3c30b76" },
                    { "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894", "9cd842af-b711-44cc-aa5e-3863e3c30b76" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "c3733288-b354-445d-95da-4c655c3220b3" },
                    { "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894", "c3733288-b354-445d-95da-4c655c3220b3" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "c654adef-5f0c-48e6-946a-52706f8ac520" },
                    { "651e4e93-f8a9-4c4e-9e85-9f0aea1d1894", "c654adef-5f0c-48e6-946a-52706f8ac520" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "ca0a0328-0f5b-4ff3-b40e-6ffa8d145abb" },
                    { "4751f532-04d5-497f-b48d-b9e26bcffe6f", "d88d60a8-a9c5-484a-9c1c-af2e5d3447a0" },
                    { "4751f532-04d5-497f-b48d-b9e26bcffe6f", "df48dcf8-198f-4c4a-878c-d50e6eb0cf7a" },
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "e4309639-4588-4553-8c14-5ce4426e0dd7" },
                    { "4751f532-04d5-497f-b48d-b9e26bcffe6f", "ea4e325c-b58a-47e4-8c29-f69bb0d5b7e8" },
                    { "4751f532-04d5-497f-b48d-b9e26bcffe6f", "f4613409-a53e-446d-854d-db0f9d652864" },
                    { "4751f532-04d5-497f-b48d-b9e26bcffe6f", "fd0953f0-b46b-4070-9958-4a841eba3af7" }
                });

            migrationBuilder.InsertData(
                table: "Mensajes",
                columns: new[] { "IdMensaje", "Apellidos", "Correo", "Fecha", "IdAtencionViajero", "IdUsuario", "MensajeDescripcion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, null, null, new DateTimeOffset(new DateTime(2024, 7, 25, 10, 30, 50, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), 1, "11bc73ce-dbe2-4370-bc92-0d57e5b366d7", "Me gustaría presentar una queja sobre el servicio recibido el pasado 25 de julio de 2024 a través de su plataforma de turismo. Ese día, tenía programada una visita guiada para las 10:00 a.m. en el centro histórico, pero la guía no llegó hasta las 11:30 a.m., sin ninguna explicación por parte del equipo de soporte. Además, la atención recibida fue poco profesional, ya que la guía no pudo responder adecuadamente a mis preguntas sobre los lugares visitados. Agradecería una revisión de este caso y una explicación sobre lo ocurrido, así como las medidas que se tomarán para evitar que situaciones similares se repitan en el futuro. /n Adjunto capturas de pantalla de los correos de confirmación de mi reserva y del pago realizado como referencia.", null, null },
                    { 2, null, null, new DateTimeOffset(new DateTime(2024, 7, 26, 10, 30, 50, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), 1, "fd0953f0-b46b-4070-9958-4a841eba3af7", "Gracias por comunicarse con nosotros y por informarnos sobre su experiencia con nuestro servicio el 25 de julio de 2024. Lamentamos sinceramente los inconvenientes que experimentó durante su visita guiada y cualquier insatisfacción que esto le haya causado. /n Hemos revisado su caso y constatamos que hubo un problema de programación inesperado que retrasó la llegada de la guía. Apreciamos su paciencia y comprensión en esta situación. Hemos tomado medidas para mejorar nuestros procesos de planificación y comunicación con el equipo de guías para asegurarnos de que este tipo de incidentes no se repitan. /n Además, como gesto de disculpa, nos gustaría ofrecerle un reembolso completo del costo de su reserva y un descuento del 20% en su próxima visita con nosotros. Un representante de nuestro equipo se pondrá en contacto con usted en breve para gestionar el reembolso. /n Gracias por su comprensión y por darnos la oportunidad de corregir este error. Valoramos mucho su opinión y esperamos poder servirle mejor en el futuro.", null, null }
                });

            migrationBuilder.InsertData(
                table: "Publicaciones",
                columns: new[] { "IdPublicacion", "Descripcion", "Direccion", "Fecha", "IdAliado", "NumeroResenas", "Precio", "Puntuacion", "Titulo" },
                values: new object[,]
                {
                    { 1, "Descubre la magia de la naturaleza sin renunciar a las comodidades del hogar en Casa Quincha Glamping. Ubicada en un entorno sereno y pintoresco, nuestra experiencia de glamping combina el lujo y la aventura, ofreciendo una estancia inolvidable para quienes buscan relajarse y reconectar con el entorno natural.", "Km 5 Via San Francisco - Supatá, San Francisco 253601 Colombia", new DateTime(2024, 8, 1, 14, 15, 0, 0, DateTimeKind.Unspecified), "01bfd429-16ea-44b3-902c-794e2c78dfa7", 150, 813000m, 4.3m, "Casa Quincha Glamping" },
                    { 2, "Sumérgete en la tranquilidad de la naturaleza en Eco Lodge del Valle. Ofrecemos cabañas ecológicas con vistas impresionantes, actividades al aire libre y un enfoque en la sostenibilidad. Perfecto para quienes buscan un escape relajante y responsable.", "Vereda El Dorado, Valle de Cauca, Colombia", new DateTime(2024, 8, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), "01bfd429-16ea-44b3-902c-794e2c78dfa7", 98, 925000m, 4.7m, "Eco Lodge del Valle" },
                    { 3, "Refugio del Bosque ofrece una experiencia única en medio de un bosque encantado. Disfruta de nuestras cabañas acogedoras, senderos para caminatas y actividades al aire libre. Ideal para familias y aventureros.", "Km 10 Via Manizales - Chinchina, Manizales, Colombia", new DateTime(2024, 8, 3, 12, 30, 0, 0, DateTimeKind.Unspecified), "01bfd429-16ea-44b3-902c-794e2c78dfa7", 76, 675000m, 4.2m, "Refugio del Bosque" },
                    { 4, "Descubre el lujo y la serenidad en Oasis de la Sierra. Nuestra propiedad ofrece vistas espectaculares, instalaciones de primera clase y actividades exclusivas en un entorno montañoso inigualable.", "Avenida de los Andes, Cúcuta, Colombia", new DateTime(2024, 8, 4, 14, 45, 0, 0, DateTimeKind.Unspecified), "c654adef-5f0c-48e6-946a-52706f8ac520", 120, 1150000m, 4.6m, "Oasis de la Sierra" },
                    { 5, "Villas del Mar ofrece una experiencia de lujo frente al mar con villas privadas, piscina infinita y servicios personalizados. Ideal para escapadas románticas o celebraciones especiales.", "Playa de San Andrés, San Andrés, Colombia", new DateTime(2024, 8, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), "c654adef-5f0c-48e6-946a-52706f8ac520", 134, 1500000m, 4.8m, "Villas del Mar" },
                    { 6, "Disfruta de una estancia relajante en Cabañas del Río, rodeado de la belleza natural de la región. Ofrecemos cabañas rústicas con acceso directo al río y actividades de pesca y senderismo.", "Vereda El Río, Medellín, Colombia", new DateTime(2024, 8, 6, 9, 15, 0, 0, DateTimeKind.Unspecified), "8142c33b-ee02-4a13-b0c1-1e941387433d", 85, 720000m, 4.4m, "Cabañas del Río" },
                    { 7, "Rincón del Viento ofrece una experiencia de glamping en medio de la naturaleza con tiendas de lujo, fogatas y una vista impresionante de las montañas. Perfecto para una escapada romántica o una aventura familiar.", "Km 20 Via Villa de Leyva, Boyacá, Colombia", new DateTime(2024, 8, 7, 11, 30, 0, 0, DateTimeKind.Unspecified), "39e10980-4df3-494a-bbe7-410e105f6551", 63, 860000m, 4.1m, "Rincón del Viento" },
                    { 8, "Hotel del Lago ofrece una estancia lujosa con vistas al lago, spa, y restaurante gourmet. Ideal para una experiencia de relax y confort con servicios de alta calidad.", "Río Guatapé, Antioquia, Colombia", new DateTime(2024, 8, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), "39e10980-4df3-494a-bbe7-410e105f6551", 142, 1050000m, 4.5m, "Hotel del Lago" },
                    { 9, "Vive una experiencia de bienestar total en nuestro centro de bienestar natural. Ofrecemos retiros de meditación, yoga, y spa en un entorno tranquilo y rejuvenecedor.", "Vereda La Primavera, Bogotá, Colombia", new DateTime(2024, 8, 9, 10, 15, 0, 0, DateTimeKind.Unspecified), "c3733288-b354-445d-95da-4c655c3220b3", 167, 1300000m, 1.0m, "Centro de Bienestar Natural" },
                    { 10, "Aventura en la Selva ofrece una experiencia única de ecoturismo con cabañas en la selva, guías especializados y actividades de exploración en la biodiversidad local.", "Reserva Natural del Amazonas, Leticia, Colombia", new DateTime(2024, 8, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "4c03648f-7727-4e5c-b096-fcbe3b9e3059", 110, 930000m, 1.3m, "Aventura en la Selva" },
                    { 11, "Casas del Valle ofrece una estancia encantadora en casas de campo tradicionales con acceso a actividades al aire libre, incluyendo paseos a caballo y rutas de senderismo.", "Vereda El Valle, Tunja, Colombia", new DateTime(2024, 8, 11, 12, 45, 0, 0, DateTimeKind.Unspecified), "6e291ab8-a9b5-4a7a-afbc-bbbd71b6291b", 95, 785000m, 2.4m, "Casas del Valle" },
                    { 12, "Camping de Montaña ofrece una experiencia auténtica de campamento con acceso a rutas de senderismo y vistas panorámicas de las montañas. Perfecto para los amantes de la naturaleza y la aventura.", "Parque Nacional de los Nevados, Manizales, Colombia", new DateTime(2024, 8, 12, 8, 30, 0, 0, DateTimeKind.Unspecified), "96067e6f-c29b-46ab-9ba1-18ec7b6534f4", 80, 590000m, 3.0m, "Camping de Montaña" }
                });

            migrationBuilder.InsertData(
                table: "Verificados",
                columns: new[] { "IdVerificado", "FechaRespuesta", "FechaSolicitud", "IdAliado", "VerificadoEstado" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 15, 10, 10, 54, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 8, 8, 20, 0, 0, DateTimeKind.Unspecified), "01bfd429-16ea-44b3-902c-794e2c78dfa7", 1 },
                    { 2, new DateTime(2024, 7, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "9cd842af-b711-44cc-aa5e-3863e3c30b76", 1 },
                    { 3, new DateTime(2024, 7, 20, 16, 25, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 12, 14, 45, 0, 0, DateTimeKind.Unspecified), "c654adef-5f0c-48e6-946a-52706f8ac520", 1 },
                    { 4, new DateTime(2024, 7, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), "8142c33b-ee02-4a13-b0c1-1e941387433d", 1 },
                    { 5, new DateTime(2024, 7, 25, 14, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), "39e10980-4df3-494a-bbe7-410e105f6551", 1 },
                    { 6, new DateTime(2024, 7, 27, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 20, 9, 15, 0, 0, DateTimeKind.Unspecified), "c3733288-b354-445d-95da-4c655c3220b3", 1 },
                    { 7, new DateTime(2024, 7, 29, 15, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 22, 13, 20, 0, 0, DateTimeKind.Unspecified), "4c03648f-7727-4e5c-b096-fcbe3b9e3059", 2 },
                    { 8, new DateTime(2024, 8, 1, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), "6e291ab8-a9b5-4a7a-afbc-bbbd71b6291b", 2 },
                    { 9, new DateTime(2024, 8, 4, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 28, 10, 45, 0, 0, DateTimeKind.Unspecified), "96067e6f-c29b-46ab-9ba1-18ec7b6534f4", 2 },
                    { 10, new DateTime(2024, 8, 6, 14, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), "5cf9f86f-36db-4d17-8ec3-cad66cd7f10f", 2 },
                    { 11, null, new DateTime(2024, 8, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), "96067e6f-c29b-46ab-9ba1-18ec7b6534f4", 0 },
                    { 12, null, new DateTime(2024, 8, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), "5cf9f86f-36db-4d17-8ec3-cad66cd7f10f", 0 }
                });

            migrationBuilder.InsertData(
                table: "Adjuntos",
                columns: new[] { "IdAdjunto", "IdMensaje", "RutaAdjunto" },
                values: new object[] { 1, 1, "https://DViaje.com/adjuntos/queja_tourrtt.jpg" });

            migrationBuilder.InsertData(
                table: "Favoritos",
                columns: new[] { "IdFavorito", "IdPublicacion", "IdUsuario" },
                values: new object[,]
                {
                    { 1, 1, "11bc73ce-dbe2-4370-bc92-0d57e5b366d7" },
                    { 2, 2, "11bc73ce-dbe2-4370-bc92-0d57e5b366d7" },
                    { 3, 3, "11bc73ce-dbe2-4370-bc92-0d57e5b366d7" },
                    { 4, 4, "11bc73ce-dbe2-4370-bc92-0d57e5b366d7" },
                    { 5, 5, "26cfe5c9-00f8-411e-b589-df3405a8b798" },
                    { 6, 6, "26cfe5c9-00f8-411e-b589-df3405a8b798" },
                    { 7, 7, "26cfe5c9-00f8-411e-b589-df3405a8b798" },
                    { 8, 8, "26cfe5c9-00f8-411e-b589-df3405a8b798" },
                    { 9, 9, "26cfe5c9-00f8-411e-b589-df3405a8b798" },
                    { 10, 10, "26cfe5c9-00f8-411e-b589-df3405a8b798" },
                    { 11, 11, "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1" },
                    { 12, 11, "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1" },
                    { 13, 1, "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1" },
                    { 14, 2, "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1" },
                    { 15, 3, "e4309639-4588-4553-8c14-5ce4426e0dd7" },
                    { 16, 4, "e4309639-4588-4553-8c14-5ce4426e0dd7" },
                    { 17, 5, "e4309639-4588-4553-8c14-5ce4426e0dd7" },
                    { 18, 6, "e4309639-4588-4553-8c14-5ce4426e0dd7" },
                    { 19, 7, "e4309639-4588-4553-8c14-5ce4426e0dd7" },
                    { 20, 8, "e4309639-4588-4553-8c14-5ce4426e0dd7" },
                    { 21, 9, "e4309639-4588-4553-8c14-5ce4426e0dd7" },
                    { 22, 10, "e4309639-4588-4553-8c14-5ce4426e0dd7" },
                    { 23, 11, "3a895383-b546-4693-8246-924a9fc5289f" },
                    { 24, 12, "3a895383-b546-4693-8246-924a9fc5289f" }
                });

            migrationBuilder.InsertData(
                table: "FechasNoDisponibles",
                columns: new[] { "IdFechaNoDisponible", "FechaFinal", "FechaInicial", "IdPublicacion" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 30, 15, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 20, 15, 45, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2024, 8, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2024, 8, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2024, 8, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, new DateTime(2024, 8, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 6, new DateTime(2024, 8, 29, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 22, 8, 30, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 7, new DateTime(2024, 9, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 25, 15, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 8, new DateTime(2024, 9, 10, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 9, new DateTime(2024, 9, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 10, new DateTime(2024, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 11, new DateTime(2024, 11, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 12, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "PublicacionesCategorias",
                columns: new[] { "IdPublicacionCategoria", "IdCategoria", "IdPublicacion" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 4, 2 },
                    { 6, 5, 2 },
                    { 7, 6, 2 },
                    { 8, 7, 3 },
                    { 9, 8, 4 },
                    { 10, 9, 5 },
                    { 11, 10, 5 },
                    { 12, 11, 5 },
                    { 13, 12, 5 },
                    { 14, 13, 5 },
                    { 15, 14, 5 },
                    { 16, 15, 6 },
                    { 17, 16, 6 },
                    { 18, 17, 7 },
                    { 19, 1, 8 },
                    { 20, 2, 9 },
                    { 21, 3, 9 },
                    { 22, 4, 9 },
                    { 23, 5, 10 },
                    { 24, 6, 10 },
                    { 25, 7, 11 },
                    { 26, 8, 12 }
                });

            migrationBuilder.InsertData(
                table: "PublicacionesFavoritas",
                columns: new[] { "IdPublicacionFavorita", "IdPublicacion" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "PublicacionesImagenes",
                columns: new[] { "IdPublicacionImagen", "Alt", "IdPublicacion", "Ruta" },
                values: new object[,]
                {
                    { 1, "Vista panorámica de la playa con arena blanca y aguas cristalinas en una soleada tarde de verano", 1, "https://images.unsplash.com/photo-1707343848552-893e05dba6ac?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 2, "Sendero en un bosque denso lleno de árboles altos", 1, "https://images.unsplash.com/photo-1500835556837-99ac94a94552?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 3, "Antiguo castillo medieval situado en lo alto de una colina", 1, "https://images.unsplash.com/photo-1469854523086-cc02fe5d8800?q=80&w=1421&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 4, "Cascada en medio de un bosque tropical exuberante", 1, "https://images.unsplash.com/photo-1433086966358-54859d0ed716?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 5, "Calle adoquinada en una ciudad histórica con edificios coloridos", 1, "https://images.unsplash.com/photo-1504598318550-17eba1008a68?q=80&w=1372&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 6, "Tranquilo lago reflejando majestuosas montañas en el fondo", 2, "https://images.unsplash.com/photo-1476514525535-07fb3b4ae5f1?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 7, "Puente colgante sobre un cañón profundo y pintoresco", 2, "https://images.unsplash.com/photo-1473163928189-364b2c4e1135?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 8, "Mercado local vibrante con frutas exóticas y artesanías", 2, "https://images.unsplash.com/photo-1483683804023-6ccdb62f86ef?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 9, "Ruinas de una antigua civilización en un paisaje desértico", 3, "https://images.unsplash.com/photo-1512100356356-de1b84283e18?q=80&w=1375&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 10, "Jardín botánico con una impresionante variedad de flores", 3, "https://images.unsplash.com/photo-1533104816931-20fa691ff6ca?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 11, "Playa aislada con palmeras y aguas turquesas cristalinas", 3, "https://images.unsplash.com/photo-1494783367193-149034c05e8f?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 12, "Puesta de sol espectacular sobre el océano en un día despejado", 3, "https://images.unsplash.com/photo-1533105079780-92b9be482077?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 13, "Vistas impresionantes de un río serpenteante en el valle", 3, "https://images.unsplash.com/photo-1719937206491-ed673f64be1f?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 14, "Acantilados dramáticos con vistas al mar abierto", 3, "https://images.unsplash.com/photo-1499063078284-f78f7d89616a?q=80&w=1528&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 15, "Pueblo pintoresco en la ladera de una montaña", 3, "https://images.unsplash.com/photo-1522199710521-72d69614c702?q=80&w=1472&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 16, "Glaciares brillando bajo la luz del sol en un paisaje helado", 4, "https://images.unsplash.com/photo-1500530855697-b586d89ba3ee?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 17, "Selva tropical densa con una ligera niebla matutina", 4, "https://images.unsplash.com/photo-1512757776214-26d36777b513?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 18, "Campos de lavanda en flor bajo un cielo azul claro", 4, "https://images.unsplash.com/photo-1496950866446-3253e1470e8e?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 19, "Viñedos ondulantes que cubren colinas soleadas", 4, "https://images.unsplash.com/photo-1476900543704-4312b78632f8?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 20, "Desierto dorado bajo un cielo despejado y azul", 4, "https://images.unsplash.com/photo-1707344088547-3cf7cea5ca49?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 21, "Isla tropical con playas de arena blanca y palmeras", 5, "https://images.unsplash.com/photo-1530841377377-3ff06c0ca713?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 22, "Camino rural bordeado de girasoles bajo un cielo despejado", 5, "https://images.unsplash.com/photo-1506929562872-bb421503ef21?q=80&w=1368&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 23, "Cañón con formaciones rocosas y un río al fondo", 6, "https://images.unsplash.com/photo-1568849676085-51415703900f?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 24, "Templo antiguo rodeado de naturaleza exuberante", 6, "https://images.unsplash.com/photo-1467269204594-9661b134dd2b?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 25, "Parque nacional con una vasta pradera verde y montañas", 6, "https://images.unsplash.com/photo-1516483638261-f4dbaf036963?q=80&w=1372&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 26, "Ciudad moderna con rascacielos al atardecer", 6, "https://images.unsplash.com/photo-1504150558240-0b4fd8946624?q=80&w=1528&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 27, "Vista aérea de un arrecife de coral en aguas turquesas", 6, "https://images.unsplash.com/photo-1527631746610-bca00a040d60?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 28, "Bahía serena con barcos veleros flotando tranquilamente", 6, "https://images.unsplash.com/photo-1446160657592-4782fb76fb99?q=80&w=1469&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 29, "Volcán activo con humo saliendo del cráter", 6, "https://images.unsplash.com/photo-1500301111609-42f1aa6df72a?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 30, "Camino de montaña cubierto de flores silvestres en primavera", 6, "https://images.unsplash.com/photo-1500815845799-7748ca339f27?q=80&w=1527&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 31, "Carretera costera con impresionantes vistas al mar", 8, "https://images.unsplash.com/photo-1507525428034-b723cf961d3e?q=80&w=1473&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 32, "Campo de tulipanes multicolores en un día soleado", 8, "https://images.unsplash.com/photo-1526784725085-c69e947bf92e?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 33, "Lago congelado rodeado de montañas nevadas", 8, "https://images.unsplash.com/photo-1471623320832-752e8bbf8413?q=80&w=1410&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 34, "Pueblo pesquero con barcos amarrados en el puerto", 8, "https://images.unsplash.com/photo-1528164344705-47542687000d?q=80&w=1492&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 35, "Ruinas romanas en un paisaje mediterráneo", 8, "https://images.unsplash.com/photo-1491800943052-1059ce1e1012?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 36, "Selva amazónica vista desde arriba", 8, "https://images.unsplash.com/photo-1551918120-9739cb430c6d?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 37, "Desierto con dunas de arena y un oasis en el horizonte", 9, "https://images.unsplash.com/photo-1548625149-720134d51a3a?q=80&w=1528&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 38, "Granja en el campo con colinas ondulantes de fondo", 9, "https://images.unsplash.com/photo-1492693429561-1c283eb1b2e8?q=80&w=1480&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 39, "Plaza de una ciudad europea con una fuente central", 9, "https://images.unsplash.com/photo-1532347922424-c652d9b7208e?q=80&w=1372&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 40, "Atardecer sobre el puente Golden Gate en San Francisco", 9, "https://images.unsplash.com/photo-1567069160354-f25b26e62fa1?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 41, "Panorama de un fiordo noruego con aguas tranquilas", 9, "https://images.unsplash.com/photo-1705588217460-d548807940ad?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 42, "Camino de tierra serpenteante en un bosque de pinos", 10, "https://images.unsplash.com/photo-1558352541-95f7ac02fff2?q=80&w=1632&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 43, "Catedral gótica en el centro de una ciudad histórica", 10, "https://images.unsplash.com/photo-1558461670-abf3421e18b6?q=80&w=1632&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 44, "Costa rocosa con olas rompiendo contra los acantilados", 10, "https://images.unsplash.com/photo-1480497209098-7b9e9555bcee?q=80&w=1376&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 45, "Vista de un valle alpino con pastizales verdes", 10, "https://images.unsplash.com/photo-1502489597346-dad15683d4c2?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 46, "Auroras boreales iluminando el cielo en el Ártico", 10, "https://images.unsplash.com/photo-1679420438051-19bd5aad4d67?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 47, "Pueblo medieval rodeado por murallas antiguas", 10, "https://images.unsplash.com/photo-1692308516530-5ffc490476a8?q=80&w=1528&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 48, "Río bordeado por árboles en pleno otoño", 10, "https://images.unsplash.com/photo-1704803269187-d6eb334ea5fe?q=80&w=1472&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 49, "Cabaña rústica en un paisaje montañoso", 7, "https://images.unsplash.com/photo-1643234804946-7ae71ca3aea3?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 50, "Mercado al aire libre con puestos de comida local", 7, "https://images.unsplash.com/photo-1688321998704-e5bba733728c?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 51, "Vista del horizonte de Nueva York desde el agua", 7, "https://images.unsplash.com/photo-1622343782402-94ea774c4f61?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 52, "Sendero costero con vistas al océano Atlántico", 7, "https://images.unsplash.com/photo-1707073687377-fbda787a7db9?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 53, "Campo de arrozales en terrazas al atardecer", 7, "https://images.unsplash.com/photo-1646672571916-453b48d71710?q=80&w=1978&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 54, "Parque nacional con formaciones rocosas únicas", 7, "https://images.unsplash.com/photo-1649807944854-a7b57dd6afb5?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 55, "Isla volcánica con playas de arena negra", 7, "https://images.unsplash.com/photo-1577741553317-7f231343599a?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 56, "Jardines palaciegos con estatuas clásicas y fuentes", 11, "https://images.unsplash.com/photo-1573435708546-32beaff245c1?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 57, "Cueva iluminada por luces de colores en su interior", 11, "https://images.unsplash.com/photo-1708187181457-8bafec80833a?q=80&w=2077&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 58, "Viejo faro en un acantilado con vistas al océano", 11, "https://images.unsplash.com/photo-1683384546413-d207b5677dc0?q=80&w=2076&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 59, "Carretera escénica a través de colinas de té", 11, "https://images.unsplash.com/photo-1610228328499-53c36a14dbc1?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 60, "Paisaje ártico con icebergs flotando en el agua", 11, "https://images.unsplash.com/photo-1656371559747-1ca93a271206?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 61, "Puente de madera cruzando un río en un bosque", 11, "https://images.unsplash.com/photo-1635222722123-fd2b74b6bc9d?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 62, "Murallas antiguas rodeando una ciudad medieval", 12, "https://images.unsplash.com/photo-1707073687052-0edc1463d1f8?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 63, "Jardines japoneses con estanques y bonsáis", 12, "https://images.unsplash.com/photo-1705373069474-e01b8b18b6f6?q=80&w=2073&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 64, "Vistas panorámicas de una ciudad desde una colina", 12, "https://images.unsplash.com/photo-1688254708497-732d5a8d923b?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 65, "Desfiladero con paredes de roca y un río serpenteante", 12, "https://images.unsplash.com/photo-1663948017079-2906ed90a5d6?q=80&w=1936&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 66, "Ruinas mayas en medio de la selva", 12, "https://images.unsplash.com/photo-1573435708534-6b6dbc589bfc?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" }
                });

            migrationBuilder.InsertData(
                table: "PublicacionesRestricciones",
                columns: new[] { "IdPublicacionRestriccion", "IdPublicacion", "IdRestriccion" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 4, 3, 4 },
                    { 5, 3, 5 },
                    { 6, 5, 6 },
                    { 7, 7, 7 },
                    { 8, 8, 8 },
                    { 9, 8, 9 },
                    { 10, 9, 10 },
                    { 11, 10, 11 },
                    { 12, 11, 1 },
                    { 13, 12, 2 }
                });

            migrationBuilder.InsertData(
                table: "PublicacionesServicios",
                columns: new[] { "IdPublicacionServicio", "IdPublicacion", "IdServicio" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 3 },
                    { 3, 1, 4 },
                    { 4, 1, 5 },
                    { 5, 1, 8 },
                    { 6, 1, 10 },
                    { 7, 1, 11 },
                    { 8, 2, 12 },
                    { 9, 2, 13 },
                    { 10, 2, 14 },
                    { 11, 2, 15 },
                    { 12, 2, 16 },
                    { 13, 2, 17 },
                    { 14, 2, 18 },
                    { 15, 2, 19 },
                    { 16, 3, 20 },
                    { 17, 3, 21 },
                    { 18, 3, 22 },
                    { 19, 3, 23 },
                    { 20, 3, 24 },
                    { 21, 3, 25 },
                    { 22, 3, 26 },
                    { 23, 3, 27 },
                    { 24, 3, 28 },
                    { 25, 4, 29 },
                    { 26, 4, 30 },
                    { 27, 4, 31 },
                    { 28, 4, 32 },
                    { 29, 4, 33 },
                    { 30, 4, 34 },
                    { 31, 4, 35 },
                    { 32, 4, 1 },
                    { 33, 4, 2 },
                    { 34, 4, 3 },
                    { 35, 4, 5 },
                    { 36, 4, 6 },
                    { 37, 4, 7 },
                    { 38, 5, 8 },
                    { 39, 5, 9 },
                    { 40, 5, 10 },
                    { 41, 5, 11 },
                    { 42, 6, 12 },
                    { 43, 6, 13 },
                    { 44, 6, 14 },
                    { 45, 6, 15 },
                    { 46, 6, 16 },
                    { 47, 6, 17 },
                    { 48, 6, 18 },
                    { 49, 6, 19 },
                    { 50, 6, 20 },
                    { 51, 6, 21 },
                    { 52, 6, 22 },
                    { 53, 7, 23 },
                    { 54, 7, 24 },
                    { 55, 7, 25 },
                    { 56, 7, 26 },
                    { 57, 8, 27 },
                    { 58, 8, 28 },
                    { 59, 8, 29 },
                    { 60, 9, 30 },
                    { 61, 9, 31 },
                    { 62, 9, 32 },
                    { 63, 9, 33 },
                    { 64, 9, 34 },
                    { 65, 9, 35 },
                    { 66, 9, 1 },
                    { 67, 9, 2 },
                    { 68, 9, 3 },
                    { 69, 10, 4 },
                    { 70, 10, 5 },
                    { 71, 10, 6 },
                    { 72, 10, 7 },
                    { 73, 10, 8 },
                    { 74, 10, 9 },
                    { 75, 10, 11 },
                    { 76, 10, 12 },
                    { 77, 10, 13 },
                    { 78, 10, 14 },
                    { 79, 11, 15 },
                    { 80, 11, 16 },
                    { 81, 11, 17 },
                    { 82, 11, 18 },
                    { 83, 11, 19 },
                    { 84, 12, 20 },
                    { 85, 12, 21 },
                    { 86, 12, 22 },
                    { 87, 12, 23 },
                    { 88, 12, 24 },
                    { 89, 12, 25 }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "IdReserva", "FechaFinal", "FechaInicial", "IdPublicacion", "IdUsuario", "NumeroPersonas", "ReservaEstado" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 24, 15, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 20, 15, 45, 0, 0, DateTimeKind.Unspecified), 1, "11bc73ce-dbe2-4370-bc92-0d57e5b366d7", 3, 2 },
                    { 2, new DateTime(2024, 9, 30, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, "26cfe5c9-00f8-411e-b589-df3405a8b798", 2, 0 },
                    { 3, new DateTime(2024, 10, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1", 4, 1 },
                    { 4, new DateTime(2024, 10, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 10, 16, 0, 0, 0, DateTimeKind.Unspecified), 1, "e4309639-4588-4553-8c14-5ce4426e0dd7", 5, 2 },
                    { 5, new DateTime(2024, 10, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 12, 11, 0, 0, 0, DateTimeKind.Unspecified), 2, "11bc73ce-dbe2-4370-bc92-0d57e5b366d7", 2, 0 },
                    { 6, new DateTime(2024, 10, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, "1c8e89f7-7db6-4cd5-907d-f01b058cd784", 4, 1 },
                    { 7, new DateTime(2024, 10, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 18, 8, 30, 0, 0, DateTimeKind.Unspecified), 2, "13825fa6-5c27-4303-ab17-6e13aac24c12", 3, 2 },
                    { 8, new DateTime(2024, 10, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, "230d9aeb-6bca-4faa-b867-2d49e1a8c12e", 6, 0 },
                    { 9, new DateTime(2024, 10, 28, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, "3a895383-b546-4693-8246-924a9fc5289f", 2, 2 },
                    { 10, new DateTime(2024, 10, 30, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, "11bc73ce-dbe2-4370-bc92-0d57e5b366d7", 5, 1 },
                    { 11, new DateTime(2024, 11, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), 4, "26cfe5c9-00f8-411e-b589-df3405a8b798", 4, 2 },
                    { 12, new DateTime(2024, 11, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 30, 11, 0, 0, 0, DateTimeKind.Unspecified), 5, "e4309639-4588-4553-8c14-5ce4426e0dd7", 3, 0 },
                    { 13, new DateTime(2024, 11, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), 6, "13825fa6-5c27-4303-ab17-6e13aac24c12", 2, 2 },
                    { 14, new DateTime(2024, 11, 12, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), 6, "230d9aeb-6bca-4faa-b867-2d49e1a8c12e", 6, 1 },
                    { 15, new DateTime(2024, 11, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 9, "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1", 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "ServiciosAdicionales",
                columns: new[] { "IdServicioAdicional", "IdPublicacion", "IdServicio", "PrecioServicioAdicional" },
                values: new object[,]
                {
                    { 1, 1, 1, 50000m },
                    { 3, 2, 2, 60000m },
                    { 4, 3, 3, 70000m },
                    { 5, 4, 4, 80000m },
                    { 6, 5, 5, 90000m },
                    { 7, 6, 6, 100000m },
                    { 8, 7, 7, 110000m },
                    { 9, 8, 8, 120000m },
                    { 10, 9, 9, 130000m }
                });

            migrationBuilder.InsertData(
                table: "Resenas",
                columns: new[] { "IdResena", "Calificacion", "Fecha", "IdReserva", "MeGusta", "Opinion" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2024, 11, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, "Muy tranquilo, privado y atención personalizada, muy atentos a nuestras necesidades y solicitudes, la llegada fácil a borde de la carretera lo cual es una ventaja para carros bajitos, la comida deliciosa y un personal atento, amable y respetuoso." },
                    { 2, 5, new DateTime(2024, 11, 7, 14, 30, 0, 0, DateTimeKind.Unspecified), 4, 8, "La estancia fue excelente, el lugar es hermoso y muy bien cuidado. La atención del personal fue impecable y siempre estuvieron disponibles para cualquier solicitud. La ubicación es perfecta para quienes buscan paz y tranquilidad." },
                    { 3, 3, new DateTime(2024, 11, 10, 16, 15, 0, 0, DateTimeKind.Unspecified), 7, 2, "El alojamiento es bastante bueno, aunque el servicio podría mejorar en términos de tiempo de respuesta. La limpieza estaba bien, pero la comida no cumplió completamente con nuestras expectativas." },
                    { 4, 4, new DateTime(2024, 11, 12, 9, 45, 0, 0, DateTimeKind.Unspecified), 9, 5, "Un lugar acogedor con un ambiente muy relajante. El personal es amable y la comida es deliciosa. Sin embargo, hubo algunos problemas con la conexión a internet durante nuestra estancia." },
                    { 5, 4, new DateTime(2024, 11, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), 11, 6, "La experiencia fue muy buena en general. Las instalaciones estaban limpias y bien mantenidas. El check-in fue rápido y sin problemas, pero el precio es un poco alto para lo que ofrecen." },
                    { 6, 5, new DateTime(2024, 11, 18, 13, 30, 0, 0, DateTimeKind.Unspecified), 13, 7, "El lugar es encantador y muy cómodo. La atención del personal fue muy buena y hicieron todo lo posible para que nuestra estancia fuera agradable. Recomendado para una escapada de fin de semana." },
                    { 7, 3, new DateTime(2024, 11, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), 15, 3, "Buena ubicación, pero la habitación necesitaba una mejor limpieza. La comida estaba bien, pero no había muchas opciones en el menú. El personal fue amable, aunque a veces parecía desorganizado." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adjuntos_IdMensaje",
                table: "Adjuntos",
                column: "IdMensaje");

            migrationBuilder.CreateIndex(
                name: "IX_Adjuntos_RutaAdjunto",
                table: "Adjuntos",
                column: "RutaAdjunto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Direccion",
                table: "AspNetUsers",
                column: "Direccion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RazonSocial",
                table: "AspNetUsers",
                column: "RazonSocial",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_NombreCategoria",
                table: "Categorias",
                column: "NombreCategoria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_IdPublicacion",
                table: "Favoritos",
                column: "IdPublicacion");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_IdUsuario",
                table: "Favoritos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_FechasNoDisponibles_IdPublicacion",
                table: "FechasNoDisponibles",
                column: "IdPublicacion");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_IdAtencionViajero",
                table: "Mensajes",
                column: "IdAtencionViajero");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_IdUsuario",
                table: "Mensajes",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_IdAliado",
                table: "Publicaciones",
                column: "IdAliado");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionesCategorias_IdCategoria",
                table: "PublicacionesCategorias",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionesCategorias_IdPublicacion",
                table: "PublicacionesCategorias",
                column: "IdPublicacion");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionesFavoritas_IdPublicacion",
                table: "PublicacionesFavoritas",
                column: "IdPublicacion");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionesImagenes_IdPublicacion",
                table: "PublicacionesImagenes",
                column: "IdPublicacion");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionesImagenes_Ruta",
                table: "PublicacionesImagenes",
                column: "Ruta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionesRestricciones_IdPublicacion",
                table: "PublicacionesRestricciones",
                column: "IdPublicacion");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionesRestricciones_IdRestriccion",
                table: "PublicacionesRestricciones",
                column: "IdRestriccion");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionesServicios_IdPublicacion",
                table: "PublicacionesServicios",
                column: "IdPublicacion");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionesServicios_IdServicio",
                table: "PublicacionesServicios",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_Resenas_IdReserva",
                table: "Resenas",
                column: "IdReserva");

            migrationBuilder.CreateIndex(
                name: "IX_ResenasMeGusta_IdResena_IdUsuario",
                table: "ResenasMeGusta",
                columns: new[] { "IdResena", "IdUsuario" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResenasMeGusta_IdUsuario",
                table: "ResenasMeGusta",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdPublicacion",
                table: "Reservas",
                column: "IdPublicacion");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdUsuario",
                table: "Reservas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Restricciones_NombreRestriccion",
                table: "Restricciones",
                column: "NombreRestriccion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_NombreServicio",
                table: "Servicios",
                column: "NombreServicio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosAdicionales_IdPublicacion",
                table: "ServiciosAdicionales",
                column: "IdPublicacion");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosAdicionales_IdServicio",
                table: "ServiciosAdicionales",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_Verificados_IdAliado",
                table: "Verificados",
                column: "IdAliado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adjuntos");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.DropTable(
                name: "FechasNoDisponibles");

            migrationBuilder.DropTable(
                name: "PublicacionesCategorias");

            migrationBuilder.DropTable(
                name: "PublicacionesFavoritas");

            migrationBuilder.DropTable(
                name: "PublicacionesImagenes");

            migrationBuilder.DropTable(
                name: "PublicacionesRestricciones");

            migrationBuilder.DropTable(
                name: "PublicacionesServicios");

            migrationBuilder.DropTable(
                name: "ResenasMeGusta");

            migrationBuilder.DropTable(
                name: "ServiciosAdicionales");

            migrationBuilder.DropTable(
                name: "Verificados");

            migrationBuilder.DropTable(
                name: "Mensajes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Restricciones");

            migrationBuilder.DropTable(
                name: "Resenas");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "AtencionViajeros");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Publicaciones");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
