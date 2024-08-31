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
                paginaActual = paginaActual < 1 ? 1 : paginaActual;

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
                paginaActual = paginaActual < 1 ? 1 : paginaActual;

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

        public async Task<List<ResenaDisponibleTarjetaVM>> ObtenerMisResenasDisponiblesAsync(
            string idUsuario,
            int? elementosPorPagina = null,
            int paginaActual = 0)
                {
                    var consulta = _db.Reservas
                        .Where(r => r.IdUsuario == idUsuario && r.FechaFinal <= DateTime.Now)
                        .Join(
                            _db.Resenas,
                            reserva => reserva.IdReserva,
                            resena => resena.IdReserva,
                            (reserva, resena) => new { reserva, resena }
                        )
                        .Join(
                            _db.Publicaciones, 
                            x => x.reserva.IdPublicacion,
                            publicacion => publicacion.IdPublicacion,
                            (x, publicacion) => new
                            {
                                x.reserva,
                                x.resena,
                                publicacion,
                                ImagenUrl = publicacion.PublicacionImagenes
   
                                    .Select(img => img.Ruta) // Selecciona la URL de la imagen
                                    .FirstOrDefault() // Obtiene la primera URL
                            }
                        )
                        .Select(x => new ResenaDisponibleTarjetaVM
                        {
                            TituloPublicacion = x.publicacion.Titulo,
                            FechaInicio = x.reserva.FechaInicial,
                            FechaFin = x.reserva.FechaFinal,
                            ImagenUrl = x.ImagenUrl
                        });

                    // Aplicar paginación
                    if (elementosPorPagina.HasValue && elementosPorPagina.Value > 0)
                    {
                        consulta = consulta
                            .Skip((paginaActual - 1) * elementosPorPagina.Value)
                            .Take(elementosPorPagina.Value);
                    }

                    // Ejecutar la consulta y obtener los resultados
                    return await consulta.ToListAsync();
                }


    }
}
