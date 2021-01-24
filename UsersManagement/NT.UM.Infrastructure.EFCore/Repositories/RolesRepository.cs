using _01.Framework.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;
using System.Linq;

namespace NT.UM.Infrastructure.EFCore.Repositories
{
    public class RolesRepository : BaseRepository<long, Role>, IRolesRepository
    {
        private readonly NTUMContext _ntumcontext;
        public RolesRepository(NTUMContext ntumcontext) : base(ntumcontext)
        {
            _ntumcontext = ntumcontext;
        }

        public RolesViewModel GetDetails(long id)
        {
            var result = _ntumcontext.Tbl_Roles.Where(x => x.Status == true).Select(x => new RolesViewModel
            {
                ID = x.ID,
                RoleName = x.RoleName,
                Description = x.Description,
                Status = x.Status
            }).FirstOrDefault(x => x.ID == id);

            result.PermissionsList = _ntumcontext.Tbl_Role_Permission
                .Where(x => x.RoleID == result.ID)
                .Select(x => new RolePermissionViewModel
                {
                    ID = x.ID,
                    PermissionID = x.PermissionID,
                    PermissionName = x.Permissions.Title,
                    PermissionPerentID = x.Permissions.ParentId,
                    PermissionParentName = x.Permissions.permission.Title,
                }).ToList();
            result.SelectedPermissions = result.PermissionsList.Select(x => x.PermissionID).ToList();


            return result;
        }


        public List<RolesViewModel> Search(RolesViewModel command = null)
        {
            var Query = _ntumcontext.Tbl_Roles.Where(x => x.Status == true).Select(x => new RolesViewModel
            {
                ID = x.ID,
                RoleName = x.RoleName,
                Description = x.Description,
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
