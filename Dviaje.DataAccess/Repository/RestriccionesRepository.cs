using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using System.Data;

namespace Dviaje.DataAccess.Repository
{
    public class RestriccionesRepository : IRestriccionesRepository
    {
        private readonly IDbConnection _db;

        public RestriccionesRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<bool> CrearRestriccionAsync(Restriccion restriccion)
        {
            var sql = @"
                    INSERT INTO restricciones (NombreRestriccion, RutaIcono) 
                    VALUES (@NombreRestriccion, @RutaIcono)";

            var result = await _db.ExecuteAsync(sql, restriccion);
            return result > 0;
        }


        public async Task<Restriccion?> ObtenerRestriccionPorIdAsync(int idRestriccion)
        {
            var sql = @"
                    SELECT IdRestriccion, NombreRestriccion, RutaIcono 
                    FROM restricciones 
                    WHERE IdRestriccion = @IdRestriccion";

            return await _db.QueryFirstOrDefaultAsync<Restriccion>(sql, new { IdRestriccion = idRestriccion });
        }


        public async Task<List<Restriccion>> ObtenerRestriccionesAsync()
        {
            var sql = @"
                        SELECT IdRestriccion, NombreRestriccion, RutaIcono 
                        FROM restricciones";

            var restricciones = await _db.QueryAsync<Restriccion>(sql);
            return restricciones.ToList();
        }


        public async Task<bool> ActualizarRestriccionAsync(Restriccion restriccion)
        {
            var sql = @"
                    UPDATE restricciones 
                    SET NombreRestriccion = @NombreRestriccion, RutaIcono = @RutaIcono 
                    WHERE IdRestriccion = @IdRestriccion";

            var result = await _db.ExecuteAsync(sql, restriccion);
            return result > 0;
        }


        public async Task<bool> EliminarRestriccionAsync(int idRestriccion)
        {
            var sql = @"
                    DELETE FROM restricciones 
                    WHERE IdRestriccion = @IdRestriccion";

            var result = await _db.ExecuteAsync(sql, new { IdRestriccion = idRestriccion });
            return result > 0;
        }

    }
}
