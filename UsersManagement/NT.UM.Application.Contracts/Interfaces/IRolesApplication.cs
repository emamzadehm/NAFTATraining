using _01.Framework.Application;
using NT.UM.Application.Contracts.ViewModels;
using System.Collections.Generic;

namespace NT.UM.Application.Contracts.Interfaces
{
    public interface IRolesApplication
    {
        OperationResult Create(RolesViewModel command);
        OperationResult Edit(RolesViewModel command);
        OperationResult Remove(long id);
        RolesViewModel GetBy(long id);
        List<RolesViewModel> Search(RolesViewModel searchmodel);
    }
}
