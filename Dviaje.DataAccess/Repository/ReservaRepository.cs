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

        public async Task<IEnumerable<ReservaTarjetaV2VM>> GetAllReservasAsync(string idUsuario)
        {
            var sql = @"
                SELECT r.IdReserva, r.FechaInicial, r.FechaFinal, r.Estado AS ReservaEstado,
                       p.IdPublicacion, p.Titulo AS TituloPublicacion, p.Puntuacion,
                       u.IdUsuario AS IdAliado, u.UserName AS NombreAliado, u.Avatar AS AvatarAliado, u.Verificado AS VerificadoAliado
                FROM Reservas r
                INNER JOIN Publicaciones p ON r.IdPublicacion = p.IdPublicacion
                INNER JOIN Usuarios u ON p.IdAliado = u.IdUsuario
                WHERE r.IdUsuario = @IdUsuario";

            return await _db.QueryAsync<ReservaTarjetaV2VM>(sql, new { IdUsuario = idUsuario });
        }

        public async Task<ReservaTarjetaV3VM> GetReservaByIdAsync(int idReserva)
        {
            var sql = @"
                SELECT r.IdReserva, r.FechaInicial, r.FechaFinal, r.NumeroPersonas, r.Estado AS ReservaEstado,
                       p.IdPublicacion, p.Titulo AS TituloPublicacion, p.Puntuacion, p.NumeroResenas, p.Ubicacion,
                       u.IdUsuario AS IdAliado, u.UserName AS NombreAliado, u.Avatar AS AvatarAliado, u.Verificado AS Verificado,
                       (SELECT TOP 5 pi.Ruta FROM PublicacionImagenes pi WHERE pi.IdPublicacion = p.IdPublicacion ORDER BY pi.Orden) AS Imagen
                FROM Reservas r
                INNER JOIN Publicaciones p ON r.IdPublicacion = p.IdPublicacion
                INNER JOIN Usuarios u ON p.IdAliado = u.IdUsuario
                WHERE r.IdReserva = @IdReserva";

            return await _db.QueryFirstOrDefaultAsync<ReservaTarjetaV3VM>(sql, new { IdReserva = idReserva });
        }

        public async Task<bool> RegistrarReservaAsync(ReservaCrearVM reservaCrearVM)
        {
            var sql = @"
                INSERT INTO Reservas (FechaInicial, FechaFinal, NumeroPersonas, PrecioTotal, IdUsuario, IdPublicacion)
                VALUES (@FechaInicial, @FechaFinal, @NumeroPersonas, @PrecioTotal, @IdUsuario, @IdPublicacion)";

            var result = await _db.ExecuteAsync(sql, reservaCrearVM);

            //  lógica para manejar los servicios adicionales (prueba)

            return result > 0;
        }

        public async Task<bool> CancelarReservaAsync(int idReserva)
        {
            var sql = "UPDATE Reservas SET Estado = 'Cancelado' WHERE IdReserva = @IdReserva";
            var result = await _db.ExecuteAsync(sql, new { IdReserva = idReserva });
            return result > 0;
        }

        public Task<bool> SaveAsync()
        {
            // No implementation needed for Dapper
            return Task.FromResult(true);
        }
    }
}
