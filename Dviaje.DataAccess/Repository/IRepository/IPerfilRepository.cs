﻿using Dviaje.Models.VM;

namespace Dviaje.DataAccess.Repository.IRepository
{
    public interface IPerfilRepository
    {
        Task<PerfilPublicoVM?> ObtenerPerfilPublicoAsync(string idUsuario);
    }
}
