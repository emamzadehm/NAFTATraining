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
        OperationResult Login(LoginViewModel command);
        UsersViewModel GetDetails(long id);
        Dictionary<long, List<UsersViewModel>> Search(UsersViewModel searchmodel = null);
        OperationResult CreateRole(long roleId, long userId);
        OperationResult RemoveRole(long roleId, long userId);
        void Logout();

    }
}
