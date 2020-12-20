using _01.Framework.Infrastructure.EFCore;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;
using System.Linq;

namespace NT.UM.Infrastructure.EFCore.Repositories
{
    public class RolePermissionRepository : BaseRepository<long, RolePermission> , IRolePermissionRepository
    {
        private readonly NTUMContext _ntumcontext;
        public RolePermissionRepository(NTUMContext ntumcontext) : base(ntumcontext)
        {
            _ntumcontext = ntumcontext;
        }

        public List<RolePermissionViewModel> Search(RolePermissionViewModel command = null)
        {
            var Query = _ntumcontext.Tbl_Role_Permission.Where(x => x.Status == true).Select(x => new RolePermissionViewModel
            {
                ID = x.ID,
                RoleID = x.RoleID,
                RoleName = x.Roles.RoleName,
                PermissionID = x.PermissionID,
                PermissionName = x.Permissions.Title,
                Status = x.Status
            });
            if (command != null)
            {
                if (!string.IsNullOrWhiteSpace(command.RoleName))
                    Query = Query.Where(x => x.RoleName.Contains(command.RoleName));
            }


            return Query.ToList();
        }
    }
}
