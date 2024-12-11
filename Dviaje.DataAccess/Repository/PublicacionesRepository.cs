using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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


        public async Task<int> PublicacionesTotalesPorIdAliadoAsync(string idAliado)
        {
            string consulta = "SELECT COUNT(*) FROM publicaciones WHERE IdAliado = @IdAliado;";
            int totalPublicaciones = await _db.ExecuteScalarAsync<int>(consulta, new { IdAliado = idAliado });

            return totalPublicaciones;
        }


        public async Task<List<PublicacionTarjetaBusquedaVM>> ObtenerListaPublicacionTarjetaBusquedaVMAsync(int pagina, int numeroPublicaciones, string? ordenarPor = null)
        {
            // Consulta para obtener las publicaciones
            string consultaPublicaciones = @"
        SELECT 
            p.IdPublicacion,
            a.Id AS AliadoId,
            a.UserName AS NombreAliado,
            a.Avatar AS AvatarAliado,
            IFNULL(a.NumeroPublicaciones, 0) AS TotalPublicacionesAliado,
            IFNULL(a.Verificado, 0) AS Verificado,
            p.PrecioNoche AS Precio,
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
                WHEN @orderBy = 'precio_mayor' THEN p.PrecioNoche 
            END DESC,
            CASE 
                WHEN @orderBy = 'precio_menor' THEN p.PrecioNoche 
            END ASC
        LIMIT @pageSize OFFSET @offset";

            // Consulta para obtener las imágenes
            string consultaImagenes = @"
        SELECT 
            pi.IdPublicacion,
            pi.Ruta,
            pi.Alt
        FROM 
            publicacionesimagenes pi
        WHERE 
            pi.IdPublicacion IN @idsPublicaciones";

            // Ejecuta y obtiene la consulta de las publicaciones
            var publicaciones = await _db.QueryAsync<PublicacionTarjetaBusquedaVM>(consultaPublicaciones, new
            {
                orderBy = ordenarPor,
                pageSize = numeroPublicaciones,
                offset = (pagina - 1) * numeroPublicaciones
            });

            // Obtiene los Id de las publicaciones para usarlos en las siguientes consultas
            var idsPublicaciones = publicaciones.Select(p => p.IdPublicacion).ToList();

            // Ejecuta y obtiene la consulta de las imágenes
            var imagenes = await _db.QueryAsync<PublicacionImagenVM>(consultaImagenes, new { idsPublicaciones });

            // Carga las imágenes en las publicaciones
            foreach (var publicacion in publicaciones)
            {
                publicacion.Imagenes = imagenes.Where(i => i.IdPublicacion == publicacion.IdPublicacion).ToList();
            }

            return publicaciones.ToList();
        }


        public async Task<List<PublicacionMisPublicacionesVM>>? ObtenerListaPublicacionMisPublicacionesVMAsync(int pagina, int numeroPublicaciones, string? ordenarPor = null, string idAliado = "")
        {
            // Consulta para obtener las publicaciones
            string consultaPublicaciones = @"
                SELECT 
                    p.IdPublicacion,
                    p.PrecioNoche AS Precio,
                    p.Titulo,
                    p.Direccion,
                    p.Puntuacion,
                    p.NumeroResenas,
                    p.Descripcion,
                    IFNULL(a.NumeroPublicaciones, 0) AS TotalPublicacionesAliado
                FROM 
                    publicaciones p
                LEFT JOIN 
                    aspnetusers a ON p.IdAliado = a.Id
                WHERE 
                    (@IdAliado IS NULL OR p.IdAliado = @IdAliado)
                ORDER BY 
                    CASE 
                        WHEN @orderBy IS NULL OR @orderBy NOT IN ('precio_mayor', 'precio_menor') THEN p.Puntuacion 
                    END DESC,
                    CASE 
                        WHEN @orderBy = 'precio_mayor' THEN p.PrecioNoche 
                    END DESC,
                    CASE 
                        WHEN @orderBy = 'precio_menor' THEN p.PrecioNoche 
                    END ASC
                LIMIT @pageSize OFFSET @offset
            ";
            var publicaciones = await _db.QueryAsync<PublicacionMisPublicacionesVM>(consultaPublicaciones, new
            {
                orderBy = ordenarPor,
                pageSize = numeroPublicaciones,
                offset = (pagina - 1) * numeroPublicaciones,
                IdAliado = idAliado
            });

            if (!publicaciones.Any()) return null;

            // Ids
            var idsPublicaciones = publicaciones.Select(p => p.IdPublicacion).ToList();

            // Consulta para obtener imágenes
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

            // Consulta para obtener las propiedades
            string consultaPropiedad = @"
                SELECT 
                    p.IdPublicacion,
                    pr.IdPropiedad,
                    pr.Nombre,
                    pr.RutaIcono
                FROM 
                    publicaciones p
                INNER JOIN 
                    propiedades pr ON p.IdPropiedad = pr.IdPropiedad
                WHERE 
                    p.IdPublicacion IN @idsPublicaciones
            ";

            // Consulta para obtener las categorías
            string consultaCategoria = @"
                SELECT 
                    c.IdCategoria,
                    c.NombreCategoria,
                    c.RutaIcono,
                    p.IdPublicacion
                FROM 
                    publicaciones p
                INNER JOIN 
                    propiedades pr ON p.IdPropiedad = pr.IdPropiedad
                INNER JOIN 
                    categorias c ON pr.IdCategoria = c.IdCategoria
                WHERE 
                    p.IdPublicacion IN @idsPublicaciones;
            ";

            // Consulta para obtener los servicios
            string consultaServicios = @"
                SELECT 
                    ps.IdPublicacion,
                    s.IdServicio,
                    s.NombreServicio,
                    s.RutaIcono
                FROM 
                    PublicacionesServicios ps
                INNER JOIN 
                    servicios s ON ps.IdServicio = s.IdServicio
                WHERE 
                    ps.IdPublicacion IN @idsPublicaciones;
            ";

            // consulta para obtener las restricciones
            string consultaRestricciones = @"
                SELECT 
                    pr.IdPublicacion,
                    r.IdRestriccion,
                    r.NombreRestriccion,
                    r.RutaIcono
                FROM 
                    PublicacionesRestricciones pr
                INNER JOIN 
                    Restricciones r ON pr.IdRestriccion = r.IdRestriccion
                WHERE 
                    pr.IdPublicacion IN @idsPublicaciones;
            ";


            // Carga de datos en las publicaciones
            var imagenes = await _db.QueryAsync<PublicacionImagenVM>(consultaImagenes, new { idsPublicaciones });
            var propiedades = await _db.QueryAsync<PropiedadVM>(consultaPropiedad, new { idsPublicaciones });
            var categorias = await _db.QueryAsync<CategoriaVM>(consultaCategoria, new { idsPublicaciones });
            var servicios = await _db.QueryAsync<ServicioVM>(consultaServicios, new { idsPublicaciones });
            var restricciones = await _db.QueryAsync<RestriccionVM>(consultaRestricciones, new { idsPublicaciones });
            publicaciones = publicaciones.Select(publicacion =>
            {
                publicacion.Imagenes = imagenes
                    .Where(i => i.IdPublicacion == publicacion.IdPublicacion)
                    .ToList();

                publicacion.Propiedad = propiedades
                    .Where(p => p.IdPublicacion == publicacion.IdPublicacion)
                    .Select(pr => new PropiedadVM
                    {
                        IdPropiedad = pr.IdPropiedad,
                        Nombre = pr.Nombre,
                        RutaIcono = pr.RutaIcono
                    })
                    .FirstOrDefault();

                publicacion.Categoria = categorias
                    .Where(c => c.IdPublicacion == publicacion.IdPublicacion)
                    .Select(pr => new CategoriaVM
                    {
                        IdCategoria = pr.IdCategoria,
                        NombreCategoria = pr.NombreCategoria,
                        RutaIcono = pr.RutaIcono
                    })
                    .FirstOrDefault();

                publicacion.Servicios = servicios
                    .Where(s => s.IdPublicacion == publicacion.IdPublicacion)
                    .Select(s => new ServicioVM
                    {
                        IdServicio = s.IdServicio,
                        NombreServicio = s.NombreServicio,
                        RutaIcono = s.RutaIcono
                    })
                    .ToList();

                publicacion.Restricciones = restricciones
                    .Where(r => r.IdPublicacion == publicacion.IdPublicacion)
                    .Select(r => new RestriccionVM
                    {
                        IdRestriccion = r.IdRestriccion,
                        NombreRestriccion = r.NombreRestriccion,
                        RutaIcono = r.RutaIcono
                    })
                    .ToList();

                return publicacion;
            }).ToList();


            return publicaciones.ToList();
        }











        public async Task<PublicacionDetalleVM?> ObtenerPublicacionDetalleVMAsync(int idPublicacion)
        {
            // Consulta para obtener la publicación
            string consultaPublicacion = @"
                SELECT 
                    p.IdPublicacion,
                    p.Titulo,
                    p.Puntuacion,
                    p.NumeroResenas,
                    p.Descripcion,
                    p.PrecioNoche AS Precio,
                    p.Direccion AS Ubicacion,
                    a.Id AS IdAliado,
                    a.UserName AS NombreAliado,
                    a.Avatar AS AvatarAliado,
                    IFNULL(a.NumeroPublicaciones, 0) AS PublicacionesAliado,
                    IFNULL(a.Verificado, 0) AS VerificadoAliado
                FROM 
                    publicaciones p
                LEFT JOIN 
                    aspnetusers a ON p.IdAliado = a.Id
                WHERE 
                    p.IdPublicacion = @IdPublicacion
            ";

            // Ejecutar la consulta principal
            var publicacion = await _db.QueryFirstOrDefaultAsync<PublicacionDetalleVM>(consultaPublicacion, new { IdPublicacion = idPublicacion });

            if (publicacion != null)
            {
                // Consultas relacionadas
                string consultaPuntuaciones = @"
                    SELECT 
                        r.Calificacion AS Puntuacion,
                        COUNT(r.Calificacion) AS Cantidad
                    FROM 
                        resenas r
                    JOIN 
                        reservas res ON r.IdReserva = res.IdReserva
                    WHERE 
                        res.IdPublicacion = @IdPublicacion
                    GROUP BY 
                        r.Calificacion
                    ORDER BY 
                        r.Calificacion DESC
                ";

                string consultaImagenes = @"
                    SELECT 
                        pi.Ruta,
                        pi.Alt
                    FROM 
                        publicacionesimagenes pi
                    WHERE 
                        pi.IdPublicacion = @IdPublicacion";

                string consultaServicios = @"
                    SELECT
                        s.IdServicio,
                        s.NombreServicio,
                        s.ServicioTipo,
                        s.RutaIcono,
                        s.ServicioTipo
                    FROM 
                        publicacionesservicios ps
                    INNER JOIN 
                        servicios s ON ps.IdServicio = s.IdServicio
                    WHERE 
                        ps.IdPublicacion = @IdPublicacion
                ";

                string consultaRestricciones = @"
                    SELECT 
                        r.NombreRestriccion,
                        r.RutaIcono
                    FROM 
                        publicacionesrestricciones pr
                    INNER JOIN 
                        restricciones r ON pr.IdRestriccion = r.IdRestriccion
                    WHERE 
                        pr.IdPublicacion = @IdPublicacion
                ";

                string consultaPropiedad = @"
                    SELECT 
                        p.IdPublicacion,
                        pr.IdPropiedad,
                        pr.Nombre,
                        pr.RutaIcono
                    FROM 
                        publicaciones p
                    INNER JOIN 
                        propiedades pr ON p.IdPropiedad = pr.IdPropiedad
                    WHERE 
                        p.IdPublicacion = @IdPublicacion;
                ";

                string consultaCategoria = @"
                    SELECT 
                        c.IdCategoria,
                        c.NombreCategoria,
                        c.RutaIcono
                    FROM 
                        publicaciones p
                    INNER JOIN 
                        propiedades pr ON p.IdPropiedad = pr.IdPropiedad
                    INNER JOIN 
                        categorias c ON pr.IdCategoria = c.IdCategoria
                    WHERE 
                        p.IdPublicacion = @IdPublicacion;
                ";


                // Ejecuta las consultas relacionadas
                var puntuaciones = await _db.QueryAsync<PuntuacionVM>(consultaPuntuaciones, new { IdPublicacion = idPublicacion });
                var imagenes = await _db.QueryAsync<PublicacionImagenVM>(consultaImagenes, new { IdPublicacion = idPublicacion });
                var categoria = await _db.QueryFirstOrDefaultAsync<CategoriaVM>(consultaCategoria, new { IdPublicacion = idPublicacion });
                var propiedad = await _db.QueryFirstOrDefaultAsync<PropiedadVM>(consultaPropiedad, new { IdPublicacion = idPublicacion });
                var servicios = await _db.QueryAsync<ServicioVM>(consultaServicios, new { IdPublicacion = idPublicacion });
                var restricciones = await _db.QueryAsync<RestriccionVM>(consultaRestricciones, new { IdPublicacion = idPublicacion });

                // Asigna los resultados a la publicación
                publicacion.PuntuacionPorEstrellas = puntuaciones.ToList();
                publicacion.Imagenes = imagenes.ToList();
                publicacion.ServiciosHabitacion = servicios.Where(s => s.ServicioTipo == ServicioTipo.Habitacion.ToString()).ToList();
                publicacion.ServiciosEstablecimiento = servicios.Where(s => s.ServicioTipo == ServicioTipo.Establecimiento.ToString()).ToList();
                publicacion.ServiciosAccesibilidad = servicios.Where(s => s.ServicioTipo == ServicioTipo.Accesibilidad.ToString()).ToList();
                publicacion.Restricciones = restricciones.ToList();
                publicacion.Categoria = categoria;
                publicacion.Propiedad = propiedad;
                // ToDo: Agregar lógica para TopResenas si es necesario
                publicacion.TopResenas = null;
            }

            return publicacion;
        }


        public async Task<PublicacionResenasVM?> ObtenerPublicacionResenasVMAsync(int idPublicacion)
        {
            string consulta = @"
        SELECT 
            p.IdPublicacion, 
            p.Titulo AS TituloPublicacion,
            p.Puntuacion AS PuntuacionPublicacion,
            p.Descripcion AS DescripcionPublicacion,
            p.Direccion AS DireccionPublicacion,
            (SELECT pi.Ruta FROM publicacionesimagenes pi WHERE pi.IdPublicacion = p.IdPublicacion ORDER BY pi.Orden LIMIT 1) AS ImagenPublicacion
        FROM 
            publicaciones p
        WHERE 
            p.IdPublicacion = @IdPublicacion";

            return await _db.QueryFirstOrDefaultAsync<PublicacionResenasVM>(consulta, new { IdPublicacion = idPublicacion });
        }





        public async Task<PublicacionTarjetaImagenVM?> ObtenerPublicacionTarjetaImagenVMAsync(int idPublicacion)
        {
            var sql = @"
                SELECT 
                    p.Titulo,
                    p.IdPublicacion,
                    (SELECT pi.Ruta FROM publicacionesimagenes pi WHERE pi.IdPublicacion = p.IdPublicacion ORDER BY pi.Orden LIMIT 1) AS Imagen,
                    p.Direccion,
                    p.Puntuacion,
                    a.Id AS IdAliado,
                    a.UserName AS NombreAliado,
                    a.Avatar AS AvatarAliado
                FROM 
                    publicaciones p
                LEFT JOIN 
                    aspnetusers a ON p.IdAliado = a.Id
                WHERE 
                    p.IdPublicacion = @IdPublicacion
            ";

            return await _db.QueryFirstOrDefaultAsync<PublicacionTarjetaImagenVM>(sql, new { IdPublicacion = idPublicacion });
        }




        public async Task<int?> CrearPublicacionAsync(PublicacionCrearFrontVM publicacion)
        {
            try
            {
                if (_db.State != ConnectionState.Open)
                {
                    _db.Open();
                }

                using var transaction = _db.BeginTransaction();
                try
                {
                    // Registro tabla Publicaciones
                    var sqlPublicacion = @"
                        INSERT INTO publicaciones (Titulo, Descripcion, PrecioNoche, Fecha, Direccion, NumeroCamas, Huespedes, Recamaras, Banios, PublicacionEstado, IdPropiedad, IdAliado)
                        VALUES (@Titulo, @Descripcion, @PrecioNoche, @Fecha, @Direccion, @NumeroCamas, @Huespedes, @Recamaras, @Banios, @PublicacionEstado, @PropiedadSeleccionada, @IdAliado);
                        SELECT LAST_INSERT_ID();
                    ";
                    var idPublicacion = await _db.ExecuteScalarAsync<int>(sqlPublicacion, publicacion, transaction);

                    var data = ":adsf";


                    // Registro tabla PublicacionesServicios
                    var serviciosLista = publicacion.ServiciosSeleccionados.Select(s => new
                    {
                        IdPublicacion = idPublicacion,
                        IdServicio = s
                    });
                    var sqlServicios = @"
                        INSERT INTO PublicacionesServicios (IdPublicacion, IdServicio)
                        VALUES (@IdPublicacion, @IdServicio);
                    ";

                    await _db.ExecuteAsync(sqlServicios, serviciosLista, transaction);


                    // Registro tabla PublicacionesRestricciones
                    if (publicacion.RestriccionesSeleccionadas != null)
                    {
                        var sqlRestricciones = @"
                            INSERT INTO PublicacionesRestricciones (IdPublicacion, IdRestriccion)
                            VALUES (@IdPublicacion, @IdRestriccion);
                        ";
                        var restricciones = publicacion.RestriccionesSeleccionadas.Select(restriccion => new
                        {
                            IdPublicacion = idPublicacion,
                            IdRestriccion = restriccion
                        });
                        await _db.ExecuteAsync(sqlRestricciones, restricciones, transaction);
                    }


                    //// Registro tabla FechasNoDisponibles
                    if (publicacion.FechasNoDisponibles != null)
                    {
                        var sqlFechas = @"
                            INSERT INTO FechasNoDisponibles (FechaInicial, FechaFinal, IdPublicacion)
                            VALUES (@FechaInicial, @FechaFinal, @IdPublicacion);
                        ";
                        var fechas = publicacion.FechasNoDisponibles.Select(fecha => new
                        {
                            fecha.FechaInicial,
                            fecha.FechaFinal,
                            IdPublicacion = idPublicacion
                        }).ToList();
                        await _db.ExecuteAsync(sqlFechas, fechas, transaction);
                    }


                    transaction.Commit();
                    return idPublicacion;
                }
                catch
                {
                    transaction.Rollback();
                    return null;
                }
            }
            finally
            {
                if (_db.State == ConnectionState.Open)
                {
                    _db.Close();
                }
            }
        }






        public async Task<bool> EditarPublicacionAsync(PublicacionCrearVM publicacion)
        {
            var sql = @"
        UPDATE publicaciones 
        SET 
            Titulo = @Titulo, 
            Descripcion = @Descripcion, 
            PrecioNoche = @PrecioNoche, 
            Direccion = @Direccion
        WHERE 
            IdPublicacion = @IdPublicacion";

            var resultado = await _db.ExecuteAsync(sql, publicacion);
            return resultado > 0;
        }



        public async Task<PublicacionCrearVM?> ObtenerPublicacionCrearVMAsync(int idPublicacion)
        {
            var sql = @"
        SELECT 
            p.Titulo, 
            p.Descripcion, 
            p.PrecioNoche AS Precio, 
            p.Fecha, 
            p.Direccion, 
            p.IdAliado,
            (SELECT JSON_ARRAYAGG(JSON_OBJECT('Ruta', pi.Ruta, 'Alt', pi.Alt, 'Orden', pi.Orden))
             FROM publicacionesimagenes pi 
             WHERE pi.IdPublicacion = p.IdPublicacion) AS Imagenes
        FROM 
            publicaciones p
        WHERE 
            p.IdPublicacion = @IdPublicacion";

            return await _db.QueryFirstOrDefaultAsync<PublicacionCrearVM>(sql, new { IdPublicacion = idPublicacion });
        }









        // realizar  consultas


        //cambiar el estado de la publicacion a eliminar  
        public async Task<bool> EstadoEliminarPublicacionAsync(int idPublicacion, int idAliado)
        {
            var sql = @"
        UPDATE publicaciones 
        SET PublicacionEstado = 'Eliminada'
        WHERE IdPublicacion = @IdPublicacion 
        AND IdAliado = @IdAliado";

            var result = await _db.ExecuteAsync(sql, new { IdPublicacion = idPublicacion, IdAliado = idAliado });

            return result > 0;
        }




        // Cambiar estado de la publicacion a activo o pausado según corresponda
        public async Task<bool> EstadoCambiarPublicacionAsync(int idPublicacion, int idAliado, string estado)
        {
            var sql = @"
        UPDATE publicaciones 
        SET PublicacionEstado = @Estado
        WHERE IdPublicacion = @IdPublicacion 
        AND IdAliado = @IdAliado";

            var result = await _db.ExecuteAsync(sql, new { Estado = estado, IdPublicacion = idPublicacion, IdAliado = idAliado });

            return result > 0;
        }




        //Pendiente
        public async Task<List<PublicacionTablaItemVM>?> ObtenerListaPublicacionTablaItemVMAsync()
        {
            var sql = @"
        SELECT 
            p.IdPublicacion,
            (SELECT pi.Ruta 
             FROM publicacionesimagenes pi 
             WHERE pi.IdPublicacion = p.IdPublicacion 
             ORDER BY pi.Orden 
             LIMIT 1) AS ImagenPublicacion,
            p.Titulo AS TituloPublicacion,
            p.PrecioNoche AS PrecioPublicacion,
            p.PublicacionEstado,
            u.Id AS IdTurista,
            u.Avatar AS AvatarTurista,
            u.UserName AS NombreTurista
        FROM 
            publicaciones p
        INNER JOIN 
            reservas r ON p.IdPublicacion = r.IdPublicacion
        INNER JOIN 
            aspnetusers u ON r.IdUsuario = u.Id
        WHERE 
            p.PublicacionEstado = 'Activa'
        ORDER BY 
            p.Fecha DESC";

            var publicaciones = await _db.QueryAsync<PublicacionTablaItemVM>(sql);
            return publicaciones.ToList();
        }




        // Obtener publicaciones filtradas por categoría
        public async Task<List<PublicacionCategoriaVM>> ObtenerPublicacionesPorCategoriaAsync(int idCategoria)
        {
            var sqlPublicaciones = @"
    SELECT 
        p.IdPublicacion,
        p.Titulo,
        p.Puntuacion,
        p.NumeroResenas,
        p.Descripcion,
        p.PrecioNoche AS Precio,
        p.Direccion,
        p.PublicacionEstado,
        c.NombreCategoria
    FROM 
        publicaciones p
    INNER JOIN 
        propiedades pr ON p.IdPropiedad = pr.IdPropiedad
    INNER JOIN 
        categorias c ON pr.IdCategoria = c.IdCategoria
    WHERE 
        c.IdCategoria = @IdCategoria 
        AND p.PublicacionEstado = 'Activa'
    ORDER BY 
        p.Fecha DESC";

            var sqlImagenes = @"
    SELECT 
        pi.IdPublicacion,
        pi.Ruta,
        pi.Alt
    FROM 
        publicacionesimagenes pi
    WHERE 
        pi.IdPublicacion IN @idsPublicaciones";

            // Ejecutar la consulta de publicaciones
            var publicaciones = await _db.QueryAsync<PublicacionCategoriaVM>(sqlPublicaciones, new { IdCategoria = idCategoria });

            // Obtener los IDs de las publicaciones
            var idsPublicaciones = publicaciones.Select(p => p.IdPublicacion).ToList();

            if (!idsPublicaciones.Any()) return publicaciones.ToList(); // Retornar vacío si no hay publicaciones

            // Ejecutar la consulta de imágenes
            var imagenes = await _db.QueryAsync<PublicacionImagenVM>(sqlImagenes, new { idsPublicaciones });

            // Mapear las imágenes en las publicaciones
            foreach (var publicacion in publicaciones)
            {
                publicacion.Imagenes = imagenes.Where(i => i.IdPublicacion == publicacion.IdPublicacion).ToList();
            }

            return publicaciones.ToList();
        }



        // Obtener el total de publicaciones en una categoría
        public async Task<int> ObtenerTotalPublicacionesPorCategoriaAsync(int idCategoria)
        {
            var sql = @"
        SELECT COUNT(*)
        FROM publicaciones p
        INNER JOIN propiedades pr ON p.IdPropiedad = pr.IdPropiedad
        INNER JOIN categorias c ON pr.IdCategoria = c.IdCategoria
        WHERE c.IdCategoria = @IdCategoria
          AND p.PublicacionEstado = 'Activa'";

            return await _db.ExecuteScalarAsync<int>(sql, new { IdCategoria = idCategoria });
        }



        // consulta que trae la cantidad (numero) de publicaciones que se hicieron, que tambien trae el año y mes de todas la publicaciones
        public async Task<List<ReportesPublicacionesPorMesVM>?> ReportePublicacionesPorMesAsync()
        {
            var sql = @"
                            SELECT 
                                YEAR(Fecha) AS Anio, 
                                MONTH(Fecha) AS Mes, 
                                COUNT(*) AS NumeroPublicaciones
                            FROM publicaciones
                            GROUP BY YEAR(Fecha), MONTH(Fecha)
                            ORDER BY YEAR(Fecha), MONTH(Fecha)";

            var result = await _db.QueryAsync<ReportesPublicacionesPorMesVM>(sql);
            return result.ToList();
        }



        // conulta que trae la categorias mas usadas en la publicaciones, en ranking de top 10
        public async Task<List<ReportesPublicacionesTopCategoriaVM>?> ReporteTopCategoriasAsync()
        {
            var sql = @"
                    SELECT c.NombreCategoria, 
                           COUNT(pc.IdCategoria) * 100.0 / (SELECT COUNT(*) FROM publicacionescategorias) AS Porcentaje
                    FROM publicacionescategorias pc
                    INNER JOIN categorias c ON pc.IdCategoria = c.IdCategoria
                    GROUP BY c.NombreCategoria
                    ORDER BY COUNT(pc.IdCategoria) DESC
                    LIMIT 10";

            var result = await _db.QueryAsync<ReportesPublicacionesTopCategoriaVM>(sql);

            return result.ToList();
        }


        // consulta que trae la cantidad (numero) de publicaciones que esten activas por mes 
        public async Task<List<ReportesPublicacionesActivasVM>?> ReportePublicacionesActivasAsync()
        {
            var sql = @"
                    SELECT 
                        DATE_FORMAT(p.Fecha, '%Y-%m') AS Mes,
                        SUM(CASE WHEN p.PublicacionEstado = 'Activa' THEN 1 ELSE 0 END) AS PublicacionesActivas,
                        SUM(CASE WHEN p.PublicacionEstado = 'Inactiva' THEN 1 ELSE 0 END) AS PublicacionesInactivas
                    FROM 
                        publicaciones p
                    GROUP BY 
                        DATE_FORMAT(p.Fecha, '%Y-%m')
                    ORDER BY 
                        DATE_FORMAT(p.Fecha, '%Y-%m') DESC";

            var result = await _db.QueryAsync<ReportesPublicacionesActivasVM>(sql);

            return result.ToList();
        }


        // consulta que trae por mes el promedio de precio de la publicaciones 
        public async Task<List<ReportesPublicacionesPreciosVM>?> ReportePreciosPromediosAsync()
        {
            var sql = @"
        SELECT 
            DATE_FORMAT(p.Fecha, '%Y-%m') AS Mes,
            AVG(p.PrecioNoche) AS PrecioPromedio
        FROM 
            publicaciones p
        GROUP BY 
            DATE_FORMAT(p.Fecha, '%Y-%m')
        ORDER BY 
            DATE_FORMAT(p.Fecha, '%Y-%m') DESC";

            var result = await _db.QueryAsync<ReportesPublicacionesPreciosVM>(sql);
            return result.ToList();
        }



        //consulta que trae el top 10 de las publicaciones con mas like
        public async Task<List<ReportesPublicacionesTopPublicacionesVM>?> ReporteTopPublicacionesAsync()
        {
            var sql = @"
        SELECT 
            p.IdPublicacion,
            p.Titulo AS TituloPublicacion,
            COUNT(rmg.IdResena) AS NotaPublicacion
        FROM 
            publicaciones p
        JOIN 
            reservas r ON p.IdPublicacion = r.IdPublicacion
        JOIN 
            resenas rs ON r.IdReserva = rs.IdReserva
        JOIN 
            resenamegusta rmg ON rs.IdResena = rmg.IdResena
        GROUP BY 
            p.IdPublicacion, 
            p.Titulo
        ORDER BY 
            COUNT(rmg.IdResena) DESC
        LIMIT 10";

            var result = await _db.QueryAsync<ReportesPublicacionesTopPublicacionesVM>(sql);

            return result.ToList();
        }




        //consulta que trae las publicaciones, hechas ayer, hoy, en el mes, en el año
        public async Task<ReportesPublicacionesDetallesVM?> ReporteDetallesAsync(DateTime FechaActual)
        {
            var sql = @"
                    SELECT 
                        (SELECT COUNT(*) 
                         FROM publicaciones 
                         WHERE DATE(Fecha) = CURDATE()) AS PublicacionesHoy,
                        (SELECT COUNT(*) 
                         FROM publicaciones 
                         WHERE DATE(Fecha) = CURDATE() - INTERVAL 1 DAY) AS PublicacionesAyer,
                        (SELECT COUNT(*) 
                         FROM publicaciones 
                         WHERE YEAR(Fecha) = YEAR(CURDATE()) 
                           AND MONTH(Fecha) = MONTH(CURDATE())) AS PublicacionesPorMes,
                        (SELECT COUNT(*) 
                         FROM publicaciones 
                         WHERE Fecha >= CURDATE() - INTERVAL 7 DAY) AS PublicacionesSemanaAnterior;
                ";

            var resultado = await _db.QueryFirstOrDefaultAsync<ReportesPublicacionesDetallesVM>(sql);

            return resultado;
        }

        public async Task<bool> RegistrarImagenes(List<PublicacionesImagenes> imagenes)
        {
            var consulta = @"
                INSERT INTO PublicacionesImagenes (IdPublico, Ruta, Alt, IdPublicacion)
                VALUES (@IdPublico, @Ruta, @Alt, @IdPublicacion);
            ";

            var filasAfectadas = await _db.ExecuteAsync(consulta, imagenes);

            return filasAfectadas > 0;
        }






        public async Task<List<PublicacionTarjetaBusquedaVM>>? BuscarPublicacionesAsync(
            List<int> categorias,
            List<int> propiedadaes,
            List<int> restricciones,
            string palabraClave,
            DateTime? fechaInicio,
            DateTime? fechaFin,
            decimal? precioMinimo,
            decimal? precioMaximo,
            string? ordenar = null,
            int pagina = 1,
            int elementosPorPagina = 10
        )
        {
            string consulta = @"
                WITH PublicacionesFiltradas AS (
                    SELECT DISTINCT
                        p.IdPublicacion,
                        p.Titulo,
                        p.Descripcion,
                        p.PrecioNoche AS Precio,
                        p.Direccion,
                        p.Puntuacion,
                        pr.IdPropiedad,
                        pr.Nombre AS NombrePropiedad,
                        pr.RutaIcono AS IconoPropiedad,
                        c.IdCategoria,
                        c.NombreCategoria,
                        c.RutaIcono AS IconoCategoria,
                        a.Id AS AliadoId,
                        a.Avatar AS AvatarAliado,
                        a.UserName AS NombreAliado,
                        a.NumeroPublicaciones AS TotalPublicaciones,
                        a.Verificado,
                        a.NumeroResenas
                    FROM 
                        publicaciones p
                    INNER JOIN 
                        propiedades pr ON p.IdPropiedad = pr.IdPropiedad
                    INNER JOIN 
                        categorias c ON pr.IdCategoria = c.IdCategoria
                    INNER JOIN 
                        aspnetusers a ON p.IdAliado = a.Id
                    LEFT JOIN 
                        publicacionesrestricciones rp ON p.IdPublicacion = rp.IdPublicacion
                    LEFT JOIN 
                        fechasnodisponibles fn ON p.IdPublicacion = fn.IdPublicacion
                    WHERE 
                        (@IdCategorias IS NULL OR c.IdCategoria IN @IdCategorias)
                        AND (@IdPropiedades IS NULL OR p.IdPropiedad IN @IdPropiedades)
                        AND (@Restricciones IS NULL OR rp.IdRestriccion IN @Restricciones)
                        AND (@FechaInicio IS NULL OR @FechaFin IS NULL OR NOT (
                            fn.FechaInicial BETWEEN @FechaInicio AND @FechaFin 
                            OR fn.FechaFinal BETWEEN @FechaInicio AND @FechaFin
                        ))
                        AND (@PrecioMinimo IS NULL OR @PrecioMaximo IS NULL OR (
                            p.PrecioNoche BETWEEN @PrecioMinimo AND @PrecioMaximo
                        ))
                        AND (@PalabraClave IS NULL OR TRIM(@PalabraClave) = '' OR (
                            LOWER(p.Titulo) LIKE LOWER(CONCAT('%', @PalabraClave, '%')) OR
                            LOWER(c.NombreCategoria) LIKE LOWER(CONCAT('%', @PalabraClave, '%')) OR
                            LOWER(pr.Nombre) LIKE LOWER(CONCAT('%', @PalabraClave, '%')) OR
                            LOWER(a.UserName) LIKE LOWER(CONCAT('%', @PalabraClave, '%'))
                        ))
                )
                SELECT 
                    COUNT(*) OVER () AS TotalResultados, 
                    pf.*
                FROM 
                    PublicacionesFiltradas pf
                ORDER BY 
                    CASE 
                        WHEN @Ordenar IS NULL OR @Ordenar NOT IN ('precio_mayor', 'precio_menor') THEN pf.Puntuacion 
                    END DESC,
                    CASE 
                        WHEN @Ordenar = 'precio_mayor' THEN pf.Precio 
                    END DESC,
                    CASE 
                        WHEN @Ordenar = 'precio_menor' THEN pf.Precio 
                    END ASC
                LIMIT @ElementosPorPagina OFFSET @Offset
            ";

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

            var parametros = new
            {
                IdCategorias = categorias?.Count > 0 ? categorias : null,
                IdPropiedades = propiedadaes?.Count > 0 ? propiedadaes.ToArray() : null,
                Restricciones = restricciones?.Count > 0 ? restricciones : null,
                PalabraClave = !string.IsNullOrEmpty(palabraClave) ? palabraClave : null,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                PrecioMinimo = precioMinimo,
                PrecioMaximo = precioMaximo,
                Ordenar = ordenar,
                Pagina = pagina,
                ElementosPorPagina = elementosPorPagina,
                Offset = (pagina - 1) * elementosPorPagina,
            };


            var publicaciones = await _db.QueryAsync<PublicacionTarjetaBusquedaVM>(consulta, parametros);

            var idsPublicaciones = publicaciones.Select(p => p.IdPublicacion).ToList();
            var imagenes = await _db.QueryAsync<PublicacionImagenVM>(consultaImagenes, new { idsPublicaciones });


            foreach (var publicacion in publicaciones)
            {
                publicacion.Imagenes = imagenes.Where(i => i.IdPublicacion == publicacion.IdPublicacion).ToList();
            }


            return publicaciones.ToList();
        }
    }
}
