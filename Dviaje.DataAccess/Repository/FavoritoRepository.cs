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
        public async Task<List<FavoritoTarjetaVM>?> ObtenerListaFavoritoTarjetaVMAsync(string idUsuario, int pagina = 1, int resultadosPorPagina = 10)
        {
            var sql = @"
        SELECT 
            p.IdPublicacion, 
            p.Titulo, 
            p.Descripcion, 
            p.Puntuacion, 
            p.NumeroResenas, 
            (SELECT pi.Ruta 
             FROM publicacionesimagenes pi 
             WHERE pi.IdPublicacion = p.IdPublicacion 
             ORDER BY pi.Orden 
             LIMIT 1) AS Imagen
        FROM 
            Favoritos f
        INNER JOIN 
            publicaciones p ON f.IdPublicacion = p.IdPublicacion
        WHERE 
            f.IdUsuario = @IdUsuario
        ORDER BY 
            f.FechaAgregado DESC
        LIMIT 
            @ResultadosPorPagina OFFSET @Offset";

            var offset = (pagina - 1) * resultadosPorPagina;

            var favoritos = await _db.QueryAsync<FavoritoTarjetaVM>(sql, new
            {
                IdUsuario = idUsuario,
                ResultadosPorPagina = resultadosPorPagina,
                Offset = offset
            });

            return favoritos.ToList();
        }



        // Agrega un favorito para el usuario
        public async Task<bool> CrearFavoritoAsync(int idPublicacion, string idUsuario)
        {
            var sql = "INSERT INTO Favoritos (IdPublicacion, IdUsuario) VALUES (@IdPublicacion, @IdUsuario)";
            var result = await _db.ExecuteAsync(sql, new { IdPublicacion = idPublicacion, IdUsuario = idUsuario });
            return result > 0;
        }



        // Elimina un favorito del usuario
        public async Task<bool> EliminarFavoritoAsync(int idPublicacion, string idUsuario)
        {
            var sql = "DELETE FROM Favoritos WHERE IdPublicacion = @IdPublicacion AND IdUsuario = @IdUsuario";
            var result = await _db.ExecuteAsync(sql, new { IdPublicacion = idPublicacion, IdUsuario = idUsuario });
            return result > 0;
        }



        // solo el numero total de los favoritos (numero total)
        public async Task<int> FavoritosGuardadosTotal(string idUsuario)
        {
            var sql = @"
                SELECT COUNT(*)
                FROM Favoritos
                WHERE IdUsuario = @IdUsuario";

            // Ejecuta la consulta y retorna el número total de favoritos
            var totalFavoritos = await _db.ExecuteScalarAsync<int>(sql, new { IdUsuario = idUsuario });
            return totalFavoritos;
        }
    }
}
