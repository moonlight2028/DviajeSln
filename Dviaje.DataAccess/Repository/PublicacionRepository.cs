using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using Microsoft.EntityFrameworkCore;

namespace Dviaje.DataAccess.Repository
{
    public class PublicacionRepository : Repository<Publicacion>, IPublicacionRepository
    {
        private readonly ApplicationDbContext _db;


        public PublicacionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public async Task<List<PublicacionPublicacionesVM>> GetPublicacionesAsync(int page, int pageSize)
        {
            List<PublicacionPublicacionesVM> publicaciones = await _db.Publicaciones
                .Include(p => p.Aliado)
                .Include(p => p.PublicacionCategorias)
                    .ThenInclude(pc => pc.Categoria)
                .Include(p => p.PublicacionImagenes)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new PublicacionPublicacionesVM
                {
                    IdPublicacion = p.IdPublicacion,
                    AliadoId = p.Aliado != null ? p.Aliado.Id : null,
                    AvatarAliado = p.Aliado != null ? p.Aliado.Avatar : null,
                    NombreAliado = p.Aliado != null ? p.Aliado.UserName : null,
                    Precio = p.Precio,
                    Titulo = p.Titulo,
                    Direccion = p.Direccion,
                    Descripcion = p.Descripcion,
                    TotalPublicacionesAliado = p.Aliado != null ? p.Aliado.NumeroPublicaciones : 0,
                    TotalResenas = p.NumeroResenas,
                    Categorias = p.PublicacionCategorias != null ? p.PublicacionCategorias.Select(pc => new Categoria
                    {
                        NombreCategoria = pc.Categoria != null ? pc.Categoria.NombreCategoria : null,
                        RutaIcono = pc.Categoria != null ? pc.Categoria.RutaIcono : null
                    }).ToList() : null,
                    Imagenes = p.PublicacionImagenes != null ? p.PublicacionImagenes.Select(pi => pi.Ruta).ToList() : null
                }).ToListAsync();

            return publicaciones;
        }


        public void Update(Publicacion publicacion)
        {
            _db.Publicaciones.Update(publicacion);
        }

    }
}
