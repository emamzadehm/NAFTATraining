using _01.Framework.Domain;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;

namespace NT.UM.Domain
{
    public interface IRolesRepository : IRepository<long, Role>
    {
        List<RolesViewModel> Search(RolesViewModel command = null);
        RolesViewModel GetDetails(long id);
    }
}
