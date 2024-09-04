using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
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

        public async Task<Reserva> GetReservaConDetallesAsync(int idReserva)
        {
            var sql = @"SELECT * FROM Reservas 
                        INNER JOIN Publicaciones ON Reservas.IdPublicacion = Publicaciones.IdPublicacion
                        INNER JOIN Usuarios ON Reservas.IdUsuario = Usuarios.Id
                        WHERE Reservas.IdReserva = @IdReserva";
            var reserva = await _db.QueryFirstOrDefaultAsync<Reserva, Publicacion, Usuario, Reserva>(sql, (reserva, publicacion, usuario) =>
            {
                reserva.Publicacion = publicacion;
                reserva.Usuario = usuario;
                return reserva;
            }, new { IdReserva = idReserva }, splitOn: "IdPublicacion,Id");

            return reserva;
        }

        public async Task<IEnumerable<Reserva>> GetReservasPorUsuarioAsync(string userId, string estado)
        {
            var sql = @"SELECT * FROM Reservas 
                        INNER JOIN Publicaciones ON Reservas.IdPublicacion = Publicaciones.IdPublicacion
                        WHERE Reservas.IdUsuario = @UserId";

            if (!string.IsNullOrEmpty(estado))
            {
                sql += " AND Reservas.ReservaEstado = @Estado";
            }

            return await _db.QueryAsync<Reserva, Publicacion, Reserva>(sql, (reserva, publicacion) =>
            {
                reserva.Publicacion = publicacion;
                return reserva;
            }, new { UserId = userId, Estado = estado }, splitOn: "IdPublicacion");
        }

        public async Task AddAsync(Reserva reserva)
        {
            var sql = @"INSERT INTO Reservas (IdUsuario, IdPublicacion, FechaInicial, FechaFinal, NumeroPersonas, PrecioTotal, ReservaEstado) 
                        VALUES (@IdUsuario, @IdPublicacion, @FechaInicial, @FechaFinal, @NumeroPersonas, @PrecioTotal, @ReservaEstado)";
            await _db.ExecuteAsync(sql, reserva);
        }

        public async Task Update(Reserva reserva)
        {
            var sql = @"UPDATE Reservas SET FechaInicial = @FechaInicial, FechaFinal = @FechaFinal, NumeroPersonas = @NumeroPersonas, 
                        PrecioTotal = @PrecioTotal, ReservaEstado = @ReservaEstado 
                        WHERE IdReserva = @IdReserva";
            await _db.ExecuteAsync(sql, reserva);
        }

        public async Task<Reserva> GetAsync(Func<Reserva, bool> predicate)
        {
            var sql = @"SELECT * FROM Reservas WHERE IdReserva = @IdReserva";
            return (await _db.QueryAsync<Reserva>(sql)).FirstOrDefault(predicate);
        }
    }
}
