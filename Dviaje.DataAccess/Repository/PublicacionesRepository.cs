using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
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
                                        av.Url_50px AS AvatarAliado,
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
                                    LEFT JOIN 
                                        avatares av ON a.Id = av.IdTurista
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
                                    LIMIT @pageSize OFFSET @offset";

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
            pc.IdPublicacion IN @idsPublicaciones";

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
            // Consulta para obtener la publicación
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
                                        av.Url_50px AS AvatarAliado,
                                        a.UserName AS NombreAliado,
                                        a.NumeroPublicaciones AS PublicacionesAliado,
                                        IFNULL(a.Verificado, 0) AS VerificadoAliado
                                    FROM Publicaciones p
                                    LEFT JOIN aspnetusers a ON p.IdAliado = a.Id
                                    LEFT JOIN avatares av ON a.Id = av.IdTurista
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

        public async Task<PublicacionResenasVM?> ObtenerPublicacionResenasVMAsync(int idPublicacion)
        {
            // Consulta para obtener los detalles de la publicación junto con su primera reseña
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
                                p.IdPublicacion = @IdPublicacion
                        ";

            var publicacion = await _db.QueryFirstOrDefaultAsync<PublicacionResenasVM>(consulta, new { IdPublicacion = idPublicacion });

            return publicacion;


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


        //aun no es posible

        public async Task<PublicacionTarjetaImagenVM?> ObtenerPublicacionTarjetaImagenVMAsync(int idPublicacion)
        {
            var sql = @"
                    SELECT 
                        p.IdPublicacion,
                        (SELECT pi.Ruta FROM PublicacionesImagenes pi WHERE pi.IdPublicacion = p.IdPublicacion ORDER BY pi.Orden LIMIT 1) AS Imagen,
                        p.Direccion,
                        p.Puntuacion,
                        a.Id AS IdAliado,
                        av.Url_50px AS AvatarAliado,
                        a.UserName AS NombreAliado
                    FROM 
                        Publicaciones p
                    LEFT JOIN 
                        aspnetusers a ON p.IdAliado = a.Id
                    LEFT JOIN 
                        avatares av ON a.Id = av.IdTurista
                    WHERE 
                        p.IdPublicacion = @IdPublicacion";

            return await _db.QueryFirstOrDefaultAsync<PublicacionTarjetaImagenVM>(sql, new { IdPublicacion = idPublicacion });
        }


        public async Task<int?> CrearPublicacionAsync(PublicacionCrearVM publicacion)
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
                    INSERT INTO Publicaciones (Titulo, Descripcion, Precio, Fecha, Direccion, CamasMaximo, PublicacionEstado, IdAliado)
                    VALUES (@Titulo, @Descripcion, @Precio, @Fecha, @Direccion, @NumeroCamas, 'Activa', @IdAliado);
                    SELECT LAST_INSERT_ID();
                ";

                    var idPublicacion = await _db.ExecuteScalarAsync<int>(sqlPublicacion, publicacion, transaction);


                    // Registro tabla PublicacionesServicios
                    var todosServiciosSeleccionados = new List<object>();

                    todosServiciosSeleccionados.AddRange(publicacion.ServiciosHabitacionSeleccionados?.Select(IdServicio => new { IdPublicacion = idPublicacion, IdServicio }) ?? Enumerable.Empty<object>());
                    todosServiciosSeleccionados.AddRange(publicacion.ServiciosEstablecimientoSeleccionados?.Select(IdServicio => new { IdPublicacion = idPublicacion, IdServicio }) ?? Enumerable.Empty<object>());
                    todosServiciosSeleccionados.AddRange(publicacion.ServiciosAccesibilidadSeleccionados?.Select(IdServicio => new { IdPublicacion = idPublicacion, IdServicio }) ?? Enumerable.Empty<object>());

                    if (todosServiciosSeleccionados.Any())
                    {
                        var sqlServicios = @"
                        INSERT INTO PublicacionesServicios (IdPublicacion, IdServicio)
                        VALUES (@IdPublicacion, @IdServicio);
                    ";

                        await _db.ExecuteAsync(sqlServicios, todosServiciosSeleccionados, transaction);
                    }


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


                    // Registro tabla PublicacionesCategorias
                    if (publicacion.CategoriasSeleccionadas != null)
                    {
                        var sqlCategorias = @"
                        INSERT INTO PublicacionesCategorias (IdPublicacion, IdCategoria)
                        VALUES (@IdPublicacion, @IdCategoria);
                    ";

                        var categorias = publicacion.CategoriasSeleccionadas.Select(categoria => new
                        {
                            IdPublicacion = idPublicacion,
                            IdCategoria = categoria
                        });

                        await _db.ExecuteAsync(sqlCategorias, categorias, transaction);
                    }


                    // Registro tabla FechasNoDisponibles
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
                    UPDATE Publicaciones 
                    SET Titulo = @Titulo, Descripcion = @Descripcion, Precio = @Precio, Direccion = @Direccion
                    WHERE IdPublicacion = @IdPublicacion";

            var resultado = await _db.ExecuteAsync(sql, publicacion);
            return resultado > 0;
        }


        public async Task<PublicacionCrearVM?> ObtenerPublicacionCrearVMAsync(int idPublicacion)
        {
            var sql = @"
                    SELECT 
                        p.Titulo, 
                        p.Descripcion, 
                        p.Precio, 
                        p.Fecha, 
                        p.Direccion, 
                        p.IdAliado,
                        (SELECT JSON_ARRAYAGG(JSON_OBJECT('Ruta', pi.Ruta, 'Alt', pi.Alt, 'Orden', pi.Orden))
                         FROM PublicacionesImagenes pi WHERE pi.IdPublicacion = p.IdPublicacion) AS Imagenes
                    FROM 
                        Publicaciones p
                    WHERE 
                        p.IdPublicacion = @IdPublicacion";

            return await _db.QueryFirstOrDefaultAsync<PublicacionCrearVM>(sql, new { IdPublicacion = idPublicacion });
        }


        public Task<PublicacionCrearVM?> ObtenerPublicacionCrearVMAsync()
        {
            throw new NotImplementedException();
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
                         FROM PublicacionesImagenes pi 
                         WHERE pi.IdPublicacion = p.IdPublicacion 
                         ORDER BY pi.Orden 
                         LIMIT 1) AS ImagenPublicacion,
                        p.Titulo AS TituloPublicacion,
                        p.Precio AS PrecioPublicacion,
                        p.PublicacionEstado,
                        u.Id AS IdTurista,
                        av.Url_50px AS AvatarTurista,
                        u.UserName AS NombreTurista
                    FROM 
                        Publicaciones p
                    INNER JOIN 
                        Reservas r ON p.IdPublicacion = r.IdPublicacion
                    INNER JOIN 
                        aspnetusers u ON r.IdUsuario = u.Id
                    LEFT JOIN 
                        Avatares av ON u.Id = av.IdTurista
                    WHERE 
                        p.PublicacionEstado = 'Activa'
                    ORDER BY 
                        p.Fecha DESC;
                ";

            var publicaciones = await _db.QueryAsync<PublicacionTablaItemVM>(sql);
            return publicaciones.ToList();
        }


        //traer publicaciones segun la categoria

        public async Task<List<PublicacionCategoriaVM>> ObtenerPublicacionesPorCategoriaAsync(int idCategoria)
        {
            var sql = @"
        SELECT 
            p.IdPublicacion, 
            p.Titulo, 
            p.Puntuacion, 
            p.NumeroResenas, 
            p.Descripcion, 
            p.Precio, 
            p.Direccion, 
            p.PublicacionEstado, 
            pi.Ruta AS ImagenPrincipal, 
            c.NombreCategoria
        FROM 
            publicacionescategorias pc
        INNER JOIN 
            publicaciones p ON pc.IdPublicacion = p.IdPublicacion
        LEFT JOIN 
            publicacionesimagenes pi ON p.IdPublicacion = pi.IdPublicacion AND pi.Orden = 1
        INNER JOIN 
            categorias c ON pc.IdCategoria = c.IdCategoria
        WHERE 
            c.IdCategoria = @IdCategoria
          AND 
            p.PublicacionEstado = 'Activa'
        ORDER BY 
            p.Fecha DESC;
    ";

            return (await _db.QueryAsync<PublicacionCategoriaVM>(sql, new { IdCategoria = idCategoria })).ToList();
        }



        //Realizar consultas




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
                        AVG(p.Precio) AS PrecioPromedio
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
                INSERT INTO PublicacionesImagenes (Ruta, Alt, IdPublicacion)
                VALUES (@Ruta, @Alt, @IdPublicacion);
            ";

            var filasAfectadas = await _db.ExecuteAsync(consulta, imagenes);

            return filasAfectadas > 0;
        }



    }
}
