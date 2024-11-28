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

        //Obtener MiReserva, Detalles de la reserva
        public async Task<ReservaMiReservaVM?> ObtenerReservaMiReservaAsync(int idReserva, string idUsuario)
        {
            var sql = @"
    SELECT 
        r.IdReserva, 
        r.FechaInicial, 
        r.FechaFinal, 
        r.ReservaEstado AS ReservaEstado,
        p.IdPublicacion, 
        p.Titulo AS TituloPublicacion, 
        p.Puntuacion, 
        p.NumeroResenas, 
        p.Direccion,
        u.Id AS IdAliado, 
        u.UserName AS NombreAliado, 
        u.Avatar AS AvatarAliado,
        (SELECT pi.Ruta 
         FROM publicacionesimagenes pi 
         WHERE pi.IdPublicacion = p.IdPublicacion 
         ORDER BY pi.Orden 
         LIMIT 1) AS Imagen
    FROM 
        reservas r
    INNER JOIN 
        publicaciones p ON r.IdPublicacion = p.IdPublicacion
    INNER JOIN 
        aspnetusers u ON p.IdAliado = u.Id
    WHERE 
        r.IdReserva = @IdReserva 
        AND r.IdUsuario = @IdUsuario";

            var reserva = await _db.QueryFirstOrDefaultAsync<ReservaMiReservaVM>(sql, new { IdReserva = idReserva, IdUsuario = idUsuario });
            return reserva;
        }




        //obtner reservas de los turistas, por parte se publicacion generada
        public async Task<ReservaMiReservaVM?> ObtenerReservaMiReservaPorAliadoAsync(int idReserva, string idAliado)
        {
            var sql = @"
        SELECT 
            r.FechaInicial, 
            r.FechaFinal, 
            r.NumeroPersonas AS Personas, 
            r.ReservaEstado, 
            r.PrecioTotal AS Precio, 
            p.IdPublicacion, 
            p.Titulo AS TituloPublicacion, 
            p.Descripcion AS DescripcionPublicacion, 
            p.Puntuacion AS PuntuacionPublicacion, 
            p.NumeroResenas AS NumeroReseñasPublicacion,
            (SELECT JSON_ARRAYAGG(JSON_OBJECT('Ruta', pi.Ruta, 'Alt', pi.Alt, 'Orden', pi.Orden))
             FROM publicacionesimagenes pi
             WHERE pi.IdPublicacion = p.IdPublicacion) AS ImagenesPublicacion,
            u.Id AS IdAliado,
            u.UserName AS NombreAliado,
            u.Avatar AS AvatarAliado,
            (SELECT COUNT(*) 
             FROM publicaciones 
             WHERE IdAliado = u.Id) AS NumeroPublicacionesAliado,
            u.Verificado AS VerificadoAliado
        FROM 
            reservas r
        INNER JOIN 
            publicaciones p ON r.IdPublicacion = p.IdPublicacion
        INNER JOIN 
            aspnetusers u ON p.IdAliado = u.Id
        WHERE 
            r.IdReserva = @IdReserva 
            AND u.Id = @IdAliado";

            var reserva = await _db.QueryFirstOrDefaultAsync<ReservaMiReservaVM>(sql, new { IdReserva = idReserva, IdAliado = idAliado });
            return reserva;
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
            (SELECT COUNT(*) 
             FROM publicaciones 
             WHERE IdAliado = u.Id) AS NumeroPublicacionesPublicacion,
            (SELECT pi.Ruta 
             FROM publicacionesimagenes pi 
             WHERE pi.IdPublicacion = p.IdPublicacion 
             ORDER BY pi.Orden 
             LIMIT 1) AS ImagenPublicacion,
            u.Id AS IdAliado, 
            u.UserName AS NombreAliado, 
            u.Avatar AS AvatarAliado, 
            u.Verificado AS VerificadoAliado
        FROM 
            reservas r
        INNER JOIN 
            publicaciones p ON r.IdPublicacion = p.IdPublicacion
        INNER JOIN 
            aspnetusers u ON p.IdAliado = u.Id
        WHERE 
            r.IdUsuario = @IdUsuario 
            AND (@Estado IS NULL OR r.ReservaEstado = @Estado)
        ORDER BY 
            r.FechaInicial DESC
        LIMIT 
            @ResultadosMostrados OFFSET @Offset";

            var offset = (pagina - 1) * resultadosMostrados;

            var parameters = new
            {
                IdUsuario = idUsuario,
                Estado = estado,
                ResultadosMostrados = resultadosMostrados,
                Offset = offset
            };

            var reservas = await _db.QueryAsync<ReservaTarjetaBasicaVM>(sql, parameters);
            return reservas.ToList();
        }



        public async Task<int> ObtenerTotalReservas(string idUsuario, ReservaEstado? estado = null)
        {
            var consulta = @"SELECT COUNT(*) FROM reservas WHERE IdUsuario = @IdUsuario AND ReservaEstado = @Estado";

            var parametros = new
            {
                IdUsuario = idUsuario,
                Estado = estado == null ? ReservaEstado.Activo.ToString() : estado.ToString()
            };

            var resultado = await _db.QuerySingleAsync<int>(consulta, parametros);

            return resultado;
        }


        // id del aliado (se guarda en idUsuario, se encuentra en la tabla publicaciones), servicios adicionales que tenga la publicacion

        public async Task<ReservaCrearVM?> ObtenerReservaCrearVMAsync(int idPublicacion)
        {
            // Consulta para obtener los datos de la publicación
            var sqlPublicacion = @"
                        SELECT 
                            p.IdAliado AS IdUsuario,
                            p.IdPublicacion,
                            p.PrecioNoche AS PrecioTotal
                        FROM 
                            Publicaciones p
                        WHERE 
                            p.IdPublicacion = @IdPublicacion;
                        ";

            // Consulta para obtener los servicios
            var sqlServicios = @"
                        SELECT 
                            s.IdServicio, 
                            s.NombreServicio, 
                            s.RutaIcono
                        FROM 
                            Servicios s;
                        ";

            // Ejecutar la consulta para obtener los datos de la publicación
            var publicacion = await _db.QueryFirstOrDefaultAsync<ReservaCrearVM>(sqlPublicacion, new { IdPublicacion = idPublicacion });

            if (publicacion == null)
            {
                return null; // Si no se encuentra la publicación, retorna null
            }

            // Ejecutar la consulta para obtener los servicios
            //var servicios = await _db.QueryAsync<ServicioVM>(sqlServicios);

            // Asignar los servicios a la publicación
            //publicacion.Servicios = servicios.ToList();

            return publicacion;
        }


        public async Task<bool> RegistrarReservaAsync(ReservaCrearVM reservaCrearVM)
        {
            try
            {
                // Abrir la conexión si no está abierta
                if (_db.State != ConnectionState.Open)
                {
                    _db.Open();
                }


                // Validación 2: Verificar conflictos con otras reservas activas
                var sqlVerificarReserva = @"
            SELECT COUNT(*)
            FROM reservas
            WHERE IdPublicacion = @IdPublicacion
              AND ReservaEstado = 'Activo'
              AND (
                (@FechaInicial BETWEEN FechaInicial AND FechaFinal)
                OR (@FechaFinal BETWEEN FechaInicial AND FechaFinal)
                OR (FechaInicial BETWEEN @FechaInicial AND @FechaFinal)
              )";

                var reservasConflicto = await _db.ExecuteScalarAsync<int>(sqlVerificarReserva, new
                {
                    IdPublicacion = reservaCrearVM.IdPublicacion,
                    FechaInicial = reservaCrearVM.FechaInicial,
                    FechaFinal = reservaCrearVM.FechaFinal
                });

                if (reservasConflicto > 0)
                {
                    return false;
                }

                using (var transaction = _db.BeginTransaction())
                {
                    try
                    {
                        // Inserción de la reserva en la tabla reservas
                        var sqlReserva = @"
                                 INSERT INTO reservas (FechaReserva, ReservaEstado, FechaInicial, FechaFinal, PrecioTotal, IdUsuario, IdPublicacion)
                                 VALUES (@FechaReserva, @ReservaEstado, @FechaInicial, @FechaFinal, @PrecioTotal, @IdUsuario, @IdPublicacion);
                                 SELECT LAST_INSERT_ID();";

                        var idReserva = await _db.ExecuteScalarAsync<int>(sqlReserva, new
                        {
                            FechaReserva = DateTime.UtcNow,
                            ReservaEstado = ReservaEstado.Activo.ToString(),
                            FechaInicial = reservaCrearVM.FechaInicial,
                            FechaFinal = reservaCrearVM.FechaFinal,
                            PrecioTotal = reservaCrearVM.PrecioTotal,
                            IdUsuario = reservaCrearVM.IdUsuario,
                            IdPublicacion = reservaCrearVM.IdPublicacion
                        }, transaction);

                        // Confirmar la transacción
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        // Revertir la transacción si ocurre algún error
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



        public async Task<ReservaTarjetaResumenVM?> ObtenerReservaTarjetaResumenVMAsync(int idReserva, string idUsuario)
        {
            var sql = @"
    SELECT 
        r.IdReserva,
        r.FechaInicial,
        r.FechaFinal,
        p.IdPublicacion,
        p.NumeroResenas AS NumeroResenasPublicacion,
        (SELECT COUNT(*) 
         FROM Reservas 
         WHERE IdPublicacion = p.IdPublicacion) AS NumeroReservasPublicacion,
        (SELECT pi.Ruta 
         FROM PublicacionesImagenes pi 
         WHERE pi.IdPublicacion = p.IdPublicacion 
         ORDER BY pi.Orden 
         LIMIT 1) AS ImagenPublicacion
    FROM 
        Reservas r
    INNER JOIN 
        Publicaciones p ON r.IdPublicacion = p.IdPublicacion
    WHERE 
        r.IdReserva = @IdReserva
    AND 
        r.IdUsuario = @IdUsuario;
    ";

            var reservaResumen = await _db.QueryFirstOrDefaultAsync<ReservaTarjetaResumenVM>(sql, new { IdReserva = idReserva, IdUsuario = idUsuario });
            return reservaResumen;
        }


        public async Task<List<ReservaTablaItemVM>?> ObtenerListaReservaTablaItemVMAsync(string idAliado)
        {
            var sql = @"
        SELECT 
            r.IdReserva,
            r.ReservaEstado AS Estado,
            r.PrecioTotal AS PrecioReserva,
            r.FechaInicial,
            r.FechaFinal,
            u.Id AS IdUsuario,
            u.UserName AS NombreUsuario,
            u.Avatar AS AvatarUsuario,
            p.IdPublicacion,
            p.Titulo AS TituloPublicacion,
            (SELECT pi.Ruta 
             FROM publicacionesimagenes pi 
             WHERE pi.IdPublicacion = p.IdPublicacion 
             ORDER BY pi.Orden 
             LIMIT 1) AS ImagenPublicacion
        FROM 
            reservas r
        INNER JOIN 
            publicaciones p ON r.IdPublicacion = p.IdPublicacion
        INNER JOIN 
            aspnetusers u ON r.IdUsuario = u.Id
        WHERE 
            p.IdAliado = @IdAliado
        ORDER BY 
            r.FechaInicial DESC";

            var reservas = await _db.QueryAsync<ReservaTablaItemVM>(sql, new { IdAliado = idAliado });
            return reservas.ToList();
        }

    }
}
