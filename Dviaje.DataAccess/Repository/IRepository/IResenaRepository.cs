namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IResenaRepository : IRepository<Resena>
    {
        void Update(Resena resena);
    }
}
