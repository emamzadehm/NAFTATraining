using _01.Framework.Domain;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;

namespace NT.UM.Domain
{
    public interface IRolePermission : IRepository<long, RolePermission>
    {
        List<RolePermissionViewModel> Search(RolePermissionViewModel command = null);
    }
}
