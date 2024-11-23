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
            var sql = @"
        SELECT 
            u.Id AS Id, 
            u.UserName, 
            u.Avatar, 
            u.Banner,
            CASE 
                WHEN EXISTS(SELECT 1 FROM publicaciones p WHERE p.IdAliado = u.Id) THEN 1 
                ELSE 0 
            END AS EsAliado,
            u.Verificado,
            u.RazonSocial,
            u.SitioWeb,
            u.Direccion,
            u.Puntuacion,
            u.AliadoEstado,
            (SELECT COUNT(*) FROM reservas r WHERE r.IdUsuario = u.Id) AS NumeroReservas,
            (SELECT COUNT(*) FROM publicaciones p WHERE p.IdAliado = u.Id) AS NumeroPublicaciones,
            (SELECT COUNT(*) FROM resenas re 
                INNER JOIN reservas r ON re.IdReserva = r.IdReserva 
                WHERE r.IdUsuario = u.Id) AS NumeroResenas
        FROM 
            aspnetusers u
        WHERE 
            u.Id = @IdUsuario";

            return await _db.QueryFirstOrDefaultAsync<PerfilPublicoVM>(sql, new { IdUsuario = idUsuario });
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

        /// <summary>
        /// Asigna o actualiza el banner asociado al turista especificado. 
        /// Si el turista no tiene un banner, crea un nuevo registro; si ya existe, actualiza la información del banner.
        /// </summary>
        /// <param name="url">URL de la imagen del banner.</param>
        /// <param name="idTurista">ID del turista al que se le asigna el banner.</param>
        /// <param name="idPublico">ID opcional para el banner público, si corresponde. Usa como valor predeterminado "default" si es nulo o vacío.</param>
        /// <returns>Retorna true si la operación fue exitosa, false en caso contrario.</returns>
        public async Task<bool> SetBanner(string url, string idTurista, string? idPublico = null)
        {
            var consulta = @"
        UPDATE aspnetusers
        SET Banner = @Url
        WHERE Id = @IdTurista";

            var parametros = new
            {
                Url = url,
                IdTurista = idTurista
            };

            var filasAfectadas = await _db.ExecuteAsync(consulta, parametros);

            return filasAfectadas > 0;
        }



        /// <summary>
        /// Asigna o actualiza el avatar asociado al turista especificado.
        /// Si el turista no tiene avatar, crea un nuevo registro; si ya existe, actualiza las URLs de los avatares.
        /// </summary>
        /// <param name="urlCincuentaPx">URL de la imagen del avatar en tamaño de 50px x 50px.</param>
        /// <param name="urlDoscientosPx">URL de la imagen del avatar en tamaño de 200px x 200px.</param>
        /// <param name="idTurista">ID del turista al que se le asigna el avatar.</param>
        /// <param name="idPublico">ID opcional para el avatar público, si corresponde. Usa como valor predeterminado "default" si es nulo o vacío.</param>
        /// <returns>Retorna true si la operación fue exitosa, false en caso contrario.</returns>
        public async Task<bool> SetAvatar(string urlCincuentaPx, string urlDoscientosPx, string idTurista, string? idPublico = null)
        {
            var consulta = @"
        UPDATE aspnetusers
        SET Avatar = @UrlDoscientosPx
        WHERE Id = @IdTurista";

            var parametros = new
            {
                UrlDoscientosPx = urlDoscientosPx,
                IdTurista = idTurista
            };

            var filasAfectadas = await _db.ExecuteAsync(consulta, parametros);

            return filasAfectadas > 0;
        }



        /// <summary>
        /// Obtiene el avatar en resolución de 200px junto con el banner asociado a un turista especificado.
        /// </summary>
        /// <param name="idTurista">ID del turista cuyo avatar y banner se desean obtener.</param>
        /// <returns>
        /// Una tupla que contiene la URL del avatar (Avatar) y la URL del banner (Banner). 
        /// Retorna null si no se encuentra información para el turista especificado.
        /// </returns>
        public async Task<(string Avatar, string Banner)?> ObtenerBannerAvatar(string idTurista)
        {
            var consulta = @"
        SELECT 
            Avatar, 
            Banner
        FROM 
            aspnetusers
        WHERE 
            Id = @IdTurista";

            var resultado = await _db.QueryFirstOrDefaultAsync<(string Avatar, string Banner)>(consulta, new { IdTurista = idTurista });

            return resultado;
        }

    }
}
