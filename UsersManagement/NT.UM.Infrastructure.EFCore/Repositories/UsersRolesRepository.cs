using _01.Framework.Infrastructure.EFCore;
using NT.UM.Domain;
using NT.UM.Domain.UsersAgg;
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
                .Where(x => x.Status == true)
                .Where(x => x.UserID == userID).ToList();
        }
    }
}
