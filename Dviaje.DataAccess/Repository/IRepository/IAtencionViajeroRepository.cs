namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IAtencionViajeroRepository : IRepository<AtencionViajero>
    {
        void Update(AtencionViajero atencionViajero);
    }
}
