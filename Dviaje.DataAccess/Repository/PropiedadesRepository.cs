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

    }
}
