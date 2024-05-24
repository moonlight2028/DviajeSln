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
    }
}
