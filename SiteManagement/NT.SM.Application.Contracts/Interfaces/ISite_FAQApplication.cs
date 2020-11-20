using _01.Framework.Application;
using NT.SM.Application.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Application.Contracts.Interfaces
{
    public interface ISite_FAQApplication
    {
        OperationResult Create(Site_FAQViewModel command);
        OperationResult Edit(Site_FAQViewModel command);
        OperationResult Remove(long id);
        Site_FAQViewModel GetBy(long id);
        List<Site_FAQViewModel> Search(Site_FAQViewModel command);
    }
}
