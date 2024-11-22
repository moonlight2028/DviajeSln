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

    public async Task<List<UsuarioVM>> ObtenerUsuariosAsync()
    {
        var sql = @"
            SELECT u.Id AS IdUsuario, u.UserName, u.Email, u.Avatar, u.PhoneNumber, 
                   (SELECT STRING_AGG(r.Name, ', ') 
                    FROM AspNetUserRoles ur
                    JOIN AspNetRoles r ON ur.RoleId = r.Id
                    WHERE ur.UserId = u.Id) AS Roles
            FROM AspNetUsers u";

        return (await _db.QueryAsync<UsuarioVM>(sql)).ToList();
    }

    public async Task<bool> CambiarRolUsuarioAsync(string idUsuario, string nuevoRol)
    {
        var eliminarRoles = @"
            DELETE FROM AspNetUserRoles 
            WHERE UserId = @IdUsuario";

        var agregarRol = @"
            INSERT INTO AspNetUserRoles (UserId, RoleId)
            SELECT @IdUsuario, Id 
            FROM AspNetRoles 
            WHERE Name = @NuevoRol";

        using var transaction = _db.BeginTransaction();

        try
        {
            await _db.ExecuteAsync(eliminarRoles, new { IdUsuario = idUsuario }, transaction);
            await _db.ExecuteAsync(agregarRol, new { IdUsuario = idUsuario, NuevoRol = nuevoRol }, transaction);
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }

    public async Task<bool> BanearUsuarioAsync(string idUsuario)
    {
        var sql = @"
            UPDATE AspNetUsers 
            SET LockoutEnd = @LockoutEnd 
            WHERE Id = @IdUsuario";

        var lockoutEnd = DateTime.UtcNow.AddYears(100);
        var rowsAffected = await _db.ExecuteAsync(sql, new { LockoutEnd = lockoutEnd, IdUsuario = idUsuario });
        return rowsAffected > 0;
    }

    public async Task<bool> EliminarUsuarioAsync(string idUsuario)
    {
        var sql = @"
            DELETE FROM AspNetUsers 
            WHERE Id = @IdUsuario";

        var rowsAffected = await _db.ExecuteAsync(sql, new { IdUsuario = idUsuario });
        return rowsAffected > 0;
    }
}
