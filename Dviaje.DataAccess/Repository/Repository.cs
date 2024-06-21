using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dviaje.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public async Task AddAsync(T entity) => await dbSet.AddAsync(entity);


        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? incluideProperties = null)
        {
            IQueryable<T> consulta = dbSet;
            if (filter != null)
            {
                consulta = consulta.Where(filter);
            }

            if (incluideProperties != null)
            {
                foreach (var propiedad in incluideProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    consulta.Include(propiedad);
                }
            }

            return await consulta.ToListAsync();



        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>>? filter = null, string? incluideProperties = null, bool tracking = false)
        {
            IQueryable<T> consulta = tracking ? dbSet : dbSet.AsNoTracking();
            if (filter != null)
            {
                consulta = consulta.Where(filter);
            }

            if (incluideProperties != null)
            {
                foreach (var propiedad in incluideProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    consulta.Include(propiedad);
                }
            }

            return await consulta.FirstOrDefaultAsync();

        }

        public void Remove(T entity) => dbSet.Remove(entity);

    }
}
