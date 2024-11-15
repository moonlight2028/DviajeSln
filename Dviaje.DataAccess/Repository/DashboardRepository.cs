using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using System.Data;

namespace Dviaje.DataAccess.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly IDbConnection _db;

        public DashboardRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<DashboardVM> ObtenerDatosDashboardAsync()
        {
            var sql = @"
            SELECT 
                (SELECT COUNT(*) FROM aspnetusers) AS TotalUsuarios,
                (SELECT COUNT(*) FROM aspnetusers WHERE Discriminator = 'Aliado') AS TotalAliados,
                (SELECT COUNT(*) FROM Reservas) AS TotalReservas,
                (SELECT COUNT(*) FROM Reservas WHERE ReservaEstado = 'Activo') AS ReservasActivas,
                (SELECT COUNT(*) FROM Publicaciones) AS TotalPublicaciones,
                (SELECT COUNT(*) FROM Publicaciones WHERE PublicacionEstado = 'Activa') AS PublicacionesActivas,
                (SELECT COUNT(*) FROM Resenas) AS TotalResenas,
                (SELECT AVG(Calificacion) FROM Resenas) AS PromedioCalificaciones;
        ";

            return await _db.QueryFirstOrDefaultAsync<DashboardVM>(sql);
        }

        public async Task<List<ReservasMensualesVM>> ObtenerReservasMensualesAsync()
        {
            var sql = @"
            SELECT 
                DATE_FORMAT(FechaReserva, '%Y-%m') AS Mes, 
                COUNT(*) AS TotalReservas
            FROM Reservas
            GROUP BY DATE_FORMAT(FechaReserva, '%Y-%m')
            ORDER BY DATE_FORMAT(FechaReserva, '%Y-%m') DESC;
        ";

            return (await _db.QueryAsync<ReservasMensualesVM>(sql)).ToList();
        }

        public async Task<byte[]> GenerarReporteCompletoAsync()
        {
            // Lógica para generar un archivo PDF con los datos
            // Esto incluirá información de usuarios, reservas, publicaciones, etc.
            // Aquí, simula el archivo para el ejemplo
            return await Task.FromResult(new byte[0]); // Reemplaza con tu lógica de generación de PDF
        }
    }
}
