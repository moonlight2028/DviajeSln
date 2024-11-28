using Dapper;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using System.Data;

public class UserRepository : IUserRepository
{
    private readonly IDbConnection _db;

    public UserRepository(IDbConnection db)
    {
        _db = db;
    }

    // Obtener lista de usuarios con sus roles
    public async Task<List<UsuarioVM>> ObtenerUsuariosAsync()
    {
        var sql = @"
        SELECT 
            u.Id AS IdUsuario, 
            u.UserName, 
            u.Email, 
            u.Avatar, 
            u.PhoneNumber, 
            COALESCE(
                (SELECT GROUP_CONCAT(r.Name SEPARATOR ', ') 
                 FROM aspnetuserroles ur
                 JOIN aspnetroles r ON ur.RoleId = r.Id
                 WHERE ur.UserId = u.Id),
                'Sin rol'
            ) AS Roles
        FROM 
            aspnetusers u";

        return (await _db.QueryAsync<UsuarioVM>(sql)).ToList();
    }

    // Obtener lista de roles disponibles
    public async Task<List<string>> ObtenerRolesDisponiblesAsync()
    {
        var sql = "SELECT Name FROM aspnetroles";
        return (await _db.QueryAsync<string>(sql)).ToList();
    }

    // Cambiar rol de usuario
    public async Task<bool> CambiarRolUsuarioAsync(string idUsuario, string nuevoRol)
    {
        if (_db.State != ConnectionState.Open)
        {
            _db.Open();
        }

        var eliminarRoles = @"
        DELETE FROM aspnetuserroles 
        WHERE UserId = @IdUsuario";

        var agregarRol = @"
        INSERT INTO aspnetuserroles (UserId, RoleId)
        SELECT @IdUsuario, Id 
        FROM aspnetroles 
        WHERE Name = @NuevoRol";

        using var transaction = _db.BeginTransaction();

        try
        {
            await _db.ExecuteAsync(eliminarRoles, new { IdUsuario = idUsuario }, transaction);
            await _db.ExecuteAsync(agregarRol, new { IdUsuario = idUsuario, NuevoRol = nuevoRol }, transaction);
            transaction.Commit();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en CambiarRolUsuarioAsync: {ex.Message}");
            transaction.Rollback();
            return false;
        }
    }



    // Banear usuario
    public async Task<bool> BanearUsuarioAsync(string idUsuario)
    {
        var sql = @"
        UPDATE aspnetusers 
        SET LockoutEnd = @LockoutEnd 
        WHERE Id = @IdUsuario";

        var lockoutEnd = DateTime.UtcNow.AddYears(100);
        var rowsAffected = await _db.ExecuteAsync(sql, new { LockoutEnd = lockoutEnd, IdUsuario = idUsuario });
        return rowsAffected > 0;
    }

    // Eliminar usuario
    public async Task<bool> EliminarUsuarioAsync(string idUsuario)
    {
        var sql = @"
        DELETE FROM aspnetusers 
        WHERE Id = @IdUsuario";

        var rowsAffected = await _db.ExecuteAsync(sql, new { IdUsuario = idUsuario });
        return rowsAffected > 0;
    }
}
