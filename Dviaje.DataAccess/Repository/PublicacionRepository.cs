namespace Dviaje.DataAccess.Repository
{
    internal class PublicacionRepository : Repository<Publicacion>, IPublicacionRepository
    {
        private readonly ApplicationDbContext _db;

        public PublicacionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Publicacion publicacion)
        {
            _db.Publicaciones.Update(publicacion);
        }

    }
}
