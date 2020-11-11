using _01.Framework.Application;
using NT.UM.Application.Contracts.ViewModels;
using System.Collections.Generic;

namespace NT.UM.Application.Contracts.Interfaces
{
    public interface IRolePermissionApplication
    {
        OperationResult Create(RolePermissionViewModel command);
        OperationResult Edit(RolePermissionViewModel command);
        OperationResult Remove(long id);
        RolePermissionViewModel GetBy(long id);
        List<RolePermissionViewModel> Search(RolePermissionViewModel searchmodel);
    }
}
