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
        OperationResult Remove(Site_FAQViewModel command);
        Site_FAQViewModel GetBy(int id);
        List<Site_FAQViewModel> Search(Site_FAQViewModel command);
    }
}
