using Dviaje.Models;

namespace Dviaje.Services.IServices
{
    public interface IPublicacionAliadoServicio
    {
        void CrearPublicacion(Publicacion publicacion);
        void PausarPublicacion(int idPublicacion);
        void EditarPublicacion(Publicacion publicacion);
        void EliminarPublicacion(int idPublicacion);
    }
}
