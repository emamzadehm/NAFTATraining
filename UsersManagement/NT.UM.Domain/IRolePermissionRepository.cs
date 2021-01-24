using _01.Framework.Domain;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;

namespace NT.UM.Domain
{
    public interface IRolePermissionRepository : IRepository<long, RolePermission>
    {
        //List<RolePermissionViewModel> Search(RolePermissionViewModel command = null);
        //RolePermissionViewModel GetDetailsbyRole(long id);
        Dictionary<long?, List<RolePermissionViewModel>> GetPermissionsByRole(long id = 0);
        RolePermission GetIdByRoleAndPermission(long PermissionId, long RoleId);
        List<RolePermission> GetPermissionsByRoleId(long RoleId);

    }
}
