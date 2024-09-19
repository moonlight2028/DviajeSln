using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using System.Data;

namespace Dviaje.DataAccess.Repository
{
    public class PublicacionesRepository : IPublicacionesRepository
    {
        // Conexión de la base de datos
        private readonly IDbConnection _db;


        // Constructor e inyección de la conexión a la base de datos
        public PublicacionesRepository(IDbConnection db)
        {
            _db = db;
        }

        // Retorna todas las publicaciones registradas
        public async Task<int> PublicacionesTotales()
        {
            string consulta = "SELECT COUNT(*) FROM publicaciones";
            int totalPublicaciones = await _db.ExecuteScalarAsync<int>(consulta);

            return totalPublicaciones;
        }


        //metodo get all para reportes 

        public async Task<List<PublicacionTarjetaV2VM>> GetAll()
        {
            string consulta = @"
        SELECT 
            p.IdPublicacion,
            p.Titulo,
            p.Puntuacion,
            p.Descripcion,
            c.NombreCategoria AS Categoria
        FROM 
            publicaciones p
        JOIN 
            publicacionescategorias pc ON p.IdPublicacion = pc.IdPublicacion
        JOIN 
            categorias c ON pc.IdCategoria = c.IdCategoria;
    ";

            // Ejecuta la consulta y mapea los resultados a PublicacionTarjetaV2VM
            var publicaciones = await _db.QueryAsync<PublicacionTarjetaV2VM>(consulta);

            return publicaciones.ToList();
        }


        public async Task<List<PublicacionTarjetaVM>> ObtenerPublicacionesAsync(int pagina, int numeroPublicaciones, string? ordenarPor = null)
        {
            // Consulta para obtener las publicaciones
            string consultaPublicaciones = @"
                SELECT 
                    p.IdPublicacion,
                    a.Id AS AliadoId,
                    a.Avatar AS AvatarAliado,
                    a.UserName AS NombreAliado,
                    IFNULL(a.NumeroPublicaciones, 0) AS TotalPublicacionesAliado,
                    IFNULL(a.Verificado, 0) AS Verificado,
                    p.Precio,
                    p.Titulo,
                    p.Direccion,
                    p.Puntuacion,
                    p.NumeroResenas,
                    p.Descripcion
                FROM 
                    publicaciones p
                LEFT JOIN 
                    aspnetusers a ON p.IdAliado = a.Id
                ORDER BY 
                    CASE 
                        WHEN @orderBy IS NULL OR @orderBy NOT IN ('precio_mayor', 'precio_menor') THEN p.Puntuacion 
                    END DESC,
                    CASE 
                        WHEN @orderBy = 'precio_mayor' THEN p.Precio 
                    END DESC,
                    CASE 
                        WHEN @orderBy = 'precio_menor' THEN p.Precio 
                    END ASC
                LIMIT @pageSize OFFSET @offset;
            ";

            // Consulta para obtener las categorías
            string consultaCategorias = @"
                SELECT 
                    pc.IdPublicacion,
                    c.IdCategoria,
                    c.NombreCategoria,
                    c.RutaIcono
                FROM 
                    publicacionescategorias pc
                JOIN 
                    categorias c ON pc.IdCategoria = c.IdCategoria
                WHERE 
                    pc.IdPublicacion IN @idsPublicaciones
            ";

            // Consulta para obtener las imágenes
            string consultaImagenes = @"
                SELECT 
                    pi.IdPublicacion,
                    pi.Ruta,
                    pi.Alt
                FROM 
                    publicacionesimagenes pi
                WHERE 
                    pi.IdPublicacion IN @idsPublicaciones
            ";


            // Ejecuta y obtiene la consulta de las publicaciones
            var publicaciones = await _db.QueryAsync<PublicacionTarjetaVM>(consultaPublicaciones, new { orderBy = ordenarPor, pageSize = numeroPublicaciones, offset = (pagina - 1) * numeroPublicaciones });

            // Obtiene los Id de las publicaciones para usarlos en las siguientes consultas
            var idsPublicaciones = publicaciones.Select(p => p.IdPublicacion).ToList();

            // Ejecuta y obtiene la consulta de las categorías
            var categorias = await _db.QueryAsync<CategoriaVM>(consultaCategorias, new { idsPublicaciones });

            // Ejecuta y obtiene la consulta de las imágenes
            var imagenes = await _db.QueryAsync<PublicacionImagenVM>(consultaImagenes, new { idsPublicaciones });


            // Carga las categorías y las imágenes en las publicaciones
            foreach (var publicacion in publicaciones)
            {
                publicacion.Categorias = categorias.Where(c => c.IdPublicacion == publicacion.IdPublicacion).ToList();
                publicacion.Imagenes = imagenes.Where(i => i.IdPublicacion == publicacion.IdPublicacion).ToList();
            }

            return publicaciones.ToList();
        }

        public async Task<PublicacionVM?> ObtenerPublicacionPorIdAsync(int idPublicacion)
        {
            // // Consulta para obtener la publicación
            string consultaPublicacion = @"
                SELECT 
                    p.IdPublicacion,
                    p.Titulo,
                    p.Puntuacion,
                    p.NumeroResenas,
                    p.Descripcion,
                    p.Precio,
                    p.Direccion,
                    a.Id AS IdAliado,
                    a.Avatar AS AvatarAliado,
                    a.UserName AS NombreAliado,
                    a.NumeroPublicaciones AS PublicacionesAliado
                FROM Publicaciones p
                LEFT JOIN aspnetusers a ON p.IdAliado = a.Id
                WHERE p.IdPublicacion = @IdPublicacion;";


            // Ejecutar las consultas
            var publicacion = await _db.QueryFirstOrDefaultAsync<PublicacionVM>(consultaPublicacion, new { IdPublicacion = idPublicacion });


            if (publicacion != null)
            {
                // Consultas para obtener las listas relacionadas
                string consultaImagenes = @"
                    SELECT 
                        pi.Ruta,
                        pi.Alt
                    FROM publicacionesimagenes pi 
                    WHERE pi.IdPublicacion = @IdPublicacion;";

                string consultaCategorias = @"
                    SELECT 
                        c.IdCategoria,
                        c.NombreCategoria,
                        c.RutaIcono
                    FROM publicacionescategorias pc 
                    INNER JOIN categorias c ON pc.IdCategoria = c.IdCategoria
                    WHERE pc.IdPublicacion = @IdPublicacion;";

                string consultaServicios = @"
                    SELECT 
                        s.NombreServicio,
                        s.ServicioTipo,
                        s.RutaIcono 
                    FROM publicacionesservicios ps 
                    INNER JOIN servicios s ON ps.IdServicio = s.IdServicio
                    WHERE ps.IdPublicacion = @IdPublicacion;";

                string consultaServiciosAdicionales = @"
                    SELECT 
                        sa.Precio,
                        s.NombreServicio,
                        s.ServicioTipo,
                        s.RutaIcono 
                    FROM serviciosadicionales sa 
                    INNER JOIN servicios s ON sa.IdServicio = s.IdServicio
                    WHERE sa.IdPublicacion = @IdPublicacion;";

                string consultaRestricciones = @"
                    SELECT 
                        r.NombreRestriccion,
                        r.RutaIcono
                    FROM publicacionesrestricciones pr 
                    INNER JOIN restricciones r ON pr.IdRestriccion = r.IdRestriccion
                    WHERE pr.IdPublicacion = @IdPublicacion;";


                // Ejecuta y obtiene los datos de las consultas
                var imagenes = await _db.QueryAsync<PublicacionImagenVM>(consultaImagenes, new { IdPublicacion = idPublicacion });
                var categorias = await _db.QueryAsync<CategoriaVM>(consultaCategorias, new { IdPublicacion = idPublicacion });
                var servicios = await _db.QueryAsync<ServicioVM>(consultaServicios, new { IdPublicacion = idPublicacion });
                var serviciosAdicionales = await _db.QueryAsync<ServicioAdicionalVM>(consultaServiciosAdicionales, new { IdPublicacion = idPublicacion });
                var restricciones = await _db.QueryAsync<RestriccionVM>(consultaRestricciones, new { IdPublicacion = idPublicacion });


                // Carga los datos de las sub consultas en el modelo de publicación
                publicacion.Imagenes = imagenes.ToList();
                publicacion.Categorias = categorias.ToList();
                publicacion.Servicios = servicios.ToList();
                publicacion.ServiciosAdicionales = serviciosAdicionales.ToList();
                publicacion.Restricciones = restricciones.ToList();
            }

            return publicacion;
        }

        Task<PublicacionTarjetaV2VM> IPublicacionesRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
