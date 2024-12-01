using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using System.Data;

namespace Dviaje.DataAccess.Repository
{
    public class CategoriasRepository : ICategoriasRepository
    {
        private readonly IDbConnection _db;

        public CategoriasRepository(IDbConnection db)
        {
            _db = db;
        }

        // Crear nueva categoría
        public async Task<bool> CrearCategoriaAsync(Categoria categoria)
        {
            var sql = @"
            INSERT INTO Categorias (NombreCategoria, Descripcion, RutaIcono, UrlImagen, IdImagen)
            VALUES (@NombreCategoria, @Descripcion, @RutaIcono, @UrlImagen, @IdImagen)";

            var result = await _db.ExecuteAsync(sql, new
            {
                NombreCategoria = categoria.NombreCategoria,
                Descripcion = categoria.Descripcion,
                RutaIcono = categoria.RutaIcono,
                UrlImagen = categoria.UrlImagen,
                IdImagen = categoria.IdImagen
            });

            return result > 0; // Retorna true si la inserción fue exitosa
        }

        // Obtener una categoría por su ID
        public async Task<Categoria?> ObtenerCategoriaPorIdAsync(int idCategoria)
        {
            var sql = @"
            SELECT IdCategoria, NombreCategoria, Descripcion, RutaIcono, UrlImagen, IdImagen
            FROM Categorias
            WHERE IdCategoria = @IdCategoria";

            return await _db.QueryFirstOrDefaultAsync<Categoria>(sql, new { IdCategoria = idCategoria });
        }

        // Obtener todas las categorías
        public async Task<List<Categoria>> ObtenerCategoriasAsync()
        {
            var sql = @"
            SELECT IdCategoria, NombreCategoria, Descripcion, RutaIcono, UrlImagen, IdImagen
            FROM Categorias";

            var categorias = await _db.QueryAsync<Categoria>(sql);
            return categorias.ToList();
        }

        // Actualizar una categoría existente
        public async Task<bool> ActualizarCategoriaAsync(Categoria categoria)
        {
            var sql = @"
            UPDATE Categorias
            SET NombreCategoria = @NombreCategoria, 
                Descripcion = @Descripcion, 
                RutaIcono = @RutaIcono, 
                UrlImagen = @UrlImagen, 
                IdImagen = @IdImagen
            WHERE IdCategoria = @IdCategoria";

            var result = await _db.ExecuteAsync(sql, new
            {
                NombreCategoria = categoria.NombreCategoria,
                Descripcion = categoria.Descripcion,
                RutaIcono = categoria.RutaIcono,
                UrlImagen = categoria.UrlImagen,
                IdImagen = categoria.IdImagen,
                IdCategoria = categoria.IdCategoria
            });

            return result > 0; // Retorna true si la actualización fue exitosa
        }

        // Eliminar una categoría
        public async Task<bool> EliminarCategoriaAsync(int idCategoria)
        {
            var sql = @"
            DELETE FROM Categorias
            WHERE IdCategoria = @IdCategoria";

            var result = await _db.ExecuteAsync(sql, new { IdCategoria = idCategoria });
            return result > 0; // Retorna true si la eliminación fue exitosa
        }
    }
}
