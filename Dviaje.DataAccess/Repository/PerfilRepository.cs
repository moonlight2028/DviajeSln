using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using System.Data;

namespace Dviaje.DataAccess.Repository
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly IDbConnection _db;

        public PerfilRepository(IDbConnection db)
        {
            _db = db;
        }

        // Corregir
        // Obtener el perfil del usuario
        public async Task<PerfilPublicoVM?> ObtenerPerfilPublicoAsync(string idUsuario)
        {
            var sql = @"
                SELECT u.UserName AS Nombre, u.Avatar, 
                       COUNT(r.IdReserva) AS NumeroReservas
                FROM Usuarios u
                LEFT JOIN Reservas r ON u.IdUsuario = r.IdUsuario
                WHERE u.IdUsuario = @IdUsuario
                GROUP BY u.UserName, u.Avatar";

            return await _db.QueryFirstOrDefaultAsync<PerfilPublicoVM>(sql, new { IdUsuario = idUsuario });
        }
    }
}
