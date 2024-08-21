using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models;
using Microsoft.AspNetCore.Identity;

namespace Dviaje.DataAccess.Repository
{
    internal class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Usuario> _userManager;

        public UsuarioRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        // recibe el UserManager y el contexto de la base de datos
        public UsuarioRepository(ApplicationDbContext db, UserManager<Usuario> userManager) : base(db)
        {
            _userManager = userManager;
        }

        // Método para cambiar el rol de un usuario
        public async Task CambiarRol(Usuario usuario, string nuevoRol)
        {
            var rolesActuales = await _userManager.GetRolesAsync(usuario);
            await _userManager.RemoveFromRolesAsync(usuario, rolesActuales);
            await _userManager.AddToRoleAsync(usuario, nuevoRol);
        }

        public async Task<IList<string>> GetRolesAsync(Usuario usuario)
        {
            return await _userManager.GetRolesAsync(usuario);
        }



        public void Update(Usuario usuario)
        {
            _db.Usuarios.Update(usuario);
        }



    }
}
