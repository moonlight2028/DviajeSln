using Dviaje.DataAccess.Repository.IRepository;
using System.Data;

namespace Dviaje.DataAccess.Repository
{
    public class ResenaRepository : IResenasRepository
    {
        // Conexión de la base de datos
        private readonly IDbConnection _db;


        // Constructor e inyección de la conexión a la base de datos
        public ResenaRepository(IDbConnection db)
        {
            _db = db;
        }



    }
}
