using _01.Framework.Application;
using NT.UM.Application.Contracts.ViewModels;
using System.Collections.Generic;

namespace NT.UM.Application.Contracts.Interfaces
{
    public interface IPermissionsApplication
    {
        OperationResult Create(PermissionsViewModel command);
        OperationResult Edit(PermissionsViewModel command);
        OperationResult Remove(long id);
        PermissionsViewModel GetDetails(long? id);
        List<PermissionsViewModel> Search(PermissionsViewModel searchmodel = null);
        List<PermissionsViewModel> GetAllModules();
        //List<PermissionsViewModel> GetPermissionsByModule(long id=0);
        Dictionary<long?, List<PermissionsViewModel>> GetPermissionsByModule(long id = 0);
        List<PermissionsViewModel> GetPermissionOperationByType(long id);
        //long GetPermissionId(string Module, string Section, string Operation);
    }
}
