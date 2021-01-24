using _01.Framework.Application;
using _01.Framework.Infrastructure.EFCore;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain;
using NT.UM.Domain.UsersAgg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NT.UM.Infrastructure.EFCore.Repositories
{
    public class UsersRolesRepository : BaseRepository<long, UserRole>, IUsersRolesRepository
    {
        private readonly NTUMContext _ntumcontext;
        public UsersRolesRepository(NTUMContext ntumcontext) : base(ntumcontext)
        {
            _ntumcontext = ntumcontext;
        }

        public UserRole GetByUserRole(long userID, long roleID)
        {
            return _ntumcontext.Tbl_Users_Roles
                .Where(x => x.Status == true)
                .FirstOrDefault(x => x.UserID == userID && x.RoleID == roleID);
        }

        public List<UserRole> GetRoleByUser(long userID)
        {
            return _ntumcontext.Tbl_Users_Roles
                            .Where(x => x.Status == true && x.UserID == userID).ToList();
        }

        public UsersRolesViewModel GetRolePermissionByUser(long userID)
        {
            var result = _ntumcontext.Tbl_Users
                .Where(x => x.Status == true)
                .Select(x => new UsersRolesViewModel
                {
                    UserID = x.ID,
                    Username = x.Email,
                    Fullname = x.Sex.ToSexName() + " " + x.FirstName + " " + x.LastName,
                    Status = x.Status,
                }).FirstOrDefault(x => x.UserID == userID);

            result.RolesList = _ntumcontext.Tbl_Users_Roles.Where(x => x.UserID == result.UserID && x.Status==true && x.Roles.Status==true)
                .Select(x => new UsersRolesViewModel
                {
                    ID = x.ID,
                    RoleID = x.RoleID,
                    RoleName = x.Roles.RoleName
                }).ToList();
            foreach (var item in result.RolesList)
            {
                result.PermissionsList = _ntumcontext.Tbl_Role_Permission
                    .Where(x => x.RoleID == item.RoleID && x.Status == true && x.Permissions.Status==true)
                    .Select(x => new RolePermissionViewModel
                    {
                        ID = x.ID,
                        PermissionID = x.PermissionID,
                        PermissionName = x.Permissions.permission.permission.Title + "-"+ x.Permissions.permission.Title + "-" + x.Permissions.Title,
                        //PermissionPerentID=x.Permissions.ParentId,
                        //PermissionParentName=x.Permissions.permission.Title
                    }).ToList();
            }
            return result;
        }

    }
}
