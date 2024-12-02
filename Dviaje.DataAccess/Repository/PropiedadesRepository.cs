using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using System.Data;

namespace Dviaje.DataAccess.Repository
{
    public class PropiedadesRepository : IPropiedadesRepository
    {
        private readonly IDbConnection _db;


        public PropiedadesRepository(IDbConnection db)
        {
            _db = db;
        }


        public async Task<List<Propiedad>> ObtenerPropiedadesPorCategoriaAsync(int idCategoria)
        {
            var sql = @"SELECT * FROM Propiedades where IdCategoria = @IdCategoria";

            var propiedades = await _db.QueryAsync<Propiedad>(sql, new { IdCategoria = idCategoria });
            return propiedades.ToList();
        }

        public async Task<bool> VerificarCategoriaPropiedadAsync(int idCategoria, int idPropiedad)
        {
            var consulta = @"
                SELECT EXISTS (
                    SELECT 1
                    FROM Propiedades
                    WHERE IdPropiedad = @IdPropiedad AND IdCategoria = @IdCategoria
                );
            ";

            var resultado = await _db.ExecuteScalarAsync<bool>(consulta, new { IdCategoria = idCategoria, IdPropiedad = idPropiedad });

            return resultado;
        }

        public async Task<List<Propiedad>> ObtenerPropiedadesAsync()
        {
            var sql = "SELECT * FROM Propiedades";
            var propiedades = await _db.QueryAsync<Propiedad>(sql);
            return propiedades.ToList();
        }

        public async Task<Propiedad?> ObtenerPropiedadPorIdAsync(int idPropiedad)
        {
            var sql = "SELECT * FROM Propiedades WHERE IdPropiedad = @IdPropiedad";
            return await _db.QueryFirstOrDefaultAsync<Propiedad>(sql, new { IdPropiedad = idPropiedad });
        }

        public async Task<bool> CrearPropiedadAsync(Propiedad propiedad)
        {
            var sql = @"
                INSERT INTO Propiedades (Nombre, RutaIcono, Descripcion, IdCategoria)
                VALUES (@Nombre, @RutaIcono, @Descripcion, @IdCategoria)";
            var result = await _db.ExecuteAsync(sql, propiedad);
            return result > 0;
        }

        public async Task<bool> ActualizarPropiedadAsync(Propiedad propiedad)
        {
            var sql = @"
                UPDATE Propiedades
                SET Nombre = @Nombre,
                    RutaIcono = @RutaIcono,
                    Descripcion = @Descripcion,
                    IdCategoria = @IdCategoria
                WHERE IdPropiedad = @IdPropiedad";
            var result = await _db.ExecuteAsync(sql, propiedad);
            return result > 0;
        }

        public async Task<bool> EliminarPropiedadAsync(int idPropiedad)
        {
            var sql = "DELETE FROM Propiedades WHERE IdPropiedad = @IdPropiedad";
            var result = await _db.ExecuteAsync(sql, new { IdPropiedad = idPropiedad });
            return result > 0;
        }

    }
}
