using _01.Framework.Application;
using _01.Framework.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain;
using NT.UM.Domain.UsersAgg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NT.UM.Infrastructure.EFCore.Repositories
{
    public class UsersRolesRepository : BaseRepository<long, UsersRoles>, IUsersRolesRepository
    {
        private readonly NTUMContext _ntumcontext;
        public UsersRolesRepository(NTUMContext ntumcontext) : base(ntumcontext)
        {
            _ntumcontext = ntumcontext;
        }

        public UsersRolesViewModel GetDetails(long id)
        {
            return _ntumcontext.Tbl_Users_Roles.Where(x => x.Status == true).Select(x => new UsersRolesViewModel
            {
                ID = x.ID,
                UserID = x.UserID,
                RoleID = x.RoleID,
                Status = x.Status
            }).FirstOrDefault(x => x.ID == id);
        }

        public List<UsersRolesViewModel> Search(UsersRolesViewModel command = null)
        {

            return _ntumcontext.Tbl_Users_Roles.Where(x => x.Status == true).Select(x => new UsersRolesViewModel
            {
                ID = x.ID,
                UserID = x.UserID,
                Fullname = x.Users.Sex.ToSexName() + " " + x.Users.FirstName + " " + x.Users.LastName,
                Username = x.Users.Email,
                RoleID = x.RoleID,
                RoleName = x.Roles.RoleName,
                Status = x.Status,
            }).ToList();
        }
    }
}
