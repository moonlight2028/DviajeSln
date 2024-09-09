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

        // Obtiene el perfil del turista
        public async Task<PerfilPublicoVM> GetPerfilTuristaAsync(string idUsuario)
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

        // Obtiene el perfil del aliado
        public async Task<PerfilPublicoVM> GetPerfilAliadoAsync(string idUsuario)
        {
            var sql = @"
                SELECT a.RazonSocial, a.SitioWeb, a.Direccion, a.Verificado, 
                       COUNT(p.IdPublicacion) AS NumeroPulicaciones, 
                       AVG(p.Puntuacion) AS Puntuacion, a.AliadoEstado
                FROM Aliados a
                LEFT JOIN Publicaciones p ON a.IdAliado = p.IdAliado
                WHERE a.IdAliado = @IdUsuario
                GROUP BY a.RazonSocial, a.SitioWeb, a.Direccion, a.Verificado, a.AliadoEstado";

            return await _db.QueryFirstOrDefaultAsync<PerfilPublicoVM>(sql, new { IdUsuario = idUsuario });
        }
    }
}
