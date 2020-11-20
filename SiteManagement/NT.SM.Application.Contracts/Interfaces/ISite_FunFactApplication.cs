using _01.Framework.Application;
using NT.SM.Application.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Application.Contracts.Interfaces
{
    public interface ISite_FunFactApplication
    {
        OperationResult Create(Site_FunFactViewModel command);
        OperationResult Edit(Site_FunFactViewModel command);
        OperationResult Remove(long id);
        Site_FunFactViewModel GetBy(long id);
        List<Site_FunFactViewModel> Search(Site_FunFactViewModel command);
    }
}
