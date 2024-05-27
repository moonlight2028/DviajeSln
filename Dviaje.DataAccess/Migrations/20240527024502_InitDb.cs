using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dviaje.DataAccess.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RutaIcono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Restricciones",
                columns: table => new
                {
                    IdRestriccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRestriccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RutaIcono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restricciones", x => x.IdRestriccion);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    IdServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreServicio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ServicioTipo = table.Column<int>(type: "int", nullable: false),
                    RutaIcono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.IdServicio);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Aliados",
                columns: table => new
                {
                    IdAliado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazonSocial = table.Column<string>(type: "text", maxLength: 40, nullable: false),
                    SitioWeb = table.Column<string>(type: "text", maxLength: 250, nullable: false),
                    Telefono = table.Column<string>(type: "text", maxLength: 15, nullable: false),
                    Direccion = table.Column<string>(type: "text", maxLength: 50, nullable: false),
                    Verificado = table.Column<bool>(type: "bit", nullable: false),
                    AliadoEstado = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliados", x => x.IdAliado);
                    table.ForeignKey(
                        name: "FK_Aliados_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtencionViajeros",
                columns: table => new
                {
                    IdAtencion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAtencion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "text", maxLength: 250, nullable: false),
                    Respuesta = table.Column<string>(type: "text", maxLength: 250, nullable: false),
                    Asunto = table.Column<string>(type: "text", maxLength: 100, nullable: false),
                    FechaRespuesta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtencionViajeroTipoPqrs = table.Column<int>(type: "int", nullable: false),
                    AtencionViajeroPrioridad = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtencionViajeros", x => x.IdAtencion);
                    table.ForeignKey(
                        name: "FK_AtencionViajeros_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    IdPublicacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "text", maxLength: 50, nullable: false),
                    Puntuacion = table.Column<int>(type: "int", nullable: false),
                    NumeroResenas = table.Column<int>(type: "int", nullable: false),
                    CapacidadCamas = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "text", maxLength: 1500, nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "text", maxLength: 50, nullable: false),
                    IdAliado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.IdPublicacion);
                    table.ForeignKey(
                        name: "FK_Publicaciones_Aliados_IdAliado",
                        column: x => x.IdAliado,
                        principalTable: "Aliados",
                        principalColumn: "IdAliado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Verificados",
                columns: table => new
                {
                    IdVerificado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRespuesta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerificadoEstado = table.Column<int>(type: "int", nullable: false),
                    IdAliado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verificados", x => x.IdVerificado);
                    table.ForeignKey(
                        name: "FK_Verificados_Aliados_IdAliado",
                        column: x => x.IdAliado,
                        principalTable: "Aliados",
                        principalColumn: "IdAliado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adjuntos",
                columns: table => new
                {
                    IdAdjunto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RutaAdjunto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAtencion = table.Column<int>(type: "int", nullable: false)
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
                    IdFavorito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdPublicacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => x.IdFavorito);
                    table.ForeignKey(
                        name: "FK_Favoritos_Publicaciones_IdPublicacion",
                        column: x => x.IdPublicacion,
                        principalTable: "Publicaciones",
                        principalColumn: "IdPublicacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favoritos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FechasNoDisponibles",
                columns: table => new
                {
                    IdFechaNoDisponible = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaSinDisponible = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPublicacion = table.Column<int>(type: "int", nullable: false)
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
                    IdPublicacionCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPublicacion = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
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
                    IdPublicacionFavorita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPublicacion = table.Column<int>(type: "int", nullable: false)
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
                    IdPublicacionImagen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ruta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPublicacion = table.Column<int>(type: "int", nullable: false)
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
                    IdPublicacionRestriccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPublicacion = table.Column<int>(type: "int", nullable: false),
                    IdRestriccion = table.Column<int>(type: "int", nullable: false)
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
                    IdPublicacionServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPublicacion = table.Column<int>(type: "int", nullable: false),
                    IdServicio = table.Column<int>(type: "int", nullable: false)
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
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservaEstado = table.Column<int>(type: "int", nullable: false),
                    NumeroPersonas = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdPublicacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Publicaciones_IdPublicacion",
                        column: x => x.IdPublicacion,
                        principalTable: "Publicaciones",
                        principalColumn: "IdPublicacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosAdicionales",
                columns: table => new
                {
                    IdServicioAdicional = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecioServicioAdicional = table.Column<double>(type: "float", nullable: false),
                    IdServicio = table.Column<int>(type: "int", nullable: false),
                    IdPublicacion = table.Column<int>(type: "int", nullable: false)
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
                    IdResena = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opinion = table.Column<string>(type: "text", maxLength: 1500, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: false),
                    MeGusta = table.Column<int>(type: "int", nullable: false),
                    IdPublicacion = table.Column<int>(type: "int", nullable: false),
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resenas", x => x.IdResena);
                    table.ForeignKey(
                        name: "FK_Resenas_Publicaciones_IdPublicacion",
                        column: x => x.IdPublicacion,
                        principalTable: "Publicaciones",
                        principalColumn: "IdPublicacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resenas_Reservas_IdReserva",
                        column: x => x.IdReserva,
                        principalTable: "Reservas",
                        principalColumn: "IdReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "NombreCategoria", "RutaIcono" },
                values: new object[,]
                {
                    { 1, "Finca", "Ruta" },
                    { 2, "Apartamento", "Ruta" },
                    { 3, "Casa", "Ruta" },
                    { 4, "Hotel", "Ruta" },
                    { 5, "Hostal", "Ruta" },
                    { 6, "Cabaña", "Ruta" },
                    { 7, "Villa", "Ruta" },
                    { 8, "Resort", "Ruta" },
                    { 9, "Piso compartido", "Ruta" },
                    { 10, "Finca", "Ruta" }
                });

            migrationBuilder.InsertData(
                table: "Restricciones",
                columns: new[] { "IdRestriccion", "NombreRestriccion", "RutaIcono" },
                values: new object[,]
                {
                    { 1, "Prohibido mascotas", "random" },
                    { 2, "Prohibido mascotas", "random" },
                    { 3, "No fumar", "random" },
                    { 4, "No se permiten fiestas o eventos", "random" },
                    { 5, "Hora de silencio después de las 10 PM", "random" },
                    { 6, "No se permite el acceso a personas no registradas", "random" },
                    { 7, "Máximo 2 personas por habitación", "random" },
                    { 8, "Uso obligatorio de mascarilla en áreas comunes", "random" },
                    { 9, "No se permiten visitantes después de las 8 PM", "random" },
                    { 10, "Lavarse las manos antes de entrar a la piscina", "random" }
                });

            migrationBuilder.InsertData(
                table: "Servicios",
                columns: new[] { "IdServicio", "NombreServicio", "RutaIcono", "ServicioTipo" },
                values: new object[,]
                {
                    { 1, "Cama", "", 0 },
                    { 2, "Gimnasio", "random", 2 },
                    { 3, "Spa", "random", 2 },
                    { 4, "Restaurante", "random", 2 },
                    { 5, "Sala de juegos", "random", 2 },
                    { 6, "Cine", "random", 0 },
                    { 7, "Cancha de tenis", "random", 2 },
                    { 8, "Cancha de baloncesto", "random", 2 },
                    { 9, "Sauna", "random", 0 },
                    { 10, "Bar", "random", 0 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                column: "IdUsuario",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10
                });

            migrationBuilder.InsertData(
                table: "Aliados",
                columns: new[] { "IdAliado", "AliadoEstado", "Direccion", "IdUsuario", "RazonSocial", "SitioWeb", "Telefono", "Verificado" },
                values: new object[,]
                {
                    { 1, 1, "calle me lo calana", 1, "quiero plata", "www.abueno.com", "3333332222", true },
                    { 2, 1, "Avenida Siempre Viva 123", 2, "Finanzas Seguras", "www.finseguras.com", "3111111111", true },
                    { 3, 0, "Calle Luna 456", 3, "Crédito Fácil", "www.creditofacil.com", "3222222222", false },
                    { 4, 1, "Calle Sol 789", 4, "Préstamos Ya", "www.prestamosya.com", "3333333333", true },
                    { 5, 0, "Avenida del Parque 101", 5, "Dinero Rápido", "www.dinerorapido.com", "3444444444", false },
                    { 6, 1, "Calle del Río 202", 6, "Crédito Seguro", "www.creditoseguro.com", "3555555555", true },
                    { 7, 0, "Boulevard del Mar 303", 7, "Préstamo Fácil", "www.prestamofacil.com", "3666666666", false },
                    { 8, 1, "Calle del Sol 404", 8, "Dinero Seguro", "www.dineroseguro.com", "3777777777", true },
                    { 9, 0, "Avenida de las Flores 505", 9, "Préstamos Rápidos", "www.prestamosrapidos.com", "3888888888", false },
                    { 10, 1, "Calle del Bosque 606", 10, "Créditos al Instante", "www.creditosinstante.com", "3999999999", true }
                });

            migrationBuilder.InsertData(
                table: "AtencionViajeros",
                columns: new[] { "IdAtencion", "Asunto", "AtencionViajeroPrioridad", "AtencionViajeroTipoPqrs", "Descripcion", "FechaAtencion", "FechaRespuesta", "IdUsuario", "Respuesta" },
                values: new object[,]
                {
                    { 1, "No funciona la pagina", 2, 0, "No sivre", new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), 1, "A bueno" },
                    { 2, "No puedo hacer una reserva", 0, 1, "Problema con la reserva", new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), 2, "Resuelto" },
                    { 3, "¿Cuál es mi itinerario?", 1, 0, "Consulta sobre el itinerario", new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), 3, "Información enviada" },
                    { 4, "Podrían mejorar el servicio", 1, 3, "Sugerencia para mejorar", new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), 4, "Gracias por la sugerencia" },
                    { 5, "Perdí mi equipaje", 2, 2, "Incidente con el equipaje", new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), 5, "Lo sentimos mucho" },
                    { 6, "¿Qué comida se ofrece a bordo?", 1, 0, "Consulta sobre el servicio de comida", new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), 6, "Información proporcionada" },
                    { 7, "No puedo hacer el check-in online", 2, 1, "Problema con el check-in", new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), 7, "Solucionado" },
                    { 8, "Más opciones de entretenimiento a bordo", 2, 3, "Sugerencia sobre el entretenimiento", new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), 8, "Apreciamos su feedback" },
                    { 9, "¿Cuáles son las tarifas para el próximo mes?", 0, 0, "Consulta sobre tarifas", new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), 9, "Información enviada" },
                    { 10, "Mi vuelo fue cancelado sin previo aviso", 0, 2, "Reclamo por vuelo cancelado", new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), 10, "Estamos investigando" }
                });

            migrationBuilder.InsertData(
                table: "Adjuntos",
                columns: new[] { "IdAdjunto", "IdAtencion", "RutaAdjunto" },
                values: new object[,]
                {
                    { 1, 1, "PDF" },
                    { 2, 2, "Image" },
                    { 3, 3, "Document" },
                    { 4, 4, "Spreadsheet" },
                    { 5, 5, "Presentation" },
                    { 6, 6, "PDF" },
                    { 7, 7, "Image" },
                    { 8, 8, "Document" },
                    { 9, 9, "Spreadsheet" },
                    { 10, 10, "Presentation" }
                });

            migrationBuilder.InsertData(
                table: "Publicaciones",
                columns: new[] { "IdPublicacion", "CapacidadCamas", "Descripcion", "Direccion", "Fecha", "IdAliado", "NumeroResenas", "Precio", "Puntuacion", "Titulo" },
                values: new object[,]
                {
                    { 1, 5, "una ona de relax", "calle diomedez", new DateTime(2024, 5, 26, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2431), 5, 5, 5000.0, 5, "hola colombia" },
                    { 2, 3, "Un lugar lleno de cultura", "Avenida Reforma", new DateTime(2024, 5, 25, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2441), 6, 10, 7000.0, 4, "Descubre México" },
                    { 3, 4, "Explora la magia de los Andes", "Calle de las Flores", new DateTime(2024, 5, 24, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2455), 7, 8, 8000.0, 5, "Aventura en Perú" },
                    { 4, 6, "Disfruta del sol y la playa", "Playa Copacabana", new DateTime(2024, 5, 23, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2465), 8, 12, 9000.0, 4, "Paraíso en Brasil" },
                    { 5, 5, "Descansa en la Patagonia", "Calle San Martín", new DateTime(2024, 5, 22, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2480), 9, 15, 10000.0, 5, "Relax en Argentina" },
                    { 6, 3, "Explora el desierto de Atacama", "Avenida del Mar", new DateTime(2024, 5, 21, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2490), 10, 6, 6000.0, 4, "Encanto en Chile" },
                    { 7, 4, "Descubre el Salar de Uyuni", "Calle Uyuni", new DateTime(2024, 5, 20, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2499), 2, 7, 7500.0, 3, "Aventura en Bolivia" },
                    { 8, 5, "Visita Punta del Este", "Avenida Gorlero", new DateTime(2024, 5, 19, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2514), 1, 9, 8500.0, 5, "Diversión en Uruguay" },
                    { 9, 2, "Relájate en Asunción", "Calle Palma", new DateTime(2024, 5, 18, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2524), 3, 5, 5500.0, 4, "Tranquilidad en Paraguay" },
                    { 10, 6, "Explora las Islas Galápagos", "Avenida Amazonas", new DateTime(2024, 5, 17, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2538), 4, 14, 9500.0, 5, "Maravillas de Ecuador" }
                });

            migrationBuilder.InsertData(
                table: "Verificados",
                columns: new[] { "IdVerificado", "FechaRespuesta", "FechaSolicitud", "IdAliado", "VerificadoEstado" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 26, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2142), new DateTime(2024, 5, 26, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2133), 1, 0 },
                    { 2, new DateTime(2024, 5, 27, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2172), new DateTime(2024, 5, 25, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2152), 2, 0 },
                    { 3, new DateTime(2024, 5, 28, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2196), new DateTime(2024, 5, 24, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2182), 3, 1 },
                    { 4, new DateTime(2024, 5, 29, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2226), new DateTime(2024, 5, 23, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2216), 4, 2 },
                    { 5, new DateTime(2024, 5, 30, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2255), new DateTime(2024, 5, 22, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2235), 5, 0 },
                    { 6, new DateTime(2024, 5, 31, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2289), new DateTime(2024, 5, 21, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2279), 6, 1 },
                    { 7, new DateTime(2024, 6, 1, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2309), new DateTime(2024, 5, 20, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2299), 7, 2 },
                    { 8, new DateTime(2024, 6, 2, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2328), new DateTime(2024, 5, 19, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2318), 8, 0 },
                    { 9, new DateTime(2024, 6, 3, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2353), new DateTime(2024, 5, 18, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2343), 9, 1 },
                    { 10, new DateTime(2024, 6, 4, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2372), new DateTime(2024, 5, 17, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2362), 10, 2 }
                });

            migrationBuilder.InsertData(
                table: "Favoritos",
                columns: new[] { "IdFavorito", "IdPublicacion", "IdUsuario" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 6, 6, 6 },
                    { 7, 7, 7 },
                    { 8, 8, 8 },
                    { 9, 9, 9 },
                    { 10, 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "FechasNoDisponibles",
                columns: new[] { "IdFechaNoDisponible", "FechaSinDisponible", "IdPublicacion" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 26, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(3321), 1 },
                    { 2, new DateTime(2024, 5, 27, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(3335), 2 },
                    { 3, new DateTime(2024, 5, 28, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(3345), 3 },
                    { 4, new DateTime(2024, 5, 29, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(3355), 4 },
                    { 5, new DateTime(2024, 5, 30, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(3365), 5 },
                    { 6, new DateTime(2024, 5, 31, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(3379), 6 },
                    { 7, new DateTime(2024, 6, 1, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(3389), 7 },
                    { 8, new DateTime(2024, 6, 2, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(3399), 8 },
                    { 9, new DateTime(2024, 6, 3, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(3409), 9 },
                    { 10, new DateTime(2024, 5, 26, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(3418), 1 }
                });

            migrationBuilder.InsertData(
                table: "PublicacionesCategorias",
                columns: new[] { "IdPublicacionCategoria", "IdCategoria", "IdPublicacion" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 6, 6, 6 },
                    { 7, 7, 7 },
                    { 8, 8, 8 },
                    { 9, 9, 9 },
                    { 10, 1, 1 }
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
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "PublicacionesImagenes",
                columns: new[] { "IdPublicacionImagen", "IdPublicacion", "Ruta" },
                values: new object[,]
                {
                    { 1, 1, "img/nose/playboy" },
                    { 2, 2, "img/nose/beachview" }
                });

            migrationBuilder.InsertData(
                table: "PublicacionesImagenes",
                columns: new[] { "IdPublicacionImagen", "IdPublicacion", "Ruta" },
                values: new object[,]
                {
                    { 3, 3, "img/nose/mountainview" },
                    { 4, 4, "img/nose/cityscape" },
                    { 5, 5, "img/nose/luxuryroom" },
                    { 6, 6, "img/nose/poolview" },
                    { 7, 7, "img/nose/gardenview" },
                    { 8, 8, "img/nose/rooftopview" },
                    { 9, 9, "img/nose/spa" },
                    { 10, 10, "img/nose/historicalsite" }
                });

            migrationBuilder.InsertData(
                table: "PublicacionesRestricciones",
                columns: new[] { "IdPublicacionRestriccion", "IdPublicacion", "IdRestriccion" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 6, 6, 6 },
                    { 7, 7, 7 },
                    { 8, 8, 8 },
                    { 9, 9, 9 },
                    { 10, 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "PublicacionesServicios",
                columns: new[] { "IdPublicacionServicio", "IdPublicacion", "IdServicio" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 6, 6, 6 },
                    { 7, 7, 7 },
                    { 8, 8, 8 },
                    { 9, 9, 9 },
                    { 10, 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "IdReserva", "FechaFinal", "FechaInicial", "IdPublicacion", "IdUsuario", "NumeroPersonas", "ReservaEstado" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 26, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2641), new DateTime(2024, 5, 26, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2631), 1, 4, 1, 0 },
                    { 2, new DateTime(2024, 5, 28, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2666), new DateTime(2024, 5, 27, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2656), 2, 5, 2, 0 },
                    { 3, new DateTime(2024, 5, 30, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2705), new DateTime(2024, 5, 29, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2675), 3, 6, 3, 1 },
                    { 4, new DateTime(2024, 6, 1, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2724), new DateTime(2024, 5, 31, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2714), 4, 7, 4, 2 },
                    { 5, new DateTime(2024, 6, 3, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2749), new DateTime(2024, 6, 2, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2739), 5, 8, 2, 0 },
                    { 6, new DateTime(2024, 6, 5, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2817), new DateTime(2024, 6, 4, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2807), 6, 9, 1, 1 },
                    { 7, new DateTime(2024, 6, 7, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2842), new DateTime(2024, 6, 6, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2827), 7, 10, 3, 2 },
                    { 8, new DateTime(2024, 6, 9, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2861), new DateTime(2024, 6, 8, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2851), 8, 1, 4, 0 },
                    { 9, new DateTime(2024, 6, 11, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2881), new DateTime(2024, 6, 10, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2871), 9, 2, 2, 1 },
                    { 10, new DateTime(2024, 6, 13, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2905), new DateTime(2024, 6, 12, 21, 45, 1, 476, DateTimeKind.Local).AddTicks(2890), 10, 3, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "ServiciosAdicionales",
                columns: new[] { "IdServicioAdicional", "IdPublicacion", "IdServicio", "PrecioServicioAdicional" },
                values: new object[,]
                {
                    { 1, 1, 1, 50000.0 },
                    { 2, 1, 1, 50000.0 },
                    { 3, 2, 2, 60000.0 },
                    { 4, 3, 3, 70000.0 }
                });

            migrationBuilder.InsertData(
                table: "ServiciosAdicionales",
                columns: new[] { "IdServicioAdicional", "IdPublicacion", "IdServicio", "PrecioServicioAdicional" },
                values: new object[,]
                {
                    { 5, 4, 4, 80000.0 },
                    { 6, 5, 5, 90000.0 },
                    { 7, 6, 6, 100000.0 },
                    { 8, 7, 7, 110000.0 },
                    { 9, 8, 8, 120000.0 },
                    { 10, 9, 9, 130000.0 }
                });

            migrationBuilder.InsertData(
                table: "Resenas",
                columns: new[] { "IdResena", "Calificacion", "Fecha", "IdPublicacion", "IdReserva", "MeGusta", "Opinion" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local), 4, 5, 3, "que ondaaa" },
                    { 2, 5, new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Local), 2, 3, 10, "Excelente servicio y atención." },
                    { 3, 4, new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Local), 5, 1, 7, "La comida estaba deliciosa." },
                    { 4, 5, new DateTime(2024, 5, 23, 0, 0, 0, 0, DateTimeKind.Local), 3, 2, 15, "El lugar es muy acogedor." },
                    { 5, 3, new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Local), 1, 4, 4, "El servicio podría mejorar." },
                    { 6, 3, new DateTime(2024, 5, 21, 0, 0, 0, 0, DateTimeKind.Local), 6, 5, 2, "El precio es un poco alto." },
                    { 7, 5, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Local), 4, 7, 20, "Recomiendo totalmente este lugar." },
                    { 8, 2, new DateTime(2024, 5, 19, 0, 0, 0, 0, DateTimeKind.Local), 7, 6, 1, "No me gustó la atención recibida." },
                    { 9, 4, new DateTime(2024, 5, 18, 0, 0, 0, 0, DateTimeKind.Local), 8, 8, 8, "El ambiente es muy agradable." },
                    { 10, 5, new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Local), 9, 9, 12, "Volvería sin dudarlo." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adjuntos_IdAtencion",
                table: "Adjuntos",
                column: "IdAtencion");

            migrationBuilder.CreateIndex(
                name: "IX_Aliados_IdUsuario",
                table: "Aliados",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_AtencionViajeros_IdUsuario",
                table: "AtencionViajeros",
                column: "IdUsuario");

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
                name: "IX_Resenas_IdPublicacion",
                table: "Resenas",
                column: "IdPublicacion");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adjuntos");

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
                name: "Aliados");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
