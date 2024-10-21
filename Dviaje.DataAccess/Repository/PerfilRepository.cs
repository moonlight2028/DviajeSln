using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using System.Data;

namespace Dviaje.DataAccess.Repository
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly IDbConnection _db;

        public PerfilRepository(IDbConnection db)
        {
            _db = db;
        }


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
    }
}
