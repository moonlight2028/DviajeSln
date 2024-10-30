using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
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

        //Obtener MiReserva, Detalles de la reserva
        public async Task<ReservaMiReservaVM?> ObtenerReservaMiReservaAsync(int idReserva, string idUsuario)
        {
            var sql = @"
                    SELECT r.IdReserva, r.FechaInicial, r.FechaFinal, r.NumeroPersonas, r.ReservaEstado AS ReservaEstado,
                    p.IdPublicacion, p.Titulo AS TituloPublicacion, p.Puntuacion, p.NumeroResenas, p.Direccion,
                    u.Id AS IdAliado, u.UserName AS NombreAliado, u.Avatar AS AvatarAliado, u.Verificado AS Verificado,
                    pi.Ruta AS Imagen
                    FROM Reservas r
                    INNER JOIN Publicaciones p ON r.IdPublicacion = p.IdPublicacion
                    INNER JOIN aspnetusers u ON p.IdAliado = u.Id
                    LEFT JOIN PublicacionesImagenes pi ON pi.IdPublicacion = p.IdPublicacion
                    WHERE r.IdReserva = @IdReserva AND r.IdUsuario = @IdUsuario
                    ORDER BY pi.Orden 
                    LIMIT 5";

            var reserva = await _db.QueryFirstOrDefaultAsync<ReservaMiReservaVM>(sql, new { IdReserva = idReserva, IdUsuario = idUsuario });
            return reserva;
        }



        //Faltante
        public Task<ReservaMiReservaVM?> ObtenerReservaMiReservaPorAliadoAsync(int idReserva, string idAliado)
        {
            throw new NotImplementedException();
        }


        // Obtner las tarjetas de las reservas hechas por el turista
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
            -- Aquí seleccionamos una sola imagen por publicación
            (SELECT pi.Ruta 
             FROM PublicacionesImagenes pi 
             WHERE pi.IdPublicacion = p.IdPublicacion 
             ORDER BY pi.Orden 
             LIMIT 1) AS ImagenPublicacion,
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
        WHERE 
            r.IdUsuario = @IdUsuario 
            AND (@Estado IS NULL OR r.ReservaEstado = @Estado)
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
                IdUsuario = idUsuario,
                Estado = estado,
                ResultadosMostrados = resultadosMostrados,
                Offset = offset
            };

            // Ejecuta la consulta y retorna la lista de reservas
            var reservas = await _db.QueryAsync<ReservaTarjetaBasicaVM>(sql, parameters);

            return reservas.ToList();
        }


        public async Task<int> ObtenerTotalReservas(string idUsuario, string? estado)
        {
            return 10;
        }


        // id del aliado (se guarda en idUsuario, se encuentra en la tabla publicaciones), servicios adicionales que tenga la publicacion

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

        // Crear una reserva 
        public async Task<bool> RegistrarReservaAsync(ReservaCrearVM reservaCrearVM)
        {
            try
            {
                // Conexión
                if (_db.State != ConnectionState.Open)
                {
                    _db.Open();
                }

                // Validación 1: No permitir fechas exageradas
                if (reservaCrearVM.FechaFinal > DateTime.UtcNow.AddYears(1))
                {
                    return false; // La fecha es demasiado posterior
                }

                // Validación 2: No permitir si ya existe una reserva en el mismo rango de fechas
                var sqlVerificarReserva = @"
                                        SELECT COUNT(*)
                                        FROM reservas
                                        WHERE IdUsuario = @IdUsuario
                                        AND IdPublicacion = @IdPublicacion
                                        AND ReservaEstado = 'Activo'
                                        AND ((FechaInicial <= @FechaFinal AND FechaFinal >= @FechaInicial))";

                var reservasConflicto = await _db.ExecuteScalarAsync<int>(sqlVerificarReserva, new
                {
                    IdUsuario = reservaCrearVM.IdUsuario,
                    IdPublicacion = reservaCrearVM.IdPublicacion,
                    FechaInicial = reservaCrearVM.FechaInicial,
                    FechaFinal = reservaCrearVM.FechaFinal
                });

                if (reservasConflicto > 0)
                {
                    return false; // Ya existe una reserva en ese periodo
                }

                using (var transaction = _db.BeginTransaction())
                {
                    try
                    {
                        // Inserción de la reserva en la tabla reservas
                        var sqlReserva = @"
                                        INSERT INTO reservas (FechaReserva, ReservaEstado, FechaInicial, FechaFinal, NumeroPersonas, PrecioTotal, IdUsuario, IdPublicacion)
                                        VALUES (@FechaReserva, @ReservaEstado, @FechaInicial, @FechaFinal, @NumeroPersonas, @PrecioTotal, @IdUsuario, @IdPublicacion);
                                        SELECT LAST_INSERT_ID();";  // Obtener el ID de la reserva recién insertada

                        var idReserva = await _db.ExecuteScalarAsync<int>(sqlReserva, new
                        {
                            FechaReserva = DateTime.UtcNow,
                            ReservaEstado = "Activo",
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
                                                        INSERT INTO reservaserviciosadicionales (IdReserva, IdServicioAdicional)
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




        //Cancelar una rerserva
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




        // obtener el resumen de la tarjeta de reserva
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

            var df = "sdfsd";

            return reservas.ToList();
        }
    }
}
