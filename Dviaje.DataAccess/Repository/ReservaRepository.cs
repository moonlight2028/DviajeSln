using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using System.Data;

namespace Dviaje.DataAccess.Repository
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly IDbConnection _db;


        public ReservaRepository(IDbConnection db)
        {
            _db = db;
        }


        public async Task<ReservaMiReservaVM?> ObtenerReservaMiReservaAsync(int idReserva, string idUsuario)
        {
            var sql = @"
                SELECT r.IdReserva, r.FechaInicial, r.FechaFinal, r.NumeroPersonas, r.Estado AS ReservaEstado,
                p.IdPublicacion, p.Titulo AS TituloPublicacion, p.Puntuacion, p.NumeroResenas, p.Ubicacion,
                u.Id AS IdAliado, u.UserName AS NombreAliado, u.Avatar AS AvatarAliado, u.Verificado AS Verificado,
                pi.Ruta AS Imagen
                FROM Reservas r
                INNER JOIN Publicaciones p ON r.IdPublicacion = p.IdPublicacion
                INNER JOIN aspnetusers u ON p.IdAliado = u.Id
                LEFT JOIN PublicacionesImagenes pi ON pi.IdPublicacion = p.IdPublicacion
                WHERE r.IdReserva = @IdReserva AND r.IdUsuario = @IdUsuario
                ORDER BY pi.Orden 
                LIMIT 5";


            // Datos de test borrar cuando esté la consulta
            ReservaMiReservaVM datosTest = new ReservaMiReservaVM
            {
                IdPublicacion = 1,
                TituloPublicacion = "Titulo publicación ajdsklfjkaldsf adsfjakldsjfl aldkfjlkadsjfl adslkfjkladsjf aadkfjlkadj aldskfjkalds adsfjlkjdkls",
                PuntuacionPublicacion = 4.3m,
                NumeroReseñasPublicacion = 1156,
                Direccion = "Calle 186 #48 - 45",
                DescripcionPublicacion = "La comunicación efectiva es fundamental en todos los aspectos de la vida. Permite expresar ideas, compartir conocimientos y construir relaciones sólidas. En el ámbito profesional, la comunicación clara y precisa es clave para alcanzar objetivos, resolver conflictos y fomentar la colaboración. Además, una buena comunicación ayuda a motivar a los equipos, a mejorar la productividad y a garantizar el éxito en proyectos. Dominar esta habilidad es esencial para el desarrollo personal y profesional en un entorno cada vez más interconectado.",
                IdAliado = "DFSS",
                AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                NombreAliado = "Barca",
                VerificadoAliado = true,
                NumeroPublicacionesAliado = 4562,
                FechaInicial = new DateTime(2023, 11, 18),
                FechaFinal = new DateTime(2023, 11, 20),
                Personas = 10,
                ReservaEstado = ReservaEstado.Aprobado,
                Precio = 464165m,
                ServiciosAdicionalesPublicacion = new List<ServicioVM> {
                    new ServicioVM {
                        NombreServicio = "Tour Guiado por la Ciudad",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        NombreServicio = "Aventura en Montaña",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        NombreServicio = "Spa y Relajación",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        NombreServicio = "Alquiler de Bicicletas",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        NombreServicio = "Clases de Surf",
                        RutaIcono = "fa-solid fa-fire-burner"
                    }
                },
                ServiciosPublicacion = new List<ServicioVM> {
                    new ServicioVM {
                        IdServicio = 1,
                        NombreServicio = "Tour Guiado por la Ciudad",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        IdServicio = 2,
                        NombreServicio = "Aventura en Montaña",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        IdServicio = 3,
                        NombreServicio = "Spa y Relajación",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        IdServicio = 4,
                        NombreServicio = "Alquiler de Bicicletas",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        IdServicio = 5,
                        NombreServicio = "Clases de Surf",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        IdServicio = 6,
                        NombreServicio = "Visita a Viñedos",
                        RutaIcono = "fa-solid fa-fire-burner"
                    },
                    new ServicioVM {
                        IdServicio = 7,
                        NombreServicio = "Cena Romántica",
                        RutaIcono = "fa-solid fa-fire-burner"
                    }
                },
                ImagenesPublicacion = new List<PublicacionImagenVM> {
                    new PublicacionImagenVM{
                        Ruta = "https://images.unsplash.com/photo-1726461974101-d98a3c616dcc?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                        Alt = "Vista panorámica del paisaje al atardecer"
                    },
                    new PublicacionImagenVM{
                        Ruta = "https://images.unsplash.com/photo-1726533870778-8be51bf99bb1?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                        Alt = "Interior de una cabaña de lujo en la montaña"
                    },
                    new PublicacionImagenVM{
                        Ruta = "https://images.unsplash.com/photo-1726715245558-69afa5ded798?q=80&w=1925&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                        Alt = "Turistas disfrutando de una caminata por el bosque"
                    },
                    new PublicacionImagenVM{
                        Ruta = "https://plus.unsplash.com/premium_photo-1699566447802-0551b84a186d?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                        Alt = "Piscina al aire libre con vistas a las montañas"
                    }
                }
            };

            return datosTest;
        }

        public Task<ReservaMiReservaVM?> ObtenerReservaMiReservaPorAliadoAsync(int idReserva, string idAliado)
        {
            throw new NotImplementedException();
        }
        public async Task<List<ReservaTarjetaBasicaVM>?> ObtenerListaReservaTarjetaBasicaVMAsync(string idUsuario, int pagina = 1, int resultadosMostrados = 10, string? estado = null)
        {
            var sql = @"
                    SELECT 
                        r.IdReserva, 
                        r.FechaInicial, 
                        r.FechaFinal, 
                        r.ReservaEstado AS Estado,
                        p.IdPublicacion, 
                        p.Titulo AS TituloPublicacion, 
                        p.Puntuacion AS PuntuacionPublicacion, 
                        p.NumeroResenas AS NumeroResenasPublicacion,
                        (SELECT COUNT(*) FROM Publicaciones WHERE IdAliado = u.Id) AS NumeroPublicacionesPublicacion,
                        pi.Ruta AS ImagenPublicacion,
                        u.Id AS IdAliado, 
                        u.UserName AS NombreAliado, 
                        u.Avatar AS AvatarAliado, 
                        u.Verificado AS VerificadoAliado
                    FROM 
                        Reservas r
                    INNER JOIN 
                        Publicaciones p ON r.IdPublicacion = p.IdPublicacion
                    INNER JOIN 
                        aspnetusers u ON p.IdAliado = u.Id
                    LEFT JOIN 
                        PublicacionesImagenes pi ON pi.IdPublicacion = p.IdPublicacion
                    WHERE 
                        r.IdUsuario = @IdUsuario AND (@Estado IS NULL OR r.ReservaEstado = @Estado)
                    ORDER BY 
                        r.FechaInicial DESC
                    LIMIT 
                        @ResultadosMostrados OFFSET @Offset;
                    ";

            // Cálculo del offset para paginación
            var offset = (pagina - 1) * resultadosMostrados;

            // Parámetros de consulta para Dapper
            var parameters = new
            {
                IdUsuario = idUsuario, // Filtro por el usuario
                Estado = estado,
                ResultadosMostrados = resultadosMostrados,
                Offset = offset
            };

            // Ejecuta la consulta y retorna la lista de reservas
            var reservas = await _db.QueryAsync<ReservaTarjetaBasicaVM>(sql, parameters);

            return reservas.ToList();


            // Datos de test borrar cuando esté la consulta
            List<ReservaTarjetaBasicaVM>? datosTest = new List<ReservaTarjetaBasicaVM> {
                new ReservaTarjetaBasicaVM {
                    IdReserva = 2,
                    FechaInicial = new DateTime(2023, 11, 18),
                    FechaFinal = new DateTime(2023, 11, 20),
                    ReservaEstado = ReservaEstado.Aprobado,
                    IdPublicacion = 1,
                    TituloPublicacion = "Titulo publicación ajdsklfjkaldsf adsfjakldsjfl aldkfjlkadsjfl adslkfjkladsjf aadkfjlkadj aldskfjkalds adsfjlkjdkls",
                    PuntuacionPublicacion = 4.3m,
                    NumeroResenasPublicacion = 4561,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1726266852911-ee5f5b49ea0d?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdAliado = "DASF",
                    NombreAliado = "Barca",
                    AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    VerificadoAliado = true,
                    NumeroPublicacionesPublicacion  = 1542
                },
                new ReservaTarjetaBasicaVM {
                    IdReserva = 3,
                    FechaInicial = new DateTime(2024, 02, 15),
                    FechaFinal = new DateTime(2024, 02, 17),
                    ReservaEstado = ReservaEstado.Activo,
                    IdPublicacion = 2,
                    TituloPublicacion = "Escapada de fin de semana a las montañas",
                    PuntuacionPublicacion = 4.7m,
                    NumeroResenasPublicacion = 59,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1726500087639-0a68be284497?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdAliado = "XYZ123",
                    NombreAliado = "Mountain Escape",
                    AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    VerificadoAliado = true,
                    NumeroPublicacionesPublicacion = 234
                },
                new ReservaTarjetaBasicaVM {
                    IdReserva = 4,
                    FechaInicial = new DateTime(2024, 03, 10),
                    FechaFinal = new DateTime(2024, 03, 12),
                    ReservaEstado = ReservaEstado.Cancelado,
                    IdPublicacion = 3,
                    TituloPublicacion = "Aventura tropical en la playa",
                    PuntuacionPublicacion = 3.8m,
                    NumeroResenasPublicacion = 481,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1726677644019-c010b789cf12?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdAliado = "BEACH789",
                    NombreAliado = "Tropical Vibes",
                    AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    VerificadoAliado = false,
                    NumeroPublicacionesPublicacion = 674
                }
            };

            return datosTest;
        }

        public async Task<int> ObtenerTotalReservas(string idUsuario, string? estado)
        {
            return 10;
        }


        // id del aliado (se guarda en idUsuario, se encuentra en la tabla publicaciones), servicios adicionales que tenga la publicacion
        // 
        public async Task<ReservaCrearVM?> ObtenerReservaCrearVMAsync(int idPublicacion)
        {
            // Consulta para obtener los datos de la publicación, incluyendo el IdAliado como IdUsuario
            var sqlPublicacion = @"
                                SELECT 
                                    p.IdAliado AS IdUsuario,
                                    p.IdPublicacion,
                                    p.Precio AS PrecioTotal
                                FROM 
                                    Publicaciones p
                                WHERE 
                                    p.IdPublicacion = @IdPublicacion;
                                ";

            // Consulta para obtener los servicios adicionales asociados a la publicación
            var sqlServiciosAdicionales = @"
                                SELECT 
                                    sa.IdServicioAdicional, 
                                    sa.Precio, 
                                    s.NombreServicio, 
                                    s.RutaIcono
                                FROM 
                                    ServiciosAdicionales sa
                                INNER JOIN 
                                    Servicios s ON sa.IdServicio = s.IdServicio
                                WHERE 
                                    sa.IdPublicacion = @IdPublicacion;
                                ";

            // Ejecutar la consulta para obtener los datos de la publicación
            var publicacion = await _db.QueryFirstOrDefaultAsync<ReservaCrearVM>(sqlPublicacion, new { IdPublicacion = idPublicacion });

            if (publicacion == null)
            {
                return null; // Si no se encuentra la publicación, retorna null
            }

            // Ejecutar la consulta para obtener los servicios adicionales
            var serviciosAdicionales = await _db.QueryAsync<ServicioAdicionalVM>(sqlServiciosAdicionales, new { IdPublicacion = idPublicacion });

            // Asignar los servicios adicionales a la publicación
            publicacion.ServiciosAdicionales = serviciosAdicionales.ToList();

            return publicacion;





        }

        public async Task<bool> RegistrarReservaAsync(ReservaCrearVM reservaCrearVM)
        {

            try
            {
                // Asegurarse de que la conexión esté abierta antes de comenzar la transacción
                if (_db.State != ConnectionState.Open)
                {
                    _db.Open();  // Usar Open() sincrónico en lugar de OpenAsync()
                }


                using (var transaction = _db.BeginTransaction())
                {
                    try
                    {
                        // Inserción de la reserva en la tabla Reservas
                        var sqlReserva = @"
                INSERT INTO Reservas (FechaReserva, ReservaEstado,  FechaInicial, FechaFinal, NumeroPersonas, PrecioTotal, IdUsuario, IdPublicacion)
                VALUES (@FechaReserva, @Estado, @FechaInicial, @FechaFinal, @NumeroPersonas, @PrecioTotal, @IdUsuario, @IdPublicacion);
                SELECT LAST_INSERT_ID();";  // Obtener el ID de la reserva recién insertada

                        var idReserva = await _db.ExecuteScalarAsync<int>(sqlReserva, new
                        {
                            FechaReserva = DateTime.UtcNow,
                            Estado = ReservaEstado.Activo,
                            FechaInicial = reservaCrearVM.FechaInicial,
                            FechaFinal = reservaCrearVM.FechaFinal,
                            NumeroPersonas = reservaCrearVM.NumeroPersonas,
                            PrecioTotal = reservaCrearVM.PrecioTotal,
                            IdUsuario = reservaCrearVM.IdUsuario,
                            IdPublicacion = reservaCrearVM.IdPublicacion
                        }, transaction);

                        // Verificación de servicios adicionales seleccionados y su inserción en la tabla intermedia
                        if (reservaCrearVM.ServiciosAdicionales != null && reservaCrearVM.ServiciosAdicionales.Any(s => s.Seleccionado))
                        {
                            var sqlServiciosAdicionales = @"
                    INSERT INTO ReservaServicioAdicional (IdReserva, IdServicioAdicional)
                    VALUES (@IdReserva, @IdServicioAdicional);";

                            foreach (var servicio in reservaCrearVM.ServiciosAdicionales.Where(s => s.Seleccionado))
                            {
                                await _db.ExecuteAsync(sqlServiciosAdicionales, new
                                {
                                    IdReserva = idReserva,
                                    IdServicioAdicional = servicio.IdServicioAdicional
                                }, transaction);
                            }
                        }

                        // Confirmar la transacción
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        // Si algo falla, revertir la transacción
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            finally
            {
                // Cerrar la conexión si está abierta
                if (_db.State == ConnectionState.Open)
                {
                    _db.Close();
                }
            }

        }



        public async Task<bool> CancelarReservaAsync(int idReserva, string idUsuario)
        {
            // verifica si esta activa y si pertenece como tal al usuario 
            var verificarReservaSql = @"
                                    SELECT COUNT(*) 
                                    FROM Reservas 
                                    WHERE IdReserva = @IdReserva 
                                    AND IdUsuario = @IdUsuario 
                                    AND ReservaEstado = 'Activo'";

            var existeReserva = await _db.ExecuteScalarAsync<int>(verificarReservaSql, new { IdReserva = idReserva, IdUsuario = idUsuario });

            if (existeReserva == 0)
            {
                return false; // si no pertenece o esta cancelada 
            }

            // ya validada cancelar reserva xd 
            var sql = "UPDATE Reservas SET ReservaEstado = 'Cancelado' WHERE IdReserva = @IdReserva";
            var result = await _db.ExecuteAsync(sql, new { IdReserva = idReserva });

            return result > 0;
        }





        public async Task<ReservaTarjetaResumenVM?> ObtenerReservaTarjetaResumenVMAsync(int idReserva, string idUsuario)
        {
            // obtener los datos de la reserva y la publicación
            var sql = @"
        SELECT 
            r.IdReserva,
            r.FechaInicial,
            r.FechaFinal,
            r.NumeroPersonas AS Personas,
            p.IdPublicacion,
            p.NumeroResenas AS NumeroResenasPublicacion,
            (SELECT COUNT(*) FROM Reservas WHERE IdPublicacion = p.IdPublicacion) AS NumeroReservasPublicacion,
            (SELECT pi.Ruta FROM PublicacionesImagenes pi WHERE pi.IdPublicacion = p.IdPublicacion ORDER BY pi.Orden LIMIT 1) AS ImagenPublicacion
        FROM 
            Reservas r
        INNER JOIN 
            Publicaciones p ON r.IdPublicacion = p.IdPublicacion
        WHERE 
            r.IdReserva = @IdReserva
        AND 
            r.IdUsuario = @IdUsuario;
    ";

            // Ejecutar la consulta utilizando Dapper
            var reservaResumen = await _db.QueryFirstOrDefaultAsync<ReservaTarjetaResumenVM>(sql, new { IdReserva = idReserva, IdUsuario = idUsuario });

            return reservaResumen;
        }


        public async Task<List<ReservaTablaItemVM>?> ObtenerListaReservaTablaItemVMAsync(string idAliado)
        {
            // obtener los detalles de las reservas y las publicaciones asociadas al aliado
            var sql = @"
        SELECT 
            r.IdReserva,
            r.ReservaEstado AS Estado ,
            r.PrecioTotal AS PrecioReserva,
            r.FechaInicial,
            r.FechaFinal,
            u.Id AS IdUsuario,
            u.UserName AS NombreUsuario,
            u.Avatar AS AvatarUsuario,
            p.IdPublicacion,
            p.Titulo AS TituloPublicacion,
            (SELECT pi.Ruta FROM PublicacionesImagenes pi WHERE pi.IdPublicacion = p.IdPublicacion ORDER BY pi.Orden LIMIT 1) AS ImagenPublicacion
        FROM 
            Reservas r
        INNER JOIN 
            Publicaciones p ON r.IdPublicacion = p.IdPublicacion
        INNER JOIN 
            aspnetusers u ON r.IdUsuario = u.Id
        WHERE 
            p.IdAliado = @IdAliado
        ORDER BY 
            r.FechaInicial DESC;
    ";

            // Ejecutar la consulta utilizando Dapper
            var reservas = await _db.QueryAsync<ReservaTablaItemVM>(sql, new { IdAliado = idAliado });

            return reservas.ToList();
        }
    }
}
