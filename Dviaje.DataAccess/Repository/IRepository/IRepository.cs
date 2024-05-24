using System.Linq.Expressions;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? incluideProperties = null);
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, string? incluideProperties = null, bool tracking = false);
        Task AddAsync(T entity);
        void Remove(T entity);



    }
}
