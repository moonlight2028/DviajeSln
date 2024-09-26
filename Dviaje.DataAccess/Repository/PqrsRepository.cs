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


        public async Task<bool> CrearPqrsAsync(PqrsCrearVM pqrs)
        {
            using (var transaction = _db.BeginTransaction())
            {
                try
                {
                    // Insertar en la tabla de Mensajes
                    var sqlMensaje = @"
                        INSERT INTO Mensajes (FechaMensaje, Descripcion, Nombre, Apellidos, Correo, Telefono)
                        VALUES (@FechaMensaje, @Descripcion, @Nombre, @Apellidos, @Correo, @Telefono);
                        SELECT LAST_INSERT_ID();";  // Obtenemos el ID del mensaje insertado

                    var idMensaje = await _db.ExecuteScalarAsync<int>(sqlMensaje, new
                    {
                        FechaMensaje = pqrs.FechaMensaje ?? DateTime.Now,
                        Descripcion = pqrs.Descripcion,
                        Nombre = pqrs.Nombre,
                        Apellidos = pqrs.Apellidos,
                        Correo = pqrs.Correo,
                        Telefono = pqrs.Telefono
                    }, transaction);

                    // Insertar en la tabla de Adjuntos si existen
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

        public Task<List<AtencionViajerosPqrsVM>?> ObtenerListaAtencionViajerosPqrsVM(string idUsuario)
        {
            return Task.FromResult<List<AtencionViajerosPqrsVM>?>(null);
        }

        public Task<List<MensajesPqrsVM>?> ObtenerMensajesPqrsVmAsync(int idAtencionViajero)
        {
            return Task.FromResult<List<MensajesPqrsVM>?>(null);
        }

        public Task<bool> RegistrarMensajeAsync(MensajesPqrsPostVM mensaje)
        {
            return Task.FromResult(false);
        }
    }
}
