using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using System.Data;


//Repositorio completo funcional

namespace Dviaje.DataAccess.Repository
{
    public class ServiciosRepository : IServiciosRepository
    {
        private readonly IDbConnection _db;

        public ServiciosRepository(IDbConnection db)
        {
            _db = db;
        }

        // Crear un nuevo servicio
        public async Task<bool> CrearServicioAsync(Servicio servicio)
        {
            var sql = @"
        INSERT INTO Servicios (NombreServicio, RutaIcono, ServicioTipo)
        VALUES (@NombreServicio, @RutaIcono, @ServicioTipo)";

            var result = await _db.ExecuteAsync(sql, new
            {
                NombreServicio = servicio.NombreServicio,
                RutaIcono = servicio.RutaIcono, // Permitir que sea NULL
                ServicioTipo = servicio.ServicioTipo // Asegúrate de que este valor coincida con los ENUM de la base de datos
            });

            return result > 0;
        }


        // Obtener un servicio por ID
        public async Task<Servicio?> ObtenerServicioPorIdAsync(int idServicio)
        {
            var sql = @"
                SELECT IdServicio, NombreServicio, RutaIcono, ServicioTipo
                FROM Servicios
                WHERE IdServicio = @IdServicio";

            return await _db.QueryFirstOrDefaultAsync<Servicio>(sql, new { IdServicio = idServicio });
        }

        // Obtener todos los servicios
        public async Task<List<ServicioTipoStringVM>?> ObtenerServiciosAsync()
        {
            var sql = @"SELECT * FROM Servicios";

            var servicios = await _db.QueryAsync<ServicioTipoStringVM>(sql);
            return servicios.ToList();
        }

        // Actualizar un servicio
        public async Task<bool> ActualizarServicioAsync(Servicio servicio)
        {
            var sql = @"
        UPDATE Servicios
        SET NombreServicio = @NombreServicio,
            RutaIcono = @RutaIcono,
            ServicioTipo = @ServicioTipo
        WHERE IdServicio = @IdServicio";

            var result = await _db.ExecuteAsync(sql, new
            {
                IdServicio = servicio.IdServicio,
                NombreServicio = servicio.NombreServicio,
                RutaIcono = servicio.RutaIcono, // Permitir NULL si no se proporciona un ícono
                ServicioTipo = servicio.ServicioTipo // Asegúrate de que coincida con el ENUM de la tabla
            });

            return result > 0;
        }


        // Eliminar un servicio
        public async Task<bool> EliminarServicioAsync(int idServicio)
        {
            var sql = @"
                DELETE FROM Servicios
                WHERE IdServicio = @IdServicio";

            var result = await _db.ExecuteAsync(sql, new { IdServicio = idServicio });
            return result > 0;
        }
    }
}
