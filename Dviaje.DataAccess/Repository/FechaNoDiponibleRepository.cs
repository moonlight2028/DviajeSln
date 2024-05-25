using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;

namespace Dviaje.DataAccess.Repository
{
    public class FechaNoDiponibleRepository : Repository<FechaNoDisponible>, IFechaNoDisponibleRepository
    {
        private readonly ApplicationDbContext _db;
        public FechaNoDiponibleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(FechaNoDisponible fechaNoDisponible)
        {
            _db.FechasNoDisponibles.Update(fechaNoDisponible);
        }
    }
}
