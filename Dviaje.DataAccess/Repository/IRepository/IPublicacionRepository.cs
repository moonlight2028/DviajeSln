namespace Dviaje.DataAccess.Repository.IRepository
{
    internal interface IPublicacionRepository : IRepository<Publicacion>
    {
        void Update(Publicacion publicacion);
    }
}
