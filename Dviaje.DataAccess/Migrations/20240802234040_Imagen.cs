using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dviaje.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Imagen : Migration
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
                name: "AtencionViajeros",
                columns: table => new
                {
                    IdAtencion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaAtencion = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Descripcion = table.Column<string>(type: "text", maxLength: 250, nullable: true),
                    Respuesta = table.Column<string>(type: "text", maxLength: 250, nullable: true),
                    Asunto = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FechaRespuesta = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtencionViajeroTipoPqrs = table.Column<int>(type: "integer", nullable: false),
                    AtencionViajeroPrioridad = table.Column<int>(type: "integer", nullable: false),
                    IdUsuario = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtencionViajeros", x => x.IdAtencion);
                    table.ForeignKey(
                        name: "FK_AtencionViajeros_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
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
                    Direccion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IdAliado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.IdPublicacion);
                    table.ForeignKey(
                        name: "FK_Publicaciones_AspNetUsers_IdAliado",
                        column: x => x.IdAliado,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Adjuntos",
                columns: table => new
                {
                    IdAdjunto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RutaAdjunto = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IdAtencion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adjuntos", x => x.IdAdjunto);
                    table.ForeignKey(
                        name: "FK_Adjuntos_AtencionViajeros_IdAtencion",
                        column: x => x.IdAtencion,
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
                    PrecioServicioAdicional = table.Column<double>(type: "numeric(10,2)", nullable: false),
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
                columns: new[] { "Id", "AccessFailedCount", "AliadoEstado", "Aliado_Avatar", "ConcurrencyStamp", "Direccion", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RazonSocial", "SecurityStamp", "SitioWeb", "TwoFactorEnabled", "UserName", "Verificado" },
                values: new object[] { "01bfd429-16ea-44b3-902c-794e2c78dfa7", 0, 0, "https://images.unsplash.com/photo-1609137144813-7d9921338f24?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8dHVyaXNtfGVufDB8fDB8fHwy", "db42ec69-852e-4754-9153-78e817763c2d", "Carrera 7 # 45-23", "Aliado", "info@colombiaadventure.com", true, false, null, "INFO@COLOMBIAADVENTURE.COM", "COLOMBIAADV", null, "3216549870", true, "Colombia Adventure", "275e9fc2-af0e-4a41-bbd9-064bcd4a5445", "www.colombiaadventure.com", false, "ColombiaAdv", true });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11bc73ce-dbe2-4370-bc92-0d57e5b366d7", 0, "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8YXZhdGFyfGVufDB8fDB8fHww", "c2770f35-eec7-4d30-ba1d-d3133c71ce4e", "Usuario", "andres@gmail.com", true, false, null, "ANDRES@GMAIL.COM", "ANDRES", null, "3159725595", true, "4671b455-889b-49ea-bb2e-1eab9f4e4ec0", false, "Andres" },
                    { "13825fa6-5c27-4303-ab17-6e13aac24c12", 0, "https://images.unsplash.com/photo-1543610892-0b1f7e6d8ac1?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww", "d87b850c-778e-4b7a-872b-695f57946e47", "Usuario", "fernando@yahoo.com", true, false, null, "FERNANDO@YAHOO.COM", "FERNANDO", null, "3198765432", true, "4b1537d2-9c7e-4c8b-8915-4795de1abfa0", false, "Fernando" },
                    { "1c8e89f7-7db6-4cd5-907d-f01b058cd784", 0, "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OHx8YXZhdGFyfGVufDB8fDB8fHww", "3260163f-6a81-4d0a-988e-67288ead02b9", "Usuario", "isabella@gmail.com", true, false, null, "ISABELLA@GMAIL.COM", "ISABELLA", null, "3179876543", true, "c5b2b5c4-f178-4af9-88fb-55bed3a6040c", false, "Isabella" },
                    { "230d9aeb-6bca-4faa-b867-2d49e1a8c12e", 0, "https://plus.unsplash.com/premium_photo-1670884441012-c5cf195c062a?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OXx8YXZhdGFyfGVufDB8fDB8fHww", "9ab4c3b6-3cce-4cb7-9b5a-1ad4ed53a83e", "Usuario", "ana@hotmail.com", true, false, null, "ANA@HOTMAIL.COM", "ANA", null, "3149876543", true, "673119d5-58ce-4d72-af2c-2fffbc0da5cb", false, "Ana" },
                    { "26cfe5c9-00f8-411e-b589-df3405a8b798", 0, "https://plus.unsplash.com/premium_photo-1658527049634-15142565537a?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8YXZhdGFyfGVufDB8fDB8fHww", "17499518-3714-4485-bc2a-249225083ae6", "Usuario", "maria@gmail.com", true, false, null, "MARIA@GMAIL.COM", "MARIA", null, "3101234567", true, "d1129c2f-6c8e-44b8-9a32-8bc2f7779c78", false, "Maria" },
                    { "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1", 0, "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8YXZhdGFyfGVufDB8fDB8fHww", "904a01ba-aded-45ba-8a1a-6194fbd0646b", "Usuario", "carlos@yahoo.com", true, false, null, "CARLOS@YAHOO.COM", "CARLOS", null, "3189876543", true, "3cf35e4a-4ad8-4132-8383-cf04ee2c0a8e", false, "Carlos" },
                    { "2e59aa62-61bd-4c8d-9a3d-13f461696eab", 0, "https://images.unsplash.com/photo-1623582854588-d60de57fa33f?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fGF2YXRhcnxlbnwwfHwwfHx8MA%3D%3D", "c98ca6ee-01fd-410d-aa5b-7d5cc3a2e084", "Usuario", "jorge@outlook.com", true, false, null, "JORGE@OUTLOOK.COM", "JORGE", null, "3151234567", true, "b667053c-0dda-450e-892f-b4f66db97e48", false, "Jorge" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AliadoEstado", "Aliado_Avatar", "ConcurrencyStamp", "Direccion", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RazonSocial", "SecurityStamp", "SitioWeb", "TwoFactorEnabled", "UserName", "Verificado" },
                values: new object[] { "39e10980-4df3-494a-bbe7-410e105f6551", 0, 0, "https://images.unsplash.com/photo-1543746746-46047c4f4bb0?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8dHVyaXNtfGVufDB8fDB8fHwy", "192606d1-898e-4144-ace0-13977608180d", "Centro Histórico, Carrera 2 # 10-55", "Aliado", "info@santamartaadventures.com", true, false, null, "INFO@SANTAMARTAADVENTURES.COM", "SANTAMARTAADV", null, "3154321098", true, "Santa Marta Adventures", "42b1d00b-1258-49c0-b9ec-f24286b7bf66", "www.santamartaadventures.com", false, "SantaMartaAdv", true });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3a895383-b546-4693-8246-924a9fc5289f", 0, "https://images.unsplash.com/photo-1535713875002-d1d0cf377fde?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8YXZhdGFyfGVufDB8fDB8fHww", "1ac2642b-e2c0-4443-9e8c-5e3b0ed3bd44", "Usuario", "luis@outlook.com", true, false, null, "LUIS@OUTLOOK.COM", "LUIS", null, "3112345678", true, "084840d3-6e59-4e22-984d-b79f00b3c254", false, "Luis" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AliadoEstado", "Aliado_Avatar", "ConcurrencyStamp", "Direccion", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RazonSocial", "SecurityStamp", "SitioWeb", "TwoFactorEnabled", "UserName", "Verificado" },
                values: new object[,]
                {
                    { "4c03648f-7727-4e5c-b096-fcbe3b9e3059", 0, 0, "https://images.unsplash.com/photo-1492294112339-ea831887e5d7?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OXx8dHVyaXNtfGVufDB8fDB8fHwy", "d87ab239-9aa8-4c41-8432-4c562f58f179", "Vía 40 # 72-20", "Aliado", "hello@barranquillaescapes.com", true, false, null, "HELLO@BARRANQUILLAESCAPES.COM", "BQUILLAESCAPES", null, "3140987654", true, "Barranquilla Escapes", "c34861f5-d240-4ca5-97c8-16071a21eb65", "www.barranquillaescapes.com", false, "BquillaEscapes", false },
                    { "5cf9f86f-36db-4d17-8ec3-cad66cd7f10f", 0, 0, "https://images.unsplash.com/photo-1532878056386-1e96eb5221ad?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fHR1cmlzbXxlbnwwfHwwfHx8Mg%3D%3D", "533c43cf-e786-4f9f-856c-bcc8ed7282e9", "Centro, Carrera 23 # 17-18", "Aliado", "contact@manizaleswonders.com", true, false, null, "CONTACT@MANIZALESWONDERS.COM", "MANIZALESWONDERS", null, "3165432109", true, "Manizales Wonders", "a3280a47-0cd8-43c3-b5b5-4f1e2d77ea73", "www.manizaleswonders.com", false, "ManizalesWonders", false },
                    { "6e291ab8-a9b5-4a7a-afbc-bbbd71b6291b", 0, 0, "https://images.unsplash.com/photo-1463839346397-8e9946845e6d?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTB8fHR1cmlzbXxlbnwwfHwwfHx8Mg%3D%3D", "8df16be6-9e8e-4fce-9bbe-828cde8063c1", "Cabecera, Carrera 33 # 45-67", "Aliado", "support@bucaramangajourneys.com", true, false, null, "SUPPORT@BUCARAMANGAJOURNEYS.COM", "BUCARAJOURNEYS", null, "3229876543", true, "Bucaramanga Journeys", "21f6c91c-33e3-4fdc-bd3b-dc01a77dfb91", "www.bucaramangajourneys.com", false, "BucaraJourneys", false },
                    { "8142c33b-ee02-4a13-b0c1-1e941387433d", 0, 0, "https://images.unsplash.com/photo-1691225409811-a64942a0596a?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8dHVyaXNtfGVufDB8fDB8fHwy", "5527b730-9738-4621-b8cc-83f113c992c0", "Bocagrande, Avenida San Martín # 11-43", "Aliado", "support@cartagenagetaways.com", true, false, null, "SUPPORT@CARTAGENAGETAWAYS.COM", "CARTAGENAGETAWAYS", null, "3176543210", true, "Cartagena Getaways", "b6e82f5a-53c3-4ca6-93a2-74f9bbfc5665", "www.cartagenagetaways.com", false, "CartagenaGetaways", true },
                    { "96067e6f-c29b-46ab-9ba1-18ec7b6534f4", 0, 0, "https://images.unsplash.com/photo-1519998334409-c7c6b1147f65?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fHR1cmlzbXxlbnwwfHwwfHx8Mg%3D%3D", "70f88e6f-5f97-4cf1-ad8c-c94816ccd6c6", "Avenida Circunvalar # 18-10", "Aliado", "info@pereiratravels.com", true, false, null, "INFO@PEREIRATRAVELS.COM", "PEREIRATRAVELS", null, "3107654321", true, "Pereira Travels", "84b6bfe8-fe66-4e2b-a27d-f4d059d5c225", "www.pereiratravels.com", false, "PereiraTravels", false },
                    { "9cd842af-b711-44cc-aa5e-3863e3c30b76", 0, 0, "https://images.unsplash.com/photo-1678009859747-9f4620e0c355?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8dHVyaXNtfGVufDB8fDB8fHwy", "e7d991cf-ec23-4191-b911-2e724f366711", "Avenida 6 # 12-34", "Aliado", "contact@bogotatours.co", true, false, null, "CONTACT@BOGOTATOURS.CO", "BOGOTATOURS", null, "3123456789", true, "Bogotá Tours", "fccfc3b2-476a-40f1-a079-3b3c50614efa", "www.bogotatours.co", false, "BogotaTours", true },
                    { "c3733288-b354-445d-95da-4c655c3220b3", 0, 0, "https://images.unsplash.com/photo-1523345863760-5b7f3472d14f?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OHx8dHVyaXNtfGVufDB8fDB8fHwy", "40c477f6-505d-4660-8105-46e5da10911f", "Barrio San Antonio, Carrera 10 # 5-32", "Aliado", "contact@caliexperiences.com", true, false, null, "CONTACT@CALIEXPERIENCES.COM", "CALIEXP", null, "3132109876", true, "Cali Experiences", "e0784ba1-c2c3-4050-9df5-486882cc71fd", "www.caliexperiences.com", false, "CaliExp", true },
                    { "c654adef-5f0c-48e6-946a-52706f8ac520", 0, 0, "https://images.unsplash.com/photo-1673213314908-5b1863e742d1?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8dHVyaXNtfGVufDB8fDB8fHwy", "6dbfb752-43f8-4b30-a4c5-5e269927cb24", "Calle 80 # 25-67", "Aliado", "hello@medellinexplore.com", true, false, null, "HELLO@MEDELLINEXPLORE.COM", "MEDELLINEXPLORE", null, "3198765432", true, "Medellín Explore", "b28568fe-709d-4205-b0a8-2658a1ac9358", "www.medellinexplore.com", false, "MedellinExplore", true }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "ca0a0328-0f5b-4ff3-b40e-6ffa8d145abb", 0, "https://images.unsplash.com/photo-1706885093487-7eda37b48a60?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTl8fGF2YXRhcnxlbnwwfHwwfHx8MA%3D%3D", "d025d057-7f75-4300-85ad-550aa3eac7b9", "Usuario", "gabriela@gmail.com", true, false, null, "GABRIELA@GMAIL.COM", "GABRIELA", null, "3169876543", true, "934d56e6-1015-442e-a2e3-b328d75d0012", false, "Gabriela" },
                    { "e4309639-4588-4553-8c14-5ce4426e0dd7", 0, "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8YXZhdGFyfGVufDB8fDB8fHww", "9faa103a-fb16-400e-9dd2-87ec45dd02ec", "Usuario", "sofia@hotmail.com", true, false, null, "SOFIA@HOTMAIL.COM", "SOFIA", null, "3123456789", true, "49cef4bd-9437-44a9-9be8-e42d05811d42", false, "Sofia" }
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
                    { "1717add7-89b4-4bf7-990f-a9f10f18aa39", "e4309639-4588-4553-8c14-5ce4426e0dd7" }
                });

            migrationBuilder.InsertData(
                table: "AtencionViajeros",
                columns: new[] { "IdAtencion", "Asunto", "AtencionViajeroPrioridad", "AtencionViajeroTipoPqrs", "Descripcion", "FechaAtencion", "FechaRespuesta", "IdUsuario", "Respuesta" },
                values: new object[,]
                {
                    { 1, "Queja por Servicio de Visita Guiada Retrasada el 25 de Julio", 2, 1, "Me gustaría presentar una queja sobre el servicio recibido el pasado 25 de julio de 2024 a través de su plataforma de turismo. Ese día, tenía programada una visita guiada para las 10:00 a.m. en el centro histórico, pero la guía no llegó hasta las 11:30 a.m., sin ninguna explicación por parte del equipo de soporte. Además, la atención recibida fue poco profesional, ya que la guía no pudo responder adecuadamente a mis preguntas sobre los lugares visitados. Agradecería una revisión de este caso y una explicación sobre lo ocurrido, así como las medidas que se tomarán para evitar que situaciones similares se repitan en el futuro. /n Adjunto capturas de pantalla de los correos de confirmación de mi reserva y del pago realizado como referencia.", new DateTime(2024, 7, 25, 10, 30, 50, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 30, 7, 39, 20, 0, DateTimeKind.Unspecified), "11bc73ce-dbe2-4370-bc92-0d57e5b366d7", "Gracias por comunicarse con nosotros y por informarnos sobre su experiencia con nuestro servicio el 25 de julio de 2024. Lamentamos sinceramente los inconvenientes que experimentó durante su visita guiada y cualquier insatisfacción que esto le haya causado. /n Hemos revisado su caso y constatamos que hubo un problema de programación inesperado que retrasó la llegada de la guía. Apreciamos su paciencia y comprensión en esta situación. Hemos tomado medidas para mejorar nuestros procesos de planificación y comunicación con el equipo de guías para asegurarnos de que este tipo de incidentes no se repitan. /n Además, como gesto de disculpa, nos gustaría ofrecerle un reembolso completo del costo de su reserva y un descuento del 20% en su próxima visita con nosotros. Un representante de nuestro equipo se pondrá en contacto con usted en breve para gestionar el reembolso. /n Gracias por su comprensión y por darnos la oportunidad de corregir este error. Valoramos mucho su opinión y esperamos poder servirle mejor en el futuro." },
                    { 2, "Problemas Técnicos con la Aplicación de Audio-Guía", 2, 1, "Durante mi visita al museo el 20 de julio de 2024, experimenté varios problemas técnicos con la aplicación de audio-guía. La aplicación se cerraba inesperadamente, y no pude escuchar la mayoría de las explicaciones. Adjunto capturas de pantalla de los errores.", new DateTime(2024, 7, 20, 15, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), "26cfe5c9-00f8-411e-b589-df3405a8b798", "Gracias por informarnos sobre los problemas técnicos que experimentó el 20 de julio de 2024. Hemos identificado el problema y estamos trabajando para solucionarlo. Como compensación, le ofrecemos un pase gratuito para su próxima visita." },
                    { 3, "Información sobre Tour Ecológico", 2, 0, "Solicito información adicional sobre el tour ecológico programado para el 15 de agosto de 2024. Me gustaría conocer más sobre las actividades incluidas y el equipo necesario.", new DateTime(2024, 7, 15, 12, 10, 30, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 16, 8, 45, 0, 0, DateTimeKind.Unspecified), "2c49ebc9-3bcd-4f22-a87e-186a1c0c55e1", "Gracias por su interés en nuestro tour ecológico. El tour incluye caminatas guiadas, observación de fauna y flora, y un taller de reciclaje. Se recomienda llevar ropa cómoda, repelente y cámara." },
                    { 4, "Cancelación de Reserva de Tour Gastronómico", 1, 0, "Deseo cancelar mi reserva para el tour gastronómico del 22 de julio de 2024 debido a un cambio de planes. Adjunto el número de reserva.", new DateTime(2024, 7, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), "e4309639-4588-4553-8c14-5ce4426e0dd7", "Hemos procesado la cancelación de su reserva para el tour gastronómico del 22 de julio de 2024. Se ha iniciado el reembolso correspondiente, que debería reflejarse en su cuenta en 5-7 días hábiles." },
                    { 5, "Agradecimiento por Excelente Servicio en Tour de Aventura", 1, 3, "Me gustaría felicitar al equipo por el excelente servicio recibido durante el tour de aventura el 8 de julio de 2024. La guía fue muy profesional y las actividades bien organizadas.", new DateTime(2024, 7, 10, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 11, 8, 15, 0, 0, DateTimeKind.Unspecified), "3a895383-b546-4693-8246-924a9fc5289f", "Gracias por sus amables palabras y por reconocer el esfuerzo de nuestro equipo. Compartiremos sus comentarios con la guía y el resto del equipo. Nos alegra que haya disfrutado de su experiencia." },
                    { 6, "Retraso en el Servicio de Traslado al Aeropuerto", 1, 1, "El vehículo asignado para el traslado al aeropuerto el 22 de julio de 2024 no llegó a tiempo, y casi perdí mi vuelo. Agradecería una explicación y compensación por este inconveniente.", new DateTime(2024, 7, 22, 11, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), "01bfd429-16ea-44b3-902c-794e2c78dfa7", "Lamentamos sinceramente el retraso en su traslado al aeropuerto el 22 de julio de 2024. Investigamos el incidente y estamos mejorando nuestros procesos de logística. Le ofrecemos un descuento del 30% en su próximo servicio de traslado." },
                    { 7, "Consulta sobre Disponibilidad de Tours Privados para Familias", 0, 0, "Me gustaría saber si hay disponibilidad de tours privados para familias en agosto de 2024 y cuáles serían las opciones y precios.", new DateTime(2024, 7, 17, 13, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9cd842af-b711-44cc-aa5e-3863e3c30b76", null },
                    { 8, "Sugerencia para Mejorar la Aplicación Móvil", 0, 3, "Me gustaría proponer una mejora en su aplicación móvil. Sería útil poder descargar itinerarios y mapas para usarlos sin conexión.", new DateTime(2024, 7, 12, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c654adef-5f0c-48e6-946a-52706f8ac520", null },
                    { 9, "Falta de Confirmación de Reserva para Tour de Playa", 0, 2, "No recibí el correo de confirmación para mi reserva del tour de playa el 15 de julio de 2024. Adjunto el recibo de pago como comprobante.", new DateTime(2024, 7, 8, 8, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8142c33b-ee02-4a13-b0c1-1e941387433d", null },
                    { 10, "Agradecimiento por Tour Cultural", 0, 3, "Quisiera expresar mi satisfacción por el excelente servicio recibido durante el tour cultural el 3 de julio de 2024. La organización fue impecable y la guía muy conocedora.", new DateTime(2024, 7, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "39e10980-4df3-494a-bbe7-410e105f6551", null }
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
                columns: new[] { "IdAdjunto", "IdAtencion", "RutaAdjunto" },
                values: new object[,]
                {
                    { 1, 1, "https://DViaje.com/adjuntos/queja_tourrtt.jpg" },
                    { 2, 2, "https://DViaje.com/adjuntos/queja_tour.jpg" },
                    { 3, 3, "https://DViaje.com/adjuntos/confirmacion_pago.pdf" },
                    { 4, 3, "https://DViaje.com/adjuntos/itinerario_tour.pdf" },
                    { 5, 4, "https://DViaje.com/adjuntos/felicitacion_tour.jpg" },
                    { 6, 4, "https://DViaje.com/adjuntos/reembolso_traslado.pdf" },
                    { 7, 9, "https://DViaje.com/adjuntos/informacion_tour.pdf" },
                    { 8, 6, "https://DViaje.com/adjuntos/sugerencia_app.jpg" },
                    { 9, 7, "https://DViaje.com/adjuntos/comprobante_reserva.jpg" },
                    { 10, 1, "https://DViaje.com/adjuntos/agradecimiento_tour.jpg" },
                    { 11, 8, "https://DViaje.com/adjuntos/problema_pago.jpg" },
                    { 12, 3, "https://DViaje.com/adjuntos/comprobantesde_reserva.jpg" },
                    { 13, 3, "https://DViaje.com/adjuntos/agradecimientosss_tour.jpg" },
                    { 14, 9, "https://DViaje.com/adjuntos/problemaconid_pago.jpg" }
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
                columns: new[] { "IdPublicacionImagen", "IdPublicacion", "Ruta" },
                values: new object[,]
                {
                    { 1, 1, "https://images.unsplash.com/photo-1707343848552-893e05dba6ac?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 2, 1, "https://images.unsplash.com/photo-1500835556837-99ac94a94552?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 3, 1, "https://images.unsplash.com/photo-1469854523086-cc02fe5d8800?q=80&w=1421&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 4, 1, "https://unsplash.com/es/fotos/avion-en-el-cielo-durante-la-hora-dorada-M0AWNxnLaMw" },
                    { 5, 1, "https://images.unsplash.com/photo-1504598318550-17eba1008a68?q=80&w=1372&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 6, 2, "https://images.unsplash.com/photo-1476514525535-07fb3b4ae5f1?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 7, 2, "https://images.unsplash.com/photo-1473163928189-364b2c4e1135?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 8, 2, "https://images.unsplash.com/photo-1483683804023-6ccdb62f86ef?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 9, 3, "https://images.unsplash.com/photo-1512100356356-de1b84283e18?q=80&w=1375&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 10, 3, "https://images.unsplash.com/photo-1533104816931-20fa691ff6ca?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 11, 3, "https://images.unsplash.com/photo-1494783367193-149034c05e8f?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 12, 3, "https://images.unsplash.com/photo-1533105079780-92b9be482077?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 13, 3, "https://images.unsplash.com/photo-1719937206491-ed673f64be1f?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 14, 3, "https://images.unsplash.com/photo-1499063078284-f78f7d89616a?q=80&w=1528&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 15, 3, "https://images.unsplash.com/photo-1522199710521-72d69614c702?q=80&w=1472&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 16, 4, "https://images.unsplash.com/photo-1500530855697-b586d89ba3ee?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 17, 4, "https://images.unsplash.com/photo-1512757776214-26d36777b513?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 18, 4, "https://images.unsplash.com/photo-1496950866446-3253e1470e8e?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 19, 4, "https://images.unsplash.com/photo-1476900543704-4312b78632f8?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 20, 4, "https://images.unsplash.com/photo-1707344088547-3cf7cea5ca49?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 21, 5, "https://images.unsplash.com/photo-1530841377377-3ff06c0ca713?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 22, 5, "https://images.unsplash.com/photo-1506929562872-bb421503ef21?q=80&w=1368&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 23, 6, "https://images.unsplash.com/photo-1568849676085-51415703900f?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 24, 6, "https://images.unsplash.com/photo-1467269204594-9661b134dd2b?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 25, 6, "https://images.unsplash.com/photo-1516483638261-f4dbaf036963?q=80&w=1372&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 26, 6, "https://images.unsplash.com/photo-1504150558240-0b4fd8946624?q=80&w=1528&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 27, 6, "https://images.unsplash.com/photo-1527631746610-bca00a040d60?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 28, 6, "https://images.unsplash.com/photo-1446160657592-4782fb76fb99?q=80&w=1469&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 29, 6, "https://images.unsplash.com/photo-1500301111609-42f1aa6df72a?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 30, 6, "https://images.unsplash.com/photo-1500815845799-7748ca339f27?q=80&w=1527&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 31, 8, "https://images.unsplash.com/photo-1507525428034-b723cf961d3e?q=80&w=1473&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 32, 8, "https://images.unsplash.com/photo-1526784725085-c69e947bf92e?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 33, 8, "https://images.unsplash.com/photo-1471623320832-752e8bbf8413?q=80&w=1410&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 34, 8, "https://images.unsplash.com/photo-1528164344705-47542687000d?q=80&w=1492&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 35, 8, "https://images.unsplash.com/photo-1491800943052-1059ce1e1012?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 36, 8, "https://images.unsplash.com/photo-1551918120-9739cb430c6d?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 37, 9, "https://images.unsplash.com/photo-1548625149-720134d51a3a?q=80&w=1528&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 38, 9, "https://images.unsplash.com/photo-1492693429561-1c283eb1b2e8?q=80&w=1480&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 39, 9, "https://images.unsplash.com/photo-1532347922424-c652d9b7208e?q=80&w=1372&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 40, 9, "https://images.unsplash.com/photo-1567069160354-f25b26e62fa1?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 41, 9, "https://images.unsplash.com/photo-1705588217460-d548807940ad?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 42, 10, "https://images.unsplash.com/photo-1558352541-95f7ac02fff2?q=80&w=1632&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 43, 10, "https://images.unsplash.com/photo-1558461670-abf3421e18b6?q=80&w=1632&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 44, 10, "https://images.unsplash.com/photo-1480497209098-7b9e9555bcee?q=80&w=1376&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 45, 10, "https://images.unsplash.com/photo-1502489597346-dad15683d4c2?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 46, 10, "https://images.unsplash.com/photo-1679420438051-19bd5aad4d67?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 47, 10, "https://images.unsplash.com/photo-1692308516530-5ffc490476a8?q=80&w=1528&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 48, 10, "https://images.unsplash.com/photo-1704803269187-d6eb334ea5fe?q=80&w=1472&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adjuntos_IdAtencion",
                table: "Adjuntos",
                column: "IdAtencion");

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
                name: "IX_AspNetUsers_Avatar",
                table: "AspNetUsers",
                column: "Avatar",
                unique: true);

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
                name: "IX_AtencionViajeros_IdUsuario",
                table: "AtencionViajeros",
                column: "IdUsuario");

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
                name: "Resenas");

            migrationBuilder.DropTable(
                name: "ServiciosAdicionales");

            migrationBuilder.DropTable(
                name: "Verificados");

            migrationBuilder.DropTable(
                name: "AtencionViajeros");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Restricciones");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Publicaciones");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
