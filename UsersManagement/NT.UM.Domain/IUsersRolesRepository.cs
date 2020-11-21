using _01.Framework.Domain;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;

namespace NT.UM.Domain
{
    public interface IUsersRolesRepository : IRepository<long, UsersRoles>
    {
        List<UsersRolesViewModel> Search(UsersRolesViewModel command = null);
    }
}
