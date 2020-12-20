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
    public class UsersRepository : BaseRepository<long, User>, IUsersRepository
    {
        private readonly NTUMContext _ntumcontext;
        public UsersRepository(NTUMContext ntumcontext) : base(ntumcontext)
        {
            _ntumcontext = ntumcontext;
        }

        public void Save()
        {
            _ntumcontext.SaveChanges();
        }

        public UsersViewModel GetDetails(long id)
        {
            return _ntumcontext.Tbl_Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Roles)
                .Where(x => x.Status == true)
                .Select(x => new UsersViewModel
                {
                    ID = x.ID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    IDCardIMGFileAddress = x.IDCardIMG,
                    IMGFileAddress = x.IMG,
                    Sex = x.Sex,
                    Tel = x.Tel,
                    Fullname = x.Sex.ToSexName() + " " + x.FirstName + " " + x.LastName,
                    UserStatus = x.Status,
                    UserRolesList = MapUserToRoles(x.UserRoles, x.ID)
                }).FirstOrDefault(x => x.ID == id);
        }
        public Dictionary<long, List<UsersViewModel>> Search(UsersViewModel command = null)
        {

            var UserInfo = _ntumcontext
                .Tbl_Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Roles)
                .Where(x => x.Status == true)
                .Select(x => new UsersViewModel
                {
                    ID = x.ID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    IDCardIMGFileAddress = x.IDCardIMG,
                    IMGFileAddress = x.IMG,
                    Sex = x.Sex,
                    Tel = x.Tel,
                    Fullname = x.Sex.ToSexName() + " " + x.FirstName + " " + x.LastName,
                    UserStatus = x.Status,
                    UserRolesList = MapUserToRoles(x.UserRoles, x.ID)
                }).AsEnumerable().GroupBy(x => x.ID).ToList();

            //{
            //    if (!string.IsNullOrWhiteSpace(command.Fullname))
            //        UserInfo = UserInfo.Where(x => x.Fullname.Contains(command.Fullname));
            //}

            return UserInfo.ToDictionary(k => k.Key, v => v.ToList());

        }

        private static List<UsersRolesViewModel> MapUserToRoles(List<UserRole> userRoles, long uId)
        {
            return userRoles.Where(x => x.UserID == uId)
                .Where(x=>x.Status==true)
                .Select(x => new UsersRolesViewModel
            {
                ID = x.ID,
                RoleID = x.RoleID,
                RoleName = x.Roles.RoleName
            }).ToList();
        }
    }
}
