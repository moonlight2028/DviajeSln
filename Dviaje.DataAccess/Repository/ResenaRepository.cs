﻿using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository
{
    public class ResenaRepository : Repository<Resena>, IResenaRepository
    {
        private readonly ApplicationDbContext _db;

        public ResenaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public Task<List<ResenaTarjetaVM>>? ObtenerResenasAsync(int idPublicacion, int? elementoPorPagina = null, int paginaActual = 0)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResenaTarjetaVM>>? ObtenerMisResenasAsync(int idUsuario, int? elementoPorPagina = null, int paginaActual = 0)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResenaDispobibleTarjetaVM>>? ObtenerMisResenasDisponiblesAsync(int idUsuario, int? elementoPorPagina = null, int paginaActual = 0)
        {
            throw new NotImplementedException();
        }

        public void Update(Resena resena)
        {
            _db.Resenas.Update(resena);
        }
    }
}
