﻿using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
namespace Dviaje.DataAccess.Repository
{
    public class PublicacionRepository : Repository<Publicacion>, IPublicacionRepository
    {
        private readonly ApplicationDbContext _db;

        public PublicacionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Publicacion publicacion)
        {
            _db.Publicaciones.Update(publicacion);
        }

    }
}
