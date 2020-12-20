using _01.Framework.Domain;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;

namespace NT.UM.Domain
{
    public interface IPermissionsRepository : IRepository<long,Permission>
    {
        List<PermissionsViewModel> Search(PermissionsViewModel command = null);
        PermissionsViewModel GetDetails(long id);
    }
}
