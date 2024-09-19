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

        //  método GetAll para reportes 
        public async Task<List<ReservaTarjetaV2VM>> GetAll()
        {
            var sql = @"
                SELECT r.IdReserva, r.FechaInicial, r.FechaFinal, r.Estado AS ReservaEstado,
                       p.IdPublicacion, p.Titulo AS TituloPublicacion, p.Puntuacion,
                       u.Id AS IdAliado, u.UserName AS NombreAliado, u.Avatar AS AvatarAliado, u.Verificado AS VerificadoAliado
                FROM Reservas r
                INNER JOIN Publicaciones p ON r.IdPublicacion = p.IdPublicacion
                INNER JOIN aspnetusers u ON p.IdAliado = u.Id";

            var resultado = await _db.QueryAsync<ReservaTarjetaV2VM>(sql);
            return resultado.ToList();
        }

        // Obtener todas las reservas para un usuario
        public async Task<List<ReservaTarjetaV2VM>> GetAllReservasAsync(string idUsuario)
        {
            var sql = @"
                SELECT r.IdReserva, r.FechaInicial, r.FechaFinal, r.Estado AS ReservaEstado,
                       p.IdPublicacion, p.Titulo AS TituloPublicacion, p.Puntuacion,
                       u.Id AS IdAliado, u.UserName AS NombreAliado, u.Avatar AS AvatarAliado, u.Verificado AS VerificadoAliado
                FROM Reservas r
                INNER JOIN Publicaciones p ON r.IdPublicacion = p.IdPublicacion
                INNER JOIN aspnetusers u ON p.IdAliado = u.Id
                WHERE r.IdUsuario = @IdUsuario";

            var resultado = await _db.QueryAsync<ReservaTarjetaV2VM>(sql, new { IdUsuario = idUsuario });

            return resultado.ToList();
        }

        // Obtener detalles de una reserva específica por ID
        public async Task<ReservaTarjetaV3VM> GetReservaByIdAsync(int idReserva)
        {
            var sql = @"
                SELECT r.IdReserva, r.FechaInicial, r.FechaFinal, r.NumeroPersonas, r.Estado AS ReservaEstado,
                       p.IdPublicacion, p.Titulo AS TituloPublicacion, p.Puntuacion, p.NumeroResenas, p.Ubicacion,
                       u.Id AS IdAliado, u.UserName AS NombreAliado, u.Avatar AS AvatarAliado, u.Verificado AS Verificado,
                       (SELECT TOP 5 pi.Ruta FROM PublicacionImagenes pi WHERE pi.IdPublicacion = p.IdPublicacion ORDER BY pi.Orden) AS Imagen
                FROM Reservas r
                INNER JOIN Publicaciones p ON r.IdPublicacion = p.IdPublicacion
                INNER JOIN aspnetusers u ON p.IdAliado = u.Id
                WHERE r.IdReserva = @IdReserva";

            return await _db.QueryFirstOrDefaultAsync<ReservaTarjetaV3VM>(sql, new { IdReserva = idReserva });
        }

        // Registrar una nueva reserva
        public async Task<bool> RegistrarReservaAsync(ReservaCrearVM reservaCrearVM)
        {
            var sql = @"
                INSERT INTO Reservas (FechaInicial, FechaFinal, NumeroPersonas, PrecioTotal, IdUsuario, IdPublicacion)
                VALUES (@FechaInicial, @FechaFinal, @NumeroPersonas, @PrecioTotal, @IdUsuario, @IdPublicacion)";

            var result = await _db.ExecuteAsync(sql, reservaCrearVM);



            return result > 0;
        }

        // Cancelar una reserva
        public async Task<bool> CancelarReservaAsync(int idReserva)
        {
            var sql = "UPDATE Reservas SET Estado = 'Cancelado' WHERE IdReserva = @IdReserva";
            var result = await _db.ExecuteAsync(sql, new { IdReserva = idReserva });
            return result > 0;
        }

        public Task<bool> SaveAsync()
        {

            return Task.FromResult(true);
        }


    }
}
