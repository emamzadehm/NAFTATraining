using _01.Framework.Domain;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;

namespace NT.UM.Domain
{
    public interface IUsersRolesRepository : IRepository<long, UserRole>
    {
        UserRole GetByUserRole(long userID, long roleID);
        List<UserRole> GetRoleByUser(long userID);
    }
}
