using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using Microsoft.EntityFrameworkCore;

namespace Dviaje.DataAccess.Repository
{
    public class ResenaRepository : Repository<Resena>, IResenaRepository
    {
        private readonly ApplicationDbContext _db;

        public ResenaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<ResenaTarjetaVM>> ObtenerResenasAsync(int idPublicacion, int? elementosPorPagina = null, int paginaActual = 0)
        {
            var consulta = _db.Resenas
                .Include(r => r.Reserva)
                .ThenInclude(r => r.Usuario)
                .Include(r => r.Reserva.Publicacion)
                .Where(r => r.Reserva.IdPublicacion == idPublicacion)
                .Select(r => new ResenaTarjetaVM
                {
                    IdResena = r.IdResena,
                    Opinion = r.Opinion,
                    Calificacion = r.Calificacion,
                    MeGusta = r.MeGusta,
                    Fecha = r.Fecha,
                    NombreUsuario = r.Reserva.Usuario.UserName,
                    AvatarUrl = r.Reserva.Usuario.Avatar,
                    TituloPublicacion = r.Reserva.Publicacion.Titulo,
                    PuntuacionPublicacion = r.Reserva.Publicacion.Puntuacion
                })
                .OrderByDescending(r => r.Calificacion)
                .AsQueryable();

            if (elementosPorPagina.HasValue)
            {
                consulta = consulta
                    .Skip((paginaActual - 1) * elementosPorPagina.Value)
                    .Take(elementosPorPagina.Value);
            }

            return await consulta.ToListAsync();
        }

        public async Task<List<ResenaTarjetaVM>> ObtenerMisResenasAsync(string idUsuario, int? elementosPorPagina = null, int paginaActual = 0)
        {
            var consulta = _db.Resenas
                .Include(r => r.Reserva)
                .ThenInclude(r => r.Usuario)
                .Include(r => r.Reserva.Publicacion)
                .Where(r => r.Reserva.Usuario.Id == idUsuario) // Filtra por el ID del usuario
                .Select(r => new ResenaTarjetaVM
                {
                    IdResena = r.IdResena,
                    Opinion = r.Opinion,
                    Calificacion = r.Calificacion,
                    MeGusta = r.MeGusta,
                    Fecha = r.Fecha,
                    NombreUsuario = r.Reserva.Usuario.UserName,
                    AvatarUrl = r.Reserva.Usuario.Avatar,
                    TituloPublicacion = r.Reserva.Publicacion.Titulo,
                    PuntuacionPublicacion = r.Reserva.Publicacion.Puntuacion
                })
                .OrderByDescending(r => r.Calificacion)
                .AsQueryable();

            if (elementosPorPagina.HasValue)
            {
                consulta = consulta
                    .Skip((paginaActual - 1) * elementosPorPagina.Value)
                    .Take(elementosPorPagina.Value);
            }

            return await consulta.ToListAsync();
        }

        public void Update(Resena resena)
        {
            _db.Resenas.Update(resena);
        }

        public Task<bool> ValiadacionUsuarioResena(string idUsuario, int idReserva)
        {
            throw new NotImplementedException();
        }
    }
}
