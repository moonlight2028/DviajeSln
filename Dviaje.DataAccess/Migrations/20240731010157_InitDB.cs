using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

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
                    Titulo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Puntuacion = table.Column<decimal>(type: "numeric(1,1)", nullable: false),
                    NumeroResenas = table.Column<int>(type: "integer", nullable: false),
                    Descripcion = table.Column<string>(type: "text", maxLength: 1500, nullable: false),
                    Precio = table.Column<double>(type: "numeric(10,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Direccion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
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
                    FechaRespuesta = table.Column<DateTime>(type: "timestamp", nullable: false),
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
