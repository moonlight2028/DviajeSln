﻿using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository
{
    public class FavoritoRepository : Repository<Favorito>, IFavoritoRepository
    {
        private readonly ApplicationDbContext _db;

        public FavoritoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public Task<List<PublicacionTarjetaVM>>? ObtenerFavoritos(int pagina = 0)
        {
            throw new NotImplementedException();
        }

        public void Update(Favorito favorito)
        {
            _db.Favoritos.Update(favorito);
        }


    }
}
