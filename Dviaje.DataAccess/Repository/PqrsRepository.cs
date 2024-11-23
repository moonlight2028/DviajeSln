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
                if (_db.State != ConnectionState.Open)
                {
                    _db.Open();
                }

                using (var transaction = _db.BeginTransaction())
                {
                    try
                    {
                        // Inserción en atencionesviajeros
                        var sqlAtencionesViajeros = @"
                    INSERT INTO atencionesviajeros (FechaAtencion, TipoPqrs, Estado, IdUsuario)
                    VALUES (@FechaAtencion, @TipoPqrs, @Estado, @IdUsuario);
                    SELECT LAST_INSERT_ID();";

                        var idAtencionViajeros = await _db.ExecuteScalarAsync<int>(sqlAtencionesViajeros, new
                        {
                            FechaAtencion = pqrs.FechaAtencion,
                            TipoPqrs = pqrs.AtencionesViajerosTipoPqrs.ToString(),
                            Estado = pqrs.AtencionesViajerosEstado.ToString(),
                            IdUsuario = pqrs.IdTurista
                        }, transaction);

                        // Inserción en mensajes
                        var sqlMensaje = @"
                    INSERT INTO mensajes (Fecha, Descripcion, Nombre, Apellidos, Correo, Telefono, IdUsuario, IdAtencionViajero)
                    VALUES (@Fecha, @Descripcion, @Nombre, @Apellidos, @Correo, @Telefono, @IdUsuario, @IdAtencionViajero);
                    SELECT LAST_INSERT_ID();";

                        var idMensaje = await _db.ExecuteScalarAsync<int>(sqlMensaje, new
                        {
                            Fecha = pqrs.FechaAtencion,
                            Descripcion = pqrs.Descripcion,
                            Nombre = pqrs.Nombre,
                            Apellidos = pqrs.Apellidos,
                            Correo = pqrs.Correo,
                            Telefono = pqrs.Telefono,
                            IdUsuario = pqrs.IdTurista,
                            IdAtencionViajero = idAtencionViajeros
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
        SELECT 
            av.IdAtencionViajero AS IdAtencion, 
            av.FechaAtencion, 
            av.TipoPqrs, 
            av.Estado,
            (SELECT m.Descripcion 
             FROM mensajes m 
             WHERE m.IdAtencionViajero = av.IdAtencionViajero 
             ORDER BY m.Fecha DESC 
             LIMIT 1) AS DescripcionMensajes
        FROM 
            atencionesviajeros av
        WHERE 
            av.IdUsuario = @IdUsuario
        ORDER BY 
            av.FechaAtencion DESC";

            var result = await _db.QueryAsync<AtencionViajerosPqrsVM>(sql, new { IdUsuario = idUsuario });
            return result.ToList();
        }


        // mensajes de una atención al viajero
        public async Task<List<MensajesPqrsVM>?> ObtenerMensajesPqrsVmAsync(int idAtencionViajero)
        {
            var sql = @"
        SELECT 
            m.Fecha, 
            m.Descripcion, 
            u.Id AS IdUsuario, 
            u.Avatar AS AvatarUsuario
        FROM 
            mensajes m
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
                INSERT INTO mensajes (Fecha, Descripcion, IdUsuario, IdAtencionViajero)
                VALUES (@Fecha, @Descripcion, @IdUsuario, @IdAtencionViajero)";

                    var idMensaje = await _db.ExecuteScalarAsync<int>(sqlMensaje, new
                    {
                        Fecha = mensaje.Fecha ?? DateTime.Now,
                        Descripcion = mensaje.Descripcion,
                        IdUsuario = mensaje.IdUsuario,
                        IdAtencionViajero = mensaje.IdAtencionViajero
                    }, transaction);

                    // Insertar en la tabla de Adjuntos
                    if (mensaje.Adjuntos != null && mensaje.Adjuntos.Any())
                    {
                        var sqlAdjuntos = @"
                    INSERT INTO adjuntos (RutaAdjunto, IdMensaje)
                    VALUES (@RutaAdjunto, @IdMensaje)";

                        foreach (var adjunto in mensaje.Adjuntos)
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

    }
}
