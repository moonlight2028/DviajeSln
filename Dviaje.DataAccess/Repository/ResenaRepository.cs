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

        // Obtiene las reseñas disponibles para reseñar
        public async Task<List<ResenaDisponibleTarjetaVM>> ObtenerResenasDisponiblesAsync(string idUsuario, int paginaActual, int elementosPorPagina = 10)
        {
            var sql = @"
                SELECT r.IdReserva, p.Titulo AS TituloPublicacion, p.Descripcion AS DescripcionPublicacion, p.Puntuacion AS PuntuacionPublicacion, p.ImagenUrl AS ImagenPublicacion, r.FechaInicial, r.FechaFinal
                FROM Reservas r
                INNER JOIN Publicaciones p ON r.IdPublicacion = p.IdPublicacion
                WHERE r.IdUsuario = @IdUsuario
                AND r.Estado = 'Aprobado'
                AND r.FechaFinal <= CURRENT_DATE
                AND NOT EXISTS (SELECT 1 FROM Resenas rs WHERE rs.IdReserva = r.IdReserva)
                ORDER BY r.FechaFinal DESC
                LIMIT @ElementosPorPagina OFFSET @Offset";

            var offset = (paginaActual - 1) * elementosPorPagina;

            return (await _db.QueryAsync<ResenaDisponibleTarjetaVM>(sql, new
            {
                IdUsuario = idUsuario,
                ElementosPorPagina = elementosPorPagina,
                Offset = offset
            })).ToList();
        }

        // Obtiene las reseñas que ya realizó el usuario
        public async Task<List<ResenasTarjetaVM>> ObtenerMisResenasAsync(string idUsuario, int paginaActual, int elementosPorPagina = 10)
        {
            var sql = @"
                SELECT rs.IdPublicacion, rs.Opinion, rs.Fecha, rs.Calificacion AS Puntuacion, rs.MeGusta, NULL AS AvatarTurista
                FROM Resenas rs
                INNER JOIN Reservas r ON rs.IdReserva = r.IdReserva
                WHERE r.IdUsuario = @IdUsuario
                ORDER BY rs.Fecha DESC
                LIMIT @ElementosPorPagina OFFSET @Offset";

            var offset = (paginaActual - 1) * elementosPorPagina;

            return (await _db.QueryAsync<ResenasTarjetaVM>(sql, new
            {
                IdUsuario = idUsuario,
                ElementosPorPagina = elementosPorPagina,
                Offset = offset
            })).ToList();
        }

        // Valida si la reserva puede ser reseñada
        public async Task<bool> ValidarReservaParaResenaAsync(int idReserva, string idUsuario)
        {
            var sql = @"
                SELECT COUNT(*)
                FROM Reservas r
                WHERE r.IdReserva = @IdReserva
                AND r.IdUsuario = @IdUsuario
                AND r.Estado = 'Aprobado'
                AND r.FechaFinal <= CURRENT_DATE
                AND NOT EXISTS (SELECT 1 FROM Resenas rs WHERE rs.IdReserva = r.IdReserva)";

            return await _db.ExecuteScalarAsync<bool>(sql, new { IdReserva = idReserva, IdUsuario = idUsuario });
        }

        // Crea una nueva reseña
        public async Task<bool> CrearResenaAsync(ResenaCrearVM resenaCrear)
        {
            var sql = @"
                INSERT INTO Resenas (Opinion, Fecha, Calificacion, IdReserva)
                VALUES (@Opinion, @Fecha, @Calificacion, @IdReserva)";

            var result = await _db.ExecuteAsync(sql, resenaCrear);
            return result > 0;
        }

        // Añadir "Me Gusta" a una reseña
        public async Task<bool> AgregarMeGustaAsync(int idResena, string idUsuario)
        {
            var sql = @"
                INSERT INTO ResenasMeGusta (IdResena, IdUsuario)
                VALUES (@IdResena, @IdUsuario)";

            var result = await _db.ExecuteAsync(sql, new { IdResena = idResena, IdUsuario = idUsuario });
            return result > 0;
        }

        // Elimina "Me Gusta" de una reseña
        public async Task<bool> EliminarMeGustaAsync(int idResena, string idUsuario)
        {
            var sql = @"
                DELETE FROM ResenasMeGusta
                WHERE IdResena = @IdResena AND IdUsuario = @IdUsuario";

            var result = await _db.ExecuteAsync(sql, new { IdResena = idResena, IdUsuario = idUsuario });
            return result > 0;
        }

        // Método para obtener las reseñas con más "Me Gusta"
        public async Task<List<ResenasTarjetaVM>> ObtenerResenasTopAsync(int cantidad)
        {
            var sql = @"
                SELECT rs.IdPublicacion, rs.Opinion, rs.Fecha, rs.Calificacion AS Puntuacion, rs.MeGusta, NULL AS AvatarTurista
                FROM Resenas rs
                ORDER BY rs.MeGusta DESC
                LIMIT @Cantidad";

            return (await _db.QueryAsync<ResenasTarjetaVM>(sql, new { Cantidad = cantidad })).ToList();
        }
    }
}
