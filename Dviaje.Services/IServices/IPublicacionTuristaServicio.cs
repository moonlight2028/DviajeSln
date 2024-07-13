using Dviaje.Models;

namespace Dviaje.Services.IServices
{
    public interface IPublicacionTuristaServicio
    {
        void AgregarPublicacion(int idPublicacion);
        void EliminarPublicacion(int idPublicacion);
        // Corregis el modelo al VM
        IEnumerable<Publicacion> PublicacionesFavoritas(string idUsuario);
    }
}
