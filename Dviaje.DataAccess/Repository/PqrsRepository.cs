using Dviaje.DataAccess.Repository.IRepository;
using System.Data;

namespace Dviaje.DataAccess.Repository
{
    public class PqrsRepository : IPqrsRepository
    {
        // Conexión de la base de datos
        private readonly IDbConnection _db;


        // Constructor e inyección de la conexión a la base de datos
        public PqrsRepository(IDbConnection db)
        {
            _db = db;
        }



    }
}
