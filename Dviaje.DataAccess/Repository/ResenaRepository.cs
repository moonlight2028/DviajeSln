using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using System.Data;

namespace Dviaje.DataAccess.Repository
{
    public class ResenaRepository : IResenasRepository
    {
        private readonly IDbConnection _db;


        public ResenaRepository(IDbConnection db)
        {
            _db = db;
        }



        //crear una Reseña
        public async Task<bool> CrearResenaAsync(ResenaCrearVM resenaCrear)
        {
            var sql = @"
                INSERT INTO Resenas (Opinion, Fecha, Calificacion, IdReserva)
                VALUES (@Opinion, @Fecha, @Calificacion, @IdReserva)";

            var result = await _db.ExecuteAsync(sql, resenaCrear);
            return result > 0;
        }



        //Obtner las resenas para las tarjetas 
        public async Task<List<ResenaTarjetaBasicaVM>?> ObtenerListaResenaTarjetaBasicaVMAsync(int idPublicacion, int pagina = 1, int resultadosMostrados = 10)
        {
            var sql = @"
                SELECT r.IdReserva, u.Id AS IdTurista, u.UserName AS NombreTurista, u.Avatar AS AvatarTurista, 
                       rs.Opinion, rs.Fecha, rs.Calificacion AS Puntuacion, 
                       (SELECT COUNT(*) FROM resenamegusta WHERE IdResena = rs.IdResena) AS NumeroLikes
                FROM Resenas rs
                INNER JOIN Reservas r ON rs.IdReserva = r.IdReserva
                INNER JOIN Publicaciones p ON r.IdPublicacion = p.IdPublicacion
                INNER JOIN aspnetusers u ON r.IdUsuario = u.Id
                WHERE p.IdPublicacion = @IdPublicacion
                ORDER BY rs.Fecha DESC
                LIMIT @ElementosPorPagina OFFSET @Offset";

            var offset = (pagina - 1) * resultadosMostrados;
            var result = await _db.QueryAsync<ResenaTarjetaBasicaVM>(sql, new
            {
                IdPublicacion = idPublicacion,
                ElementosPorPagina = resultadosMostrados,
                Offset = offset
            });

            return result.ToList();
        }


        // Obtner las reseñas que estan disponibles 
        public async Task<List<ResenaTarjetaDisponibleVM>> ObtenerListaResenaTarjetaDisponibleVMAsync(string idUsuario, int pagina = 1, int resultadosMostrados = 10)
        {
            var sql = @"
                SELECT r.IdReserva, p.Titulo AS TituloPublicacion, p.Descripcion AS DescripcionPublicacion, 
                       p.Puntuacion AS PuntuacionPublicacion, pi.Ruta AS ImagenPublicacion, 
                       r.FechaInicial, r.FechaFinal
                FROM Reservas r
                INNER JOIN Publicaciones p ON r.IdPublicacion = p.IdPublicacion
                LEFT JOIN PublicacionesImagenes pi ON p.IdPublicacion = pi.IdPublicacion AND pi.Orden = 1
                WHERE r.IdUsuario = @IdUsuario
                AND r.FechaFinal <= CURRENT_DATE
                AND NOT EXISTS (SELECT 1 FROM Resenas rs WHERE rs.IdReserva = r.IdReserva)
                ORDER BY r.FechaFinal DESC
                LIMIT @ElementosPorPagina OFFSET @Offset";

            var offset = (pagina - 1) * resultadosMostrados;
            var result = await _db.QueryAsync<ResenaTarjetaDisponibleVM>(sql, new
            {
                IdUsuario = idUsuario,
                ElementosPorPagina = resultadosMostrados,
                Offset = offset
            });

            return result.ToList();


            // Datos de test borrar cuando esté la consulta
            List<ResenaTarjetaDisponibleVM>? datosTest = new List<ResenaTarjetaDisponibleVM> {
                new ResenaTarjetaDisponibleVM {
                    TituloPublicacion = "Aventura en la Montaña",
                    DescripcionPublicacion = "Una experiencia inolvidable rodeado de naturaleza, perfecta para quienes buscan desconectarse y disfrutar del aire libre.",
                    IdPublicacion = 2,
                    PuntuacionPublicacion = 4.8m,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1726266852936-bb4cfcdffaf0?q=80&w=1931&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdReserva = 3,
                    FechaInicial = new DateTime(2024, 01, 15),
                    FechaFinal = new DateTime(2024, 01, 18)
                },
                new ResenaTarjetaDisponibleVM {
                    TituloPublicacion = "Relax en la Playa",
                    DescripcionPublicacion = "El lugar perfecto para relajarse con vistas al mar, disfrutar de la tranquilidad y desconectar del mundo.",
                    IdPublicacion = 3,
                    PuntuacionPublicacion = 4.5m,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1726266852936-bb4cfcdffaf0?q=80&w=1931&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdReserva = 4,
                    FechaInicial = new DateTime(2024, 02, 05),
                    FechaFinal = new DateTime(2024, 02, 10)
                },
                new ResenaTarjetaDisponibleVM {
                    TituloPublicacion = "Escapada Rural",
                    DescripcionPublicacion = "Una hermosa casa de campo con vistas espectaculares, ideal para una escapada romántica o con amigos.",
                    IdPublicacion = 4,
                    PuntuacionPublicacion = 4.9m,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1726266852936-bb4cfcdffaf0?q=80&w=1931&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdReserva = 5,
                    FechaInicial = new DateTime(2024, 03, 12),
                    FechaFinal = new DateTime(2024, 03, 15)
                },
                new ResenaTarjetaDisponibleVM {
                    TituloPublicacion = "Tour en la Ciudad",
                    DescripcionPublicacion = "Descubre los secretos y maravillas de la ciudad con este tour guiado por los principales puntos de interés.",
                    IdPublicacion = 5,
                    PuntuacionPublicacion = 4.3m,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1726266852936-bb4cfcdffaf0?q=80&w=1931&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdReserva = 6,
                    FechaInicial = new DateTime(2024, 04, 02),
                    FechaFinal = new DateTime(2024, 04, 05)
                },
                new ResenaTarjetaDisponibleVM {
                    TituloPublicacion = "Aventura en la Selva",
                    DescripcionPublicacion = "Una experiencia emocionante para quienes buscan adentrarse en la selva y vivir la naturaleza de cerca.",
                    IdPublicacion = 6,
                    PuntuacionPublicacion = 4.7m,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1726266852936-bb4cfcdffaf0?q=80&w=1931&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    IdReserva = 7,
                    FechaInicial = new DateTime(2024, 05, 10),
                    FechaFinal = new DateTime(2024, 05, 15)
                }
            };

            return datosTest;
        }


        // Obtner los detalles de la reseña
        public async Task<List<ResenaTarjetaDetalleVM>?> ObtenerListaResenaTarjetaDetalleAsync(string idUsuario, int pagina = 1, int resultadosMostrados = 10)
        {
            var sql = @"
                    SELECT 
                    p.IdPublicacion, 
                    rs.Opinion, 
                    rs.Fecha, 
                    rs.Calificacion AS Puntuacion, 
                    (SELECT COUNT(*) FROM ResenaMeGusta WHERE IdResena = rs.IdResena) AS NumerosLikes,
                    p.Titulo AS TituloPublicacion, 
                    pi.Ruta AS ImagenPublicacion, 
                    u.Id AS IdAliado, 
                    u.UserName AS NombreAliado, 
                    u.Avatar AS AvatarAliado, 
                    u.NumeroPublicaciones AS NumeroPublicacionesAliado
                FROM 
                    Resenas rs
                INNER JOIN 
                    Reservas r ON rs.IdReserva = r.IdReserva
                INNER JOIN 
                    Publicaciones p ON r.IdPublicacion = p.IdPublicacion
                INNER JOIN 
                    aspnetusers u ON p.IdAliado = u.Id
                LEFT JOIN 
                    PublicacionesImagenes pi ON pi.IdPublicacion = p.IdPublicacion
                WHERE 
                    r.IdUsuario = '@IdUsuario'
                ORDER BY 
                    rs.Fecha DESC
                LIMIT ELEMENTOS_POR_PAGINA OFFSET OFFSET";

            var offset = (pagina - 1) * resultadosMostrados;
            var result = await _db.QueryAsync<ResenaTarjetaDetalleVM>(sql, new
            {
                IdUsuario = idUsuario,
                ElementosPorPagina = resultadosMostrados,
                Offset = offset
            });

            return result.ToList();



            // Datos de test borrar cuando esté la consulta
            List<ResenaTarjetaDetalleVM>? datosTest = new List<ResenaTarjetaDetalleVM>
            {
                new ResenaTarjetaDetalleVM
                {
                    IdPublicacion = 1,
                    TituloPublicacion = "Aventura en la Montaña",
                    Opinion = "Una experiencia increíble, todo estuvo perfecto.",
                    Fecha = new DateTime(2024, 1, 15),
                    Puntuacion = 4.8m,
                    NumerosLikes = 120,
                    IdAliado = "A123",
                    AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    NombreAliado = "Juan Pérez",
                    NumeroPublicacionesAliado = 15,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1637419567748-6789aec01324?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new ResenaTarjetaDetalleVM
                {
                    IdPublicacion = 2,
                    TituloPublicacion = "Relajación en la Playa",
                    Opinion = "El lugar es hermoso, pero el servicio podría mejorar.",
                    Fecha = new DateTime(2023, 8, 23),
                    Puntuacion = 3.7m,
                    NumerosLikes = 85,
                    IdAliado = "B456",
                    AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    NombreAliado = "María Gómez",
                    NumeroPublicacionesAliado = 10,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1637419567748-6789aec01324?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new ResenaTarjetaDetalleVM
                {
                    IdPublicacion = 3,
                    TituloPublicacion = "Escapada Rural",
                    Opinion = "La cabaña era acogedora y perfecta para desconectar.",
                    Fecha = new DateTime(2024, 2, 10),
                    Puntuacion = 4.5m,
                    NumerosLikes = 95,
                    IdAliado = "C789",
                    AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    NombreAliado = "Pedro Sánchez",
                    NumeroPublicacionesAliado = 8,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1637419567748-6789aec01324?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new ResenaTarjetaDetalleVM
                {
                    IdPublicacion = 4,
                    TituloPublicacion = "Tour por la Ciudad klajdslkfjalk adslkfjalksd aldkjflkads alsdkjflk adkjflkadsjf adkfjlkadsjfl asdfjkladsjf adfjlkadsjflk",
                    Opinion = "La tecnología avanza rápidamente, transformando la forma en que vivimos y trabajamos. Adaptarse a estos cambios es clave para mantenerse competitivo. Aprender nuevas habilidades y mejorar constantemente es esencial en un mundo donde la innovación es la norma diaria.",
                    Fecha = new DateTime(2023, 11, 18),
                    Puntuacion = 4.9m,
                    NumerosLikes = 135,
                    IdAliado = "D321",
                    AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    NombreAliado = "Ana López",
                    NumeroPublicacionesAliado = 20,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1637419567748-6789aec01324?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new ResenaTarjetaDetalleVM
                {
                    IdPublicacion = 5,
                    TituloPublicacion = "Viaje en Familia",
                    Opinion = "Todo estuvo bien, aunque la comida no fue tan buena.",
                    Fecha = new DateTime(2023, 5, 5),
                    Puntuacion = 3.9m,
                    NumerosLikes = 65,
                    IdAliado = "E654",
                    AvatarAliado = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXZhdGFyfGVufDB8fDB8fHww",
                    NombreAliado = "Carlos Ruiz",
                    NumeroPublicacionesAliado = 12,
                    ImagenPublicacion = "https://images.unsplash.com/photo-1637419567748-6789aec01324?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                }
            };

            return datosTest;
        }


        //obtener la lista de reservas 
        public async Task<List<ResenaTarjetaRecibidaVM>?> ObtenerListaResenaTarjetaRecibidaVMAsync(string idAliado, int pagina = 1, int resultadosMostrados = 10, string? ordenar = null)
        {
            var sql = @"
                SELECT rs.Opinion, rs.Calificacion AS Puntuacion, rs.Fecha, 
                       (SELECT COUNT(*) FROM ResenaMeGusta WHERE IdResena = rs.IdResena) AS NumerosLikes,
                       p.IdPublicacion, p.Titulo AS TituloPublicacion, 
                       (SELECT pi.Ruta FROM PublicacionesImagenes pi WHERE pi.IdPublicacion = p.IdPublicacion ORDER BY pi.Orden LIMIT 1) AS ImagenPublicacion,
                       u.Id AS IdTurista, u.UserName AS NombreTurista, u.Avatar AS AvatarTurista,
                       (SELECT COUNT(*) FROM Resenas r WHERE r.IdUsuario = u.Id) AS NumeroResenasTurista
                FROM Resenas rs
                INNER JOIN Reservas r ON rs.IdReserva = r.IdReserva
                INNER JOIN Publicaciones p ON r.IdPublicacion = p.IdPublicacion
                INNER JOIN aspnetusers u ON r.IdUsuario = u.Id
                WHERE p.IdAliado = @IdAliado
                ORDER BY CASE WHEN @Ordenar IS NOT NULL THEN
                        CASE @Ordenar
                            WHEN 'Fecha' THEN rs.Fecha
                            WHEN 'Puntuacion' THEN rs.Calificacion
                            WHEN 'Likes' THEN NumerosLikes
                        END
                        ELSE rs.Fecha
                    END DESC
                LIMIT @ElementosPorPagina OFFSET @Offset";

            var offset = (pagina - 1) * resultadosMostrados;
            var result = await _db.QueryAsync<ResenaTarjetaRecibidaVM>(sql, new
            {
                IdAliado = idAliado,
                Ordenar = ordenar,
                ElementosPorPagina = resultadosMostrados,
                Offset = offset
            });

            return result.ToList();
        }

        // Agregar me gusta del usuario
        public async Task<bool> AgregarMeGustaAsync(int idResena, string idUsuario)
        {
            // Verificar si el usuario ya ha dado "Me Gusta"
            var sqlCheck = @"
                        SELECT COUNT(*)
                        FROM ResenaMeGusta
                        WHERE IdResena = @IdResena AND IdUsuario = @IdUsuario";

            var yaDioMeGusta = await _db.ExecuteScalarAsync<int>(sqlCheck, new { IdResena = idResena, IdUsuario = idUsuario });

            if (yaDioMeGusta > 0)
            {
                // El usuario ya dio "Me Gusta" previamente, no hacer nada
                return false;
            }

            // Insertar un nuevo "Me Gusta"
            var sqlInsert = @"
                        INSERT INTO ResenaMeGusta (IdResena, IdUsuario)
                        VALUES (@IdResena, @IdUsuario)";

            var result = await _db.ExecuteAsync(sqlInsert, new { IdResena = idResena, IdUsuario = idUsuario });
            return result > 0;
        }


        //eliminar me gusta 
        public async Task<bool> EliminarMeGustaAsync(int idResena, string idUsuario)
        {
            var sql = @"
                DELETE FROM ResenaMeGusta
                WHERE IdResena = @IdResena AND IdUsuario = @IdUsuario";

            var result = await _db.ExecuteAsync(sql, new { IdResena = idResena, IdUsuario = idUsuario });
            return result > 0;
        }


        //Traer me gusta (cantidad numerada)
        public async Task<int> ObtenerMeGustaCountAsync(int idResena)
        {
            var sql = "SELECT COUNT(*) FROM ResenaMeGusta WHERE IdResena = @IdResena";

            var count = await _db.ExecuteScalarAsync<int>(sql, new { IdResena = idResena });
            return count;
        }

        //Validar resena
        public async Task<bool> ValidarReservaParaResenaAsync(int idReserva, string idUsuario)
        {
            var sql = @"
                SELECT COUNT(*)
                FROM Reservas r
                WHERE r.IdReserva = @IdReserva
                AND r.IdUsuario = @IdUsuario
                AND r.ReservaEstado = 'Aprovado'
                AND r.FechaFinal <= CURRENT_DATE
                AND NOT EXISTS (SELECT 1 FROM Resenas rs WHERE rs.IdReserva = r.IdReserva)";

            return await _db.ExecuteScalarAsync<bool>(sql, new { IdReserva = idReserva, IdUsuario = idUsuario });
        }
    }
}
