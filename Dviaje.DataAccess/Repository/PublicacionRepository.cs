using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dviaje.DataAccess.Repository
{
    public class PublicacionRepository : Repository<Publicacion>, IPublicacionRepository
    {
        private readonly ApplicationDbContext _db;


        public PublicacionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        //Información de las tarjetas de publicación de la vista de publicaciones.
        public async Task<List<PublicacionTarjetaVM>> GetPublicacionesAsync(int page, int pageSize, Expression<Func<Publicacion, object>>? orderBy = null)
        {
            IQueryable<Publicacion> query = _db.Publicaciones
                .Include(p => p.Aliado)
                .Include(p => p.PublicacionCategorias)
                    .ThenInclude(pc => pc.Categoria)
                .Include(p => p.PublicacionImagenes);

            query = orderBy != null ? query.OrderBy(orderBy) : query.OrderByDescending(p => p.Puntuacion);

            List<PublicacionTarjetaVM> publicaciones = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new PublicacionTarjetaVM
                {
                    IdPublicacion = p.IdPublicacion,
                    AliadoId = p.Aliado != null ? p.Aliado.Id : null,
                    AvatarAliado = p.Aliado != null ? p.Aliado.Avatar : null,
                    NombreAliado = p.Aliado != null ? p.Aliado.UserName : null,
                    Precio = p.Precio,
                    Titulo = p.Titulo,
                    Direccion = p.Direccion,
                    Calificacion = p.Puntuacion,
                    Descripcion = p.Descripcion,
                    TotalPublicacionesAliado = p.Aliado != null ? p.Aliado.NumeroPublicaciones : 0,
                    TotalResenas = p.NumeroResenas,
                    Categorias = p.PublicacionCategorias != null ? p.PublicacionCategorias.Select(pc => new Categoria
                    {
                        NombreCategoria = pc.Categoria != null ? pc.Categoria.NombreCategoria : null,
                        RutaIcono = pc.Categoria != null ? pc.Categoria.RutaIcono : null
                    }).ToList() : null,
                    Imagenes = p.PublicacionImagenes != null ? p.PublicacionImagenes.Select(pi => new PublicacionImagenVM
                    {
                        Ruta = pi.Ruta,
                        Alt = pi.Alt
                    }).ToList() : null
                }).ToListAsync();

            return publicaciones;
        }


        // Publicaciones totales de la vista de publicaciones.
        public async Task<int> GetTotalPublicacionesAsync() => await _db.Publicaciones.CountAsync();

        public void Update(Publicacion publicacion)
        {
            _db.Publicaciones.Update(publicacion);
        }

    }
}
