namespace Dviaje.DataAccess.Repository
{
    public class AdjuntoRepository : Repository<Adjunto>, IAdjuntoRepository
    {
        private readonly ApplicationDbContext _db;
        public AdjuntoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Adjunto adjunto)
        {
            _db.Adjuntos.Update(adjunto);
        }
    }
}
