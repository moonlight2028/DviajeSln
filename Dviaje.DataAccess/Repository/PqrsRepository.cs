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

        // Crear PQRS
        public async Task<int?> CrearPqrsAsync(PqrsCrearVM pqrs)
        {
            try
            {
                // Asegurarse de que la conexión esté abierta antes de comenzar la transacción
                if (_db.State != ConnectionState.Open)
                {
                    _db.Open();  // Usar Open() sincrónico en lugar de OpenAsync()
                }

                using (var transaction = _db.BeginTransaction())
                {
                    try
                    {
                        int idAtencionViajeros;
                        int idMensaje;

                        var sqlAtencionesViajeros = @"
                            INSERT INTO atencionesviajeros (FechaAtencion, TipoPqrs, Estado, IdTurista)
                            VALUES (@FechaAtencion, @TipoPqrs, @Estado, @IdTurista);
                            SELECT LAST_INSERT_ID();";

                        idAtencionViajeros = await _db.ExecuteScalarAsync<int>(sqlAtencionesViajeros, new
                        {
                            FechaAtencion = pqrs.FechaAtencion,
                            TipoPqrs = pqrs.AtencionesViajerosTipoPqrs.ToString(),
                            Estado = pqrs.AtencionesViajerosEstado.ToString(),
                            IdTurista = pqrs.IdTurista
                        }, transaction);

                        var sqlMensaje = @"
                            INSERT INTO Mensajes (Fecha, Descripcion, Nombre, Apellidos, Correo, Telefono, IdUsuario, IdAtencionViajero)
                            VALUES (@Fecha, @Descripcion, @Nombre, @Apellidos, @Correo, @Telefono, @IdUsuario, @IdAtencionViajero);
                            SELECT LAST_INSERT_ID();";

                        idMensaje = await _db.ExecuteScalarAsync<int>(sqlMensaje, new
                        {
                            Fecha = pqrs.FechaAtencion,
                            Descripcion = pqrs.Descripcion,
                            Nombre = pqrs.Nombre,
                            Apellidos = pqrs.Apellidos,
                            Correo = pqrs.Correo,
                            Telefono = pqrs.Telefono,
                            IdUsuario = pqrs.IdTurista,
                            IdAtencionViajero = idAtencionViajeros  // Usar el ID generado en la primera inserción
                        }, transaction);

                        transaction.Commit();

                        return idMensaje;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return null;
                    }
                }
            }
            finally
            {
                // Cerrar la conexión si está abierta
                if (_db.State == ConnectionState.Open)
                {
                    _db.Close();
                }
            }
        }

        //Regustrar un adjunto (si es necesario)
        public async Task<bool> RegistrarAdjuntosAsync(List<AdjuntosVM> adjuntos)
        {
            var sql = @"
                INSERT INTO Adjuntos (IdPublico, IdMensaje)
                VALUES (@IdPublico, @IdMensaje)";

            var result = await _db.ExecuteAsync(sql, adjuntos);
            return result > 0;
        }

        // lista de atenciones al viajero (PQRS) por usuario
        public async Task<List<AtencionViajerosPqrsVM>?> ObtenerListaAtencionViajerosPqrsVMAsync(string idUsuario)
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
                    a.Url_50px AS AvatarUsuario
                FROM 
                    Mensajes m
                INNER JOIN 
                    aspnetusers u ON m.IdUsuario = u.Id
                LEFT JOIN 
                    avatares a ON u.Id = a.IdTurista
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
