using _01.Framework.Application;
using NT.UM.Application.Contracts.ViewModels;
using System.Collections.Generic;

namespace NT.UM.Application.Contracts.Interfaces
{
    public interface IUserApplication
    {
        OperationResult Create(UsersViewModel command);
        OperationResult Edit(UsersViewModel command);
        OperationResult ChangePassword(long uid, string password);
        OperationResult Remove(long id);
        UsersViewModel GetDetails(long id);
        List<UsersViewModel> Search(UsersViewModel searchmodel = null);
    }
}
