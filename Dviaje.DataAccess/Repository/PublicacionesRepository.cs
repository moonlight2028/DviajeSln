using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using System.Data;

namespace Dviaje.DataAccess.Repository
{
    public class PublicacionesRepository : IPublicacionesRepository
    {
        private readonly IDbConnection _db;


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

        public async Task<List<PublicacionTarjetaBusquedaVM>> ObtenerListaPublicacionTarjetaBusquedaVMAsync(int pagina, int numeroPublicaciones, string? ordenarPor = null)
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
            var publicaciones = await _db.QueryAsync<PublicacionTarjetaBusquedaVM>(consultaPublicaciones, new { orderBy = ordenarPor, pageSize = numeroPublicaciones, offset = (pagina - 1) * numeroPublicaciones });

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

        public async Task<PublicacionDetalleVM?> ObtenerPublicacionDetalleVMAsync(int idPublicacion)
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
                    p.Direccion AS Ubicacion,
                    a.Id AS IdAliado,
                    a.Avatar AS AvatarAliado,
                    a.UserName AS NombreAliado,
                    a.NumeroPublicaciones AS PublicacionesAliado,
                    IFNULL(a.Verificado, 0) AS VerificadoAliado
                FROM Publicaciones p
                LEFT JOIN aspnetusers a ON p.IdAliado = a.Id
                WHERE p.IdPublicacion = @IdPublicacion;";


            // Ejecutar las consultas
            var publicacion = await _db.QueryFirstOrDefaultAsync<PublicacionDetalleVM>(consultaPublicacion, new { IdPublicacion = idPublicacion });


            if (publicacion != null)
            {
                // Consultas para obtener las listas relacionadas
                string consultaPuntuaciones = @"
                    SELECT 
                        r.Calificacion AS puntuacion,
                        COUNT(r.Calificacion) AS cantidad
                    FROM 
                        resenas r
                    JOIN 
                        reservas res ON r.IdReserva = res.IdReserva
                    WHERE 
                        res.IdPublicacion = @IdPublicacion
                    GROUP BY 
                        r.Calificacion
                    ORDER BY 
                        r.Calificacion DESC;
                ";

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
                        s.IdServicio,
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
                var puntuaciones = await _db.QueryAsync<PuntuacionVM>(consultaPuntuaciones, new { IdPublicacion = idPublicacion });
                var imagenes = await _db.QueryAsync<PublicacionImagenVM>(consultaImagenes, new { IdPublicacion = idPublicacion });
                var categorias = await _db.QueryAsync<CategoriaVM>(consultaCategorias, new { IdPublicacion = idPublicacion });
                var servicios = await _db.QueryAsync<ServicioVM>(consultaServicios, new { IdPublicacion = idPublicacion });
                var serviciosAdicionales = await _db.QueryAsync<ServicioAdicionalVM>(consultaServiciosAdicionales, new { IdPublicacion = idPublicacion });
                var restricciones = await _db.QueryAsync<RestriccionVM>(consultaRestricciones, new { IdPublicacion = idPublicacion });


                // Carga los datos de las sub consultas en el modelo de publicación
                publicacion.PuntuacionPorEstrellas = puntuaciones.ToList();
                publicacion.Imagenes = imagenes.ToList();
                publicacion.Categorias = categorias.ToList();
                publicacion.Servicios = servicios.ToList();
                publicacion.ServiciosAdicionales = serviciosAdicionales.ToList();
                publicacion.Restricciones = restricciones.ToList();
                // ToDo: Agregar consulta
                publicacion.TopResenas = null;
            }

            return publicacion;
        }

        public async Task<PublicacionResenasVM?> ObtenerPublicacionResenasVMAsyn(int idPublicacion)
        {
            // Corregir consulta retornar solo la informacion del modelo PublicacionResenasVM
            //var sql = @"
            //    SELECT rs.IdPublicacion, rs.Opinion, rs.Fecha, rs.Calificacion AS Puntuacion, rs.MeGusta, NULL AS AvatarTurista
            //    FROM Resenas rs
            //    WHERE rs.IdPublicacion = @IdPublicacion
            //    ORDER BY rs.Calificacion DESC
            //    LIMIT @ElementosPorPagina OFFSET @Offset";

            //var offset = (paginaActual - 1) * elementosPorPagina;

            //return (await _db.QueryAsync<ResenasTarjetaVM>(sql, new
            //{
            //    IdPublicacion = idPublicacion,
            //    ElementosPorPagina = elementosPorPagina,
            //    Offset = offset
            //})).ToList();


            // Datos de test borrar cuando esté lista la consulta
            PublicacionResenasVM informacionResenaPublicacion = new PublicacionResenasVM
            {
                IdPublicacion = 1,
                TituloPublicacion = "Aventura en la Montaña",
                PuntuacionPublicacion = 4.2m,
                DescripcionPublicacion = "La comunicación efectiva es fundamental en todos los aspectos de la vida. Permite expresar ideas, compartir conocimientos y construir relaciones sólidas. En el ámbito profesional, la comunicación clara y precisa es clave para alcanzar objetivos, resolver conflictos y fomentar la colaboración. Además, una buena comunicación ayuda a motivar a los equipos, a mejorar la productividad y a garantizar el éxito en proyectos. Dominar esta habilidad es esencial para el desarrollo personal y profesional en un entorno cada vez más interconectado.",
                DireccionPublicacion = "Calle Falsa 123, Ciudad, País",
                ImagenPublicacion = "https://images.unsplash.com/photo-1724093121148-ec407f45e44c?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
            };

            return (informacionResenaPublicacion);
        }

        public Task<PublicacionTarjetaImagenVM?> ObtenerPublicacionTarjetaImagenVMAsync(int idPublicacion)
        {
            return Task.FromResult<PublicacionTarjetaImagenVM?>(null);
        }

        public Task<bool> CrearPublicacionAsync(PublicacionCrearVM publicacion)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditarPublicacionAsync(PublicacionCrearVM publicacion)
        {
            throw new NotImplementedException();
        }

        public Task<PublicacionCrearVM?> ObtenerPublicacionCrearVMAsync(int idPublicacion)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EstadoEliminarPublicacionAsync(int idPublicacion, int idAliado)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EstadoCambiarPublicacionAsync(int idPublicacion, int idAliado, string estado)
        {
            throw new NotImplementedException();
        }

        public Task<List<PublicacionTablaItemVM>?> ObtenerListaPublicacionTablaItemVMAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ReportesPublicacionesPorMesVM>?> ReportePublicacionesPorMesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ReportesPublicacionesTopCategoriaVM>?> ReporteTopCategoriasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ReportesPublicacionesActivasVM>?> ReportePublicacionesActivasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ReportesPublicacionesPreciosVM>?> ReportePreciosPromediosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ReportesPublicacionesTopPublicacionesVM>?> ReporteTopPublicacionesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ReportesPublicacionesDetallesVM?> ReporteDetallesAsync(DateTime FechaActual)
        {
            throw new NotImplementedException();
        }
    }
}
