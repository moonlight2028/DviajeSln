using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using System.Data;

namespace Dviaje.DataAccess.Repository
{
    public class PqrsRepository : IPqrsRepository
    {
        private readonly IDbConnection _db;

        public PqrsRepository(IDbConnection db)
        {
            _db = db;
        }

        // Crear PQRS y sus adjuntos
        public async Task<bool> CrearPqrsAsync(PqrsCrearVM pqrs)
        {
            using (var transaction = _db.BeginTransaction())
            {
                try
                {
                    int idMensaje;

                    if (!string.IsNullOrEmpty(pqrs.IdTurista))
                    {
                        // Si el usuario está registrado, solo la descripción, tipo de PQRS, y la relación con el IdUsuario
                        var sqlMensajeRegistrado = @"
                            INSERT INTO Mensajes (Fecha, Descripcion, IdUsuario, IdAtencionViajero)
                            VALUES (@Fecha, @Descripcion, @IdUsuario, @IdAtencionViajero);
                            SELECT LAST_INSERT_ID();";  // ID del mensaje insertado

                        idMensaje = await _db.ExecuteScalarAsync<int>(sqlMensajeRegistrado, new
                        {
                            Fecha = pqrs.FechaMensaje ?? DateTime.Now,
                            Descripcion = pqrs.Descripcion,
                            IdUsuario = pqrs.IdTurista,
                            IdAtencionViajero = pqrs.IdAtencionViajero
                        }, transaction);
                    }
                    else
                    {
                        // Si el usuario no está registrado, incluye los datos de contacto
                        var sqlMensajeNoRegistrado = @"
                            INSERT INTO Mensajes (Fecha, Descripcion, Nombre, Apellidos, Correo, Telefono, IdAtencionViajero)
                            VALUES (@Fecha, @Descripcion, @Nombre, @Apellidos, @Correo, @Telefono, @IdAtencionViajero);
                            SELECT LAST_INSERT_ID();";  // ID del mensaje insertado

                        idMensaje = await _db.ExecuteScalarAsync<int>(sqlMensajeNoRegistrado, new
                        {
                            Fecha = pqrs.FechaMensaje ?? DateTime.Now,
                            Descripcion = pqrs.Descripcion,
                            Nombre = pqrs.Nombre,
                            Apellidos = pqrs.Apellidos,
                            Correo = pqrs.Correo,
                            Telefono = pqrs.Telefono,
                            IdAtencionViajero = pqrs.IdAtencionViajero
                        }, transaction);
                    }

                    // Insertar en la tabla de Adjuntos (prueba)
                    if (pqrs.Adjuntos != null && pqrs.Adjuntos.Any())
                    {
                        var sqlAdjuntos = @"
                            INSERT INTO Adjuntos (RutaAdjunto, IdMensaje)
                            VALUES (@RutaAdjunto, @IdMensaje)";

                        foreach (var adjunto in pqrs.Adjuntos)
                        {
                            await _db.ExecuteAsync(sqlAdjuntos, new
                            {
                                RutaAdjunto = adjunto.RutaAdjunto,
                                IdMensaje = idMensaje
                            }, transaction);
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        // lista de atenciones al viajero (PQRS) por usuario
        public async Task<List<AtencionViajerosPqrsVM>?> ObtenerListaAtencionViajerosPqrsVM(string idUsuario)
        {
            var sql = @"
                SELECT av.IdAtencionViajero AS IdAtencion, av.FechaAtencion, av.TipoPqrs, av.Estado,
                (SELECT m.Descripcion FROM Mensajes m WHERE m.IdAtencionViajero = av.IdAtencionViajero ORDER BY m.Fecha DESC LIMIT 1) AS DescripcionMensajes
                FROM AtencionesViajeros av
                WHERE av.IdUsuario = @IdUsuario
                ORDER BY av.FechaAtencion DESC";

            var result = await _db.QueryAsync<AtencionViajerosPqrsVM>(sql, new { IdUsuario = idUsuario });
            return result.ToList();
        }

        // mensajes de una atención al viajero
        public async Task<List<MensajesPqrsVM>?> ObtenerMensajesPqrsVmAsync(int idAtencionViajero)
        {
            var sql = @"
                SELECT 
                    m.Fecha AS Fecha, 
                    m.Descripcion, 
                    u.Id AS IdUsuario, 
                    u.Avatar AS AvatarUsuario
                FROM 
                    Mensajes m
                INNER JOIN 
                    aspnetusers u ON m.IdUsuario = u.Id
                WHERE 
                    m.IdAtencionViajero = @IdAtencionViajero";

            var mensajes = await _db.QueryAsync<MensajesPqrsVM>(sql, new { IdAtencionViajero = idAtencionViajero });
            return mensajes.ToList();
        }

        // Registrar un nuevo mensaje
        public async Task<bool> RegistrarMensajeAsync(MensajesPqrsPostVM mensaje)
        {
            using (var transaction = _db.BeginTransaction())
            {
                try
                {
                    // Insertar el mensaje
                    var sqlMensaje = @"
                        INSERT INTO Mensajes (Fecha, Descripcion, IdUsuario, IdAtencionViajero)
                        VALUES (@Fecha, @Descripcion, @IdUsuario, @IdAtencionViajero)";

                    await _db.ExecuteAsync(sqlMensaje, new
                    {
                        Fecha = mensaje.Fecha ?? DateTime.Now,
                        Descripcion = mensaje.Descripcion,
                        IdUsuario = mensaje.IdUsuario,
                        IdAtencionViajero = mensaje.IdAtencionViajero
                    }, transaction);

                    // Insertar en la tabla de Adjuntos (pruba, reutilizada)
                    if (mensaje.Adjuntos != null && mensaje.Adjuntos.Any())
                    {
                        var sqlAdjuntos = @"
                            INSERT INTO Adjuntos (RutaAdjunto, IdMensaje)
                            VALUES (@RutaAdjunto, (SELECT LAST_INSERT_ID()))";

                        foreach (var adjunto in mensaje.Adjuntos)
                        {
                            await _db.ExecuteAsync(sqlAdjuntos, new
                            {
                                RutaAdjunto = adjunto.RutaAdjunto
                            }, transaction);
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
