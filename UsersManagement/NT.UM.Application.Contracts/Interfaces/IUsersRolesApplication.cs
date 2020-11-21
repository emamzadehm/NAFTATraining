using _01.Framework.Application;
using NT.UM.Application.Contracts.ViewModels;
using System.Collections.Generic;

namespace NT.UM.Application.Contracts.Interfaces
{
    public interface IUsersRolesApplication
    {
        OperationResult Create(UsersRolesViewModel command);
        OperationResult Edit(UsersRolesViewModel command);
        OperationResult Remove(long id);
        UsersRolesViewModel GetBy(long id);
        List<UsersRolesViewModel> Search(UsersRolesViewModel searchmodel = null);
    }
}
