using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using System.Data;

namespace Dviaje.DataAccess.Repository
{
    /// <summary>
    /// Repositorio especializado en las operaciones relacionadas con el perfil de usuario y su información asociada.
    /// Proporciona métodos para gestionar y acceder a los datos del perfil de usuario en la base de datos.
    /// </summary>
    public class PerfilRepository : IPerfilRepository
    {
        private readonly IDbConnection _db;

        public PerfilRepository(IDbConnection db)
        {
            _db = db;
        }

        //Obtner Usuario por ID - Perfil del usuario 
        public async Task<PerfilPublicoVM?> ObtenerPerfilPublicoVMAsync(string idUsuario)
        {
            // Consulta - detalles del perfil público
            var sql = @"
        SELECT 
            u.Id AS Id, 
            u.UserName, 
            u.Avatar, 
            u.Banner,
            CASE 
                WHEN EXISTS(SELECT 1 FROM Publicaciones p WHERE p.IdAliado = u.Id) THEN 1 
                ELSE 0 
            END AS EsAliado,
            u.Verificado,
            u.RazonSocial,
            u.SitioWeb,
            u.Direccion,
            u.Puntuacion,
            u.AliadoEstado,
            (SELECT COUNT(*) FROM Reservas r WHERE r.IdUsuario = u.Id) AS NumeroReservas,
            (SELECT COUNT(*) FROM Publicaciones p WHERE p.IdAliado = u.Id) AS NumeroPulicaciones,
            (SELECT COUNT(*) FROM Resenas re INNER JOIN Reservas r ON re.IdReserva = r.IdReserva WHERE r.IdUsuario = u.Id) AS NumeroResenas
        FROM 
            aspnetusers u
        WHERE 
            u.Id = @IdUsuario";

            return await _db.QueryFirstOrDefaultAsync<PerfilPublicoVM>(sql, new { IdUsuario = idUsuario });

            // Datos de test borrar cuando esté la consulta
            PerfilPublicoVM datosTest = new PerfilPublicoVM
            {
                Id = "SADF",
                UserName = "Juan Pérez",
                Avatar = "https://plus.unsplash.com/premium_photo-1658527049634-15142565537a?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8YXZhdGFyfGVufDB8fDB8fHww",
                NumeroReservas = 115,
                NumeroResenas = 468,
                Banner = "https://images.unsplash.com/photo-1504221507732-5246c045949b?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                EsAliado = true,
                NumeroPulicaciones = 1515,
                Verificado = true,
                RazonSocial = "Juan Pérez S.A.S.",
                SitioWeb = "https://www.youtube.com/",
                Direccion = "Calle Falsa 123, Ciudad, País",
                AliadoEstado = AliadoEstado.Disponible,
                Puntuacion = 4.3m
            };

            return (datosTest);
        }

        /// <summary>
        /// Verifica si la razón social proporcionada ya existe en el sistema, indicando si está en uso.
        /// Retorna true si existe, de lo contrario false.
        /// </summary>
        /// <param name="razonSocial">La razón social a validar.</param>
        /// <returns>Booleano indicando si la razón social ya está en uso.</returns>
        public async Task<bool> ExisteRazonSocialAsync(string razonSocial)
        {
            var consulta = "SELECT COUNT(*) FROM AspNetUsers WHERE RazonSocial = @RazonSocial;";

            var count = await _db.ExecuteScalarAsync<int>(consulta, new { RazonSocial = razonSocial });
            return count > 0;
        }

        /// <summary>
        /// Verifica si la dirección proporcionada ya existe en el sistema, indicando si está en uso.
        /// Retorna true si existe, de lo contrario false.
        /// </summary>
        /// <param name="direccion">La dirección a validar.</param>
        /// <returns>Booleano indicando si la dirección ya está en uso.</returns>
        public async Task<bool> ExisteDireccionAsync(string direccion)
        {
            var consulta = "SELECT COUNT(*) FROM AspNetUsers WHERE Direccion = @Direccion;";

            var count = await _db.ExecuteScalarAsync<int>(consulta, new { Direccion = direccion });
            return count > 0;
        }

        /// <summary>
        /// Comprueba si el usuario aliado está en estado pendiente en la obtención del verificado de su cuenta.
        /// Recibe el ID del aliado para realizar la validación.
        /// </summary>
        /// <param name="idAliado">El ID del aliado a verificar.</param>
        /// <returns>Booleano indicando si el aliado tiene una solicitud pendiente de cuenta verificada.</returns>
        public async Task<bool> VerificadoTieneEstadoPendienteAsync(string idAliado)
        {
            var consulta = @"
                SELECT COUNT(*) > 0
                FROM Verificados
                WHERE IdAliado = @IdAliado
                AND VerificadoEstado = @Estado;
            ";

            var parametros = new { IdAliado = idAliado, Estado = VerificadoEstado.Pendiente.ToString() };

            var resultado = await _db.ExecuteScalarAsync<bool>(consulta, parametros);
            return resultado;
        }

        /// <summary>
        /// Registra una solicitud de verificación en la tabla de verificados para el aliado especificado.
        /// Almacena la fecha de solicitud, el estado de verificación como pendiente, y el ID del aliado.
        /// </summary>
        /// <param name="idAliado">ID único del aliado que solicita la verificación.</param>
        /// <returns>Verdadero si la solicitud fue registrada correctamente; falso en caso contrario.</returns>
        public async Task<bool> SolicitarVerificado(string idAliado)
        {
            var consulta = @"
                INSERT INTO verificados (FechaSolicitud, VerificadoEstado, IdAliado) 
                VALUES (@FechaSolicitud, @VerificadoEstado, @IdAliado);
            ";

            var parametros = new
            {
                FechaSolicitud = DateTime.UtcNow,
                VerificadoEstado = VerificadoEstado.Pendiente.ToString(),
                IdAliado = idAliado
            };

            var filasAfectadas = await _db.ExecuteAsync(consulta, parametros);

            return filasAfectadas > 0;
        }
    }
}
