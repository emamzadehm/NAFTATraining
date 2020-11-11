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
        PermissionsViewModel GetBy(long id);
        List<PermissionsViewModel> Search(PermissionsViewModel searchmodel);
    }
}
