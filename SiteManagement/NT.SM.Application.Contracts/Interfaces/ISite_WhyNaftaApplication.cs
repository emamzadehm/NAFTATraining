using _01.Framework.Application;
using NT.SM.Application.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Application.Contracts.Interfaces
{
    public interface ISite_WhyNaftaApplication
    {
        OperationResult Create(Site_WhyNaftaViewModel command);
        OperationResult Edit(Site_WhyNaftaViewModel command);
        OperationResult Remove(long id);
        Site_WhyNaftaViewModel GetBy(long id);
        List<Site_WhyNaftaViewModel> Search(Site_WhyNaftaViewModel command = null);
    }
}
