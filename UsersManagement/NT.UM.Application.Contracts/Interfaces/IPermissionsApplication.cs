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
        PermissionsViewModel GetDetails(long id);
        List<PermissionsViewModel> Search(PermissionsViewModel searchmodel = null);
    }
}
