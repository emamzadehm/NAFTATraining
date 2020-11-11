using _01.Framework.Infrastructure.EFCore;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;
using System.Linq;

namespace NT.UM.Infrastructure.EFCore.Repositories
{
    public class UsersRolesRepository : BaseRepository<long, UsersRoles> , IUsersRolesRepository
    {
        private readonly NTUMContext _ntumcontext;
        public UsersRolesRepository(NTUMContext ntumcontext) : base(ntumcontext)
        {
            _ntumcontext = ntumcontext;
        }

        public List<UsersRolesViewModel> Search(UsersRolesViewModel command)
        {
            var Query = _ntumcontext.Tbl_Users_Roles.Where(x => x.Status == true).Select(x => new UsersRolesViewModel
            {
                ID = x.ID,
                UserID=x.UserID,
                RoleID=x.RoleID,
                Status=x.Status
            });
            //if (!string.IsNullOrWhiteSpace(command.Description))
            //    Query = Query.Where(x => x.Description.Contains(command.Description));

            return Query.ToList();
        }
    }
}
