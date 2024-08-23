using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Dviaje.Models.VM;
using Microsoft.EntityFrameworkCore;

namespace Dviaje.DataAccess.Repository
{
    public class UsuarioTest : Repository<Usuario>, IUsuariosTest
    {
        private readonly ApplicationDbContext _db;

        public UsuarioTest(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        // LINQ con sintaxis de metodos
        public async Task<List<UsuariosTestVM>>? ListaDeUsuarios()
        {
            List<UsuariosTestVM>? usuarios = await _db.Users
                .Select(user => new UsuariosTestVM
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Roles = _db.UserRoles
                    .Where(userRole => userRole.UserId == user.Id)
                    .Join(_db.Roles,
                            userRole => userRole.RoleId,
                            role => role.Id,
                            (userRole, role) => role.Name)
                    .ToList()
                })
                .ToListAsync();

            return usuarios;
        }

        // LINQ con sintaxis parecida a SQL
        public async Task<List<UsuariosTestVM>> ListaDeUsuariosDos()
        {
            List<UsuariosTestVM>? usuarios = await (from user in _db.Users
                                                    select new UsuariosTestVM
                                                    {
                                                        UserId = user.Id,
                                                        UserName = user.UserName,
                                                        Roles = (from userRole in _db.UserRoles
                                                                 join role in _db.Roles on userRole.RoleId equals role.Id
                                                                 where userRole.UserId == user.Id
                                                                 select role.Name).ToList()
                                                    }).ToListAsync();

            return usuarios;
        }


        public void UpdateUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
