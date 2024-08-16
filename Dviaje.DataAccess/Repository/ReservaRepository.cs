using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using Microsoft.EntityFrameworkCore;
namespace Dviaje.DataAccess.Repository
{
    public class ReservaRepository : Repository<Reserva>, IReservaRepository
    {
        private readonly ApplicationDbContext _db;

        public ReservaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Reserva reserva)
        {
            _db.Reservas.Update(reserva);
        }

        public async Task<List<ReservaTarjetaVM>?> GetReservaTarjetas()
        {
            var consulta = await _db.Reservas
                .Include(r => r.Publicacion)
                .Select(r => new ReservaTarjetaVM
                {
                    IdReserva = r.IdReserva,
                    TituloPublicacion = r.Publicacion != null ? r.Publicacion.Titulo : null,
                    FechaInicio = r.FechaInicial,
                    FechaFinal = r.FechaFinal,
                    Imagen = ""
                })
                .ToListAsync();

            return consulta;
        }

        public async Task<ReservaTarjetaVM?> GetReservaTarjetaPorId(int id)
        {
            var consulta = await _db.Reservas
                .Include(r => r.Publicacion)
                .Where(r => r.IdReserva == id)
                .Select(r => new ReservaTarjetaVM
                {
                    IdReserva = r.IdReserva,
                    TituloPublicacion = r.Publicacion != null ? r.Publicacion.Titulo : null,
                    FechaInicio = r.FechaInicial,
                    FechaFinal = r.FechaFinal,
                    Imagen = ""
                })
                .FirstOrDefaultAsync();

            return consulta;
        }


    }
}
