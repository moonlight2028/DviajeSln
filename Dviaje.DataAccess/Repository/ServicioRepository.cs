namespace Dviaje.DataAccess.Repository
{
    public class ServicioRepository : Repository<Servicio>, IServicioRepository
    {
        private readonly ApplicationDbContext _db;

        public ServicioRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Servicio servicio)
        {
            _db.Servicios.Update(servicio);
        }
    }
}
