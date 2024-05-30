using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;

namespace Dviaje.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public IPublicacionRepository PublicacionRepository { get; private set; }

        public IReservaRepository ReservaRepository { get; private set; }

        public IAtencionViajeroRepository AtencionViajeroRepository { get; private set; }

        public IAdjuntoRepository AdjuntoRepository { get; private set; }

        public IFavoritoRepository FavoritoRepository { get; private set; }

        public IUsuarioRepository UsuarioRepository { get; private set; }

        public IResenaRepository ResenaRepository { get; private set; }

        public IPublicacionFavoritaRepository PublicacionFavoritaRepository { get; private set; }

        public IPubliacacionImagenRepository PublicacionImagenRepository { get; private set; }

        public IPublicacionServicioRepository PublicacionServicioRepository { get; private set; }

        public IPublicacionRestriccionRepository PublicacionRestriccionRepository { get; private set; }

        public IVerificadoRepository VerificadoRepository { get; private set; }

        public IServicioRepository ServicioRepository { get; private set; }

        public IServicioAdicionalRepository ServicioAdicionalRepository { get; private set; }

        public IRestriccionRepository RestriccionRepository { get; private set; }

        public ICategoriaRepository CategoriaRepository { get; private set; }

        public IPublicacionCategoriaRepository PublicacionCategoriaRepository { get; private set; }

        public IFechaNoDisponibleRepository FechaNoDisponibleRepository { get; private set; }


        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            PublicacionRepository = new PublicacionRepository(_db);

            ReservaRepository = new ReservaRepository(_db);

            AtencionViajeroRepository = new AtencionViajeroRepository(_db);

            AdjuntoRepository = new AdjuntoRepository(_db);

            FavoritoRepository = new FavoritoRepository(_db);

            UsuarioRepository = new UsuaioRpository(_db);

            ResenaRepository = new ResenaRepository(_db);

            PublicacionFavoritaRepository = new PublicacionFavoritaRepository(_db);

            PublicacionImagenRepository = new PublicacionImagenRepository(_db);

            PublicacionServicioRepository = new PublicacionServicioRepository(_db);

            PublicacionRestriccionRepository = new PublicacionRestriccionRepository(_db);

            VerificadoRepository = new VerificadoRepository(_db);

            ServicioRepository = new ServicioRepository(_db);

            ServicioAdicionalRepository = new ServicioAdicionalRepository(_db);

            RestriccionRepository = new RestriccionRepository(_db);

            CategoriaRepository = new CategoriaRepository(_db);

            PublicacionCategoriaRepository = new PublicacionCategoriaRepository(_db);

            FechaNoDisponibleRepository = new FechaNoDiponibleRepository(_db);

        }
        public async Task Save() => await _db.SaveChangesAsync();

    }
}
