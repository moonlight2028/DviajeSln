using Dviaje.DataAccess.Repository.IRepository;
using System.Data;

namespace Dviaje.DataAccess.Repository
{
    public class ReservaRepository : IReservaRepository
    {
        // Conexión de la base de datos
        private readonly IDbConnection _db;


        // Constructor e inyección de la conexión a la base de datos
        public ReservaRepository(IDbConnection db)
        {
            _db = db;
        }



    }
}
