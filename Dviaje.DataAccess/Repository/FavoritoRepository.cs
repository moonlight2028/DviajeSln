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
            // Consulta con paginación
            var sql = @"
                     SELECT p.IdPublicacion, p.Titulo, p.Descripcion, p.Puntuacion, p.NumeroResenas, 
                     (SELECT pi.Ruta FROM publicacionimagenes pi WHERE pi.IdPublicacion = p.IdPublicacion ORDER BY pi.Orden LIMIT 1) AS Imagen
                     FROM Favoritos f
                     INNER JOIN Publicaciones p ON f.IdPublicacion = p.IdPublicacion
                     WHERE f.IdUsuario = @IdUsuario
                     ORDER BY f.FechaAgregado DESC
                     LIMIT @ResultadosPorPagina OFFSET @Offset";

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



        // solo el numero total de los favoritos (numero total)
        public Task<int> FavoritosGuardadosTotal(string idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
