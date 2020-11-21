using _01.Framework.Application;
using NT.UM.Application.Contracts.ViewModels;
using System.Collections.Generic;

namespace NT.UM.Application.Contracts.Interfaces
{
    public interface IUserApplication
    {
        OperationResult Create(UsersViewModel command);
        OperationResult Edit(UsersViewModel command);
        OperationResult Remove(long id);
        UsersViewModel GetBy(long id);
        List<UsersViewModel> Search(UsersViewModel searchmodel = null);
    }
}
