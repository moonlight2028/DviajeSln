using System.Linq.Expressions;
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

        // Detalles de publicación.
        public async Task<PublicacionVM?> GetPublicacionAsync(int idPublicacion)
        {
            PublicacionVM? publicacion = await _db.Publicaciones
                .Include(p => p.Aliado)
                .Include(p => p.PublicacionCategorias)
                    .ThenInclude(p => p.Categoria)
                .Include(p => p.PublicacionServicios)
                    .ThenInclude(p => p.Servicio)
                .Include(p => p.PublicacionRestricciones)
                    .ThenInclude(p => p.Restriccion)
                .Include(p => p.ServicioAdicionales)
                    .ThenInclude(p => p.Servicio)
                .Where(p => p.IdPublicacion == idPublicacion)
                .Select(p => new PublicacionVM
                {
                    IdPublicacion = p.IdPublicacion,
                    Titulo = p.Titulo,
                    Descripcion = p.Descripcion,
                    Ubicacion = p.Direccion,
                    Precio = p.Precio,
                    IdAliado = p.Aliado != null ? p.Aliado.Id : null,
                    AvatarAliado = p.Aliado != null ? p.Aliado.Avatar : null,
                    NombreAliado = p.Aliado != null ? p.Aliado.UserName : null,
                    PublicacionesAliado = p.Aliado != null ? p.Aliado.NumeroPublicaciones : 0,
                    Puntuacion = p.Puntuacion,
                    NumeroResenas = p.NumeroResenas,
                    Imagenes = p.PublicacionImagenes.Select(pi => new PublicacionImagenVM
                    {
                        Ruta = pi.Ruta,
                        Alt = pi.Alt
                    }).ToList(),
                    Categorias = p.PublicacionCategorias.Select(pc => new Categoria
                    {
                        NombreCategoria = pc.Categoria != null ? pc.Categoria.NombreCategoria : null,
                        RutaIcono = pc.Categoria != null ? pc.Categoria.RutaIcono : null
                    }).ToList(),
                    ServiciosHabitacion = p.ServicioAdicionales
                        .Where(ps => ps.Servicio != null ? ps.Servicio.ServicioTipo == ServicioTipo.Habitacion : false)
                        .Select(ps => new ServicioVM
                        {
                            Nombre = ps.Servicio != null ? ps.Servicio.NombreServicio : null,
                            Icono = ps.Servicio != null ? ps.Servicio.RutaIcono : null
                        }).ToList(),
                    ServiciosEstablecimiento = p.ServicioAdicionales
                        .Where(ps => ps.Servicio != null ? ps.Servicio.ServicioTipo == ServicioTipo.Establecimiento : false)
                        .Select(ps => new ServicioVM
                        {
                            Nombre = ps.Servicio != null ? ps.Servicio.NombreServicio : null,
                            Icono = ps.Servicio != null ? ps.Servicio.RutaIcono : null
                        }).ToList(),
                    ServiciosAccesibilidad = p.ServicioAdicionales
                        .Where(ps => ps.Servicio != null ? ps.Servicio.ServicioTipo == ServicioTipo.Accesibilidad : false)
                        .Select(ps => new ServicioVM
                        {
                            Nombre = ps.Servicio != null ? ps.Servicio.NombreServicio : null,
                            Icono = ps.Servicio != null ? ps.Servicio.RutaIcono : null
                        }).ToList(),
                    Restricciones = p.PublicacionRestricciones.Select(pr => pr.Restriccion).ToList(),
                    ServiciosAdicionales = p.ServicioAdicionales.Select(psa => new ServicioAdicional
                    {
                        PrecioServicioAdicional = psa.PrecioServicioAdicional,
                        Servicio = new Servicio
                        {
                            NombreServicio = psa.Servicio != null ? psa.Servicio.NombreServicio : null,
                            ServicioTipo = psa.Servicio != null ? psa.Servicio.ServicioTipo : null,
                            RutaIcono = psa.Servicio != null ? psa.Servicio.RutaIcono : null
                        }
                    }).ToList()
                }).FirstOrDefaultAsync();

            return publicacion;
        }

        // Publicaciones totales.
        public async Task<int> GetTotalPublicacionesAsync() => await _db.Publicaciones.CountAsync();

        public void Update(Publicacion publicacion)
        {
            _db.Publicaciones.Update(publicacion);
        }

    }
}
