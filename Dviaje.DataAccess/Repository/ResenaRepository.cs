using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using System.Data;

namespace Dviaje.DataAccess.Repository
{
    public class ResenaRepository : IResenasRepository
    {
        private readonly IDbConnection _db;


        public ResenaRepository(IDbConnection db)
        {
            _db = db;
        }



        //crear una Reseña
        public async Task<bool> CrearResenaAsync(ResenaCrearVM resenaCrear)
        {
            var sql = @"
                INSERT INTO Resenas (Opinion, Fecha, Calificacion, IdReserva)
                VALUES (@Opinion, @Fecha, @Calificacion, @IdReserva)";

            var result = await _db.ExecuteAsync(sql, resenaCrear);
            return result > 0;
        }



        //Obtner las resenas para las tarjetas 
        public async Task<List<ResenaTarjetaBasicaVM>> ObtenerListaResenaTarjetaBasicaVMAsync(int idPublicacion, int pagina = 1, int resultadosMostrados = 10)
        {
            var sql = @"
        SELECT 
            r.IdReserva, 
            u.Id AS IdTurista, 
            u.UserName AS NombreTurista, 
            u.Avatar AS AvatarTurista, 
            rs.Opinion, 
            rs.Fecha, 
            rs.Calificacion AS Puntuacion, 
            (SELECT COUNT(*) FROM resenamegusta WHERE IdResena = rs.IdResena) AS NumeroLikes
        FROM 
            resenas rs
        INNER JOIN 
            reservas r ON rs.IdReserva = r.IdReserva
        INNER JOIN 
            publicaciones p ON r.IdPublicacion = p.IdPublicacion
        INNER JOIN 
            aspnetusers u ON r.IdUsuario = u.Id
        WHERE 
            p.IdPublicacion = @IdPublicacion
        ORDER BY 
            rs.Fecha DESC
        LIMIT @ElementosPorPagina OFFSET @Offset";

            var offset = (pagina - 1) * resultadosMostrados;

            var result = await _db.QueryAsync<ResenaTarjetaBasicaVM>(sql, new
            {
                IdPublicacion = idPublicacion,
                ElementosPorPagina = resultadosMostrados,
                Offset = offset
            });

            return result.ToList();
        }




        // Obtner las reseñas que estan disponibles 
        public async Task<List<ResenaTarjetaDisponibleVM>> ObtenerListaResenaTarjetaDisponibleVMAsync(string idUsuario, int pagina = 1, int resultadosMostrados = 10)
        {
            var sql = @"
        SELECT 
            r.IdReserva, 
            p.Titulo AS TituloPublicacion, 
            p.Descripcion AS DescripcionPublicacion, 
            p.Puntuacion AS PuntuacionPublicacion, 
            (SELECT pi.Ruta 
             FROM publicacionesimagenes pi 
             WHERE pi.IdPublicacion = p.IdPublicacion 
             ORDER BY pi.Orden LIMIT 1) AS ImagenPublicacion, 
            r.FechaInicial, 
            r.FechaFinal
        FROM 
            reservas r
        INNER JOIN 
            publicaciones p ON r.IdPublicacion = p.IdPublicacion
        WHERE 
            r.IdUsuario = @IdUsuario
            AND r.FechaFinal <= CURRENT_DATE
            AND NOT EXISTS (SELECT 1 FROM resenas rs WHERE rs.IdReserva = r.IdReserva)
        ORDER BY 
            r.FechaFinal DESC
        LIMIT @ElementosPorPagina OFFSET @Offset";

            var offset = (pagina - 1) * resultadosMostrados;

            var result = await _db.QueryAsync<ResenaTarjetaDisponibleVM>(sql, new
            {
                IdUsuario = idUsuario,
                ElementosPorPagina = resultadosMostrados,
                Offset = offset
            });

            return result.ToList();
        }



        // Obtner los detalles de la reseña
        public async Task<List<ResenaTarjetaDetalleVM>?> ObtenerListaResenaTarjetaDetalleAsync(string idUsuario, int pagina = 1, int resultadosMostrados = 10)
        {
            var sql = @"
                    SELECT 
                    p.IdPublicacion, 
                    rs.Opinion, 
                    rs.Fecha, 
                    rs.Calificacion AS Puntuacion, 
                    (SELECT COUNT(*) FROM ResenaMeGusta WHERE IdResena = rs.IdResena) AS NumerosLikes,
                    p.Titulo AS TituloPublicacion, 
                    pi.Ruta AS ImagenPublicacion, 
                    u.Id AS IdAliado, 
                    u.UserName AS NombreAliado, 
                    u.Avatar AS AvatarAliado, 
                    u.NumeroPublicaciones AS NumeroPublicacionesAliado
                FROM 
                    Resenas rs
                INNER JOIN 
                    Reservas r ON rs.IdReserva = r.IdReserva
                INNER JOIN 
                    Publicaciones p ON r.IdPublicacion = p.IdPublicacion
                INNER JOIN 
                    aspnetusers u ON p.IdAliado = u.Id
                LEFT JOIN 
                    PublicacionesImagenes pi ON pi.IdPublicacion = p.IdPublicacion
                WHERE 
                    r.IdUsuario = '@IdUsuario'
                ORDER BY 
                    rs.Fecha DESC
                LIMIT ELEMENTOS_POR_PAGINA OFFSET OFFSET";

            var offset = (pagina - 1) * resultadosMostrados;
            var result = await _db.QueryAsync<ResenaTarjetaDetalleVM>(sql, new
            {
                IdUsuario = idUsuario,
                ElementosPorPagina = resultadosMostrados,
                Offset = offset
            });

            return result.ToList();

        }


        //obtener la lista de reservas 
        public async Task<List<ResenaTarjetaRecibidaVM>> ObtenerListaResenaTarjetaRecibidaVMAsync(string idAliado, int pagina = 1, int resultadosMostrados = 10, string? ordenar = null)
        {
            var sql = @"
        SELECT 
            rs.Opinion, 
            rs.Calificacion AS Puntuacion, 
            rs.Fecha, 
            (SELECT COUNT(*) FROM resenamegusta WHERE IdResena = rs.IdResena) AS NumeroLikes,
            p.IdPublicacion, 
            p.Titulo AS TituloPublicacion, 
            (SELECT pi.Ruta 
             FROM publicacionesimagenes pi 
             WHERE pi.IdPublicacion = p.IdPublicacion 
             ORDER BY pi.Orden LIMIT 1) AS ImagenPublicacion,
            u.Id AS IdTurista, 
            u.UserName AS NombreTurista, 
            u.Avatar AS AvatarTurista
        FROM 
            resenas rs
        INNER JOIN 
            reservas r ON rs.IdReserva = r.IdReserva
        INNER JOIN 
            publicaciones p ON r.IdPublicacion = p.IdPublicacion
        INNER JOIN 
            aspnetusers u ON r.IdUsuario = u.Id
        WHERE 
            p.IdAliado = @IdAliado
        ORDER BY 
            CASE WHEN @Ordenar IS NOT NULL THEN
                CASE @Ordenar
                    WHEN 'Fecha' THEN rs.Fecha
                    WHEN 'Puntuacion' THEN rs.Calificacion
                    WHEN 'Likes' THEN NumeroLikes
                END
            ELSE rs.Fecha END DESC
        LIMIT @ElementosPorPagina OFFSET @Offset";

            var offset = (pagina - 1) * resultadosMostrados;

            var result = await _db.QueryAsync<ResenaTarjetaRecibidaVM>(sql, new
            {
                IdAliado = idAliado,
                Ordenar = ordenar,
                ElementosPorPagina = resultadosMostrados,
                Offset = offset
            });

            return result.ToList();
        }


        // Agregar me gusta del usuario
        public async Task<bool> AgregarMeGustaAsync(int idResena, string idUsuario)
        {
            // Verificar si el usuario ya ha dado "Me Gusta"
            var sqlCheck = @"
                        SELECT COUNT(*)
                        FROM ResenaMeGusta
                        WHERE IdResena = @IdResena AND IdUsuario = @IdUsuario";

            var yaDioMeGusta = await _db.ExecuteScalarAsync<int>(sqlCheck, new { IdResena = idResena, IdUsuario = idUsuario });

            if (yaDioMeGusta > 0)
            {
                // El usuario ya dio "Me Gusta" previamente, no hacer nada
                return false;
            }

            // Insertar un nuevo "Me Gusta"
            var sqlInsert = @"
                        INSERT INTO ResenaMeGusta (IdResena, IdUsuario)
                        VALUES (@IdResena, @IdUsuario)";

            var result = await _db.ExecuteAsync(sqlInsert, new { IdResena = idResena, IdUsuario = idUsuario });
            return result > 0;
        }


        //verifica si el usuario ya dio me gusta a una reseña
        public async Task<bool> VerificarSiUsuarioLeDioLike(int idResena, string idUsuario)
        {
            var sql = @"
                    SELECT COUNT(*)
                    FROM ResenaMeGusta
                    WHERE IdResena = @IdResena AND IdUsuario = @IdUsuario";

            // Ejecuta la consulta y verifica si existe al menos un registro
            var likeCount = await _db.ExecuteScalarAsync<int>(sql, new { IdResena = idResena, IdUsuario = idUsuario });

            // Si el conteo es mayor que 0, significa que el usuario ya dio "like"
            return likeCount > 0;
        }


        //eliminar me gusta 
        public async Task<bool> EliminarMeGustaAsync(int idResena, string idUsuario)
        {
            var sql = @"
                DELETE FROM ResenaMeGusta
                WHERE IdResena = @IdResena AND IdUsuario = @IdUsuario";

            var result = await _db.ExecuteAsync(sql, new { IdResena = idResena, IdUsuario = idUsuario });
            return result > 0;
        }


        //Traer me gusta (cantidad numerada)
        public async Task<int> ObtenerMeGustaCountAsync(int idResena)
        {
            var sql = @"SELECT COUNT(*) FROM ResenasMeGusta WHERE IdResena = @IdResena";

            var count = await _db.ExecuteScalarAsync<int>(sql, new { IdResena = idResena });
            return count;
        }

        //Validar resena
        public async Task<bool> ValidarReservaParaResenaAsync(int idReserva, string idUsuario)
        {
            var sql = @"
                SELECT COUNT(*)
                FROM Reservas r
                WHERE r.IdReserva = @IdReserva
                AND r.IdUsuario = @IdUsuario
                AND r.ReservaEstado = 'Aprovado'
                AND r.FechaFinal <= CURRENT_DATE
                AND NOT EXISTS (SELECT 1 FROM Resenas rs WHERE rs.IdReserva = r.IdReserva)";

            return await _db.ExecuteScalarAsync<bool>(sql, new { IdReserva = idReserva, IdUsuario = idUsuario });
        }


        public async Task<int> ObtenerTotalResenas(string idUsuairo)
        {
            var consulta = @"SELECT COUNT(*)
                FROM resenas r
                JOIN reservas res ON r.IdReserva = res.IdReserva
                WHERE res.IdUsuario = @IdUsuario;";

            return await _db.QuerySingleAsync<int>(consulta, new { IdUsuario = idUsuairo });
        }
    }
}
