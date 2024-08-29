using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository
{
    public class AliadoRepository : Repository<Aliado>, IAliadoRepository
    {
        private readonly ApplicationDbContext _db;

        public AliadoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        // Consulta para obtener el perfil del aliado.
        public Task<AliadoPerfilPublicoVM>? ObtenerPerfilAliadoAsync(string idAliado)
        {
            throw new NotImplementedException();
        }
    }
}
