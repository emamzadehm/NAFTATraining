using _01.Framework.Application;
using NT.SM.Application.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Application.Contracts.Interfaces
{
    public interface ISite_BaseApplication
    {
        OperationResult Create(Site_BaseViewModel command);
        OperationResult Edit(Site_BaseViewModel command);
        OperationResult Remove(long id);
        Site_BaseViewModel GetBy(long id);
        List<Site_BaseViewModel> Search(Site_BaseViewModel command);
    }
}
