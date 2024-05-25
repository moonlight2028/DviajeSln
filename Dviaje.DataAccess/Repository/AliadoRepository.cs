namespace Dviaje.DataAccess.Repository
{
    public class AliadoRepository : Repository<Aliado>, IAliadoRepository
    {
        private readonly ApplicationDbContext _db;

        public AliadoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Aliado aliado)
        {
            _db.Aliados.Update(aliado);
        }
    }
}
