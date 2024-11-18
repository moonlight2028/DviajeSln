using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Dviaje.Models.VM.Dviaje.Models.VM;
using Dviaje.Models.VM.Dviaje.Models.VM.Dviaje.Models.VM;
using System.Data;

public class LandingPageRepository : ILandingPageRepository
{
    private readonly IDbConnection _db;

    public LandingPageRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<List<CategoriaVM>> ObtenerCategoriasAsync()
    {
        var sql = @"
            SELECT 
                IdCategoria,
                NombreCategoria,
                RutaIcono
            FROM 
                Categorias
            ORDER BY 
                NombreCategoria;
        ";

        return (await _db.QueryAsync<CategoriaVM>(sql)).ToList();
    }

    public async Task<List<PublicacionDestacadaVM>> ObtenerPublicacionesDestacadasAsync()
    {
        var sql = @"
        SELECT 
            p.IdPublicacion,
            p.Titulo,
            p.Descripcion,
            p.Direccion AS Ubicacion,
            (SELECT Ruta 
             FROM PublicacionesImagenes pi 
             WHERE pi.IdPublicacion = p.IdPublicacion 
             ORDER BY pi.Orden LIMIT 1) AS ImagenPrincipal
        FROM 
            Publicaciones p
        WHERE 
            p.Puntuacion >= 4.5
        ORDER BY 
            p.Puntuacion DESC
        LIMIT 5;
    ";

        var publicaciones = await _db.QueryAsync<PublicacionDestacadaVM>(sql);

        // Subconsulta para las miniaturas (lista de imágenes)
        var ids = publicaciones.Select(p => p.IdPublicacion).ToList();

        var sqlImagenes = @"
        SELECT 
            pi.IdPublicacion,
            pi.Ruta AS Imagen,
            pi.Alt AS Alt
        FROM 
            PublicacionesImagenes pi
        WHERE 
            pi.IdPublicacion IN @Ids
        ORDER BY 
            pi.Orden;
    ";

        var imagenes = await _db.QueryAsync<PublicacionImagenVM>(sqlImagenes, new { Ids = ids });

        // Asocia las imágenes a sus publicaciones correspondientes
        foreach (var publicacion in publicaciones)
        {
            publicacion.Imagenes = imagenes
                .Where(img => img.IdPublicacion == publicacion.IdPublicacion)
                .ToList();
        }

        return publicaciones.ToList();
    }

}
