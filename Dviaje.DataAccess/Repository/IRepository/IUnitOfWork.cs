namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPublicacionRepository PublicacionRepository { get; }
        IReservaRepository ReservaRepository { get; }
        IAtencionViajeroRepository AtencionViajeroRepository { get; }
        IAdjuntoRepository AdjuntoRepository { get; }
        IFavoritoRepository FavoritoRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        IResenaRepository ResenaRepository { get; }
        IPublicacionFavoritaRepository PublicacionFavoritaRepository { get; }
        IPubliacacionImagenRepository PublicacionImagenRepository { get; }
        IPublicacionServicioRepository PublicacionServicioRepository { get; }
        IPublicacionRestriccionRepository PublicacionRestriccionRepository { get; }
        IVerificadoRepository VerificadoRepository { get; }
        IServicioRepository ServicioRepository { get; }
        IServicioAdicionalRepository ServicioAdicionalRepository { get; }
        IRestriccionRepository RestriccionRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        IPublicacionCategoriaRepository PublicacionCategoriaRepository { get; }
        IFechaNoDisponibleRepository FechaNoDisponibleRepository { get; }
        IAliadoRepository AliadoRepository { get; }


        // Test usuairos
        IUsuariosTest UsuariosTest { get; }

        Task Save();

    }
}
