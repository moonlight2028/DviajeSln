namespace Dviaje.DataAccess.Repository
{
    public class RestriccionRepository : Repository<Restriccion>, IRestriccionRepository
    {
        private readonly ApplicationDbContext _db;

        public RestriccionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Udpate(Restriccion restriccion)
        {
            _db.Restricciones.Update(restriccion);
        }
    }
}
