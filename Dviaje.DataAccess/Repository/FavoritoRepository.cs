using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using System.Data;

namespace Dviaje.DataAccess.Repository
{
    public class FavoritoRepository : IFavoritosRepository
    {
        private readonly IDbConnection _db;

        public FavoritoRepository(IDbConnection db)
        {
            _db = db;
        }

        // Obtiene los favoritos del usuario
        public async Task<List<FavoritoTarjetaVM>?> ObtenerListaFavoritoTarjetaVMAsync(string idUsuario)
        {
            // Obtiene los favoritos del usuario
            // Corregir, paginar directamente en la consulta SQL, ya que esta trayendo todos los datos para paginar después en el controlador.
            // No es bueno traer todos los datos de la DB.
            // Implementación de paginación
            // Corregir, implementar lógica de paginación en la consulta SQL.
            // Error: MySqlException: Table 'dviaje.publicacionimagenes' doesn't exist

            //var sql = @"
            //    SELECT p.IdPublicacion, p.Titulo, p.Descripcion, p.Puntuacion, pi.Ruta AS Imagen
            //    FROM Favoritos f
            //    INNER JOIN Publicaciones p ON f.IdPublicacion = p.IdPublicacion
            //    LEFT JOIN PublicacionImagenes pi ON pi.IdPublicacion = p.IdPublicacion
            //    WHERE f.IdUsuario = @IdUsuario
            //    ORDER BY f.FechaAgregado DESC"; // Ordena los favoritos por fecha

            //var resultado = await _db.QueryAsync<FavoritoTarjetaVM>(sql, new { IdUsuario = idUsuario });
            //return resultado.ToList();


            return null;
        }

        // Agrega un favorito para el usuario
        public async Task<bool> CrearFavoritoAsync(int idPublicacion, string idUsuario)
        {
            var sql = "INSERT INTO Favoritos (IdPublicacion, IdUsuario, FechaAgregado) VALUES (@IdPublicacion, @IdUsuario, @FechaAgregado)";
            var result = await _db.ExecuteAsync(sql, new { IdPublicacion = idPublicacion, IdUsuario = idUsuario, FechaAgregado = DateTime.Now });
            return result > 0;
        }

        // Elimina un favorito del usuario
        public async Task<bool> EliminarFavoritoAsync(int idPublicacion, string idUsuario)
        {
            var sql = "DELETE FROM Favoritos WHERE IdPublicacion = @IdPublicacion AND IdUsuario = @IdUsuario";
            var result = await _db.ExecuteAsync(sql, new { IdPublicacion = idPublicacion, IdUsuario = idUsuario });
            return result > 0;
        }

        public Task<int> FavoritosGuardadosTotal(string idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
