using _01.Framework.Infrastructure.EFCore;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;
using System.Linq;

namespace NT.UM.Infrastructure.EFCore.Repositories
{
    public class RolePermissionRepository : BaseRepository<long, RolePermission>, IRolePermissionRepository
    {
        private readonly NTUMContext _ntumcontext;
        public RolePermissionRepository(NTUMContext ntumcontext) : base(ntumcontext)
        {
            _ntumcontext = ntumcontext;
        }



        public Dictionary<long?, List<RolePermissionViewModel>> GetPermissionsByRole(long id = 0)
        {
            var permissionbyrole = _ntumcontext.Tbl_Role_Permission
                .Where(x => x.Status == true && x.RoleID == id)
                .Select(x => new RolePermissionViewModel
                {
                    ID = x.ID,
                    RoleID = x.RoleID,
                    RoleName = x.Roles.RoleName,
                    RoleDescription = x.Roles.Description,
                    PermissionID = x.PermissionID,
                    PermissionName = x.Permissions.Title,
                    PermissionPerentID = x.Permissions.ParentId,
                    Status = x.Status,
                }).AsEnumerable().GroupBy(x => x.PermissionPerentID).ToList();

            return permissionbyrole.ToDictionary(k => k.Key, v => v.ToList());
        }
        public RolePermission GetIdByRoleAndPermission(long PermissionId, long RoleId)
        {
            return _ntumcontext.Tbl_Role_Permission
                            .FirstOrDefault(x => x.Status == true && x.RoleID == RoleId && x.PermissionID == PermissionId);
        }
        public List<RolePermission> GetPermissionsByRoleId(long RoleId)
        {
            return _ntumcontext.Tbl_Role_Permission
                            .Where(x => x.Status == true && x.RoleID == RoleId).ToList();
        }
    }
}
